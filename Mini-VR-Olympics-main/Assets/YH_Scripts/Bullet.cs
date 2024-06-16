using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 40f;
    public AudioSource cheerSound;

    public ScoreObject scoreObject10;
    public ScoreObject scoreObject9;
    public ScoreObject scoreObject8;
    public ScoreObject scoreObject7;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found on bullet.");
            return;
        }
        rb.useGravity = false;
        rb.velocity = transform.forward * speed;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous; // 충돌 감지 모드 설정
    }

    void OnCollisionEnter(Collision collision)
    {
        ScoreObject scoreObject = collision.gameObject.GetComponent<ScoreObject>();

        if (scoreObject != null)
        {
            int scoreToAdd = scoreObject.ScoreValue;
            if (ScoreManager1.Instance != null)
            {
                ScoreManager1.Instance.AddScore(scoreToAdd);
            }
            else
            {
                Debug.LogWarning("ScoreManager1 instance not found.");
            }

            if (cheerSound != null)
            {
                cheerSound.Play();
            }

            // 충돌한 후 총알을 제거
            Destroy(gameObject);
        }
        else
        {           
            Destroy(gameObject);
        }
    }
}
