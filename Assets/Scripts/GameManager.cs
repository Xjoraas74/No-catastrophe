using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float timeLeft = 45 * 60, safeTimer, timerTimeTravel;
    public Transform playerLocationPast, playerLocationFuture;
    public bool seenIntroduction;
    // 0 1 2 3 4 are Alice, Bob, Christopher, Daniel, Emily respectively
    public int[] guiltySlider = new int[5];
    public GameObject blameMenu;
    public List<string>commentsFound = new List<string>();
    public int trust1, trust2, trust3, trust4, trust5;

    float timerUntilForward = 7 * 60, timerUntilBackward = 10f;
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

        if (timerTimeTravel < 0)
        {
            // past
            if (SceneManager.GetActiveScene().name != "Monsters")
            {
                playerLocationPast = GameObject.FindWithTag("Player").transform;
                GameObject.FindWithTag("Player").GetComponent<Trust>().SaveTrust();
                timerTimeTravel = timerUntilBackward;
                safeTimer = timerUntilBackward;
                timerUntilForward -= 30f;

                scenePastName = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene("Monsters");
            }

            // future
            else
            {
                playerLocationFuture = GameObject.FindWithTag("Player").transform;
                timerTimeTravel = timerUntilForward;
                timerUntilBackward += 10f;

                SceneManager.LoadScene(scenePastName);
            }
        }

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

    public void PrepareBlame()
    {
        GameObject.FindWithTag("Player").GetComponent<Trust>().SaveTrust();
        guiltySlider[0] = trust1;
        guiltySlider[1] = trust2;
        guiltySlider[2] = trust3;
        guiltySlider[3] = trust4;
        guiltySlider[4] = trust5;
    }
}
