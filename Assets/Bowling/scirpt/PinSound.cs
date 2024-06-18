using UnityEngine;

public class PinSound : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // �浹�� ��ü�� ���� ���� ���� �Ҹ��� ����մϴ�.
        if (collision.gameObject.CompareTag("Ball") && !audioSource.isPlaying)
        {
            Debug.Log("PinSound OnCollisionEnter: " + gameObject.name + " with " + collision.gameObject.name);
            audioSource.Play();
        }
    }
}
