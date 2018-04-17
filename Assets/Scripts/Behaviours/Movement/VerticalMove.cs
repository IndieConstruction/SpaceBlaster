using UnityEngine;

public class VerticalMove : IMoveBehaviour {

    public void DoMove(Transform transformToMove, float speed) {
        transformToMove.position -= new Vector3(0, speed, 0);
    }

}