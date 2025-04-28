using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diyiduan : MonoBehaviour
{
    public Transform padA;
    //public Transform padB;


    public float speed = 0.1f; //��λΪ��/��
    public float moveTime1 = 2.0f; //t1,�ƶ���ʱ��

    private float time = 0f;
    private Vector3 startPosition;
    private bool isMoveing = true;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = GetTopCenter(padA);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoveing)
        {
            time += Time.deltaTime;

            if (time <= moveTime1)
            {
                float displacement = speed * time;
                transform.position = startPosition + new Vector3(0, displacement, 0);
            }
            else
            {
                // ����moveTime��ֹͣ�˶�
                transform.position = startPosition + new Vector3(0, speed * moveTime1, 0);
                isMoveing = false;
            }
        }
    }

    private Vector3 GetTopCenter(Transform obj)
    {
        // ��ȡ����� Renderer ���
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            // ��ȡ����ı߽��
            Bounds bounds = renderer.bounds;
            // ���㶥�����ĵ��λ��
            return new Vector3(bounds.center.x, bounds.max.y, bounds.center.z);
        }
        return obj.position;
    }
}
