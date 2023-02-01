using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnController : MonoBehaviour
{
    Animator animator;
    public bool LeftMove = false;
    public bool RightMove = false;
    public bool JumpMove = false;

    int JumpForce = 2;

    Vector3 moveVal = Vector3.zero;
    public float moveSpeed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (LeftMove) 
        {
            //animator.SetBool("", false);

            //GFunc.Log($"{LeftMove} ddd");
            moveVal = new Vector3(-1f, 0f, 0f);
            //gameObject.GetComponent<RectTransform>().localPosition += moveVal* moveSpeed *Time.deltaTime;
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

            moveVal = new Vector3(0f, JumpForce, 0f);
            transform.position  += moveVal * JumpForce * Time.deltaTime;
        }
    }
}
