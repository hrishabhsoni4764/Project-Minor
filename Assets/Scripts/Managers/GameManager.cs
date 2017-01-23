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
    public GameObject fadeScreen;
    public GameObject roomNameObj;
    public GameObject currentRooms;
    public GameObject[] spawnpoints;
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
}
