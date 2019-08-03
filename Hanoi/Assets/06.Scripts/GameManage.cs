using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    public GameObject[] hanois;
    public GameObject[] bases;
    public GameObject Temp;

    public Text scoreText1;
    public Text scoreText2;
    private int step = 0;

    public Camera MainCamera;
    public GameObject CenterObject;
    Vector2 mouse1, mouse2;
    public float ScaleSpeed = 1.0f;

    public AudioSource Sound;

    private void Start()
    {       
        for (int i = 0; i < hanois.Length; i++)//让所有圆环先加入第一个圆柱中
        {
            bases[0].GetComponent<Bases>().Hanois_List.Add(hanois[i]);
        }
    }

    public void AddScore()
    {
        step ++;
        scoreText1.text = "移动步数：" + step;
    }

    public void Victory()
    {
        scoreText2.text = "胜利";
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            mouse1 = new Vector2(Input.mousePosition.x, Input.mousePosition.y);//鼠标右键按下时记录位置1
        }

        if (Input.GetMouseButton(1))
        {
            mouse2 = new Vector2(Input.mousePosition.x, Input.mousePosition.y);//鼠标右键拖动时记录位置1                                                                               
        
            //水平旋转
            float dx = mouse2.x - mouse1.x;
            MainCamera.transform.RotateAround(CenterObject.transform.position, Vector3.up, dx*Time.deltaTime);
            
            //垂直旋转
            float dy = mouse2.y - mouse1.y;
            MainCamera.transform.RotateAround(CenterObject.transform.position, MainCamera.transform.right, dy*Time.deltaTime);
            float angle = MainCamera.transform.localEulerAngles.y;
            float maxRotAngle = 45f;
            float minRotAngle = -10f;
            //如果总角度超出指定范围，结束这一帧
            if (angle > maxRotAngle || angle < minRotAngle)
            {
                return;
            }
        }

        //滚轮调节摄像机
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            MainCamera.transform.Translate(0, 0, -1 * ScaleSpeed);
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            MainCamera.transform.Translate(0, 0, 1 * ScaleSpeed);
        }
    }

    //游戏场景返回按钮
    public void Back()
    {
        Sound.Play();
        SceneManager.LoadScene("Level");
    }
}
