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
        Invoke("VAI", 4.0f);
    }

    public void VAI() {
        base.DestroyVisualEffect();
    }

    #endregion
}
