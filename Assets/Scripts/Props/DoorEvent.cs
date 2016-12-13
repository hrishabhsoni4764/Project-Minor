using UnityEngine;
using System.Collections;

public class DoorEvent : MonoBehaviour {

    [HideInInspector] public bool active;
    public Transform posToMoveTo;
    private float transitionSpeed = 0.05f;
    private SwitchEvent sE;

    private float journeyLength;
    private float startTime;

    void Start()
    {
        startTime = Time.time;
        sE = FindObjectOfType<SwitchEvent>();
        journeyLength = Vector3.Distance(transform.position, posToMoveTo.position);
    }
	void Update () {

        if (active)
        {
            float distCovered = (Time.time - startTime) * transitionSpeed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(transform.position, posToMoveTo.position, fracJourney);
        }
	}
}
