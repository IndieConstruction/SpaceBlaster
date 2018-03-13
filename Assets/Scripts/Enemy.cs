using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int ScoreValue;
    public int Life;
    public bool IsAlive = true;

	public void TakeDamage(int damage = 1) {
        Life = 0;
        IsAlive = false;
    }
}
