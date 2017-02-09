using UnityEngine;
using System.Collections;

public class Gameover_event : MonoBehaviour
{
    Animator animator;
    // Use this for initialization
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isGameOver", true);
    }
}
