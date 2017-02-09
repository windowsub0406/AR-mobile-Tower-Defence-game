using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class pause_game : MonoBehaviour {
    public GameObject PauseUI;
    public bool paused;
	// Use this for initialization
	void Start () {
        paused = false;
    }
	
	void Update () {
        if (paused)
        {
            PauseGame(true);
        }
        else {
            PauseGame(false);
        }

        if (Input.GetButtonDown("Cancel")) {
            SwitchPause();
        }
	}

    public void PauseGame(bool state)
    {
        if (state)
        {
            Time.timeScale = 0.0f;
        }
        else {
            Time.timeScale = 1.0f;
        }
        PauseUI.SetActive(state);
    }

    public void SwitchPause() {
        if (paused)
        {
            paused = false;
        }
        else {
            paused = true;
        }
    }
}
