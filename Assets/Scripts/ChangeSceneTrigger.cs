using UnityEngine;

public class ChangeSceneTrigger : MonoBehaviour
{
    public GameObject changeScene;
    public int side; // negative for the left, positive for the right

    void OnTriggerEnter2D()
    {
        changeScene.SetActive(true);
        //Debug.Log("KAPETS");
    }

    void OnTriggerExit2d()
    {
        changeScene.GetComponent<ChangeScene>().side = side;
        changeScene.GetComponent<ChangeScene>().activatable = true;
    }
}
