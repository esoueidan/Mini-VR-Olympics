using UnityEngine;

public class ScoreObject : MonoBehaviour
{
    // ������ ���� ������ �� �ֵ��� ������Ƽ ���
    [SerializeField]
    private int _scoreValue = 0;

    // ������ ����� �� ȣ��Ǵ� �̺�Ʈ
    public delegate void ScoreChangedDelegate(int newScore);
    public event ScoreChangedDelegate OnScoreChanged;

    // ���� ������Ƽ
    public int ScoreValue
    {
        get { return _scoreValue; }
        set
        {
            _scoreValue = value;
            // ���� ���� �̺�Ʈ ȣ��
            if (OnScoreChanged != null)
            {
                OnScoreChanged(_scoreValue);
            }
        }
    }
}
