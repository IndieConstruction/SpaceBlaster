using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour, IEnemy {

    private string BulletID;
    public GameObject CurrentBulletGOPrefab;
    public Transform ShootStartPosition;
    public float ShootForce = 0.3f;
    public float ShootCooldown = 0.5f;
    float ShootCooldownBK;
    BulletPoolManager bulletManager;


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

    public abstract void MovementBehaviour();


    public virtual void ShootBehaviour() {
        ShootCooldown -= Time.deltaTime;
        if(ShootCooldown <= 0) {
            GetBullet().Shoot(ShootStartPosition.forward, ShootForce);
            ShootCooldown = ShootCooldownBK;
        }
        

    }


    private void OnBulletDestroy(IBullet bullet) {
        
    }

    public virtual void TakeDamage(int damage) {
        Life -= damage;
    }

    private void FixedUpdate() {
        MovementBehaviour();
        ShootBehaviour();
    }

    public abstract string GetID();

    public abstract int GetScore();


    public IBullet GetBullet() {
        IBullet bulletToShoot = bulletManager.GetBullet(BulletID);
        bulletToShoot.gameObject.transform.position = ShootStartPosition.position;
        bulletToShoot.OnDestroy += OnBulletDestroy;
        return bulletToShoot;
    }
}
