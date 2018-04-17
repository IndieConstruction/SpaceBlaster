using UnityEngine;
using System.Collections;

public interface IMoveBehaviour {
    void DoMove(Transform transformToMove, float speed);
}
