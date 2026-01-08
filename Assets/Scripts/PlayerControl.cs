using UnityEngine;
using System;

public class PlayerControl : MonoBehaviour
{
    public WorldManager _manolita;

    public float Gravity = -15;
    public float GroundSmooth = 0.5f;
    public float TurnSmooth = 0.01f;

    public Transform cameraTransform;

    CharacterController _controller;
    InputHandler _input;

    public Vector3 _lastVelocity;
    public Vector3 _externalForces;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _input = GetComponent<InputHandler>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;

        camForward.y = 0f;
        camRight.y = 0f;

        camForward.Normalize();
        camRight.Normalize();

        var target_velocity =
            (_input.MoveInput.x * camRight +
             _input.MoveInput.y * camForward) *
            (4 * _manolita.WorldState);

        var velocity = Vector3.Lerp(_lastVelocity, target_velocity, 0.7f);

        velocity.y = _lastVelocity.y;
        velocity.y += GetGravity();

        velocity += _externalForces;

        _controller.Move(velocity * Time.deltaTime);

        velocity -= _externalForces;
        _lastVelocity = velocity;

        if (velocity.magnitude > 0.01f)
        {
            Turn(velocity);
        }
    }

    private void Turn(Vector3 dir)
    {
        Vector3 current = transform.position + transform.forward;
        Vector3 target = transform.position + dir;
        target.y = transform.position.y;

        Vector3 look = Vector3.Lerp(current, target, TurnSmooth);
        transform.LookAt(look);
    }

    private float GetGravity()
    {
        return Gravity * Time.deltaTime;
    }
}
