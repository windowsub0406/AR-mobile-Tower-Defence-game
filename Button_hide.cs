using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button_hide : MonoBehaviour {
    public GameObject Buttonhide;
    // Use this for initialization

    public void enable()
    {
        Buttonhide.SetActive(true);
    }
    public void disable()
    {
        Buttonhide.SetActive(false);
    }
}
