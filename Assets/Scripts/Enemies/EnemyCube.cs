﻿using UnityEngine;


namespace EH.SpaceBlaster.EnemySystem_Old {

    public class EnemyCube : EnemyBase {

        public float SpeedMovement;
        public bool GoRight;
        public Transform RightLimit, LeftLimit;



        public override int GetScore() {
            return 3;
        }

        public override string GetID() {
            return "Cube";
        }

        private void Update() {
            MovementEngine = new MoveBehaviour2();
        }

        //public override void MovementBehaviour() {
        //    if (transform.position.x > RightLimit.position.x)
        //        GoRight = false;
        //    if (transform.position.x < LeftLimit.position.x)
        //        GoRight = true;

        //    if (GoRight)
        //        transform.position += Vector3.right * SpeedMovement;
        //    else
        //        transform.position += Vector3.left * SpeedMovement;
        //}





    }
}