using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PinResetter[] pins;
    public BallThrower ballThrower;

    void Start()
    {
        InvokeRepeating("ResetPinsAndBall", 10f, 10f); // 10�ʸ��� �ɰ� ���� ����
    }

    void ResetPinsAndBall()
    {
        foreach (PinResetter pin in pins)
        {
            pin.ResetPin();
        }
        ballThrower.Invoke("ResetBall", 0f);
    }
}
