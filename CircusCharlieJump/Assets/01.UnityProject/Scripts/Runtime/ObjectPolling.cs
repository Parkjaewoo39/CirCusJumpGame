using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectPolling : MonoBehaviour
{
    GameObject[] BigRing = default;

    private int ringCnt = default;

    public GameObject ringFirePrefab;

    // Start is called before the first frame update
    void Start()
    {
        ringCnt = 6;

        Vector3 ringPos = new Vector3(-1200f,0f,0f);

        BigRing = new GameObject[ringCnt];

        // �� ����� �ϴ� �ٱ��� ����
        for (int i = 0; i < ringCnt; i++)
        {
            BigRing[i] = Instantiate(ringFirePrefab, ringPos,
                Quaternion.identity, gameObject.transform);

        }


        Vector3 ringPosRe = new Vector3(0f, 0f, 0f);
        // �� ���ġ

        for (int i = 0; i < ringCnt; i++)
        {
            BigRing[i].transform.localPosition = ringPosRe;

            ringPosRe.x += 1280f;


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
