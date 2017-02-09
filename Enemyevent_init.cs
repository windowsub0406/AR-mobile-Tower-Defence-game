using UnityEngine;
using System.Collections;

public class Enemyevent_init : MonoBehaviour {
    public GameObject Event_enable;
    public GameObject Event_enable2;
    public void Start()
    {
        Event_enable.SetActive(false);
        Event_enable2.SetActive(false);
    }
}
