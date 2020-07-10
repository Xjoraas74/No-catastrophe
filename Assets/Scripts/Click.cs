using UnityEngine.EventSystems;
using UnityEngine;

public class Click : MonoBehaviour, IPointerClickHandler
{
    public string[] comment;
    public int personNumber;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click is");
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
