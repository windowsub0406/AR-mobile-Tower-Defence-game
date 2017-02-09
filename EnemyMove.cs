using UnityEngine;
using System.Collections;
using System;
namespace CompleteProject
{
    public class EnemyMove : MonoBehaviour
    {
        public static int exp;
        public static int level;
        public ParticleSystem deathParticle = null;
        public ParticleSystem hitParticle = null;
        public int startingHealth = 50;
        public int currentHealth;
        public int scoreValue = 10;
        public AudioSource deathClip = null;  // 폭발음
        public float EnemySpeed = 0.03f;
        public int SCORE = 10;
        public int Point = 10;
        int Damage = 25;
        private float startTime;
        //AudioSource enemyAudio;

        void Awake()
        {
            //enemyAudio = GetComponent<AudioSource>();
            //hitParticles = GetComponentInChildren<ParticleSystem>();
            currentHealth = startingHealth;
        }

        // Use this for initialization
        void Start()
        {            
            deathParticle.Pause();
            hitParticle.Pause();
            deathClip.Pause();
            exp = 0;
            level = 1;
        }

        void Enemy_hp(int damage)
        {
            if (currentHealth == 0)
                currentHealth = 75;
            currentHealth = currentHealth - damage;
            //enemyAudio.Play();

            if (currentHealth > 10 && currentHealth < 70)
            {
                hitParticle.Play();
            }

            else if (currentHealth <= 0)
            {
                deathClip.Play();
                deathParticle.Play();
                ScoreManager.score += scoreValue;

                Invoke("Death_Delay", 0.7f);

            }
        }

        void OnCollisionEnter(Collision col)
        {
            //if (currentHealth == 0)
            //    currentHealth = 100;
            //if (col.collider.tag == "Missile")
            //{
            //    col.gameObject.SendMessage("Enemy_hp",25);
            //}
        }

        private void Death_Delay()
        {
            this.GetComponent<Collider>().enabled = false; // 미사일과 충돌하면 비활성화
            //currentHealth = 75;
        }

        // Update is called once per frame
        void Update()
        {
            if (exp >= 1)
            {
                startTime = Time.time;
                exp++;
                deathClip.Play();
                deathParticle.Play();
                ScoreManager.score += scoreValue;
                Invoke("Death_Delay", 0.6f);
                float t = Time.time - startTime;
                if (exp ==10 )
                {
                    exp = 0;
                }
            }

            if (this.transform.position.x >= 0 && this.transform.position.z >= 0)
            {
                this.transform.Translate(new Vector3(-1, 0, -1) * EnemySpeed * Time.deltaTime*(9+level)/10);
            }
            else if (this.transform.position.x >= 0 && this.transform.position.z <= 0)
            {
                this.transform.Translate(new Vector3(-1, 0, 1) * EnemySpeed * Time.deltaTime * (9 + level) / 10);
            }
            else if (this.transform.position.x <= 0 && this.transform.position.z >= 0)
            {
                this.transform.Translate(new Vector3(1, 0, -1) * EnemySpeed * Time.deltaTime * (9 + level) / 10);
            }
            else if (this.transform.position.x <= 0 && this.transform.position.z <= 0)
            {
                this.transform.Translate(new Vector3(1, 0, 1) * EnemySpeed * Time.deltaTime * (9 + level) / 10);
            }
        }
    }
}
