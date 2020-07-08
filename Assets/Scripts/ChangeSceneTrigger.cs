using UnityEngine;

public class ChangeSceneTrigger : MonoBehaviour
{
    public GameObject changeScene;

    void OnTriggerEnter2D()
    {
        changeScene.SetActive(true);
    }
}
