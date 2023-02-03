using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBtn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadingTest()
    {
        GFunc.LoadScene(GData.SCENE_NAME_LOAD_STAGE_ONE);
        Time.timeScale= 0.5f;
    }
    public void LoadingAndPlayTest()
    {
        GFunc.LoadScene(GData.SCENE_NAME_STAGE_ONE);
        Time.timeScale = 1.0f;
    }
    public void OnStartButton() 
    {

        GFunc.LoadScene(GData.SCENE_NAME_LOAD_STAGE_ONE);

        //Invoke("LoadingAndPlayTest", 1f);
        //Time.timeScale = 0.5f;
        //GFunc.LoadScene(GData.SCENE_NAME_LOAD_STAGE_ONE);


    }
}
