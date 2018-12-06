using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public float Movement;
    private float MoveSpeed;
    public Rigidbody2D rb;
    public float Jumpforce;
    public Animator anim;
    public string Movestate;
    public bool jumping = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        PlayerMove();
        Animation();
       Jump();
    }

  void PlayerMove()
  {
        Movement = Input.GetAxis("Horizontal");
        MoveSpeed = (Speed*Movement);
        rb.velocity = new Vector2(MoveSpeed, rb.velocity.y);
    
      if(Movement>0){
          GetComponent<SpriteRenderer>().flipX = false;
      }
 
     if(Movement<0){
          GetComponent<SpriteRenderer>().flipX = true;
      }
 
 
 
 
  }


  void  Jump()
    {
        if(Input.GetButtonDown("Jump")){

            rb.AddForce(new Vector3(0,Jumpforce,0));
            jumping = true;
        }
        
        
    }

    void Animation(){
        anim.SetFloat("Speed",Mathf.Abs(Movement));
        anim.SetBool("Jump",jumping);
    }
}
