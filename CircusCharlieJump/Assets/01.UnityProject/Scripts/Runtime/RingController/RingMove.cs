using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingMove : MonoBehaviour
{
    private const float ringMove = 0.5f;

    public Rigidbody2D ringRigid;
    
    
    // Start is called before the first frame update
    void Start()
    {
        ringRigid = GetComponent<Rigidbody2D>();
        ringRigid.velocity = transform.position * ringMove * (-1f);
        ringRigid.AddForce(Vector2.left * ringMove, ForceMode2D.Impulse);
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") 
        {
            ringRigid.velocity = Vector2.zero;
        }
    }
}
