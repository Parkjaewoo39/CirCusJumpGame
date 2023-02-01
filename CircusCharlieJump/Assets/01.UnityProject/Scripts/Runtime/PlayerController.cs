using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const int JUMP_COUNT = 1;
    float jumpForce = 20f;

    private bool isGround = false;
    private bool isDead = false;

    public bool LeftMove = false;
    public bool RightMove = false;
    public bool JumpMove = false;

    public float JUMP_Y_POS = default;
    public float playerJump = default;

    private Rigidbody2D playerRigid = default;
    private Animation playerAni = default;
    Animator animator;

    Vector3 moveVal = Vector3.zero;
    public float moveSpeed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        playerRigid = gameObject.GetComponent<Rigidbody2D>();
        playerAni = gameObject.GetComponent<Animation>();

        if (isDead == true)
        {
            return;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (LeftMove)
        {
            //animator.SetBool("", false);

            //GFunc.Log($"{LeftMove} ddd");
            moveVal = new Vector3(-1f, 0f, 0f);            
            transform.position += moveVal * moveSpeed * Time.deltaTime;
        }
        if (RightMove)
        {
            //animator.SetBool("", true);

            moveVal = new Vector3(+1f, 0f, 0f);
            transform.position += moveVal * moveSpeed * Time.deltaTime;
        }
        if (JumpMove)
        {
            

            //animator.SetBool("", true);

            moveVal = new Vector3(0f, 1f, 0f);
            playerRigid.AddForce(new Vector3(0f, jumpForce, 0f));
            JumpMove= false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        isGround = true;
    }
}
