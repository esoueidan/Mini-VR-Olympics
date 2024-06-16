using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Gun : MonoBehaviour
{
    public Transform gunTip;
    public GameObject bulletPrefab;
    public float range = 100f;
    public AudioSource shotSound;
    public AudioSource cheerSound;
    private List<InputDevice> devices = new List<InputDevice>();
    private InputDevice leftHandDevice;
    private InputDevice rightHandDevice;
    private bool isGrabbed = false;
    private bool canShoot = true;

    void Start()
    {
        InitializeDevices();

        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.onSelectEntered.AddListener(OnGrabbed);
            grabInteractable.onSelectExited.AddListener(OnReleased);
        }
        else
        {
            Debug.LogWarning("XRGrabInteractable component is missing.");
        }
    }

    void Update()
    {
        if (!leftHandDevice.isValid || !rightHandDevice.isValid)
        {
            InitializeDevices();
        }

        if (isGrabbed)
        {
            bool leftTriggerPressed = false;
            bool rightTriggerPressed = false;

            if (leftHandDevice.TryGetFeatureValue(CommonUsages.triggerButton, out leftTriggerPressed) && leftTriggerPressed)
            {
                TryShoot();
            }

            if (rightHandDevice.TryGetFeatureValue(CommonUsages.triggerButton, out rightTriggerPressed) && rightTriggerPressed)
            {
                TryShoot();
            }
        }
    }

    void TryShoot()
    {
        if (canShoot)
        {
            Shoot();
            StartCoroutine(ResetShootAfterDelay(1.5f));
        }
    }

    void Shoot()
    {
        if (shotSound != null)
        {
            shotSound.Play();
        }
        else
        {
            Debug.LogWarning("Shot sound is not assigned.");
        }

        // 총알 생성 및 발사
        GameObject bullet = Instantiate(bulletPrefab, gunTip.position, gunTip.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
            rb.velocity = gunTip.forward * 20f;
        }
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.cheerSound = cheerSound;

        // 총을 발사했으므로 다시 쏠 수 없도록 설정
        canShoot = false;
    }

    IEnumerator ResetShootAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canShoot = true;
    }

    void InitializeDevices()
    {
        devices.Clear();

        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Left, devices);
        if (devices.Count > 0)
        {
            leftHandDevice = devices[0];
        }

        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Right, devices);
        if (devices.Count > 0)
        {
            rightHandDevice = devices[0];
        }
    }

    void OnGrabbed(XRBaseInteractor interactor)
    {
        isGrabbed = true;
    }

    void OnReleased(XRBaseInteractor interactor)
    {
        isGrabbed = false;
    }
}
