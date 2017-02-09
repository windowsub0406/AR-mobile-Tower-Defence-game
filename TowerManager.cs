using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
namespace CompleteProject
{
    public class TowerManager : MonoBehaviour
    {
        public static int HP;
        Text text;

        void Awake()
        {
            text = GetComponent<Text>();

            // Reset the score.
            HP = 100;
        }

        void Update()
        {
            if (HP < 50 && HP > 0)
            {
                Tower_event.sign += 1; 
            }
            if (HP <= 0)
            {
                HP = 0;
                SceneManager.LoadScene("gameover2");
            }
                
            text.text = "HP: " + HP;
        }

        private void onGameover()
        {
            Gameover_Manager.gameover = true;
        }
    }
}
