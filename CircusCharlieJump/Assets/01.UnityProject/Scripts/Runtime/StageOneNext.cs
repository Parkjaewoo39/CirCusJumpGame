using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageOneNext : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("OnStageOneNext", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnStageOneNext() 
    {
        GFunc.LoadScene(GData.SCENE_NAME_STAGE_ONE);
    }
}