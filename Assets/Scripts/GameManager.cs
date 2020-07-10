using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float timeLeft = 10800;
    public Transform playerLocationPast, playerLocationFuture;
    public bool seenIntroduction;
    // 0 1 2 3 4 are Alice, Bob, Christopher, Daniel, Emily respectively
    public int[] guiltySlider = new int[5];
    public GameObject blameMenu;

    float timerTimeTravel, timerUntilForward = 10f, timerUntilBackward = 10f;
    string scenePastName;
    bool timersPaused, showBlameMenu;

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

        /*if (timerTimeTravel < 0)
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
        }*/

        if (Input.GetKeyDown(KeyCode.Space))
        {
            showBlameMenu = !showBlameMenu;
            blameMenu.SetActive(showBlameMenu);
            if (showBlameMenu)
            {
                PauseTimers();
            }
            else
            {
                GameObject.FindWithTag("Text").GetComponent<TextMeshProUGUI>().text = "";
                ResumeTimers();
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

    public void ReloadMonsters()
    {
        timerTimeTravel = timerUntilBackward;
        SceneManager.LoadScene("Monsters");
    }
}
