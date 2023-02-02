using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectPolling : MonoBehaviour
{
    GameObject[] BigRing = default;

    private int ringCnt = default;

    public GameObject ringFirePrefab;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        ringCnt = 2;

        Vector3 ringPos = new Vector3(-1200f, 0f,0f);

        BigRing = new GameObject[ringCnt];

        transform.position = player.transform.position;
        // 링 만들고 일단 바깥에 놓기
        for (int i = 0; i < ringCnt; i++)
        {
            BigRing[i] = Instantiate(ringFirePrefab, ringPos,
                Quaternion.identity, gameObject.transform);

        }


        Vector3 ringPosRe = new Vector3(0f, -185f, 0f);
        // 링 재배치

        for (int i = 0; i < ringCnt; i++)
        {
            BigRing[i].transform.localPosition = ringPosRe;

            ringPosRe.x += player.transform.localPosition.x + 1280;


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
