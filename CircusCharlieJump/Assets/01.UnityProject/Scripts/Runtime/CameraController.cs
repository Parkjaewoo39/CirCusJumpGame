using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float smoothing = 0.2f;
    [SerializeField] Vector2 MaxCameraBinary;
    [SerializeField] Vector2 MinCameraBinary;

   
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    public void Update()
    {
        //transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        Vector3 targetPos = new Vector3(player.position.x, player.position.y, this.transform.position.z);

        targetPos.x = Mathf.Clamp(targetPos.x, MinCameraBinary.x, MaxCameraBinary.x);
        targetPos.y = Mathf.Clamp(targetPos.y, MinCameraBinary.y, MaxCameraBinary.y);

        transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);

    }
    // Update is called once per frame
    //void Update()
    //{
    //    //transform.position = transform.position + cameraPosition;
    //}
}
