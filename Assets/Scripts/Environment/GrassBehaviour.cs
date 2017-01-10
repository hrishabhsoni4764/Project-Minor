using UnityEngine;
using System.Collections;

public class GrassBehaviour : MonoBehaviour {

    private PlayerBehaviour playerB;
    private EnemyBehaviour enemyB;
    [HideInInspector] public Animator grassAnim;

    void Start() {
        playerB = GameManager.instance.playerB;
        enemyB = GetComponent<EnemyBehaviour>();
        grassAnim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other) {

        if (other == playerB.GetComponent<CapsuleCollider>() || other == enemyB.GetComponent<CapsuleCollider>())
        {
            ShakeGrass();
        } 
    }

    void ShakeGrass()
    {
        grassAnim.SetTrigger("GrassEnterTrigger");

    }

    public void Cutgrass() {
        grassAnim.SetTrigger("CutGrass");
    }

}
