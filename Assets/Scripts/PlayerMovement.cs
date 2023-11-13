using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float Speed;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        mouseFollow();
        ShootInput();
    }

    void HandleInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movementspeed = new Vector3(horizontal, 0, vertical);
        transform.Translate(Speed * movementspeed * Time.deltaTime, Space.World);
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