using UnityEngine;

public class OrizontalMove : IMoveBehaviour {

    public void DoMove(Transform transformToMove, float speed) {
        transformToMove.position -= new Vector3(speed, 0, 0);
    }

}
