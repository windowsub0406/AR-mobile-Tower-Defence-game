using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System;
using System.Collections;

public class Missile : MonoBehaviour
{
    public float MissileSpeed = 20f;  
    //public MissileEvent Event = null;
    //public int SCORE;
    //public int Point = 30;
    //public float DestroyMissileZpos = 3f;
    void Start()
    {
        //SCORE = Int32.Parse(Event.tmp_score);
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(0, 0, -0.05f) * MissileSpeed * Time.deltaTime);
        
        //if (this.transform.position.z > DestroyMissileZpos) // destroy 할때만
        //{
        //    Destroy(this.gameObject);
        //}        
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Enemy")
        {
            col.gameObject.SendMessage("Enemy_hp", 25);
            this.GetComponent<Collider>().enabled = false; // 적과 충돌하면 비활성화
            //SCORE += Point;
            //Event.SCORE_Manager(SCORE);
        }
    }
}
