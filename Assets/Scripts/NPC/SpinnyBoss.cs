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

    public GameObject[] platforms;
    public Material[] polesM;

    private SpinnyBlades spinnyBlades;

    void Start() {
        active = true;
        bossStates = BossStates.one;
        //spinnyBlades = GameManager.instance.spinnyBlades;
    }

	void Update () {
        print(health);
        switch (bossStates)
        {
            case BossStates.one:
                spinnyBlades.active = true;
                if (active)
                {
                    transform.GetChild(0).transform.RotateAround(transform.GetChild(0).transform.position, Vector3.up, rotateSpeed);
                    transform.GetChild(1).transform.RotateAround(transform.GetChild(0).transform.position, Vector3.up, rotateSpeed);
                    transform.GetChild(2).transform.RotateAround(transform.GetChild(0).transform.position, Vector3.up, rotateSpeed);
                    vulnarable = false;
                    rotateSpeed = 4f;
                    transform.GetChild(0).GetComponent<Renderer>().material = polesM[0];
                    Renderer[] rend1 = transform.GetChild(0).GetComponentsInChildren<Renderer>();
                    foreach (Renderer item in rend1)
                    {
                        item.material = polesM[0];
                    }
                }
                else
                {
                    vulnarable = true;
                    transform.GetChild(0).GetComponent<Renderer>().material = polesM[3];
                    Renderer[] rend1 = transform.GetChild(0).GetComponentsInChildren<Renderer>();
                    foreach (Renderer item in rend1)
                    {
                        item.material = polesM[3];
                    }
                }
                if (health <= 8)
                {
                    transform.GetChild(0).GetComponent<Renderer>().material = polesM[4];
                    transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                    transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
                    transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
                    transform.GetChild(0).GetChild(3).gameObject.SetActive(false);
                    platforms[0].GetComponent<MovingPlatform>().active = true;
                    bossStates = BossStates.two;

                }
                break;
            case BossStates.two:
                spinnyBlades.active = true;
                if (active)
                {
                    transform.GetChild(1).transform.RotateAround(transform.GetChild(0).transform.position, Vector3.up, rotateSpeed);
                    transform.GetChild(2).transform.RotateAround(transform.GetChild(0).transform.position, Vector3.up, rotateSpeed);
                    vulnarable = false;
                    rotateSpeed = 5f;
                    transform.GetChild(1).GetComponent<Renderer>().material = polesM[1];
                }
                else
                {
                    vulnarable = true;
                    transform.GetChild(1).GetComponent<Renderer>().material = polesM[3];
                    Renderer[] rend1 = transform.GetChild(1).GetComponentsInChildren<Renderer>();
                    foreach (Renderer item in rend1)
                    {
                        item.material = polesM[3];
                    }
                }
                if (health <= 4)
                {
                    transform.GetChild(1).GetComponent<Renderer>().material = polesM[4];
                    transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
                    transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
                    transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
                    transform.GetChild(1).GetChild(3).gameObject.SetActive(false);
                    bossStates = BossStates.three;
                }
                break;
            case BossStates.three:
                spinnyBlades.active = true;
                if (active)
                {
                    transform.GetChild(2).transform.RotateAround(transform.GetChild(0).transform.position, Vector3.up, rotateSpeed);
                    vulnarable = false;
                    rotateSpeed = 6f;
                    transform.GetChild(2).GetComponent<Renderer>().material = polesM[2];
                }
                else
                {
                    vulnarable = true;
                    transform.GetChild(2).GetComponent<Renderer>().material = polesM[3];
                    Renderer[] rend1 = transform.GetChild(2).GetComponentsInChildren<Renderer>();
                    foreach (Renderer item in rend1)
                    {
                        item.material = polesM[3];
                    }
                }
                if (health <= 0)
                {
                    transform.GetChild(2).GetComponent<Renderer>().material = polesM[4];
                    transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
                    transform.GetChild(2).GetChild(1).gameObject.SetActive(false);
                    transform.GetChild(2).GetChild(2).gameObject.SetActive(false);
                    transform.GetChild(2).GetChild(3).gameObject.SetActive(false);
                    bossStates = BossStates.dead;
                }
                break;
            case BossStates.dead:
                spinnyBlades.active = false;
                break;
        }
    }
}
