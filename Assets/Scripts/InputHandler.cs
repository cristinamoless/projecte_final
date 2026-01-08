using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal"); // A / D
        float v = Input.GetAxisRaw("Vertical");   // W / S

        MoveInput = new Vector2(h, v);
        MoveInput = Vector2.ClampMagnitude(MoveInput, 1f);
    }
}

