using UnityEngine;
using System.Collections;

public class Button_disable : MonoBehaviour
{
    public EasyJoystick Joystickactive, Joystickactive2;
    public GameObject fire_button;
    public GameObject healthbar;
    public GameObject score;
    public GameObject level;
    public GameObject timer;
    //public GameObject menu;
    // Use this for initialization
    void Start()
    {
        Joystickactive.Enable(false);
        Joystickactive2.Enable(false);
        fire_button.SetActive(false);
        healthbar.SetActive(false);
        score.SetActive(false);
        level.SetActive(false);
        timer.SetActive(false);
        //menu.SetActive(false);
        //// Update is called once per frame
        //void Update () {
        //    Joystickactive.Enable(false);
        //}
    }
}
