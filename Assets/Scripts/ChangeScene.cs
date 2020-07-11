using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    void Update()
    {
        Time.timeScale = 0f;
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            Time.timeScale = 1f;
            gameObject.SetActive(false);
        }
    }

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

    void PrepareTransition()
    {
        Time.timeScale = 1f;
        GameObject.FindWithTag("Player").GetComponent<Trust>().SaveTrust();
        gameObject.SetActive(false);
    }
}
