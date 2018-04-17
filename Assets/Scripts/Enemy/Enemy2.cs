using UnityEngine;
using System.Collections;
using EH.SpaceBlaster.ShootingSystem;

namespace EH.SpaceBlaster.EnemySystem {

    public class Enemy2 : EnemyBase {

        public override void ChangeShootBehaviour() {

            moveBehaviour = new OrizontalMove();

            if (Level < 2)
                shootBehaviour = new StandardShoot();
            else {
                shootBehaviour = new DoubleShoot();
            }
        }


        float counter = 2.0f;

        public override void UpdateForMovement() {
            if (counter >= 0) {
                counter -= Time.deltaTime;
            } else {
                moveBehaviour = new VerticalMove();
            }
        }

    }
}
 