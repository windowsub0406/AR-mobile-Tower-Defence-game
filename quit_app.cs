using UnityEngine;
using System.Collections;

public class quit_app : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    public void enable()
    {
        Application.Quit();
    }
}