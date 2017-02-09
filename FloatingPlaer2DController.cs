using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
public class FloatingPlaer2DController : MonoBehaviour {

    public float moveForce = 5, boostMultiplier = 2;
    Rigidbody2D myBody;
    void Start () {
        myBody = this.GetComponent<Rigidbody2D>();
	}
	
	
	void FixedUpdate () {
        Vector2 moveVec = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"),0, CrossPlatformInputManager.GetAxis("Vertical")) * moveForce;
        bool isBoosting = CrossPlatformInputManager.GetButton("Boost");
        Debug.Log(isBoosting ? boostMultiplier : 1);
        myBody.AddForce(moveVec * (isBoosting ? boostMultiplier : 1));

    }
}
