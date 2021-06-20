using System;
using UnityEngine;

public class P_Locomotion : MonoBehaviour
{
    private P_InputManager inputManager;

    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator animator;

    [Header("Checker Settings")]
    [SerializeField] private LayerMask mask;
    [SerializeField] private Transform groundChecker;
    [SerializeField] private Vector2 groundCheckerSize = new Vector2(0.6f, 0.1f);

    [Header("Jump Settings")]
    [SerializeField] private float jumpForse = 6f;

    [Header("Movement Settings")]
    [SerializeField] private float horizontalSpeed = 3f;
    private Vector2 lookDirection;
    private Vector2 newVelocity;

    public static Action<bool ,string> onTrigger;
    private bool isTrigger;
    private string isTriggerName;

    private void Awake()
    {
        inputManager = GetComponent<P_InputManager>();

        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    #region Checkers

    private bool IsGrounded()
    {
        return Physics2D.OverlapBox(groundChecker.position, groundCheckerSize, 0f, mask) ? true : false;
    }

    #endregion

    #region Movement

    private void MovementHandler(Vector2 move)
    {
        if(!IsGrounded() && move.x == 0f)
        {
            newVelocity.Set(rb.velocity.x, rb.velocity.y);
        }
        else
        {
            newVelocity.Set(move.x * horizontalSpeed, rb.velocity.y);
        }
        rb.velocity = newVelocity;
    }

    public void JumpHandler()
    {
        if (IsGrounded())
        {
            newVelocity.Set(rb.velocity.x, jumpForse);
        }
        rb.velocity = newVelocity;
    }

    #endregion

    #region Combat

/*    public void AttackHandler()
    {
        if (IsGrounded())
        {
            animator.SetTrigger("isAttack");
            Debug.Log("Attack");
        }
    }
*/
    #endregion

    #region Visual
    private void FlipHandler(Vector2 moveInput)
    {
        if (moveInput.x != 0)
        {
            sr.flipX = moveInput.x < 0 ? true : false;
        }

        lookDirection = !sr.flipX ? Vector2.right : Vector2.left;
    }

  /*  private void AnimationHandler(Vector2 rbVelocity)
    {
        animator.SetFloat("horizontalSpeed", rbVelocity.x);
        animator.SetBool("isGrounded", IsGrounded());
        animator.SetFloat("verticalSpeed", rbVelocity.y);
    }*/
    #endregion

    #region Transmitters

    public void AllUpdatesHandlers()
    {
        FlipHandler(inputManager.MovementInput);
       // AnimationHandler(rb.velocity);
    }

    public void AllFixedUpdatesHandlers()
    {
        MovementHandler(inputManager.MovementInput);
    }

    #endregion

    #region Gizmos

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(groundChecker.position, groundCheckerSize);
    }

    #endregion
}