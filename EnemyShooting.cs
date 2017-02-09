using UnityEngine;
using System.Collections;
namespace CompleteProject
{
    public class EnemyShooting : MonoBehaviour
    {
        public int damagePerShot = 1;                  // The damage inflicted by each bullet.
        public float timeBetweenBullets = 1f;        // The time between each shot.
        public float range = 1f;                      // The distance the gun can fire.
        float timer;                                    // A timer to determine when to fire.
        Ray shootRay;                                   // A ray from the gun end forwards.
        RaycastHit shootHit;                            // A raycast hit to get information about what was hit.
        int shootableMask;                              // A layer mask so the raycast only hits things on the shootable layer.

        public ParticleSystem AttackParticle = null;

        LineRenderer gunLine;                           // Reference to the line renderer.
        public AudioSource gunAudio = null;                           // Reference to the audio source.
        Light gunLight;                                 // Reference to the light component.
        public Light faceLight;                             // Duh
        float effectsDisplayTime = 0.2f;                // The proportion of the timeBetweenBullets that the effects will display for.
        int count = 0;

        void Awake()
        {
            // Create a layer mask for the Shootable layer.
            shootableMask = LayerMask.GetMask("Shootable");
            gunAudio.Pause();
            
            gunLine = GetComponent<LineRenderer>();
            gunLight = GetComponent<Light>();
            //faceLight = GetComponentInChildren<Light> ();
            gunLine.enabled = false;
            AttackParticle.Pause();
        }


        void Update()
        {
            // Add the time since Update was last called to the timer.
            timer += Time.deltaTime;

#if !MOBILE_INPUT
            // If the Fire1 button is being press and it's time to fire...
			if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
            {
                // ... shoot the gun.
                Shoot ();
            }
#else
            // If there is input on the shoot direction stick and it's time to fire...
            if (timer >= timeBetweenBullets)
            {
                // ... shoot the gun
                Shoot();
            }

            if (timer >= timeBetweenBullets + 0.2)
            {
                count = 0;
                timer = 0f;
                //AttackParticle.Pause();
                gunLine.enabled = false;
            }
#endif
            DisableEffects();
        }

        public void DisableEffects()
        {
            // Disable the line renderer and the light.        
            faceLight.enabled = false;
            gunLight.enabled = false;
        }


        void Shoot()
        {            
            // Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
            shootRay.origin = this.transform.position;
            shootRay.direction = new Vector3(0, 0, 0);

            // 일정 거리 안에 들어왔을 때만 레이저 쏘도록
            if (System.Math.Sqrt(System.Math.Pow(this.transform.position.x, 2) + System.Math.Pow(this.transform.position.y, 2) +
                System.Math.Pow(this.transform.position.z, 2)) <= 0.5)
            {               
                gunLine.enabled = true;
                gunLine.SetPosition(0, this.transform.position);
                gunLine.SetPosition(1, new Vector3(0, 0, 0));
                AttackParticle.transform.Translate(new Vector3(0, 0, 0));
                AttackParticle.transform.position = new Vector3(0, 0.048f, 0);
                AttackParticle.Play();
                gunAudio.Play();
                if (count == 0)
                {
                    TowerManager.HP -= damagePerShot;
                    Chelthtest.HP -= damagePerShot;                   
                }
            }
            count++;
        }
    }
}