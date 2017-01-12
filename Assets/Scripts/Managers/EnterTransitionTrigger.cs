using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnterTransitionTrigger : MonoBehaviour {


    private ThirdPersonController tpc;
    private DungeonRooms sManager;
    private UIKey uiKey;

    [Header("-Select-")]
    [Tooltip("If enabled, you will need at least one key to open")] public bool lockedDoor;
    [Tooltip ("If enabled, you will switch the scene to another (-Fill in scene name in transitionTo-)")] public bool transitionToScene;

    [Header("-Transforms-")]
    [Tooltip("Position in this scene you will move to (-Only if transitionToScene is disabled-")] public Transform posToMoveTo;

    [Header("-Text Input-")]
    [Tooltip("Indicator for the game to know to which room you are going")] public int roomSelectNum;
    [Tooltip("Name of scene you transition to")] public string transitionTo;

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
                if (Input.GetButtonDown("Interact"))
                {
                    if (lockedDoor)
                    {
                        if (this.CompareTag("BossDoor"))
                        {
                            if (uiKey.gotBossKey)
                            {
                                if (transform.parent.FindChild("Canvas").GetChild(1).gameObject.activeSelf)
                                {
                                    transform.parent.FindChild("Canvas").GetChild(1).gameObject.SetActive(false);
                                }
                                uiKey.gotBossKey = false;
                                tpc.canMove = false;
                                StartCoroutine("EnterHouseDelay");
                            }
                            else
                            {
                                transform.parent.FindChild("Canvas").GetChild(1).gameObject.SetActive(true);
                            }
                        }
                        else
                        {
                            if (UIKey.keyAmount > 0)
                            {
                                if (transform.parent.FindChild("Canvas").GetChild(1).gameObject.activeSelf)
                                {
                                    transform.parent.FindChild("Canvas").GetChild(1).gameObject.SetActive(false);
                                }
                                UIKey.keyAmount--;
                                this.lockedDoor = false;
                                tpc.canMove = false;
                                StartCoroutine("EnterHouseDelay");
                            }
                            else {
                                transform.parent.FindChild("Canvas").GetChild(1).gameObject.SetActive(true);
                            }
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
        if (transitionToScene)
        {
            SceneManager.LoadScene(transitionTo);
        }
        else
        {
            sManager.dRS = (DungeonRoomSel)roomSelectNum;
            tpc.transform.position = posToMoveTo.position;
            tpc.canMove = true;
        }
    }
}

