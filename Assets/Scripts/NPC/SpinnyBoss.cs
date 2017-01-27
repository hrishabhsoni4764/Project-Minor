using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossStates {one, two, three, dead}
public class SpinnyBoss : MonoBehaviour {

    [HideInInspector] public bool active;
    [HideInInspector] public bool vulnarable;
    public int health = 12;

    /*[HideInInspector] */public BossStates bossStates;
    public float rotateSpeed;

    void Start() {
        active = true;
        bossStates = BossStates.one;
    }

	void Update () {
        print(health);
        switch (bossStates)
        {
            case BossStates.one:
                if (active)
                {
                    transform.GetChild(0).transform.RotateAround(transform.GetChild(0).transform.position, Vector3.up, rotateSpeed);
                    transform.GetChild(1).transform.RotateAround(transform.GetChild(0).transform.position, Vector3.up, rotateSpeed);
                    transform.GetChild(2).transform.RotateAround(transform.GetChild(0).transform.position, Vector3.up, rotateSpeed);
                    vulnarable = false;
                    rotateSpeed = 4f;
                }
                else
                {
                    vulnarable = true;
                }
                if (health <= 8)
                {
                    transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(75f,75f,75f);
                    bossStates = BossStates.two;
                }
                break;
            case BossStates.two:
                if (active)
                {
                    transform.GetChild(1).transform.RotateAround(transform.GetChild(0).transform.position, Vector3.up, rotateSpeed);
                    transform.GetChild(2).transform.RotateAround(transform.GetChild(0).transform.position, Vector3.up, rotateSpeed);
                    vulnarable = false;
                    rotateSpeed = 5f;
                }
                else
                {
                    vulnarable = true;
                }
                if (health <= 4)
                {
                    transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(75f, 75f, 75f);
                    transform.GetChild(1).GetComponent<Renderer>().material.color = new Color(75f, 75f, 75f);
                    bossStates = BossStates.three;
                }
                break;
            case BossStates.three:
                if (active)
                {
                    transform.GetChild(2).transform.RotateAround(transform.GetChild(0).transform.position, Vector3.up, rotateSpeed);
                    vulnarable = false;
                    rotateSpeed = 6f;
                }
                else
                {
                    vulnarable = true;
                }
                if (health <= 0)
                {
                    transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(75f, 75f, 75f);
                    transform.GetChild(1).GetComponent<Renderer>().material.color = new Color(75f, 75f, 75f);
                    transform.GetChild(2).GetComponent<Renderer>().material.color = new Color(75f, 75f, 75f);
                    bossStates = BossStates.dead;
                }
                break;
            case BossStates.dead:

                break;
        }
    }
}
