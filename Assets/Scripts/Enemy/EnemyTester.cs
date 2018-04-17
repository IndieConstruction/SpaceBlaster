using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EH.SpaceBlaster.EnemySystem;

public class EnemyTester : MonoBehaviour {


    private void Update() {
        
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            IEnemy [] enemies = FindObjectsOfType<EnemyBase>();
            foreach (var enemy in enemies) {
                enemy.ChangeLevel(1);
                Debug.Log("Livello 1");
            } 
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            IEnemy[] enemies = FindObjectsOfType<EnemyBase>();
            foreach (var enemy in enemies) {
                enemy.ChangeLevel(2);
                Debug.Log("Livello 2");
            }
        }
    }
}
