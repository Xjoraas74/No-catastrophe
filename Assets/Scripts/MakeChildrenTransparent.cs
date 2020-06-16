// https://www.youtube.com/watch?v=nNjNWDZSkAI

using UnityEngine;

public class MakeChildrenTransparent : MonoBehaviour
{
    public GameObject toFade;// = null;
    GameObject[] listToFade;

    void Start()
    {
        listToFade = new GameObject[toFade.transform.childCount];
        Component[] transforms = GetComponentsInChildren<Transform>(toFade);
        for (int i = 0; i < listToFade.Length; i++)
        {
            listToFade[i] = transforms[i].gameObject;
        }
    }

    private bool IsCharacter(Collider2D collider)
    {
        // Implement you logic here if it is your player that is the collider
        return true;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (IsCharacter(collider))
        {
            foreach (GameObject i in listToFade)
            {
                SetMaterialTransparent(i);
                iTween.FadeTo(toFade, 0, 1);
            }
        }
    }

    private void SetMaterialTransparent(GameObject toChange)
    {
        foreach (Material m in toChange.GetComponent<Renderer>().materials)
        {
            m.SetFloat("_Mode", 2);
            m.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            m.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            m.SetInt("_ZWrite", 0);
            m.DisableKeyword("_ALPHATEST_ON");
            m.EnableKeyword("_ALPHABLEND_ON");
            m.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            m.renderQueue = 3000;
        }
    }

    private void SetMaterialOpaque(GameObject toChange)
    {
        foreach (Material m in toChange.GetComponent<Renderer>().materials)
        {
            m.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
            m.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
            m.SetInt("_ZWrite", 1);
            m.DisableKeyword("_ALPHATEST_ON");
            m.DisableKeyword("_ALPHABLEND_ON");
            m.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            m.renderQueue = -1;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (IsCharacter(collider))
        {
            foreach (GameObject i in listToFade)
            {
                iTween.FadeTo(toFade, 1, 1);
                Invoke("SetMaterialOpaque", 1.0f);
            }
        }
    }
}