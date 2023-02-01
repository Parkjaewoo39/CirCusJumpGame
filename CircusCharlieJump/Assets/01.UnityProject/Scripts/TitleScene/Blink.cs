using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Blink : MonoBehaviour
{
    float time;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }


    
    // Update is called once per frame
    void Update()
    {
        if (time < 0.5f)
        {
            GetComponent<TextMeshPro>().color = new Color(1, 1, 1, 1 - time);
        }
        else 
        {
            GetComponent<TextMeshPro>().color = new Color(1, 1, 1, time );
            if (0.5f < time) 
            {
                time = 0;
            }
        }
        time += Time.deltaTime;
    }
}
