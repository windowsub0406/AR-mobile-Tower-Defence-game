using UnityEngine;
using System.Collections;
public class Button_active : MonoBehaviour {
    public EasyJoystick Joystickactive, Joystickactive2;
    public GameObject fire_button;
    public GameObject healthbar;
    public GameObject score;
    public GameObject level;
    public GameObject timer;
    public void Enable()
    {
        Joystickactive.Enable(true);
        Joystickactive2.Enable(true);
        fire_button.SetActive(true);
        healthbar.SetActive(true);
        score.SetActive(true);
        level.SetActive(true);
        timer.SetActive(true);
    }

    public void Disable()
    {
        Joystickactive.Enable(false);
        Joystickactive2.Enable(false);
        fire_button.SetActive(false);
        healthbar.SetActive(false);
        score.SetActive(false);
        level.SetActive(false);
        timer.SetActive(false);
    }
}
