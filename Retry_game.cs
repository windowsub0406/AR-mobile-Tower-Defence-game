using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Retry_game : MonoBehaviour
{
    public AudioSource button_sound = null;
    public AudioSource gunAudio = null;
    // Use this for initialization
    void Start()
    {
        gunAudio.Play();
    }

    public void Enable()
    {
        button_sound.Play();
        SceneManager.LoadScene("start");
    }
}
