using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    
    private Rigidbody2D playerRb;
    private Animator playerAnimator;

    private bool facingRight;
    private Vector2 moveVector; 
    // Start is called before the first frame update
    void Start()
    {
        playerRb.GetComponent<Rigidbody2D>();
        playerAnimator.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        HandleAnimation();
        
    }

    private void  HandleInput() 
    {
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");

        Vector2 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

        if(dir.x > 0 && !facingRight || dir.x < 0 && facingRight) 
        {
            Flip();
        }
    }

    private void Flip() 
    {
        facingRight = !facingRight;
        transform.Rotate(0f , 180f, 0f);
    }

    private void HandleAnimation() 
    {
        playerAnimator.SetFloat("Speed", Mathf.Abs(moveVector.x) + Mathf.Abs(moveVector.y));
    }

    private void FixedUpdate () {
        Vector2 _velocity = moveVector.normalized * moveSpeed;
        playerRb.velocity = _velocity;
    }
}
