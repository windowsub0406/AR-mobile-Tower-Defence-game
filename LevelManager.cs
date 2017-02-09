using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace CompleteProject
{
    public class LevelManager : MonoBehaviour
    {
        public static int level;
        Text text;
        void Awake()
        {
            // Set up the reference.
            text = GetComponent<Text>();

            level = 1;
        }

        void Update()
        {
            text.text = "Level " + level;
            AnimManager.level = level;
            EnemyMove.level = level;
        }
    }
}
