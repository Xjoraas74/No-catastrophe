using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float timeLeft = 10800;

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
}
