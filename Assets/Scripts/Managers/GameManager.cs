using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private static GameManager _instance;

    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    [Header("-Prefabs-")]
    public GameObject fadeOverlay;
    public GameObject fadeScreen;
    public GameObject buttonPrompt;
    public GameObject dialoguePrompt;
    [Header("-Scripts-")]
    public Health health;
    public ThirdPersonController tpc;
    public CameraMovement cameraM;
    public PlayerBehaviour playerB;
    public AltWeaponOnScreen altOS;
    public AltWeapons altWeapons;
    public HookshotController hookshotCtrl;
    public MovingPlatform movingP;
    public CameraPanTrigger cpt;
    public DungeonRooms sManager;
    public UIKey uiKey;
    void Awake()
    {
    }
}
