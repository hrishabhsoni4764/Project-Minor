    using System.Collections;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    [HideInInspector] public int maxHealth = 10;
    [HideInInspector] public AnimationClip swordStrikeAnim;
    [HideInInspector] public ThirdPersonController tpc;
    [HideInInspector] public bool shieldIsUp = false;
    [HideInInspector] public bool canUseShieldAndSword = true;

    public int curHealth;
    public int returnHealth;
    public Transform deathTrans;

    private int atkDamage = 1;
    private bool canUseSword;
    private EnemyBehaviour enemyB;
    private DungeonRooms sManager;
    private AltWeapons altWeapons;
    private Health healthScript;
    private Animator shield;

    void Start () {
        enemyB = GetComponent<EnemyBehaviour>();
        sManager = GameManager.instance.sManager;
        tpc = GameManager.instance.tpc;
        altWeapons = GameManager.instance.altWeapons;
        healthScript = GameManager.instance.health;
        shield = GameObject.FindGameObjectWithTag("Shield").GetComponent<Animator>();
    }
	
	void Update () {
        if (canUseShieldAndSword) {
            ShieldUp();
            Attack();
        }
        Death();
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
            StartCoroutine("DeathDelay");
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

    IEnumerator DeathDelay() {
        tpc.canLookAround = false;
        tpc.canMove = false;
        Animator fadeScreenAnim = GameManager.instance.fadeScreen.GetComponent<Animator>();
        sManager.activate = true;
        sManager.dRS = DungeonRoomSel.R0;
        fadeScreenAnim.SetInteger("fadeScreen", 1);
        yield return new WaitForSeconds(0.6f);
        fadeScreenAnim.SetInteger("fadeScreen", 0);
        transform.position = deathTrans.position;
        curHealth = returnHealth;
        healthScript.UpdateHearts();
        transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        tpc.canLookAround = true;
        tpc.canMove = true;
    }
}

