using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum EnablePrompt { On, Off }
public enum LockedDoor { No, Yes }
public enum TransitionToScene { No, Yes }
public class EnterTransitionTrigger : MonoBehaviour {


    private ThirdPersonController tpc;
    private DungeonRooms sManager;
    private UIKey uiKey;
    [Header("-Select-")]
    public bool lockedDoor;
    public bool enablePrompt;
    public TransitionToScene transitionToScene;
    [Header("-Transforms-")]
    public Transform posToMoveTo;
    [Header("-Text Input-")]
    public int roomSelectNum;
    public string transitionTo;

    void Start() {
        tpc = GameManager.instance.tpc;
        sManager = GameManager.instance.sManager;
        uiKey = GameManager.instance.uiKey;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<ThirdPersonController>())
        {
            {
                if (lockedDoor) {
                    if (this.CompareTag("BossDoor"))
                    {
                        if (uiKey.gotBossKey)
                        {
                            uiKey.gotBossKey = false;
                            tpc.canMove = false;
                            StartCoroutine("EnterHouseDelay");
                        }
                        else
                        {
                            GameObject dialoguePrompt = GameManager.instance.dialoguePrompt;
                            dialoguePrompt.SetActive(true);
                            dialoguePrompt.GetComponentInChildren<Text>().text = ("Door is Locked...");
                        }
                    }
                    else
                    {
                        if (UIKey.keyAmount > 0)
                        {
                            UIKey.keyAmount--;
                            tpc.canMove = false;
                            StartCoroutine("EnterHouseDelay");
                        }
                        else {
                            GameObject dialoguePrompt = GameManager.instance.dialoguePrompt;
                            dialoguePrompt.SetActive(true);
                            dialoguePrompt.GetComponentInChildren<Text>().text = ("Door is Locked...");
                        }
                    }
                }
                else {
                    if(enablePrompt)
                    {
                        if (Input.GetButtonDown("Interact"))
                        {
                            tpc.canMove = false;
                            StartCoroutine("EnterHouseDelay");
                        }
                    }
                    else
                    {
                        tpc.canMove = false;
                        StartCoroutine("EnterHouseDelay");
                    }
                        
                }
            }
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
                sManager.dRS = (DungeonRoomSel)roomSelectNum;
                tpc.transform.position = posToMoveTo.position;
                tpc.canMove = true;
                break;
            case TransitionToScene.Yes:
                SceneManager.LoadScene(transitionTo);
                break;
        }
    }
}

