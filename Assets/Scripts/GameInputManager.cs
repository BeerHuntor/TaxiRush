using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputManager : MonoBehaviour {

    private PlayerInputActions playerInputActions;

    private void Awake() {

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable(); 

    }

    public Vector2 GetMovementVector() {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector3>();

        return inputVector;
    }

}
