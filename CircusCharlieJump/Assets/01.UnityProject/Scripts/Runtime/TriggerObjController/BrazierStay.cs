using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BrazierStay : MonoBehaviour
{
    public Animation brazierAni = default;
    Animator brazierAnimator;
    private bool isbrazierStop =false;
    // Start is called before the first frame update
    void Start()
    {
        isbrazierStop= true;
        { return; }
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
           
            //brazierAnimator.SetTrigger("Stop");
        }
    }
}
