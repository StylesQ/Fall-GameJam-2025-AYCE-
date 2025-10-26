
using UnityEngine;

public class PlayerCarMovement : MonoBehaviour
{
    // public GameObject obj;
    // public static Player[] activePlayers;

    [Header("Movement variables")]
    public float maxAngle;
    public float thrust;
    public Rigidbody rb;
    public WheelCollider[] frontWheels, wheels;


    void Awake(){
        
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float thrustInput = Input.GetAxis("Vertical"); // Input.GetKey(KeyCode.Space) ? 1 : 0;

        foreach (WheelCollider wheel in frontWheels){
            wheel.steerAngle = Mathf.LerpUnclamped(0, maxAngle, horizontalInput);
            // wheel.motorTorque = thrustInput * thrust * Time.fixedDeltaTime;
        }
        
        foreach (WheelCollider wheel in wheels)
        {
            wheel.motorTorque = thrustInput * thrust * Time.fixedDeltaTime;
        }

        // rb.AddForceAtPosition(transform.forward * thrustInput * thrust * Time.fixedDeltaTime, transform.position + Vector3.up, ForceMode.Force);
    }
}