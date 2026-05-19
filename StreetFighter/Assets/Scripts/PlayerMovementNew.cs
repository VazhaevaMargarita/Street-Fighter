using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementNew : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Rigidbody2D rb;
    private Animator animator;
    private CharacterFlip flip;
    private HealthNew health;
    private Vector2 movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        flip = GetComponent<CharacterFlip>();
        health = GetComponent<HealthNew>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Move", movement.sqrMagnitude);

        flip.Flip(movement.x);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = movement.normalized * speed;
    }
    private void OnEnable()
    {
        health.Died += OnDeath;
    }

    private void OnDisable()
    {
        health.Died -= OnDeath;
    }

    private void OnDeath()
    {
        animator.SetTrigger("Death");
        Invoke(nameof(Pause),1f);
    }

    private void Pause()
    {
        Time.timeScale =0f;
    }
}