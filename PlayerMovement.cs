using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System;
using System.Collections;
public class PlayerMovement : MonoBehaviour
{
    public EasyJoystick MoveJoystick;
    public float speed = 0.01f;            // The speed that the player will move at.
    public ParticleSystem Particle = null;
    public ParticleSystem moving_Particle1 = null;
    public ParticleSystem moving_Particle2 = null;
    public PlayerEvent Event = null;
    public int HP;
    public int Damage = 10;

    Vector3 movement;                   // The vector to store the direction of the player's movement.
    Animator anim;                      // Reference to the animator component.
    Rigidbody playerRigidbody;          // Reference to the player's rigidbody.

    void Start() {
        Particle.Pause();
        moving_Particle1.Pause();
        moving_Particle2.Pause();
        HP = Int32.Parse(Event.tmp_hp);
    }

#if !MOBILE_INPUT
        int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
        float camRayLength = 100f;          // The length of the ray from the camera into the scene.
#endif

    void Awake()
    {
#if !MOBILE_INPUT
        // Create a layer mask for the floor layer.
        floorMask = LayerMask.GetMask ("Floor");
#endif

        // Set up references.
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        Vector3 turnDir = new Vector3(MoveJoystick.MoveInput().x, 0f, MoveJoystick.MoveInput().z);
        if (turnDir != Vector3.zero)
        {
            moving_Particle1.Play();
            moving_Particle2.Play();
        }
        // Store the input axes.
        float h = MoveJoystick.MoveInput().x * 0.01f;//CrossPlatformInputManager.GetAxisRaw("Horizontal");
        float v = MoveJoystick.MoveInput().z * 0.01f; //CrossPlatformInputManager.GetAxisRaw("Vertical");

        if(h ==0f && v == 0f){ 
            moving_Particle1.Pause();
            moving_Particle2.Pause();
            //moving_Particle1.Stop();
            //moving_Particle2.Stop();
            //moving_Particle1.loop = false;
            //moving_Particle2.loop = false;
            //moving_Particle1 = null;
            //moving_Particle2 = null;
        }
        // Move the player around the scene.
        Move(h*0.01f, v * 0.01f);

        Turning();

        if (HP == 0)
        {
            Particle.Play();
            Invoke("Death_Delay", 3f);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Enemy")
        {
            HP -= Damage;
            if (HP <= 0)
            {
                HP = 0;
            }
            Event.HP_Manager(HP);
        }
    }
    private void Death_Delay()
    {
        this.gameObject.SetActive(false);
    }
    void Move(float h, float v)
    {
        // Set the movement vector based on the axis input.
        movement.Set(h, 0f, v);

        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime * 0.03f;
        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition(transform.position + movement);
    }


    void Turning()
    {
#if !MOBILE_INPUT
        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit floorHit;

        // Perform the raycast and if it hits something on the floor layer...
        if(Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            Vector3 playerToMouse = floorHit.point - transform.position;

            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotatation = Quaternion.LookRotation (playerToMouse);

            // Set the player's rotation to this new rotation.
            playerRigidbody.MoveRotation (newRotatation);
        }
#else

        Vector3 turnDir = new Vector3(MoveJoystick.MoveInput().x, 0, MoveJoystick.MoveInput().z);

        if (turnDir != Vector3.zero)
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            Vector3 playerToMouse = (transform.position + turnDir) - transform.position;

            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotatation = Quaternion.LookRotation(-playerToMouse);

            // Set the player's rotation to this new rotation.
            playerRigidbody.MoveRotation(newRotatation);
        }
#endif      
    }  
}