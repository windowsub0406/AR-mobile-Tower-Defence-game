using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Start_game : MonoBehaviour {
    public AudioSource gunAudio = null;
    public AudioSource button = null;
    void Start()
    {
        gunAudio.Play();
    }

    public void Enable()
    {
        button.Play();
        SceneManager.LoadScene("start");
    }    
}
