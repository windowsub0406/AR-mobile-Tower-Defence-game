using UnityEngine;
using System.Collections;

public class heal_particle : MonoBehaviour {

    public ParticleSystem heal = null;
	// Use this for initialization
	void Start () {
        heal.Pause();
	}
	
	// Update is called once per frame
	void Update () {
        if(!heal.isPlaying)
            heal.Play();
	}
}
