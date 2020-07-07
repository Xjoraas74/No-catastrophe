using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    //public static bool gameIsPaused;
    public bool activatable = true;

    void Update()
    {
        //if (activatable)
        //{
        //    Invoke("Activate", .25f);
        //}
        Time.timeScale = 0f;
        if (Input.GetKeyDown(KeyCode.Escape))
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
        SceneManager.LoadScene("Residential floor");
    }

    public void LoadScienceFloor()
    {
        SceneManager.LoadScene("Science floor");
    }

    public void LoadTechnicalFloor()
    {
        SceneManager.LoadScene("Technical floor");
    }

    //void Activate()
    //{
    //    Time.timeScale = 0f;
    //    activatable = false;
    //}
}
