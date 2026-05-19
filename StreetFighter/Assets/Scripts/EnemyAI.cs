using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyAI : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 3f;

    [Header("Distances")]
    [SerializeField] private float chaseDistance = 10f;
    [SerializeField] private float attackDistance = 1.5f;

    [Header("References")]
    

    private Rigidbody2D rb;
    private Animator animator;
    private CharacterFlip flip;
    private HealthNew health;

    private bool isDead;

    private Transform player;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        flip = GetComponent<CharacterFlip>();
        health = GetComponent<HealthNew>();
    }

    private void OnEnable()
    {
        health.Died += OnDeath;
    }

    private void OnDisable()
    {
        health.Died -= OnDeath;
    }

    private void FixedUpdate()
    {
        if (isDead || player == null)
            return;

        float distance =
            Vector2.Distance(transform.position, player.transform.position);

        if (distance > chaseDistance)
        {
            StopMoving();
            return;
        }

        if (distance <= attackDistance)
        {
            Attack();
            return;
        }

        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        Vector2 direction =
            (player.transform.position - transform.position).normalized;

        rb.linearVelocity = direction * moveSpeed;

        animator.SetFloat("Move", 1f);

        flip.Flip(direction.x);
    }

    private void Attack()
    {
        rb.linearVelocity = Vector2.zero;

        animator.SetFloat("Move", 0f);

        animator.SetTrigger("Attack");
    }

    private void StopMoving()
    {
        rb.linearVelocity = Vector2.zero;

        animator.SetFloat("Move", 0f);
    }

    public void Initialize(Transform target)
    {
        player = target;
    }
    private void OnDeath()
    {
        isDead = true;

        rb.linearVelocity = Vector2.zero;

        animator.SetTrigger("Death");

        Destroy(gameObject, 0.5f);
    }

}