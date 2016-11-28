using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExitTransitionTrigger : MonoBehaviour {

    private ThirdPersonController tpc;
    private bool canTransition = true;

    public string transitionTo;

    void Start()
    {
        tpc = FindObjectOfType<ThirdPersonController>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ThirdPersonController>() && canTransition)
        {
            tpc.canMove = false;
            canTransition = false;
            StartCoroutine("ExitHouseDelay");
        }
    }

    IEnumerator ExitHouseDelay()
    {
        Animator fadeAnim = GameManager.instance.fadeScreen.GetComponent<Animator>();
        fadeAnim.SetTrigger("fadeScreen");
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene(transitionTo);
    }
}
