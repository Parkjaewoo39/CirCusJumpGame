using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingMove : MonoBehaviour
{
    private const float ringMove = 2f;
        
    Vector3 ringPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {
       transform.Translate(Vector2.left * ringMove * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") 
        {
            ringPosition.x = 0 * Time.deltaTime;           
        }
    }
}