using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    CharacterController controller;

    public LayerMask groundMask;

    public Camera cam;

    public float moveSpeed = 5f;
    public float fallSpeed = 2f;

    Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Moving on the x and z axis

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //Make the player look at mouse

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, groundMask))
        {
            //float angle = Mathf.Atan2(raycastHit.point.z, raycastHit.point.x) * Mathf.Rad2Deg - 90;
            //transform.rotation = Quaternion.Euler(0, angle, 0);
            //Debug.Log(angle);

            raycastHit.point = new Vector3(raycastHit.point.x, transform.position.y, raycastHit.point.z);

            transform.LookAt(raycastHit.point);
        }

        //Making sure the player is on the ground
        if (transform.position.y > 2.64)
        {
            controller.Move(-Vector3.up * fallSpeed * Time.deltaTime);
        }
        

        controller.Move(new Vector3(horizontal * moveSpeed * Time.deltaTime, 0f, vertical * moveSpeed * Time.deltaTime));
    }
}
