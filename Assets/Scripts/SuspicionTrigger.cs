using UnityEngine;
using TMPro;

public class SuspicionTrigger : MonoBehaviour
{
    TextMeshProUGUI textDisplay;
    bool entered = false;

    // Start is called before the first frame update
    void Start()
    {
        textDisplay = GameObject.FindWithTag("Text").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !gameObject.GetComponent<Dialog>().dialogRunning && entered)
        {
            gameObject.GetComponent<Dialog>().StartDialog();
        }
    }

    void OnTriggerEnter2D()
    {
        textDisplay.text = "Нажмите E, чтобы взаимодействовать";
        entered = true;
    }

    void OnTriggerExit2D()
    {
        textDisplay.text = "";
        gameObject.GetComponent<Dialog>().EndDialog();
        entered = false;
    }
}
