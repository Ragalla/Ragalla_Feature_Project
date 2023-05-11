using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerInput : MonoBehaviour
{
    private Rigidbody rigidBody;
    private PlayerInputControl playerInputActions;

    // Start is called before the first frame update
    private void Awake()
    {
        playerInputActions = new PlayerInputControl();
        playerInputActions.Enable();
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector2 moveVec = playerInputActions.Player.Move.ReadValue<Vector2>();
        rigidBody.AddForce(new Vector3(moveVec.x, 0, moveVec.y) * 5f, ForceMode.Force);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            rigidBody.AddForce(Vector3.up * 5f, ForceMode.Impulse);

        }
    }
}
