using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class ThirdPersonController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 6f;
    public CharacterController controller;
    public float smoothTime = 0.1f;
    float turnVelociy;
    public Transform cam;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        float vertical = Input.GetAxisRaw("Vertical");
                
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAng = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAng, ref turnVelociy, smoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);


            Vector3 moveDir = Quaternion.Euler(0f, targetAng, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

        }
    }
}
