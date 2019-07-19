using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float Speed = 1;
    [SerializeField] private float jumpPower = 1;
    [SerializeField] private float jumpCooldown = 2f;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject characterSprite;

    private bl_Joystick joystick;
    private Button jumpButton;
    private Button attackButton;
    private Button optionsButton;
    private Camera camera;
    private DefeatScreen defeat;
    private InGameOptions options;
    private PlayerControlsCanvas playerControls;

    private float delta = 0.5f;
    private float currentJumpCooldown = 0f;

    private bool jumpOnCooldown = false;
    private bool isDead = false;
    private bool canJump = true;


    private void Start()
    {
        playerControls = FindObjectOfType<PlayerControlsCanvas>();
        defeat = FindObjectOfType<DefeatScreen>();
        options = FindObjectOfType<InGameOptions>();
        camera = Camera.main;

        attackButton = playerControls.AttackButton;
        jumpButton = playerControls.JumpButton;
        optionsButton = playerControls.OptionsButton;
        joystick = playerControls.Joystick;

        #region Assertions
        Assert.IsNotNull(rigidbody);
        Assert.IsNotNull(animator);
        Assert.IsNotNull(characterSprite);
        Assert.IsNotNull(joystick);
        Assert.IsNotNull(jumpButton);
        Assert.IsNotNull(attackButton);
        Assert.IsNotNull(optionsButton);
        Assert.IsNotNull(camera);
        Assert.IsNotNull(defeat);
        Assert.IsNotNull(options);
        Assert.IsNotNull(playerControls);
        #endregion

        optionsButton.onClick.AddListener(GoToOptions);
        jumpButton.onClick.AddListener(Jump);
        attackButton.onClick.AddListener(Attack);
        isDead = false;


    }

    void FixedUpdate()
    {

        if(isDead)
        {
            return;
        }

        float h = joystick.Horizontal;
        camera.transform.position = new Vector3(transform.position.x, camera.transform.position.y, camera.transform.position.z);
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
            canJump = false;
        }
        else if (rigidbody.velocity.y < 0 && animator.GetBool(Config.JumpLoop))
        {
            animator.SetBool(Config.Fall, true);
            canJump = false;
        }

        if (rigidbody.velocity.y > delta)
        {
            animator.SetBool(Config.JumpLoop, true);
            animator.SetBool(Config.Fall, false);
            canJump = false;
        }
    

        if(rigidbody.velocity.y == 0 || (rigidbody.velocity.y > -delta && animator.GetBool(Config.Fall)))
        {
            animator.SetBool(Config.JumpLoop, false);
            animator.SetBool(Config.Fall, false);
            canJump = true;
        }

        if (rigidbody.velocity.x > delta)
        {
            characterSprite.transform.rotation = Quaternion.Euler(0, 0, 0);
            characterSprite.transform.localPosition = Vector3.zero;
            animator.SetBool(Config.Run, true);
        }
        else if(rigidbody.velocity.x < -delta)
        {
            characterSprite.transform.rotation = Quaternion.Euler(0, 180, 0);
            characterSprite.transform.localPosition = new Vector3(-0.7f, 0, 0);
            animator.SetBool(Config.Run, true);

        }
        else
        {
            animator.SetBool(Config.Run, false);
        }

        if(jumpOnCooldown)
        {
            currentJumpCooldown += Time.fixedDeltaTime;
            if(currentJumpCooldown >= jumpCooldown)
            {
                currentJumpCooldown = 0f;
                jumpOnCooldown = false;
            }
        }

    }

    private void Jump()
    {
        if (!canJump || jumpOnCooldown)
            return;
        
        rigidbody.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
        animator.SetBool(Config.JumpLoop, true);
        animator.SetTrigger(Config.Jump);
        canJump = false;
        jumpOnCooldown = true;
    }

    public void Die()
    {
        isDead = true;
        animator.SetBool(Config.IsDead, true);
        defeat.Defeat();
    }

    private void Attack()
    {
        animator.SetTrigger(Config.Attack);
    }

    private void GoToOptions()
    {
        options.GoToOptions();
    }

}
