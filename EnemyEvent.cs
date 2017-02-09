using UnityEngine;
using System.Collections;
namespace CompleteProject
{
    public class EnemyEvent : MonoBehaviour
    {
        public AudioSource collision_sound = null;
        public ParticleSystem explosion = null;
        public int EnemyCount = 10;
        public float DestroyEnemyZpos = 0.1f;
        public float FireTime = 1f;
        public float EnemyCreateXpos = 1.2f;
        public float EnemyCreateZpos = 1.2f;
        public GameObject Enemy = null;
        //public GameObject healItem = null;
        public int damage = 10;
        MemoryPool enemypool = new MemoryPool();
        GameObject[] enemy = null;
        public Transform fighterLocation = null;
        private int Enemy_Death_Cnt_Check; // 적이 다 죽었는지 확인
        private bool enemy_State;
        float prob;
        void OnApplicationQuit()
        {
            enemypool.Dispose();
        }

        // Use this for initialization
        void Start()
        {
            collision_sound.Pause();
            explosion.Pause();
            enemypool.Create(Enemy, EnemyCount);
            enemy = new GameObject[EnemyCount];
            enemy_State = true;
            for (int i = 0; i < enemy.Length; i++)
            {
                enemy[i] = null; // enemy 배열 초기화
            }
            Enemy_Death_Cnt_Check = 0;
        }

        // Update is called once per frame
        void Update()
        {           
            if (enemy_State)
            {
                Invoke("EnemySpeedController", FireTime);
                for (int i = 0; i < enemy.Length; i++)
                {
                    if(enemy[i]==null)
                    {
                        if (i % 2 == 0)
                        {
                            enemy[i] = enemypool.NewItem(); // enemy 임의의 장소에 생성(y축은 고정)
                            enemy[i].transform.position = new Vector3(Random.Range(-EnemyCreateXpos, -0.45f), fighterLocation.transform.position.y, Random.Range(-EnemyCreateZpos, -0.45f));
                        }

                        if (i % 2 == 1)
                        {
                            enemy[i] = enemypool.NewItem(); // enemy 임의의 장소에 생성(y축은 고정)
                            enemy[i].transform.position = new Vector3(Random.Range(0.45f, EnemyCreateXpos), fighterLocation.transform.position.y, Random.Range(0.45f, EnemyCreateZpos));
                        }
                        //break;
                    }
                    enemy_State = false;
                }
            }
            for (int i = 0; i < enemy.Length; i++)
            {
                if (enemy[i])
                {
                    if (System.Math.Abs(enemy[i].transform.position.z) < DestroyEnemyZpos &&
                        System.Math.Abs(enemy[i].transform.position.x) < DestroyEnemyZpos) // 타워에 다다르면
                    {
                        TowerManager.HP -= damage;
                        Chelthtest.HP -= damage;
                        enemypool.RemoveItem(enemy[i]); // 삭제 & 비우기
                        enemy[i] = null;
                        Enemy_Death_Cnt_Check++;
                        explosion.Play();
                        collision_sound.Play();
                    }
                    if (enemy[i].GetComponent<Collider>().enabled == false) // 미사일에 맞으면
                    {
                        enemy[i].GetComponent<Collider>().enabled = true;
                        prob = Random.Range(0f, 1f);
                        if (prob < 0.20f)
                        {
                            if (prob <= 0.10f)
                            {
                                ItemEvent.x_value = enemy[i].transform.position.x;
                                ItemEvent.y_value = enemy[i].transform.position.y;
                                ItemEvent.z_value = enemy[i].transform.position.z;
                            }
                            else if (prob > 0.10f)
                            {
                                exp_Itemevert.x_value = enemy[i].transform.position.x;
                                exp_Itemevert.y_value = enemy[i].transform.position.y;
                                exp_Itemevert.z_value = enemy[i].transform.position.z;
                            }
                            
                        }                         
                        enemypool.RemoveItem(enemy[i]);
                        enemy[i] = null;
                        Enemy_Death_Cnt_Check++;
                    }
                }

                if (Enemy_Death_Cnt_Check >= 1)
                {
                    Enemy_Death_Cnt_Check = 0;
                    enemy_State = true;
                }
            }
        }
    }
}