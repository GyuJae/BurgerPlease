using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] [Range(1, 5)]
    float moveSpeed = 3;

    [SerializeField]
    float rotateSpeed = 360;

    Animator animator;
    CharacterController controller;
    AudioSource audioSource;

    IPlayerState state { get; set; } = NullPlayerState.Instance;

    void Awake()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();

        ChangeState(PlayerIdleState.Instance);
    }

    void Update()
    {
        state.Update(this);

        // 중력 작용
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }

    public void CrossFadeAnimate(string animName, float animDuration)
    {
        if (animator == null) return;
        animator.CrossFade(animName, animDuration);
    }

    public void ChangeState(IPlayerState playerState)
    {
        if (state == playerState)
            return;

        state.Exit(this);
        state = playerState;
        state.Enter(this);
    }

    public void Move(Vector3 moveDir)
    {
        controller.Move(moveDir * (moveSpeed * Time.deltaTime));
    }

    public void Rotate(Vector3 moveDir)
    {
        if (moveDir == Vector3.zero) return;
        Quaternion lookRotation = Quaternion.LookRotation(moveDir);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, rotateSpeed * Time.deltaTime);
    }

    public bool IsStop()
    {
        return GameManager.Instance.Dir == Vector2.zero;
    }
}
