using UnityEngine;
using System.Collections;

public class AttackBehaviour : MonoBehaviour {

    private bool enemyCanHurt = true;
    public AnimationClip grassDestroyAnim;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy") && (other.GetType() == typeof(BoxCollider)) && enemyCanHurt)
        {
            enemyCanHurt = false;
            EnemyBehaviour enemyB = other.transform.parent.GetComponent<EnemyBehaviour>();
            enemyB.health -= 1;
            enemyB.EnemyBounceBack(transform.parent, 10f);
            StartCoroutine("DamageDelay");
        }
        else if (other.CompareTag("Grass"))
        {
            other.GetComponent<GrassBehaviour>().Cutgrass();
            StartCoroutine("GrassDelay", other.gameObject);
        }
        else if (other.GetComponent<PotBehaviour>())
        {
            other.GetComponent<PotBehaviour>().activate = true;
        }
    }


    IEnumerator DamageDelay() {
        yield return new WaitForSeconds(0.4f);
        enemyCanHurt = true;
    }

    IEnumerator GrassDelay(GameObject other)
    {
        yield return new WaitForSeconds(grassDestroyAnim.length);
        other.gameObject.SetActive(false);
        //int heartSpawnChance = Random.Range(0, 2);
        //if (heartSpawnChance == 1)
        //{
        //    Instantiate(Resources.Load("Prefabs/Pickups/Heart"), other.transform.position, Quaternion.identity);
        //}
    }
}
