using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
        private Rigidbody2D _rb;
        private Animator _animator;
        private Vector2 _movement;
        [SerializeField] SpriteRenderer _sr;
        private bool _bIsFacingRight = true;
    
        
        void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }
    
    
        void Update()
        {
            _movement.x = Input.GetAxisRaw("Horizontal");
            _movement.y = Input.GetAxisRaw("Vertical");
            _animator.SetFloat("Move", Mathf.Abs(_movement.x)+Mathf.Abs(_movement.y));
            _rb.linearVelocity = new Vector2(_movement.x * speed, _movement.y * speed);
            
            if (_movement.x > 0 && !_bIsFacingRight)
            {
                Flip();
            }
            else if (_movement.x < 0 && _bIsFacingRight)
            { 
                Flip();
            }
            
    
        }
        
        private void Flip()
        {
            _bIsFacingRight = !_bIsFacingRight;
            _sr.flipX = !_bIsFacingRight;
        }
}
