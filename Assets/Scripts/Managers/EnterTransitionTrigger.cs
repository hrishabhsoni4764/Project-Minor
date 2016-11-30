using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum EnablePrompt { On, Off }
public enum LockedDoor { No, Yes }
public class EnterTransitionTrigger : MonoBehaviour {



    private ThirdPersonController tpc;
    private UIKey uiKey;
    [Header("-Select-")]
    public EnablePrompt enablePrompt;
    public LockedDoor lockedDoor;
    [Header ("-Text Input-")]
    public string buttonTextInput;
    public string transitionTo;

    void Start() {
        tpc = FindObjectOfType<ThirdPersonController>();
        uiKey = FindObjectOfType<UIKey>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<ThirdPersonController>())
        {
            switch (lockedDoor)
            {
                case LockedDoor.Yes:
                    if (UIKey.keyAmount > 0)
                    {
                        UIKey.keyAmount--;
                        tpc.canMove = false;
                        StartCoroutine("EnterHouseDelay");
                    }
                    else {
                        GameObject buttonPrompt = GameManager.instance.buttonPrompt;
                        buttonPrompt.SetActive(true);
                        buttonPrompt.GetComponentInChildren<Text>().text = ("Door is Locked");
                    }
                    break;
                case LockedDoor.No:
                    switch (enablePrompt)
                    {
                        case EnablePrompt.On:
                            GameObject buttonPrompt = GameManager.instance.buttonPrompt;
                            buttonPrompt.SetActive(true);
                            buttonPrompt.GetComponentInChildren<Text>().text = (buttonTextInput);
                            if (Input.GetKeyDown(KeyCode.O))
                            {
                                tpc.canMove = false;
                                StartCoroutine("EnterHouseDelay");
                            }
                            break;
                        case EnablePrompt.Off:
                            tpc.canMove = false;
                            StartCoroutine("EnterHouseDelay");
                            break;
                    }
                    break;
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
