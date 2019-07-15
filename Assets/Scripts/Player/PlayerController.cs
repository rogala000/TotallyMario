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
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject characterSprite;

    private float delta = 0.5f;
    private bool isDead = false;

    private void Start()
    {
        jumpButton.onClick.AddListener(Jump);
        isDead = false;
    }

    void FixedUpdate()
    {

        if(isDead)
        {
            return;
        }

        float h = Joystick.Horizontal;
        camera.transform.position = new Vector3(transform.position.x, camera.transform.position.y, camera.transform.position.z);
     //   Vector3 translate = (new Vector3(h, 0, 0) * Time.fixedDeltaTime) * Speed;
    //    transform.Translate(translate);
        rigidbody.velocity = new Vector2(h * Speed, rigidbody.velocity.y);

#if UNITY_EDITOR
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger(Config.Attack);
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger(Config.Die);
            animator.SetBool(Config.IsDead, true);

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger(Config.GetHit);
        }
#endif

        if (rigidbody.velocity.y < -delta && !animator.GetBool(Config.JumpLoop))
        {
            animator.SetBool(Config.Fall, true);
        }
        else if (rigidbody.velocity.y < 0 && animator.GetBool(Config.JumpLoop))
        {
            animator.SetBool(Config.Fall, true);
        }

        if (rigidbody.velocity.y > delta)
        {
            animator.SetBool(Config.JumpLoop, true);
            animator.SetBool(Config.Fall, false);
        }


        if(rigidbody.velocity.y == 0 || (rigidbody.velocity.y < -delta && animator.GetBool(Config.Fall)))
        {
            animator.SetBool(Config.JumpLoop, false);
            animator.SetBool(Config.Fall, false);
        }

        if (rigidbody.velocity.x > delta)
        {
            characterSprite.transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool(Config.Run, true);
            Debug.Log("running right");
        }
        else if(rigidbody.velocity.x < -delta)
        {
            characterSprite.transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool(Config.Run, true);
            Debug.Log("running left");

        }
        else
        {
            animator.SetBool(Config.Run, false);
            Debug.Log("idling");

        }

        Debug.Log(rigidbody.velocity.x);
        Debug.Log(rigidbody.velocity.y);
        Debug.Log("####");
    }

    private void Jump()
    {
        if(rigidbody.velocity.y == 0)
        {
            rigidbody.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            animator.SetTrigger(Config.Jump);
        }
    }

    public void Die()
    {
        isDead = true;
        animator.SetBool(Config.IsDead, true);
        // TODO END GAME
    }

}
