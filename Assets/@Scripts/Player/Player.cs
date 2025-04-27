using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour, IWorker
{
    [SerializeField] [Range(1, 5)]
    float moveSpeed = 3;

    [SerializeField]
    float rotateSpeed = 360;

    [SerializeField]
    GameObject carriedItemsObject;

    [SerializeField]
    GameObject testPickablePrefab;

    Animator animator;
    CharacterController controller;
    AudioSource audioSource;

    IPlayerState state { get; set; } = NullPlayerState.Instance;

    CarriedItems _carriedItems;

    void Awake()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();

        _carriedItems = CarriedItems.Of(carriedItemsObject);

        ChangeState(PlayerIdleState.Instance);
    }

    void Start()
    {
        StartCoroutine(CoTestPickUp());
    }

    IEnumerator CoTestPickUp()
    {
        while (true) {
            if (testPickablePrefab != null) {
                GameObject newItem = Instantiate(testPickablePrefab);
                IPickable pickable = newItem.GetComponent<IPickable>();

                if (pickable != null) {
                    PickUp(pickable);
                }
                else {
                    Debug.LogWarning("TestPickablePrefab에 IPickable 컴포넌트가 없음");
                    Destroy(newItem);
                }
            }
            yield return new WaitForSeconds(1.0f); // 1초마다 하나씩
        }
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

    public void PickUp(IPickable item)
    {
        _carriedItems.Add(item);
        item.OnPickedUp(this);
        Debug.Log("Player pick up item");
    }
}
