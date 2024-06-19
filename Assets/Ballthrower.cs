using UnityEngine;

public class BallThrower : MonoBehaviour
{
    public GameObject ballPrefab; // 공 프리팹
    public Transform handTransform; // 던지는 출발점 (카메라 또는 손)
    public float throwForce = 10f; // 던지는 힘
    public float resetTime = 5f; // 공을 다시 생성할 시간 간격
    private GameObject currentBall; // 현재 잡고 있는 공
    private bool ballThrown = false; // 공이 던져졌는지 여부

    void Update()
    {
        if (!ballThrown && Input.GetMouseButtonDown(0))
        {
            currentBall = Instantiate(ballPrefab, handTransform.position, handTransform.rotation);
            currentBall.GetComponent<Rigidbody>().isKinematic = true;
            ballThrown = true;
        }

        if (ballThrown && Input.GetMouseButtonUp(0))
        {
            currentBall.GetComponent<Rigidbody>().isKinematic = false;
            currentBall.GetComponent<Rigidbody>().AddForce(handTransform.forward * throwForce, ForceMode.VelocityChange);
            Invoke("ResetBall", resetTime);
        }
    }

    void ResetBall()
    {
        Destroy(currentBall);
        ballThrown = false;
    }
}
