using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    PlayerMovement pmove;
    Animator anim;

	// Use this for initialization
	void Start () {
        pmove = GetComponentInParent<PlayerMovement>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetInteger("xAxis", pmove.XAxisMovement);
        anim.SetInteger("yAxis", pmove.YAxisMovement);
	}

    public void OnAnimationCompleted() {
        Debug.Log("Animation Completed");
    }
}
