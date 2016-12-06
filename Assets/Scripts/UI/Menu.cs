using UnityEngine;
using System.Collections;
public enum ControlType { MouseAndKeyboard, GamePad}
public class Menu : MonoBehaviour {

    public ControlType controlType;
    private bool menuIsShowing;

	void Start () {
        controlType = ControlType.MouseAndKeyboard;
	}
	
	void Update () {
        if (!menuIsShowing) {
            menuIsShowing = !menuIsShowing;
            if (Input.GetKeyDown(KeyCode.M))
            {

            }
        }
                switch (controlType)
                {
                    case ControlType.MouseAndKeyboard:
                        break;
                    case ControlType.GamePad:
                        break;
                }
    }
}
