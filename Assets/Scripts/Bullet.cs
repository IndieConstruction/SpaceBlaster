using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public State CurrentState = State.InPool;

    public BulletEvent OnShoot;
    public BulletEvent OnDestroy;

    public EnemmyHit OnEnemyHit;

    private void OnCollisionEnter(Collision collision) {

        Enemy enemyHit;

        if (CurrentState == State.InUse) {
            enemyHit = collision.collider.gameObject.GetComponent<Enemy>();
            if(enemyHit != null) {
                if (OnEnemyHit != null)
                    OnEnemyHit(enemyHit, this);
            }
            DestroyMe();
        }
    }

    private void FixedUpdate() {
        if (CurrentState == State.InUse) {
            transform.position += direction * force;
        }
    }

    #region API

    #region Shoot 

    Vector3 direction;
    float force;

    public void Shoot(Vector3 _direction, float _force) {
        CurrentState = State.InUse;
        if(OnShoot != null)
            OnShoot(this);
        direction = _direction;
        force = _force;
    }

    #endregion

    public void DestroyMe() {
        CurrentState = State.InPool;
        if (OnDestroy != null)
            OnDestroy(this);
    }

    #endregion

    #region Dichiarazioni tipi
    
    public delegate void BulletEvent(Bullet bullet);

    public delegate void EnemmyHit(Enemy enemy, Bullet bullet);

    public enum State {
        InPool,
        InUse,
    }

    #endregion

}
