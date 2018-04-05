using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStandard : BulletBase {

    protected override string GetID() {
        return "BulletStandard";
    }

    #region visual effect

    public ParticleSystem particleSystem;

    public override void DestroyVisualEffect() {
        particleSystem.Play();
        //GetComponent<collision>
        Invoke("VAI", 0.2f);
    }

    public void VAI() {
        base.DestroyVisualEffect();
    }

    #endregion
}
