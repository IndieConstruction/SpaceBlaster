using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerData))]
public class ShootInput : MonoBehaviour {

    [Header("Shoot Settings")]
    public float ShootForce = 0.3f;
    public KeyCode ShootKey = KeyCode.P;
    public Transform ShootStartPosition;

    BulletPoolManager bulletManager;
    PlayerData playerData;

    // Use this for initialization
    void Start() {
        bulletManager = FindObjectOfType<BulletPoolManager>();
        playerData = GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(ShootKey)) {
            Shoot();
        }
    }

    void Shoot() {
        Bullet bulletToShoot = bulletManager.GetBullet();
        bulletToShoot.transform.position = ShootStartPosition.position;
        bulletToShoot.Shoot(transform.forward, ShootForce);
        bulletToShoot.OnDestroy += OnBulletDestroy;
        bulletToShoot.OnEnemyHit += OnEnemyHit;
    }

    public void OnEnemyHit(Enemy enemyHit, Bullet bullet) {
        bullet.OnEnemyHit -= OnEnemyHit;
        enemyHit.TakeDamage();
        playerData.Score += enemyHit.ScoreValue;
    }

    public void OnBulletDestroy(Bullet bullet) {
        bullet.OnEnemyHit -= OnEnemyHit;
        bullet.OnDestroy -= OnBulletDestroy;
    }
}
