using UnityEngine;
using System.Collections;

public class explosion_item : MonoBehaviour {

    public ParticleSystem explosion = null;
    // Use this for initialization
    void Start()
    {
        explosion.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if (!explosion.isPlaying)
            explosion.Play();
    }
}
