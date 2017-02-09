using UnityEngine;
using System.Collections;

public class Enemyevent_enable2 : MonoBehaviour {
    public GameObject Event_enable2;
    public void Enable()
    {
        Event_enable2.SetActive(true);
    }

    public void Disable()
    {
        Event_enable2.SetActive(false);
    }
}
