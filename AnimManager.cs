using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace CompleteProject
{
    public class AnimManager : MonoBehaviour
    {
        public static int level;
        public Animator anim;
        int temp_level = 1;
        void Awake()
        {
            // Set up the reference.
            //anim.SetBool("start", true);
            // Reset the score.
            anim.enabled = false;
            level = 0;
        }

        void Update()
        {
            if (level != temp_level)
            {
                anim.enabled = true;
                temp_level = level;
                
            }
        }
    }
}
