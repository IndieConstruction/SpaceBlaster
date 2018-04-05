using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour {

    public float BackGroundDisplace = 50;
    public float BGSpeed = 2;
    public BGController BG1;
    public BGController BG2;
    BGController currentBG;

    // Use this for initialization
    void Start () {
        currentBG = BG2;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position -= new Vector3(0, 0, BGSpeed);
	}

    public void RespawnBG(BGController bg) {
        if (bg != currentBG) return;
        BGController other = (bg == BG1) ? BG2 : BG1;
        other.transform.position = new Vector3(bg.transform.position.x, bg.transform.position.y, bg.transform.position.z + BackGroundDisplace);
        currentBG = other;

    }
}
