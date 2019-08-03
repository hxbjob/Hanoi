using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demonstrate : MonoBehaviour
{
    public GameObject[] hanoi;
    //点
    private Vector3 point1;
    private Vector3 point2;
    private Vector3 point3;
    /// <summary>
    /// 存储圆盘
    /// </summary> 
    public GameObject[] hanoiSeq;
    /// <summary>
    /// 存储圆盘坐标
    /// </summary>
    public Vector3[] posASeq;
    public Vector3[] posBSeq;
    private int i = -1;
    /// <summary>
    /// 圆盘个数
    /// </summary>
    public int n;
    /// <summary>
    /// 速度
    /// </summary>
    public float speed;

    //底座碰撞体
    private CapsuleCollider base1;
    private CapsuleCollider base2;
    private CapsuleCollider base3;

    private void Start()
    {
        base1 = GameObject.Find("base1").GetComponent<CapsuleCollider>();
        base2 = GameObject.Find("base2").GetComponent<CapsuleCollider>();
        base3 = GameObject.Find("base3").GetComponent<CapsuleCollider>();      
    }

    /// <summary>
    /// 鼠标点击事件
    /// </summary>
    public void OnMouseDown()
    {
        base1.enabled = false;
        base2.enabled = false;
        base3.enabled = false;
        point1 = GameObject.Find("WayPointA").transform.position;
        point2 = GameObject.Find("WayPointB").transform.position;
        point3 = GameObject.Find("WayPointC").transform.position;
        hanoiSeq = new GameObject[300];
        posASeq = new Vector3[300];
        posBSeq = new Vector3[300];
        Hanoi(n, point1, point2, point3);
        StartCoroutine(MoveAll());
    }

    /// <summary>
    /// 移动所有
    /// </summary>
    /// <returns></returns>
    IEnumerator MoveAll()
    {
        for (int i = 0; i < Mathf.Pow(2, n) - 1; i++)
        {
            yield return StartCoroutine(Move(hanoiSeq[i], posASeq[i], posBSeq[i]));          
        }
    }

    /// <summary>
    /// 改变圆盘坐标
    /// </summary>
    /// <param name="n"></param>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="aux"></param>
    public void Hanoi(int n, Vector3 from, Vector3 to, Vector3 aux)
    {
        if (n == 1)
        {
            AddToSequence(hanoi[0], from, to);
            return;
        }
        Hanoi(n - 1, from, aux, to);
        AddToSequence(hanoi[n - 1], from, to);
        Hanoi(n - 1, aux, to, from);
    }

    /// <summary>
    /// 添加坐标序列
    /// </summary>
    /// <param name="hanoi"></param>
    /// <param name="from"></param>
    /// <param name="to"></param>
    void AddToSequence(GameObject hanoi, Vector3 from, Vector3 to)
    {
        i++;
        hanoiSeq[i] = hanoi;
        posASeq[i].Set(from.x, from.y, from.z);
        posBSeq[i].Set(to.x, to.y, to.z);
    }


    /// <summary>
    /// 移动单个
    /// </summary>
    /// <param name="hanoi"></param>
    /// <param name="posA"></param>
    /// <param name="posB"></param>
    /// <returns></returns>
    IEnumerator Move(GameObject hanoi, Vector3 posA, Vector3 posB)
    {
        iTween.MoveTo(hanoi, posA, 2 / speed);
        yield return new WaitForSeconds(2 / speed);
        iTween.MoveTo(hanoi, posB, 1 / speed);
        yield return new WaitForSeconds(1 / speed);

        //向下发射射线检测位置
        RaycastHit hit;
        if (Physics.Raycast(posB, Vector3.down, out hit, 6))
        {
            iTween.MoveTo(hanoi, hit.point + Vector3.up*.015f, 2 / speed);
            yield return new WaitForSeconds(2 / speed);
        }
    }



}
