using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public PlayerInputControl inputControl;
    public PhysicsCheck physicsCheck;
    public PhysicsMaterial2D normal;
    public PhysicsMaterial2D wall;
    public CapsuleCollider2D coll;
    public Vector2 inputDirection;
    public float speed;
    public float jumpForce;
    public int jumpCount = 1;
    private Rigidbody2D rb;
    private PlayerAnimation playerAnimation;
    private bool moveJump;
    bool isJump;
    public bool isHurt;
    public float hurtForce;
    public bool isDead;
    public bool isAttack;
 

    private void Awake()
    {
        inputControl = new PlayerInputControl();

        rb = GetComponent<Rigidbody2D>();
        physicsCheck = GetComponent<PhysicsCheck>();
        playerAnimation = GetComponent<PlayerAnimation>();
        coll = GetComponent<CapsuleCollider2D>();

        inputControl.Gameplay.Jump.started += Jump;

        //¹¥»÷
        inputControl.Gameplay.Attack.started+=PlayerAttack;
    }

   

    private void OnEnable()
    {
        inputControl.Enable();
    }


    private void OnDisable()
    {
        inputControl.Disable();
    }


    private void Update()
    {
        inputDirection = inputControl.Gameplay.Move.ReadValue<Vector2>();

        CheckState();
    }


    private void FixedUpdate()
    {
        if(!isHurt&&!isAttack)
        {
            Move();
            if (physicsCheck.isGround)
            {
                jumpCount = 1;
            }
        }
    }


    public void Move()
    {
        rb.velocity = new Vector2(inputDirection.x * speed * Time.deltaTime, rb.velocity.y);

        int faceDir = (int)transform.localScale.x;
        if (inputDirection.x > 0)
            faceDir = 1;
        if (inputDirection.x < 0)
            faceDir = -1;


        //ÈËÎï·­×ª
        transform.localScale = new Vector3(faceDir, 1, 1);
    }

    private void Jump(InputAction.CallbackContext context)
    {

        moveJump = true;


        if (moveJump && jumpCount > 0)
        {
            isJump = true;
        }

        if (isJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            isJump = false;
            jumpCount--;
        }

        
    }

    public void GetHurt(Transform attacker)
    {
        isHurt = true;
        rb.velocity = Vector2.zero;
        Vector2 dir = new Vector2((transform.position.x - attacker.position.x), 0).normalized;

        rb.AddForce(dir * hurtForce, ForceMode2D.Impulse);
    }

    public void PlayerDead()
    {
        isDead = true;
        inputControl.Gameplay.Disable();
    }

    private void PlayerAttack(InputAction.CallbackContext context)
    {
        playerAnimation.PlayerAttack();
        isAttack = true;
       
        
    }

    private void CheckState()
    {
        coll.sharedMaterial = physicsCheck.isGround ? normal : wall;
    }
}
