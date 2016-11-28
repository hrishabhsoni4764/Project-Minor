using UnityEngine;
using System.Collections;

public class MultiSwitchEvent : MonoBehaviour {

    public bool[] actives;
    public Vector3 posToMoveTo;

    private float transitionSpeed = 0.05f;
    private float journeyLength;
    private float startTime;

    [HideInInspector] public bool cameraHasArrived;

    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(transform.position, posToMoveTo);
    }
    void Update()
    {

        if (actives[0] && actives[1])
        {
            float distCovered = (Time.time - startTime) * transitionSpeed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(transform.position, posToMoveTo, fracJourney);
        }
    }
}
