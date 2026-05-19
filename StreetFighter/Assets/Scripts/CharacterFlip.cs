using UnityEngine;

public class CharacterFlip : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    public bool IsFacingRight { get; private set; } = true;

    public void Flip(float directionX)
    {
        if (directionX > 0 && !IsFacingRight)
        {
            SetDirection(true);
        }
        else if (directionX < 0 && IsFacingRight)
        {
            SetDirection(false);
        }
    }

    private void SetDirection(bool faceRight)
    {
        IsFacingRight = faceRight;
        spriteRenderer.flipX = !faceRight;
    }
}