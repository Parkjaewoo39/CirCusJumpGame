using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectPolling1 : MonoBehaviour
{
    GameObject[] BigRing = default;

    private int ringCnt = default;
    private int pivot = default;

    public GameObject ringFirePrefab;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        ringCnt = 1;

        Vector3 ringPos = new Vector3(-1200f, 0f,0f);

        BigRing = new GameObject[ringCnt];

        transform.position = player.transform.position;
        // �� ����� �ϴ� �ٱ��� ����
        for (int i = 0; i < ringCnt; i++)
        {
            BigRing[i] = Instantiate(ringFirePrefab, ringPos,
                Quaternion.identity, gameObject.transform);
            ringPos.x += player.transform.localPosition.x + 1280+641f;
            gameObject.SetActive(false);

        }


        Vector3 ringPosRe = new Vector3(1280-290f, 10f, 0f);
        // �� ���ġ

        for (int i = 0; i < ringCnt; i++)
        {
            BigRing[i].transform.localPosition = ringPosRe;

            ringPosRe.x += player.transform.localPosition.x ;
            gameObject.SetActive(true);
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}