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
        // 충돌한 객체가 볼링 공일 때만 소리를 재생합니다.
        if (collision.gameObject.CompareTag("Ball") && !audioSource.isPlaying)
        {
            Debug.Log("PinSound OnCollisionEnter: " + gameObject.name + " with " + collision.gameObject.name);
            audioSource.Play();
        }
    }
}
