using UnityEngine;
using System.Collections;

public class Enemyevent_enable : MonoBehaviour {
    public GameObject Event_enable;
    public void Enable()
    {
        Event_enable.SetActive(true);
    }

    public void Disable()
    {
        Event_enable.SetActive(false);
    }
}
