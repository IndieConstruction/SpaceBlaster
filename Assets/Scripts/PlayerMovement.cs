using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [Header("Input Settings")]
    public KeyCode ForwardInput = KeyCode.W;
    public KeyCode BackwardInput = KeyCode.S;
    public KeyCode LeftInput = KeyCode.A;
    public KeyCode RightInput = KeyCode.D;

    public float MovementSpeed = 0.2f;

    public int XAxisMovement = 0;
    public int YAxisMovement = 0;

    private void FixedUpdate() {
        
        // Up Down
        if (Input.GetKey(ForwardInput)) {
            transform.position += Vector3.forward * MovementSpeed;
            YAxisMovement = 1;
        }else if (Input.GetKey(BackwardInput)) {
            transform.position += Vector3.back * MovementSpeed;
            YAxisMovement = -1;
        }else
            YAxisMovement = 0;
        // Left Right
        if (Input.GetKey(LeftInput)) {
            transform.position += Vector3.left * MovementSpeed;
            XAxisMovement = -1;
        } else if (Input.GetKey(RightInput)) {
            transform.position += Vector3.right * MovementSpeed;
            XAxisMovement = 1;
        } else
            XAxisMovement = 0;
    }
}
