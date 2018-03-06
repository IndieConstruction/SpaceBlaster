using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInput : MonoBehaviour {

    [Header("Shoot Settings")]
    public float ShootForce = 0.3f;
    public KeyCode ShootKey = KeyCode.P;
    public Transform ShootStartPosition;

    BulletPoolManager bulletManager;

    // Use this for initialization
    void Start () {
        bulletManager = FindObjectOfType<BulletPoolManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(ShootKey)) {
            Shoot();
        }
	}

    void Shoot() {
        Bullet bulletToShoot = bulletManager.GetBullet();
        bulletToShoot.transform.position = ShootStartPosition.position;
        bulletToShoot.Shoot(transform.forward, ShootForce);
    }
}
