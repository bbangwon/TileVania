using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField]
    int playerLives = 3;

    [SerializeField] 
    int score = 0;

    [SerializeField] 
    TextMeshProUGUI livesText;

    [SerializeField]
    TextMeshProUGUI scoreText;

    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if(numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if(playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    public void AddToScore(int pointToAdd)
    {
        score += pointToAdd;
        scoreText.text = score.ToString();
    }

    private void TakeLife()
    {
        playerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = playerLives.ToString();
    }

    private void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
