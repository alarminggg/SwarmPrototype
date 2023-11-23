using System.Collections;
using System.Collections.Generic;
using Unity.Android.Gradle.Manifest;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;

    private Vector3 moveDirection = Vector3.zero;

    public float speed = 6.0f;
    public float gravity = 20.0f;

    // Use this for initialization
    void Start()
    {
        characterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        Locomotion();
        mouseFollow();
        ShootInput();
    }

    void Locomotion()
    {
        if (characterController.isGrounded)//When grounded, set the y-axis to zero(to ignore it)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            
            moveDirection *= speed;

        }

        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
    }

    void mouseFollow()
    {
        RaycastHit hit1;
        Ray ray1 = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray1, out hit1))
        {
            transform.LookAt(new Vector3(hit1.point.x, transform.position.y, hit1.point.z));
        }
    }

    void ShootInput()
    {
        if(Input.GetButton("Fire1"))
        {
            PlayerGun.Instance.Shoot();
        }
    }
}