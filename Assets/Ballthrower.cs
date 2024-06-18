using UnityEngine;

public class BallThrower : MonoBehaviour
{
    public GameObject ballPrefab; // �� ������
    public Transform handTransform; // ������ ����� (ī�޶� �Ǵ� ��)
    public float throwForce = 10f; // ������ ��
    public float resetTime = 5f; // ���� �ٽ� ������ �ð� ����
    private GameObject currentBall; // ���� ��� �ִ� ��
    private bool ballThrown = false; // ���� ���������� ����

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
