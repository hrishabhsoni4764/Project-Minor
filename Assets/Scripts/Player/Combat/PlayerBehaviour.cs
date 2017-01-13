    using System.Collections;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    [HideInInspector] public int maxHealth = 10;
    [HideInInspector] public AnimationClip swordStrikeAnim;
    [HideInInspector] public ThirdPersonController tpc;
    [HideInInspector] public bool shieldIsUp = false;
    [HideInInspector] public bool canUseShieldAndSword = true;

    public int curHealth;

    private int atkDamage = 1;
    private bool canUseSword;
    private EnemyBehaviour enemyB;
    private AltWeapons altWeapons;
    private Health healthScript;
    private Animator shield;

    void Start () {
        enemyB = GetComponent<EnemyBehaviour>();
        tpc = GameManager.instance.tpc;
        altWeapons = GameManager.instance.altWeapons;
        healthScript = GameManager.instance.health;
        shield = GameObject.FindGameObjectWithTag("Shield").GetComponent<Animator>();
    }
	
	void Update () {
        if (curHealth <= 0) {
            curHealth = 0;
        }
        if (canUseShieldAndSword) {
            ShieldUp();
            Attack();
        }
        Death();
    }

    void OnTriggerEnter(Collider other) {

        if (enemyB != null && other == enemyB.GetComponent<CapsuleCollider>() && !shieldIsUp)
        {
            PlayerBounceBack(enemyB.transform, 10f);
            healthScript.TakeDamage(1);
        }
        else if (other.GetComponent<BossEnemyBehaviour>() && !shieldIsUp && !other.GetComponent<BossEnemyBehaviour>().isVulnarable) {
            if (other.GetComponent<BossEnemyBehaviour>().health > 5)
            {
                PlayerBounceBack(other.GetComponent<BossEnemyBehaviour>().transform, 10f);
                healthScript.TakeDamage(other.GetComponent<BossEnemyBehaviour>().atkPower);
            }
            else {
                PlayerBounceBack(other.GetComponent<BossEnemyBehaviour>().transform, 10f);
                healthScript.TakeDamage(other.GetComponent<BossEnemyBehaviour>().atkPower + 1);
            }
        } else if (other.GetComponent<BossEnemyBehaviour>() && shieldIsUp && !other.GetComponent<BossEnemyBehaviour>().isVulnarable) {
            PlayerBounceBack(other.GetComponent<BossEnemyBehaviour>().transform, 10f);
        } else if (other.CompareTag("RockSlide")) {
            healthScript.TakeDamage(1);
        }
    }

    void Attack() {
        if (Input.GetButtonDown("Sword") && canUseSword)
        {
            tpc.gameObject.GetComponentInChildren<BoxCollider>().enabled = true;
            Animator sword = GameObject.FindGameObjectWithTag("Sword").GetComponent<Animator>();
            sword.SetTrigger("SwingSword");
            StartCoroutine("SwordCollider");
        }
    }

    void ShieldUp() {
        shieldIsUp = Input.GetAxis("Shield") > 0f;
        if (shieldIsUp)
        {
            shield.SetBool("shieldIsUp", true);
            tpc.defaultSpeed = 4f;
            altWeapons.canUseAltWeapon = false;
            canUseSword = false;
            
        }
        else {
            shield.SetBool("shieldIsUp", false);
            tpc.defaultSpeed = 7f;
            altWeapons.canUseAltWeapon = true;
            canUseSword = true; ;
        }
    }

    public void PlayerBounceBack(Transform otherTrans, float pushBackPower) {
        Vector3 pushbackDirection = transform.position - otherTrans.transform.position;
        pushbackDirection.Normalize();
        GetComponent<Rigidbody>().AddForce(pushbackDirection * pushBackPower, ForceMode.VelocityChange);
    }


    public void Death() {
        if (curHealth <= 0) {
            curHealth = 0;
        }
    }

    public void RestoreHealth(int amount) {

        curHealth += amount;
        healthScript.UpdateHearts();

        if (curHealth > maxHealth) {
            curHealth = maxHealth;
        }
    }

    IEnumerator SwordCollider() {
        yield return new WaitForSeconds(swordStrikeAnim.length);
        tpc.gameObject.GetComponentInChildren<BoxCollider>().enabled = false;
    }
}

