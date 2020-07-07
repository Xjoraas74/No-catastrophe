using UnityEngine;

public class ChangeSceneTrigger : MonoBehaviour
{
    public GameObject changeScene;

    void OnTriggerEnter2D()
    {
        changeScene.SetActive(true);
        //Debug.Log("KAPETS");
    }

    void OnTriggerExit2d()
    {
        changeScene.GetComponent<ChangeScene>().activatable = true;
    }
}
