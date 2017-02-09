using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour {
    void Start()
    {
    }

    public void Enable()
    {
        SceneManager.LoadScene("start");
    }
}
