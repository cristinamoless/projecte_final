using UnityEngine;

public class WalkingAnimation : MonoBehaviour
{
    Animator _animator;
    PlayerControl _control;

    void Start()
    {
        _control = GetComponent<PlayerControl>();
        _animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Vector3 velocity = _control._lastVelocity;
        velocity.y = 0f;

        float speed = velocity.magnitude;
        bool isWalking = speed > 0.1f;

        bool isBackward = false;

        if (isWalking)
        {
            Vector3 moveDir = velocity.normalized;
            float dot = Vector3.Dot(transform.forward, moveDir);

            // dot < 0 = enrere
            isBackward = dot < -0.1f;
        }

        _animator.SetBool("isWalking", isWalking);
        _animator.SetBool("isBackward", isBackward);
    }
}
