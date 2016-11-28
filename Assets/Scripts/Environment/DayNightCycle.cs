using UnityEngine;
using System.Collections;

public class DayNightCycle : MonoBehaviour {

    public float dayNightCycleSpeed = 10f;
    public bool isNight = false;

    void Update() {

        transform.RotateAround(Vector3.zero, (Vector3.forward + Vector3.left), dayNightCycleSpeed * Time.deltaTime);
        transform.LookAt(Vector3.zero);
        GameObject sun = GameObject.FindGameObjectWithTag("Sun");

        if (sun.transform.position.y < -32f)
        {
            isNight = true;
        }
        else if (sun.transform.position.y > -32f)
        {
            isNight = false;
        }
	}

    public void TurnOnOffLight(bool turnOn) {
        GameObject sun = GameObject.FindGameObjectWithTag("Sun");
        GameObject moon = GameObject.FindGameObjectWithTag("Moon");
        if (turnOn)
        {
            sun.GetComponent<Light>().enabled = true;
            moon.GetComponent<Light>().enabled = true;
        }
        else if (!turnOn) {
            sun.GetComponent<Light>().enabled = false;
            moon.GetComponent<Light>().enabled = false;
        }
    }
}
