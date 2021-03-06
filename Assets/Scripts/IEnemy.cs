﻿using UnityEngine;

namespace EH.SpaceBlaster.EnemySystem_Old {

    public interface IEnemy {

        string ID { get; }
        GameObject gameObject { get; }
        int Life { get; }
        int ScoreValue { get; }

        void MovementBehaviour();
        void ShootBehaviour();
        void TakeDamage(int damage);

    }
}
