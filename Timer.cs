using UnityEngine;
using UnityEngine.UI;
using System.Collections;
namespace CompleteProject
{
    public class Timer : MonoBehaviour {
        public Text timerText;
        private float startTime;
        // Use this for initialization
        private int k = 1;
        void Start() {
            startTime = Time.time;
        }

        // Update is called once per frame
        void Update() {
            float t = Time.time - startTime;
            string minutes = ((int)t / 60).ToString("00");
            string seconds = (t % 60).ToString("f00");

            timerText.text = minutes + ":" + seconds;
            if ((int)t / 60 >= k)
            {
                k++;
                LevelManager.level = k;
                //AnimManager.level = k;
                Chelthtest.HP = 100;
                TowerManager.HP = 100;
                Tower_event.sign = 1;               
            }
        }
    }
}