using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class exp_Itemevert : MonoBehaviour
    {
        public AudioSource item_sound = null;
        public int itemCount = 1;
        public float FireTime = 1f;
        MemoryPool itempool = new MemoryPool();
        GameObject[] item = null;
        public Transform fighterLocation = null;
        private bool item_State;
        private float startTime;
        void OnApplicationQuit()
        {
            itempool.Dispose();
        }
        public GameObject expItem = null;
        public static float x_value;
        public static float y_value;
        public static float z_value;
        // Use this for initialization
        void Start()
        {
            item_sound.Pause();
            itempool.Create(expItem, itemCount);
            item = new GameObject[itemCount];
            item_State = true;
            for (int i = 0; i < item.Length; i++)
            {
                item[i] = null; // enemy 배열 초기화
            }
            x_value = 0.01f;
            y_value = 0.01f;
            z_value = 0.01f;
        }

        // Update is called once per frame
        void Update()
        {
            if (item_State)
            {
                Invoke("item", FireTime);
                for (int i = 0; i < item.Length; i++)
                {
                    if (System.Math.Sqrt(System.Math.Pow(x_value, 2) + System.Math.Pow(y_value, 2) + System.Math.Pow(z_value, 2)) >= 0.03f)
                    {
                        if (item[i] == null)
                        {
                            item[i] = itempool.NewItem(); // enemy 임의의 장소에 생성(y축은 고정)
                            startTime = Time.time;
                            item[i].transform.position = new Vector3(x_value, y_value, z_value);
                            item_sound.Play();
                        }
                        item_State = false;
                    }
                }
            }
            x_value = 0.01f;
            y_value = 0.01f;
            z_value = 0.01f;
            float t = Time.time - startTime;
            if (t > 7f)
            {
                itempool.RemoveItem(item[0]);
                item[0] = null;
                item_State = true;
            }
            if (System.Math.Sqrt(System.Math.Pow(item[0].transform.position.x - fighterLocation.transform.position.x, 2) +
                System.Math.Pow(item[0].transform.position.y - fighterLocation.transform.position.y, 2) +
                System.Math.Pow(item[0].transform.position.z - fighterLocation.transform.position.z, 2)) <= 0.04f)
            {
                EnemyMove.exp = 1;
                itempool.RemoveItem(item[0]);
                item[0] = null;
                item_State = true;
            }
        }
    }
}