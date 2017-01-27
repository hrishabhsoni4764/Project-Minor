using UnityEngine;
using System.Collections;

public class DoorEvent : MonoBehaviour {

    [HideInInspector] public bool active, active2;
    public Transform posToMoveTo, posToMoveTo2;
    private float transitionSpeed = 0.05f;

    private float journeyLength;
    private float startTime;

    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(transform.position, posToMoveTo.position);
    }
	void Update () {

        if (active)
        {
            float distCovered = (Time.time - startTime) * transitionSpeed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(transform.position, posToMoveTo.position, fracJourney);
        }

        if (active2)
        {
            float distCovered = (Time.time - startTime) * transitionSpeed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(transform.position, posToMoveTo2.position, fracJourney);
        }
    }
}
