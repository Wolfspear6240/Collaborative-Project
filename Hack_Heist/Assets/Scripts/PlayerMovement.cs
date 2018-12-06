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
    public float DashSpeed;
    public Animator anim;
    public bool jumping = false;
    public int maxJumps;
    int CurrentJumps = 0;
    public BoxCollider2D Bd;
    public bool Dashing;
    float Dashtime = 1;
    float DashCooldown = 2;
    bool dashright;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Bd = GetComponent<BoxCollider2D>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        Animation();
        Jump();
        Dash();
        print(jumping);
        print("Current Jumps = "+ CurrentJumps);
        print(Dashtime);
        if(transform.position.y <-10){
            transform.position = new Vector3(0,0,0);
        }
    if(Dashing){
        rb.gravityScale = 0;
            if(dashright){
            rb.AddForce(new Vector3(DashSpeed,0,0));
            }
            if(dashright == false){
                rb.AddForce(new Vector3(-DashSpeed,0,0));
              } 
 
            
         Dashtime -= (Time.deltaTime*1);
   
         if(Dashtime<=0){
        rb.gravityScale = 20;
        Dashing = false;
        Dashtime = 0;
       
    }
    }
   
    if(Dashtime == 0){
         DashCooldown -= Time.deltaTime;
        if(DashCooldown <= 0){
            Dashtime = 1;
            DashCooldown = 2;

        } 
    }
    
    
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
 
 
    if(Bd.IsTouchingLayers(LayerMask.GetMask("Floor"))){
        CurrentJumps = 0;
        jumping = false;
    }
    else{
        jumping = true;
    }
 
  }


  void  Jump()
    {
        if(Input.GetKeyDown(KeyCode.W)){
            jumping = true;
            if(CurrentJumps<maxJumps){
             rb.AddForce(new Vector3(0,Jumpforce,0));
             CurrentJumps += 1;

            }
          
        }
        
        
    }

    void Dash(){
        if(Input.GetKey(KeyCode.Space)&& Movement > 0 && Dashing == false){
            Dashing = true;
            dashright = true;
            
            }
        if(Input.GetKey(KeyCode.Space)&& Movement < 0 && Dashing == false){
            Dashing = true;
            dashright = false;
            }


    }
    void Animation(){
        anim.SetFloat("Speed",Mathf.Abs(Movement));
        anim.SetBool("Jump",jumping);
        anim.SetBool("Dashing",Dashing);
    }
}
