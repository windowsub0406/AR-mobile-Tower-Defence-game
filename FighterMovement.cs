using UnityEngine;
using System.Collections;

public class FighterMovement : MonoBehaviour
{
    public GameObject cube1;
    public EasyJoystick LookJoystick;
    public float speed;
    void Awake()
    {

    }

    void Start()
    {
               
    }

    void Update()
    {
        OrbitAround();
        

    }

    void OrbitAround()
    {
        transform.RotateAround(cube1.transform.position, Vector3.down, speed * Time.deltaTime);
    }
}
