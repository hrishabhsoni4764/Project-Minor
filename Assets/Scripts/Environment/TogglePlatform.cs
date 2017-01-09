

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePlatform : MonoBehaviour {

    public Transform[] togglePoints = new Transform[2];
    [HideInInspector] public bool isHit;

    private bool isMoving;
    private int hit;
    private float startTime;
    private float journeyLength;

    void Start() {
        hit = 0;
        startTime = Time.time;
    }

	void Update ()
    {
        if (isHit) {
            if (hit == 0) {
                //journeyLength = Vector3.Distance(transform.position, togglePoints[hit].position);
                isMoving = true;
                isHit = false;
                hit = 1;
            } else {
                //journeyLength = Vector3.Distance(transform.position, togglePoints[hit].position);
                isMoving = true;
                isHit = false;
                hit = 0;
            }
        }

        if (isMoving) {
            //MoveTowardPoint(togglePoints[hit]);
            transform.position = Vector3.Lerp(transform.position, togglePoints[hit].position, 1f * Time.deltaTime);
        }

	}

    void MoveTowardPoint(Transform togglePoint) {
        //float distCovered = (Time.time - startTime) * moveSpeed;
        //float fracJourney = distCovered / journeyLength;
        //transform.position = Vector3.Lerp(transform.position, togglePoint.position, fracJourney);
    }
}
