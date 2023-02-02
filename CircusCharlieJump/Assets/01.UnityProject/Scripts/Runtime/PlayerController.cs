using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PlayerController : MonoBehaviour
{
    private int JUMP_COUNT = default;
    private const float PLAYER_GROUND_Y_POS = 0.7f;
    float jumpForce = 7f;
    public float playerJump = default;

    private bool isGround = false;
    private bool isDead = false;
    private bool isRun = false;

    public bool LeftMove = false;
    public bool RightMove = false;
    public bool JumpMove = false;


    private Rigidbody2D playerRigid = default;
    private Animation playerAni = default;
    Animator playerAnimator;

    Vector3 moveVal = Vector3.zero;
    public float moveSpeed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();

        playerRigid = gameObject.GetComponent<Rigidbody2D>();
        playerAnimator = gameObject.GetComponent<Animator>();

        if (isDead == true)
        {
            return;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (LeftMove )
        {
            playerAnimator.SetBool("Run", true);

            //GFunc.Log($"{LeftMove} ddd");
            moveVal = new Vector3(-2f, 0f, 0f);
            transform.position += moveVal * moveSpeed * Time.deltaTime;            
        }
        
        if (RightMove)
        {            
            playerAnimator.SetBool("Run", true);
            moveVal = new Vector3(+2f, 0f, 0f);
            transform.position += moveVal * moveSpeed * Time.deltaTime;
        }

        if (JumpMove && JUMP_COUNT < 1)
        {            
            if (JUMP_COUNT == 1) { return; }
            //playerAnimator.SetBool("CharlieStop", false);
            JUMP_COUNT++;

            playerRigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                       
            JumpMove = false;
            
            //animator.SetBool("", true);
            //moveVal = new Vector3(0f, 1f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.Space) && JUMP_COUNT < 1)
        {
            if (JUMP_COUNT == 1) { return; }
            JUMP_COUNT++;

            playerRigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (LeftMove == false && RightMove == false) 
        {
            playerAnimator.SetBool("Run", false);
        }
        if (JumpMove == true && LeftMove == false && RightMove == false)
        {
            playerRigid.AddForce(new Vector2(0f,0f), ForceMode2D.Impulse);
        }
        playerAnimator.SetBool("Ground", isGround);




    }

    public void Hit()
    {
        GFunc.LoadScene(GData.SCENE_NAME_PLAY);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (PLAYER_GROUND_Y_POS < collision.contacts[0].normal.y)
        {            
            isGround = true;
            JUMP_COUNT = 0;

        }
    }   //OnCollisionEnter2D()

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGround = false;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DeadZone" && !isDead) 
        {
            Die();
            Invoke("Hit", 2f);
        }
    }   //OnTriggerEnter2D()


    //
    private void Die() 
    {
        playerAnimator.SetTrigger("Die");
        playerRigid.AddForce(Vector2.zero);
        
        isDead = true;
        
    }   //Die()
    
    

}
