using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diyiduan : MonoBehaviour
{
    public Transform padA;
    //public Transform padB;


    public float speed = 0.1f; //单位为米/秒
    public float moveTime1 = 2.0f; //t1,移动总时长

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
                // 超过moveTime后，停止运动
                transform.position = startPosition + new Vector3(0, speed * moveTime1, 0);
                isMoveing = false;
            }
        }
    }

    private Vector3 GetTopCenter(Transform obj)
    {
        // 获取物体的 Renderer 组件
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            // 获取物体的边界框
            Bounds bounds = renderer.bounds;
            // 计算顶面中心点的位置
            return new Vector3(bounds.center.x, bounds.max.y, bounds.center.z);
        }
        return obj.position;
    }
}
