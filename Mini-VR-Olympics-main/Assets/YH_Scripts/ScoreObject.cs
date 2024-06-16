using UnityEngine;

public class ScoreObject : MonoBehaviour
{
    // 점수를 직접 설정할 수 있도록 프로퍼티 사용
    [SerializeField]
    private int _scoreValue = 0;

    // 점수가 변경될 때 호출되는 이벤트
    public delegate void ScoreChangedDelegate(int newScore);
    public event ScoreChangedDelegate OnScoreChanged;

    // 점수 프로퍼티
    public int ScoreValue
    {
        get { return _scoreValue; }
        set
        {
            _scoreValue = value;
            // 점수 변경 이벤트 호출
            if (OnScoreChanged != null)
            {
                OnScoreChanged(_scoreValue);
            }
        }
    }
}
