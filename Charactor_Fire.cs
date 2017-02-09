using UnityEngine;
using System.Collections;

public class Charactor_Fire : MonoBehaviour {
    public AudioSource missileAudio = null;
    public GameObject Sphere_Missile = null;
    public Transform MissileLocation = null;
    public EasyJoystick ShootJoystick;
    bool Missile_Fire_State = true;
    public float FireTime = 0.5f;
    public int MissilePoolCount = 10;
    public float DestroyMissileZpos = 1f;
    MemoryPool pool = new MemoryPool();

    GameObject[] missile;

    void FireSpeedController()
    {
        Missile_Fire_State = true;
    }
    void OnApplocationQuit() // program 종료 시 메모리 비우기
    {
        pool.Dispose();
    }

    void Start()
    {
        missileAudio.Pause();
        pool.Create(Sphere_Missile, MissilePoolCount);
        missile = new GameObject[MissilePoolCount];
        for (int i = 0; i < missile.Length; i++)
        {
            missile[i] = null; // missile 함수 초기화
        }
    }

    void Update () {
        if (Missile_Fire_State)
        {
            if (ShootJoystick.IsPressed())
            {
                Invoke("FireSpeedController", FireTime);
                for (int i = 0; i < missile.Length; i++)
                {
                    if (missile[i] == null) // 미사일 null인거 있으면 새로 생성
                    {

                        missile[i] = pool.NewItem();
                        missile[i].transform.position = MissileLocation.transform.position;
                        missile[i].transform.rotation = MissileLocation.transform.rotation;
                        missileAudio.Play();
                        break;
                    }
                }
                Debug.Log("발사");
                Missile_Fire_State = false; 
            }
        }
        for (int i = 0; i < missile.Length; i++)
        {
            if (missile[i])
            {
                if (System.Math.Abs(missile[i].transform.position.z) > System.Math.Abs(DestroyMissileZpos) ||
                    System.Math.Abs(missile[i].transform.position.x) > System.Math.Abs(DestroyMissileZpos))
                {
                    pool.RemoveItem(missile[i]); // 범위 벗어나면 없애고, 다시 null로
                    missile[i] = null;
                }
                else if (missile[i].GetComponent<Collider>().enabled == false)
                {
                    missile[i].GetComponent<Collider>().enabled = true;
                    pool.RemoveItem(missile[i]); // 충돌하면 없애고, 다시 null로
                    missile[i] = null;
                }
            }
        }
    }
}
