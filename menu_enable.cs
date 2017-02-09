using UnityEngine;
using System.Collections;

public class menu_enable : MonoBehaviour {

    public GameObject Menu;
    public void Enable()
    {
        Menu.SetActive(true);
    }

    public void Disable()
    {
        Menu.SetActive(false);
    }
}
