using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollider : MonoBehaviour
{
  


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    


    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.tag == "DeadZone" && isGround == true && !isDead)
        //{
        //    GData.gameScore += 100;

        //    //Debug.Log($"{other.tag =="DeadZone"}");

        //    //Debug.Log($"{GData.gameScore}");

        //}
        //else 
        //{
        //    isDead = true;
        //}
    }
}
