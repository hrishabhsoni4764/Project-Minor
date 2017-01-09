using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

    public bool triggeredOnStart;
    public GameObject[] nodes;

    /*[HideInInspector] */public bool active;
    private enum PlatformState { Moving, Idle }
    private float moveSpeed = 3f;
    private int currentPoint;
    private PlatformState platformState;
    private ThirdPersonController tpc;

    [HideInInspector] public bool isParented;

    void Start() {
        tpc = FindObjectOfType<ThirdPersonController>();
    }

	void Update () {
        if (triggeredOnStart || active)
        {
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
    }

    void Moving() {
        transform.position = Vector3.MoveTowards(transform.position, nodes[currentPoint].transform.position, moveSpeed * Time.deltaTime);

        if (transform.position == nodes[currentPoint].transform.position)
        {
            currentPoint++;
            platformState = PlatformState.Idle;
            if (currentPoint >= nodes.Length)
            {
                currentPoint = 0;
            }
        }
    }

    IEnumerator Idle() {
        yield return new WaitForSeconds(0.5f);
        platformState = PlatformState.Moving;
    }
}
