using UnityEngine;
using System;

public class InputHandler : MonoBehaviour
{
    public Vector2 MoveInput;

    public bool Jump;

    void Update()
    {
        MoveInput.x = Input.GetAxis("Horizontal");
        MoveInput.y = Input.GetAxis("Vertical");

        Jump = Input.GetKeyDown(KeyCode.Space);
    }

    public Vector3 GetInputInHorizontalPlane()
    {
        return new Vector3(MoveInput.x, 0, MoveInput.y);
    }
    public Vector3 GetInputInVerticalPlane()
    {
        return new Vector3(MoveInput.x, MoveInput.y, 0);
    }
}
