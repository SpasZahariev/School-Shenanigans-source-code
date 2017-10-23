using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMovementInRunner : MonoBehaviour {

    
 
    public float moveSpeed;
    public float JumpH;
    public float Radius = 0.2f;
    public GameObject CircleArea;
    public LayerMask collidingLayer;
    public GameObject chara;


    bool allowCast = true;

    BoxCollider2D IdleCOllider;

    Animator animator;
    bool doubleJumped;
    bool isFacingLeft = false;
    bool IsGrounded;
    public int pos = 1;
    Rigidbody2D Rb2D;

	
	
	void Start () {
     
        IdleCOllider = GetComponent<BoxCollider2D>();
        doubleJumped = false;
        isFacingLeft = false;
        IsGrounded = false;
        animator = GetComponent<Animator>();
        Rb2D = GetComponent<Rigidbody2D>();

	}
 
    void Update()
    {
        if (transform.position.y < -20f)
        {
            SceneManager.LoadScene("Dead");
        }
   }
   
    public void Move(float Hot)
    {
        Rb2D.velocity = new Vector2(Hot * moveSpeed, Rb2D.velocity.y);
        if (Hot < 0 && !isFacingLeft)
        {
            pos = -1;
            Flip();
        }
        else if (Hot > 0 && isFacingLeft)
        {
            pos = 1;
            Flip();
        }
    }
         public void Jump()
    {
        if (IsGrounded || !doubleJumped)
        {
            Rb2D.velocity = new Vector2(Rb2D.velocity.x, 0f);//Tozi red e nenujen nz dali da go ostavqm
            IsGrounded = false;
            Rb2D.AddForce(Vector2.up * JumpH, ForceMode2D.Impulse);

            if (!doubleJumped && !IsGrounded)
            {
                doubleJumped = true;
            }
        }
    }
    void FixedUpdate() {
       
        animator.SetBool("Ground", IsGrounded);
        animator.SetFloat("Yvelocity", Rb2D.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(Rb2D.velocity.x));
        

       
        
        IsGrounded = Physics2D.OverlapCircle(CircleArea.transform.position, Radius, collidingLayer);
        if (IsGrounded)
            doubleJumped = false;


#if UNITY_STANDALONE || UNITY_WEBPLAYER

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        Move(Input.GetAxisRaw("Horizontal"));
#endif


    }

    


    void Flip()
    {
        isFacingLeft = !isFacingLeft;
        Vector3 Scale = this.transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
 

  
   
}
