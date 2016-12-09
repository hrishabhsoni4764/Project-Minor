using UnityEngine;
using System.Collections;

public class DoorEvent : MonoBehaviour {

    [HideInInspector] public bool active;
    public Transform posToMoveTo1;
    private float transitionSpeed = 0.05f;

    private float journeyLength;
    private float startTime;

    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(transform.position, posToMoveTo1.position);
    }
	void Update () {
        
        if (active)
        {
            float distCovered = (Time.time - startTime) * transitionSpeed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(transform.position, posToMoveTo1.position, fracJourney);
        }

	}
}
