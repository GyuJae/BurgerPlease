using System;
using UnityEngine;

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

    void Awake()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
        Debug.Log($"Camera: {Camera.main.transform}");
    }

    void Update()
    {
        Vector3 dir = GameManager.Instance.Dir;
        Vector3 moveDir = new Vector3(dir.x, 0, dir.y);

        // 45 camera y transform
        moveDir = (Quaternion.Euler(0, 45, 0) * moveDir).normalized;

        if (moveDir != Vector3.zero) {
            // 이동
            controller.Move(moveDir * (moveSpeed * Time.deltaTime));

            // 고개 돌리기
            Quaternion lookRotation = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, rotateSpeed * Time.deltaTime);

        }
        else {

        }

        // 중력 작용
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }
}
