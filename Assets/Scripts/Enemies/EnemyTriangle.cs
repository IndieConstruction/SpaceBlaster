using UnityEngine;
using System.Collections;

public class EnemyTriangle : EnemyBase {

    public float SpeedMovement;
    public bool GoRight;
    public Transform RightLimit, LeftLimit;

   

    

    public override int GetScore() {
        return 5;
    }

    public override string GetID() {
        return "Triangle";
    }


    public override void MovementBehaviour() {
        if (transform.position.x > RightLimit.position.x)
            GoRight = false;
        if (transform.position.x < LeftLimit.position.x)
            GoRight = true;

        if (GoRight)
            transform.position += new Vector3(1f, 0, -1f) * SpeedMovement;
        else
            transform.position += new Vector3(-1f, 0, -1f) * SpeedMovement;
    }

  
   
}
