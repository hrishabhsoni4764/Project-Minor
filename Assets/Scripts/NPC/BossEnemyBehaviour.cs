using UnityEngine;
using System.Collections;

public enum BossState { Standby, Chasing, Charge, Stagnant }
public class BossEnemyBehaviour : MonoBehaviour {

    public int health = 5;
    public int atkPower = 1;
    public float movespeed = 0.3f;
    public BossState bossState;
    public GameObject[] rockSlideNodes;

    private ThirdPersonController tpc;
    private bool lookAt;
    private bool isFollowing;
    private Rigidbody rb;
    
    [HideInInspector] public bool bossCanHurt = true;
    [HideInInspector] public bool isVulnarable;

	void Start () {
        tpc = FindObjectOfType<ThirdPersonController>();
        rb = GetComponent<Rigidbody>();
        bossState = BossState.Standby;
    }
	
	void Update () {
        switch (bossState)
        {
            case BossState.Standby:
                isFollowing = false;
                lookAt = false;
                isVulnarable = false;
                break;
            case BossState.Chasing:
                Chasing();
                break;
            case BossState.Charge:
                Charging();
                break;
            case BossState.Stagnant:
                Stagnant();
                break;
        }

        if (isFollowing) {
            transform.position = Vector3.Lerp(transform.position, tpc.transform.position, movespeed * Time.deltaTime);
        }

        if (lookAt)
        {
            transform.LookAt(new Vector3(tpc.transform.position.x, 3.08f, tpc.transform.position.z));
        }

        if (isVulnarable)
        {
            Material vulnarableMat = Resources.Load("Materials/NPC/VulnarableBossEnemy", typeof(Material)) as Material;
            gameObject.GetComponent<Renderer>().material = vulnarableMat;
            gameObject.GetComponentInChildren<Renderer>().material = vulnarableMat;
        }
        else {
            Material defaultMat = Resources.Load("Materials/NPC/BossEnemy", typeof(Material)) as Material;
            gameObject.GetComponent<Renderer>().material = defaultMat;
            gameObject.GetComponentInChildren<Renderer>().material = defaultMat;
        }
        Death();
    }

    void Chasing() {
        isFollowing = true;
        lookAt = true;
        isVulnarable = false;
        rb.mass = 2f;

        float distance = Vector3.Distance(transform.position, tpc.transform.position);
        if (distance <= 5f) {
            bossState = BossState.Charge;
        }

        if (health <= 5)
        {
            movespeed = 0.6f;
        }
        else {
            movespeed = 0.3f;
        }
    }

    void Charging() {
        isFollowing = false;
        lookAt = false;
        isVulnarable = false;
        rb.mass = 2f;

        StartCoroutine("ShakeCharge");

    }
    void Stagnant() {
        isVulnarable = true;
        rb.mass = 2f;
        StartCoroutine("Vulnarable");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pillar") && bossState == BossState.Charge)
        {
            Destroy(other.gameObject);
            Instantiate(Resources.Load("Prefabs/Environment/Dust"), transform.position, Quaternion.identity);
            RockSlide();

            StartCoroutine("WallKnockBack", other.gameObject);
            bossState = BossState.Stagnant;
        }
        else if (other.CompareTag("Wall") && bossState == BossState.Charge)
        {
            StartCoroutine("WallKnockBack", other.gameObject);
            bossState = BossState.Stagnant;
        }
    }

    void BossKnockBack(Transform pusher, float pushBackPower) {
        Vector3 pushbackDirection = transform.position - pusher.position;
        pushbackDirection.Normalize();
        GetComponent<Rigidbody>().AddForce(pushbackDirection * pushBackPower, ForceMode.VelocityChange);
    }

    void Death() {
        if (health <= 0)
        {
            StartCoroutine("BossDeathDelay");
        }
    }

    void RockSlide() {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(Resources.Load("Prefabs/Environment/RockSlide"), rockSlideNodes[Random.Range(0, 20)].transform.position, Quaternion.identity);
        }
    }

    IEnumerator BossDeathDelay() {
        yield return new WaitForSeconds(1);
        bossState = BossState.Standby;
        gameObject.SetActive(false);
    }

    IEnumerator Vulnarable() {
        if (health > 5)
        {
            yield return new WaitForSeconds(5);
            bossState = BossState.Chasing;
        }
        else {
            yield return new WaitForSeconds(3);
            bossState = BossState.Chasing;
        }
    }

    IEnumerator WallKnockBack(GameObject wall) {
        rb.velocity = Vector3.zero;
        BossKnockBack(wall.transform, 5f);
        yield return new WaitForSeconds(1);
    }

    IEnumerator ShakeCharge() {

        if (health > 5)
        {
            yield return new WaitForSeconds(1);
            transform.position += transform.forward * 0.4f;
        }
        else {
            yield return new WaitForSeconds(.5f);
            transform.position += transform.forward * 0.6f;
        }
    }
}
