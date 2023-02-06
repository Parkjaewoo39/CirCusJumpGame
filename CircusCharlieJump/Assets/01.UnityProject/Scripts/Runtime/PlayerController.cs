using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    private int JUMP_COUNT = default;
    private const float PLAYER_GROUND_Y_POS = 0.7f;
    //private int playerLife = default;
    private int obstacleCount = default;

    float jumpForce = 7f;
    public float playerJump = default;

    private bool isObstacleCheck = false;
    private bool isGround = false;
    private bool isDead = false;
    private bool isRun = false;
    private bool isWinGround = false;

    public bool LeftMove = false;
    public bool RightMove = false;
    public bool Left = false;
    public bool Right = false;
    public bool Score = false;
    private bool coroutinCheck = false;



    public bool JumpMove = false;


    private Rigidbody2D playerRigid = default;
    private Animation playerAni = default;
    Animator playerAnimator;

    Vector3 moveVal = Vector3.zero;
    public float moveSpeed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        //playerLife = 3;
        //playerAnimator = GetComponent<Animator>();

        playerRigid = gameObject.GetComponent<Rigidbody2D>();
        playerAnimator = gameObject.GetComponent<Animator>();

        //if (isDead == true)
        //{
        //    return;
        //}

    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            if (isGround)
            {
                playerAnimator.SetBool("Jump", false);
                if (Score)
                {
                    Score = false;
                    GData.gameScore += 100;
                }
                if (LeftMove)
                {
                    playerAnimator.SetBool("Run", true);

                    //GFunc.Log($"{LeftMove} ddd");
                    moveVal = new Vector3(-3f, 0f, 0f);
                    transform.position += moveVal * moveSpeed * Time.deltaTime;
                }

                if (RightMove)
                {
                    playerAnimator.SetBool("Run", true);
                    moveVal = new Vector3(+3f, 0f, 0f);
                    transform.position += moveVal * moveSpeed * Time.deltaTime;
                }

                if ((Input.GetKeyDown(KeyCode.Space) || JumpMove) && JUMP_COUNT < 1)
                {
                    if (JUMP_COUNT == 1) { return; }
                    //playerAnimator.SetBool("CharlieStop", false);
                    JUMP_COUNT++;

                    playerRigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

                    JumpMove = false;
                    Left = LeftMove;
                    Right = RightMove;
                    //animator.SetBool("", true);
                    //moveVal = new Vector3(0f, 1f, 0f);

                }
                if (LeftMove == false && RightMove == false)
                {
                    playerAnimator.SetBool("Run", false);
                }

                playerAnimator.SetBool("Ground", isGround);
            }
            else
            {
                playerAnimator.SetBool("Jump", true);
                if (Right)
                {
                    playerAnimator.SetBool("Jump", true);

                    moveVal = new Vector3(+3f, 0f, 0f);
                    transform.position += moveVal * moveSpeed * Time.deltaTime;
                }
                if (Left)
                {
                    playerAnimator.SetBool("Jump", true);

                    moveVal = new Vector3(-3f, 0f, 0f);
                    transform.position += moveVal * moveSpeed * Time.deltaTime;
                }
            }
        }





    }

    //public void Hit()
    //{
    //    playerLife--;
    //    playerAnimator.SetTrigger("Die");

    //    RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
    //    rectTransform.anchoredPosition = new Vector3(-365f, -175f, 0f);
    //    gameObject.SetActive(false);
    //    gameObject.SetActive(true);


    //}


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (PLAYER_GROUND_Y_POS < collision.contacts[0].normal.y)
        {
            isGround = true;
            JUMP_COUNT = 0;
            isWinGround = true;
        }
        //if()
    }   //OnCollisionEnter2D()

    private void OnCollisionExit2D(Collision2D collision)
    {
        
        isGround = false;
    }
    public IEnumerator DeadStop()
    {
       // Debug.Log($"ÄÚ·çÆ¾ 1");
        yield return new WaitForSeconds(2f);
        
        coroutinCheck = false;
        isDead = false;
        GFunc.LoadScene(GData.SCENE_NAME_LOAD_STAGE_ONE);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "DeadZone" && !isDead)
        {


            if (GData.life == 0)
            {

                Invoke("Die", 2f);

                Time.timeScale = 1f;
                GData.life = 3;
                GData.bonusTime = 5000;
                GFunc.LoadScene(GData.SCENE_NAME_TITLE);
                Time.timeScale = 1f;

            }
            else
            {
                if (coroutinCheck == false)
                {
                    
                    isDead= true;
                    coroutinCheck = true;
                    GData.life--;
                    playerAnimator.SetTrigger("Die");
                    StartCoroutine(DeadStop());
                   
                }               

            }

        }
        if (collision.tag == "WinGround" && !isDead)
        {

            Win();

            Time.timeScale = 0.01f;
        }

        if (collision.tag == "Score")
        {
            Score = true;

        }

    }   //OnTriggerEnter2D()


    //
    private void Die()
    {

        playerAnimator.SetTrigger("Die");
        playerRigid.AddForce(Vector2.zero);

        isDead = true;

    }   //Die()
    private void Hit()
    {
        Score = false;
        GFunc.LoadScene(GData.SCENE_NAME_LOAD_STAGE_ONE);


    }

    private void Win()
    {
        playerAnimator.SetTrigger("Win");
        LoadingStage2();
        GFunc.LoadScene(GData.SCENE_NAME_STAGE_TWO);

    }
    public void LoadingStage2()
    {
        GFunc.LoadScene(GData.SCENE_NAME_LOAD_STAGE_Two);
        Time.timeScale = 0.5f;
    }
    public void LoadingAndPlayTest()
    {
        GFunc.LoadScene(GData.SCENE_NAME_STAGE_ONE);
        Time.timeScale = 1.0f;
    }


}
