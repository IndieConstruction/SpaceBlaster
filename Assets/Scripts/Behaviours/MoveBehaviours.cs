using UnityEngine;
using System.Collections;

public interface IMoveBehaviour {
    void DoMove();
}

public class MoveBehaviour1 : IMoveBehaviour {

    public void DoMove() {
        Debug.Log("Move type 1");
    }

}


public class MoveBehaviour2 : IMoveBehaviour {

    public void DoMove() {
        Debug.Log("Move type 2");
    }

}