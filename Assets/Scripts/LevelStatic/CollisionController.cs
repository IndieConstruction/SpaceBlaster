using EH.SpaceBlaster.BulletSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour {

    #region Enemy Destroyer

    public bool EnemyDestroyer = false;

    private void OnEnemyDestroy(IEnemy enemy) {
        if (!EnemyDestroyer) return;
        GameObject.Destroy(enemy.gameObject);
    }

    #endregion

    #region Player Destroyer

    public bool PlayerDestroyer = false;

    private void OnPlayerDestroy(PlayerController player) {
        if (!PlayerDestroyer) return;
        GameObject.Destroy(player.gameObject);
    }

    #endregion

    #region Bullet Destroyer

    public bool BulletDestroyer = false;

    private void OnBulletDestroy(IBullet bullet) {
        if (!BulletDestroyer) return;
        bullet.DestroyBehaviour();
    }

    #endregion

    #region Background respawner

    public bool BackgroundRespawner = false;

    private void OnBackgroundRespawn(BGController background) {
        if (!BackgroundRespawner) return;
        bgManager.RespawnBG(background);
    }

    #endregion

    BackgroundManager bgManager;

    private void Start() {
        if (BackgroundRespawner)
            bgManager = FindObjectOfType<BackgroundManager>();
    }

    private void OnCollisionEnter(Collision collision) {
        if (EnemyDestroyer) {
            IEnemy enemy = collision.gameObject.GetComponent<IEnemy>();
            if (enemy != null)
                OnEnemyDestroy(enemy);
        }

        if (PlayerDestroyer) {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
                OnPlayerDestroy(player);
        }

        if (BulletDestroyer) {
            IBullet bullet = collision.gameObject.GetComponent<IBullet>();
            if (bullet != null)
                OnBulletDestroy(bullet);
        }

        if (BackgroundRespawner) {
            BGController bg = collision.gameObject.GetComponent<BGController>();
            if (bg != null)
                OnBackgroundRespawn(bg);
        }

    }

}
