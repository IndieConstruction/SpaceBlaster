using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EH.SpaceBlaster.EnemySystem {

    public interface IEnemy {

        void Shoot();

        void Move();

        int Level { get; }

        void ChangeLevel(int level);
    }
}
