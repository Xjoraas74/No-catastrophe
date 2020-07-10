using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    //public static bool gameIsPaused;

    void Update()
    {
        //if (activatable)
        //{
        //    Invoke("Activate", .25f);
        //}
        Time.timeScale = 0f;
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            //Debug.Log("running");
            Time.timeScale = 1f;
            gameObject.SetActive(false);
        }
        //Debug.Log(gameObject.activeSelf);
        //Debug.Log(activatable);

        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    gameIsPaused = !gameIsPaused;
        //    PauseGame();
        //}
    }

    //void PauseGame()
    //{
    //    if (gameIsPaused)
    //    {
    //        gameObject.SetActive(true);
    //        Time.timeScale = 0f;
    //    }
    //    else
    //    {
    //        gameObject.SetActive(false);
    //        Time.timeScale = 1;
    //    }
    //}

    public void LoadResidentialFloor()
    {
        PrepareTransition();
        SceneManager.LoadScene("Residential floor");
    }

    public void LoadScienceFloor()
    {
        PrepareTransition();
        SceneManager.LoadScene("Science floor");
    }

    public void LoadTechnicalFloor()
    {
        PrepareTransition();
        SceneManager.LoadScene("Technical floor");
    }

    //void Activate()
    //{
    //    Time.timeScale = 0f;
    //    activatable = false;
    //}

    void PrepareTransition()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
}
