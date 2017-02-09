using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace CompleteProject
{
    public class Tower_event : MonoBehaviour
    {
        public ParticleSystem fire_effect = null;
        public ParticleSystem smoke_effect = null;
        public ParticleSystem spark_effect = null;
        public AudioSource fireAudio = null;
        public Light fireLight = null;
        public static int sign;

        void Awake()
        {
            fire_effect.Pause();
            smoke_effect.Pause();
            spark_effect.Pause();
            fireAudio.enabled = false;
            fireLight.enabled = false;
            sign = 1;
        }

        void Update()
        {
            if (sign > 1)
            {
                //fire_effect.transform.position = new Vector3(0, 0.53f, 0);
                //spark_effect.transform.position = new Vector3(0, 0.53f, 0);
                //smoke_effect.transform.position = new Vector3(0, 0.53f, 0);
                if (fire_effect.isStopped || fire_effect.isPaused)
                {
                    fire_effect.Play();
                    smoke_effect.Play();
                    spark_effect.Play();
                }                  
                fireAudio.enabled = true;
                if (!fireAudio.isPlaying)
                    fireAudio.Play();
                fireLight.enabled = true;
            }
            else if(sign == 1) {
                if(fire_effect.isPlaying)
                    fire_effect.Stop();
                if (smoke_effect.isPlaying)
                    smoke_effect.Stop();
                if (spark_effect.isPlaying)
                    spark_effect.Stop();
                fireAudio.enabled = false;
                if (fireAudio.isPlaying)
                    fireAudio.Pause();
                fireLight.enabled = false;
            }
        }
    }

}
