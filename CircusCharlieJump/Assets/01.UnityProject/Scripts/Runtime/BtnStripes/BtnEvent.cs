using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnEvent : MonoBehaviour
{
    GameObject Player;
    BtnController btnController;
    PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        playerController = Player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeftBtnDown() 
    {
        playerController.LeftMove = true;
    }
    public void LeftBtnUp()
    {
        playerController.LeftMove = false;

    }
    public void RightBtnDown() 
    {
        playerController.RightMove = true;
    }
    public void RightBtnUp()
    {
        playerController.RightMove = false;
    }

    public void JumpBtnClick() 
    {
        playerController.JumpMove = true;
    }
    

    
}
