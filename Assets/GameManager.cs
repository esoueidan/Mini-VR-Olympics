using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PinResetter[] pins;
    public BallThrower ballThrower;

    void Start()
    {
        InvokeRepeating("ResetPinsAndBall", 10f, 10f); // 10초마다 핀과 공을 리셋
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
