using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EH.SpaceBlaster.ShootingSystem;

namespace EH.SpaceBlaster.EnemySystem {

    public abstract class EnemyBase : MonoBehaviour, IEnemy {
        

        private void Start() {
            ChangeShootBehaviour();
        }

        public abstract void ChangeShootBehaviour();

        private void Update() {
            Move();
            UpdateForMovement();

            if (Input.GetKeyDown(KeyCode.Space)) {
                Shoot();
            }
        }

        public virtual void UpdateForMovement() { }


        #region Shoot Behaviour

        public IShootBehaviour shootBehaviour;

        public void Shoot() {
            shootBehaviour.DoShoot();
        }

        #endregion

        public void ChangeLevel(int level) {
            Level = level;
            ChangeShootBehaviour();
        }

        #region Move Behaviour

        public IMoveBehaviour moveBehaviour = new VerticalMove();

        public void Move() {
            moveBehaviour.DoMove(this.transform, MovementSpeed);
        }

        #endregion

        public int Level { get; set; }
        public float MovementSpeed = 0;
    }
}
