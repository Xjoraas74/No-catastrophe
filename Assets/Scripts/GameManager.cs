using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float timeLeft = 10800;

    GameObject timer;

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
        timer = GameObject.FindWithTag("Timer");

        //LoadPlayer();
    }

    public void SavePlayer()
    {
        timeLeft = timer.GetComponent<Countdown>().realTime;
    }
}
