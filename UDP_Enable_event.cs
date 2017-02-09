using UnityEngine;
using System.Collections;

public class UDP_Enable_event : MonoBehaviour {
    public GameObject Event_enable;
    public void Start()
    {
        Event_enable.SetActive(false);
    }
}
