using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace CompleteProject
{
    public class ScoreManager : MonoBehaviour
    {
        public static int score;
        Text text;

        void Awake()
        {
            // Set up the reference.
            text = GetComponent<Text>();

            // Reset the score.
            score = 0;
        }

        void Update()
        {
            text.text = "Score  " + score;
        }
    }
}