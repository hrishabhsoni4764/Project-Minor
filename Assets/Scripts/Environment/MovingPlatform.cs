using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

    public GameObject[] nodes;

    private enum PlatformState { Moving, Idle }
    private float moveSpeed = 3f;
    private int currentPoint;
    private PlatformState platformState;

	void Update () {
        switch (platformState)
        {
            case PlatformState.Moving:
                Moving();
                break;
            case PlatformState.Idle:
                StartCoroutine("Idle");
                break;
        }
    }

    void Moving() {
        if (currentPoint >= nodes.Length)
        {
            currentPoint = 0;
        }

        if (transform.position == nodes[currentPoint].transform.position)
        {
            currentPoint++;
            platformState = PlatformState.Idle;
        }
        transform.position = Vector3.MoveTowards(transform.position, nodes[currentPoint].transform.position, moveSpeed * Time.deltaTime);
    }

    IEnumerator Idle() {
        yield return new WaitForSeconds(0.5f);
        platformState = PlatformState.Moving;
    }
}
