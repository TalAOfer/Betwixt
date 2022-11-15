using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private PlayerInput playerInput;
    public GameEvent OnMoveInput;
    public GameEvent OnCursorInput;
    public GameEvent OnAttackInput;
    public GameEvent OnFlipPlayerSprite;
    
    private Vector2 moveInput;
    private Vector2 mousePosInput;

    private bool isFacingRight = true;
    private float lastPositionUpdate;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator anim;

    [SerializeField] private float moveSpeed;

    [SerializeField] Camera cam;

    public Animator weaponAnim;

    private void Awake()
    {
        playerInput = new PlayerInput();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        lastPositionUpdate = 0;
    }

    private void OnEnable()
    {
        playerInput.Enable();

        playerInput.Gameplay.Movement.performed += OnMove;
        playerInput.Gameplay.Movement.canceled += OnMove;

        playerInput.Gameplay.MousePos.performed += OnMouseMove;

        playerInput.Gameplay.Attack.performed += OnAttackPressed;
        playerInput.Gameplay.Attack.canceled += OnCancelAttackPressed;

    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    public void EnableInput()
    {
        playerInput.Enable();
    }

    public void DisableInput()
    {
        playerInput.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void OnMouseMove(InputAction.CallbackContext context)
    {
        mousePosInput = cam.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }

    private void OnAttackPressed(InputAction.CallbackContext context)
    {
        OnAttackInput.Raise(this, true);
    }

    private void OnCancelAttackPressed(InputAction.CallbackContext context)
    {
        OnAttackInput.Raise(this, false);
    }



    void Update()
    {
        //if walking direction != facing direction - flip sprite and tell pivot to flip too 
        if (isFacingRight && moveInput.x < 0 || !isFacingRight && moveInput.x > 0)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
            isFacingRight = !isFacingRight;
            OnFlipPlayerSprite.Raise();
        }

        anim.SetBool("isWalking", (moveInput != Vector2.zero));
    }

    private void FixedUpdate()
    {
        //Move
        rb.velocity = moveInput * moveSpeed;

        if (moveInput != Vector2.zero)
        {
            if (Time.time > lastPositionUpdate + 0.25f)
            {
                OnMoveInput.Raise(this, transform.position);
                lastPositionUpdate = Time.time;
            }
        }

        //Rotate Gun
        Vector2 aimingDirection = mousePosInput - rb.position;
        float angle = Mathf.Atan2(aimingDirection.y, aimingDirection.x) * Mathf.Rad2Deg;
        OnCursorInput.Raise(this, angle);
    }

    public void UpdateMovementSpeed(float amount)
    {
        moveSpeed *= amount;
    }
}
