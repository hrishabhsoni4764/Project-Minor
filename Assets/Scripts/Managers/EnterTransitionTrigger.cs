using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnterTransitionTrigger : MonoBehaviour {

    private ThirdPersonController tpc;
    public string buttonTextInput;
    public string transitionTo;

    void Start() {
        tpc = FindObjectOfType<ThirdPersonController>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<ThirdPersonController>())
        {
            GameObject buttonPrompt = GameManager.instance.buttonPrompt;
            buttonPrompt.SetActive(true);
            buttonPrompt.GetComponentInChildren<Text>().text = (buttonTextInput);
            if (Input.GetKeyDown(KeyCode.O))
            {
                tpc.canMove = false;
                StartCoroutine("EnterHouseDelay");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ThirdPersonController>())
        {
            GameObject buttonPrompt = GameManager.instance.buttonPrompt;
            buttonPrompt.SetActive(false);
        }
    }

    IEnumerator EnterHouseDelay()
    {
        Animator fadeScreenAnim = GameManager.instance.fadeScreen.GetComponent<Animator>();
        fadeScreenAnim.SetTrigger("fadeScreen");
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene(transitionTo);

    }
}
