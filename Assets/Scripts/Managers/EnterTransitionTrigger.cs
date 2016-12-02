using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum EnablePrompt { On, Off }
public enum LockedDoor { No, Yes }
public enum TransitionToScene { No, Yes }
public class EnterTransitionTrigger : MonoBehaviour {


    private ThirdPersonController tpc;
    private UIKey uiKey;
    [Header("-Select-")]
    public EnablePrompt enablePrompt;
    public LockedDoor lockedDoor;
    public TransitionToScene transitionToScene;
    [Header("-Transforms-")]
    public Transform posToMoveTo;
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
                    if (this.CompareTag("BossDoor")){
                        if (uiKey.gotBossKey)
                        {
                            uiKey.gotBossKey = false;
                            tpc.canMove = false;
                            StartCoroutine("EnterHouseDelay");
                        }
                        else {
                            GameObject buttonPrompt = GameManager.instance.buttonPrompt;
                            buttonPrompt.SetActive(true);
                            buttonPrompt.GetComponentInChildren<Text>().text = ("Door is Locked");
                        }
                    }
                    else {
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
        fadeScreenAnim.SetInteger("fadeScreen", 1);
        yield return new WaitForSeconds(0.6f);
        fadeScreenAnim.SetInteger("fadeScreen", 0);
        switch (transitionToScene)
        {
            case TransitionToScene.No:
                tpc.transform.position = posToMoveTo.position;
                tpc.canMove = true;
                break;
            case TransitionToScene.Yes:
                SceneManager.LoadScene(transitionTo);
                break;
        }
    }
}
