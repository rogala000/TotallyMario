using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float Speed = 1;
    [SerializeField] private float jumpPower = 1;
    [SerializeField] private bl_Joystick Joystick;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private Button jumpButton;
    [SerializeField] private Camera camera;
    private void Start()
    {
        jumpButton.onClick.AddListener(Jump);
    }

    void FixedUpdate()
    {
        float h = Joystick.Horizontal;
        camera.transform.position = new Vector3(transform.position.x, camera.transform.position.y, camera.transform.position.z);
        Vector3 translate = (new Vector3(h, 0, 0) * Time.fixedDeltaTime) * Speed;
        transform.Translate(translate);
    }

    private void Jump()
    {
        if(rigidbody.velocity.y == 0)
        {
            rigidbody.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
        }
    }

}
