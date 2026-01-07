using UnityEngine;

public class WalkingAnimation : MonoBehaviour
{
    Animator _animator;
    PlayerControl _control;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _control = GetComponent<PlayerControl>();
    }

    void Update()
    {
        Vector3 horizontalVelocity = _control._lastVelocity;
        horizontalVelocity.y = 0f;

        bool isWalking = horizontalVelocity.magnitude > 0.1f;
        _animator.SetBool("isWalking", isWalking);
    }
}
