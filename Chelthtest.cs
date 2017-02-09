using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace CompleteProject
{
    public class Chelthtest : MonoBehaviour
    {
        public static float HP;
        public Scrollbar HealthBar;
        void Start()
        {
            HP = 100;
        }
        

        void Update()
        {
            HealthBar.size = HP / 100f;
        }
    }
}