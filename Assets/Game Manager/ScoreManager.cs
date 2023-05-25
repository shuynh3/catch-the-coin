using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreTextObject;

    private int score = 0;

    public static int GetScore()
    {
        return instance.score;
    }

    public static void SetScore(int score)
    {
        instance.score = score;
        instance.UpdateScore(instance.score);
    }

    public static void AddScore(int score)
    {
        instance.score += score;
        instance.UpdateScore(instance.score);
    }

    public static void SubtractScore(int score)
    {
        instance.score -= score;
        instance.UpdateScore(instance.score);
    }

    void Awake()
    {
        Initialize();
    }

    void Start()
    {
        instance.UpdateScore(instance.score);
    }

    void Initialize()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    string GetScoreText(int score)
    {
        return "Score: " + score.ToString();
    }

    public void UpdateScore(int score)
    {
        scoreTextObject.text = GetScoreText(score);
    }
}
