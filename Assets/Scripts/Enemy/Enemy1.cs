using UnityEngine;
using System.Collections;
using EH.SpaceBlaster.ShootingSystem;

namespace EH.SpaceBlaster.EnemySystem {

    public class Enemy1 : EnemyBase {

        public override void ChangeShootBehaviour() {
            shootBehaviour = new  StandardShoot();
        }
    }
}
