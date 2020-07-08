using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float timeLeft;
    public int sidePlayerCameFrom;

    TextMeshProUGUI timeLeftText;

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
        timeLeftText = GameObject.FindWithTag("TimeLeft").GetComponent<TextMeshProUGUI>();
    }

    public void SavePlayer(int sideElevatorIsOn)
    {
        timeLeft = float.Parse(timeLeftText.text);
        sidePlayerCameFrom = sideElevatorIsOn;
    }
}
