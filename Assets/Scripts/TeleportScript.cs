using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportScript : MonoBehaviour {

    public string sceneToMoveTo;

    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<ThirdPersonController>() && !other.GetComponent<SphereCollider>())
        {
            if (Input.GetButtonDown("Interact"))
            {
                StartCoroutine("Delay", other.gameObject);
            }
        }
    }

    IEnumerator Delay(GameObject player)
    {
        player.GetComponent<ThirdPersonController>().canMove = false;
        player.GetComponent<ThirdPersonController>().canLookAround = false;
        Animator fadeScreenAnim = GameManager.instance.fadeScreen.GetComponent<Animator>();
        fadeScreenAnim.SetInteger("fadeScreen", 1);
        yield return new WaitForSeconds(0.6f);
        fadeScreenAnim.SetInteger("fadeScreen", 0);
        SceneManager.LoadScene(sceneToMoveTo);
    }

}
