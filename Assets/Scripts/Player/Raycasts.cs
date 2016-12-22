using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Raycasts : MonoBehaviour {

    private Vector3 lastPosition;
    private MovingPlatform movingP;
    private TogglePlatform toggleP;
    private Dungeon3Rooms d3R;
    private ThirdPersonController tpc;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask movingPlatformLayer;
    [SerializeField] LayerMask togglePlatformLayer;
    [SerializeField] LayerMask roomSelectionLayer;

    [HideInInspector] public bool isGrounded;
    private bool roomIsHitting;

    void Start() {
        movingP = FindObjectOfType<MovingPlatform>();
        toggleP = FindObjectOfType<TogglePlatform>();
        d3R = FindObjectOfType<DungeonRooms>().d3R;
        tpc = FindObjectOfType<ThirdPersonController>();
    }

	void Update () {
        Debug.Log("roomIsHitting: " + roomIsHitting);
        RaycastHit hit;
        if (!GetComponent<PushBlock>())
        {
            //MovingPlatform//
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1, movingPlatformLayer))
            {
                movingP.isParented = true;
            }
            else
            {
                movingP.isParented = false;
            }
            //KillBox//
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1, groundLayer))
            {
                isGrounded = true;
                lastPosition = transform.position;
            }
            else
            {
                isGrounded = false;
            }
            //RoomSelection//
            RaycastHit room;
            Debug.DrawRay(transform.position, Vector3.down + new Vector3(0,-6,0), Color.green);
            if (Physics.Raycast(transform.position, Vector3.down, out room, 6, roomSelectionLayer))
            {
                d3R = Dungeon3Rooms.R6;
                roomIsHitting = true;
                //if (SceneManager.GetActiveScene().name == "Dungeon3")
                //{
                //    if (room.collider.gameObject.name == "RoomSelection0")
                //    {
                //        d3R = Dungeon3Rooms.R0;
                //    }
                //    else if (room.collider.gameObject.name == "RoomSelection1")
                //    {
                //        d3R = Dungeon3Rooms.R1;
                //    }
                //    else if (room.collider.gameObject.name == "RoomSelection2")
                //    {
                //        d3R = Dungeon3Rooms.R2;
                //    }
                //    else if (room.collider.gameObject.name == "RoomSelection3")
                //    {
                //        d3R = Dungeon3Rooms.R3;
                //    }
                //    else if (room.collider.gameObject.name == "RoomSelection4")
                //    {
                //        d3R = Dungeon3Rooms.R4;
                //    }
                //    else if (room.collider.gameObject.name == "RoomSelection5")
                //    {
                //        d3R = Dungeon3Rooms.R5;
                //    }
                //    else if (room.collider.gameObject.name == "RoomSelection6")
                //    {
                //        d3R = Dungeon3Rooms.R6;
                //    }
                //}
            }
            else {
                d3R = Dungeon3Rooms.R1;
                roomIsHitting = false;
            }
        }
        else
        {
            //PushBlockParenting//
            if (transform.parent != tpc.transform) {
                if (Physics.Raycast(transform.position, Vector3.down, out hit, 1, togglePlatformLayer))
                {
                    transform.SetParent(hit.transform);
                }
                else
                {
                    transform.SetParent(null);
                }
            }
        }
    }

    public void Kill()
    {
        transform.position = lastPosition;
    }
}
