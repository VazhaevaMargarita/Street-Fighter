using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] private float attackDistance = 1.5f;
    [SerializeField] private LayerMask targetLayer;

    private CharacterFlip flip;

    private void Awake()
    {
        flip = GetComponent<CharacterFlip>();
    }

    public void DealDamage()
    {
        Vector2 direction =
            flip.IsFacingRight ? Vector2.right : Vector2.left;

        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            direction,
            attackDistance,
            targetLayer);

        Debug.DrawRay(
            transform.position,
            direction * attackDistance,
            Color.red,
            1f);

        if (hit.collider == null)
            return;

        IDamageable damageable =
            hit.collider.GetComponent<IDamageable>();

        damageable?.TakeDamage(damage);
    }
}