using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float timeLeft = 10800;
    public Transform playerLocationPast, playerLocationFuture;
    public bool seenIntroduction;

    float timerTimeTravel, timerUntilForward = 10f, timerUntilBackward = 10f;
    string scenePastName;
    bool timersPaused;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        timerTimeTravel = timerUntilForward;
    }

    void Update()
    {
        if (!timersPaused)
        {
            timerTimeTravel -= Time.deltaTime;
            timeLeft -= Time.deltaTime; 
        }

        if (timerTimeTravel < 0)
        {
            // past
            if (SceneManager.GetActiveScene().name != "Monsters")
            {
                playerLocationPast = GameObject.FindWithTag("Player").transform;
                timerTimeTravel = timerUntilBackward;

                scenePastName = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene("Monsters");
            }

            // future
            else
            {
                playerLocationFuture = GameObject.FindWithTag("Player").transform;
                timerTimeTravel = timerUntilForward;

                SceneManager.LoadScene(scenePastName);
            }
        }
    }

    public void PauseTimers()
    {
        timersPaused = true;
    }

    public void ResumeTimers()
    {
        timersPaused = false;
    }
}
