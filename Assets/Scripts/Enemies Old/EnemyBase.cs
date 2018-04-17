using EH.SpaceBlaster.BulletSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EH.SpaceBlaster.EnemySystem_Old {

    public abstract class EnemyBase : MonoBehaviour, IEnemy {

        private string BulletID;
        public GameObject CurrentBulletGOPrefab;
        public Transform ShootStartPosition;
        public float ShootForce = 0.3f;
        public float ShootCooldown = 0.5f;
        float ShootCooldownBK;
        BulletPoolManager bulletManager;

        public IMoveBehaviour MovementEngine;


        private void Start() {
            bulletManager = FindObjectOfType<BulletPoolManager>();
            IBullet currentBullet = CurrentBulletGOPrefab.GetComponent<IBullet>();
            if (currentBullet == null)
                return;
            BulletID = currentBullet.ID;
            ShootCooldownBK = ShootCooldown;

        }

        public string ID {
            get {
                return GetID();
            }
        }

        public int ScoreValue { get { return GetScore(); } }

        public int Life { get; private set; }

        public void MovementBehaviour() {
            MovementEngine.DoMove(this.transform, 0.5f);
        }


        public void ShootBehaviour() {
            ShootCooldown -= Time.deltaTime;
            if (ShootCooldown <= 0) {
                GetBullet().Shoot(ShootStartPosition.forward, ShootForce);
                ShootCooldown = ShootCooldownBK;
            }

        }


        private void OnBulletDestroy(IBullet bullet) {
            GameObject.Destroy(bullet.gameObject.GetComponent<CollisionController>());
        }

        public virtual void TakeDamage(int damage) {
            Life -= damage;
        }

        private void FixedUpdate() {
            //if (Input.GetKeyDown(KeyCode.A))
            //    MovementEngine = new MoveBehaviour1();
            //if (Input.GetKeyDown(KeyCode.S))
            //    MovementEngine = new MoveBehaviour2();


            MovementBehaviour();
            ShootBehaviour();
        }

        public abstract string GetID();

        public abstract int GetScore();


        public IBullet GetBullet() {
            IBullet bulletToShoot = bulletManager.GetBullet(BulletID);
            bulletToShoot.gameObject.transform.position = ShootStartPosition.position;
            bulletToShoot.OnDestroy += OnBulletDestroy;
            bulletToShoot.gameObject.AddComponent<CollisionController>().PlayerDestroyer = true;
            return bulletToShoot;
        }
    }

}