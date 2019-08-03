using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bases : MonoBehaviour
{
    [SerializeField]
     private int _index;//本柱序号
 
     public List<GameObject> Hanois_List = new List<GameObject>();//存储本柱圆环

    [SerializeField]
    private GameObject _Temp;
     private bool _isTrans;//可以最上面可以移动
 
     [SerializeField]
     private GameManage GameManager;

    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;

    public AudioSource source;

    public int Index
     {
         get { return _index; }
     }
 
     void OnMouseDown()
     {
         _isTrans = _Temp.GetComponent<Temp>().isNull;
         if (_isTrans == true)//可以移动
         {
             if (Hanois_List.Count != 0)//判断柱子上是否有圆环
             {
                 TakeHanoi();
             }
             else if (Hanois_List.Count == 0)//判断柱子上没有东西
             {
                PlayAudioClip(clip3);
             }
         }
         if (_isTrans == false)
         {
             if (Hanois_List.Count == 0)//判断要放置的柱子是否有物体
             {
                 TranslateFunc();
             }
             if (Hanois_List.Count != 0)//判断要放置的柱子有圆环
             {
                 if (_Temp.GetComponent<Temp>().Hanois_Obj != null)
                 {
                     int a_length = _Temp.GetComponent<Temp>().Hanois_Obj.GetComponent<Hanois>().TLength;//暂存的圆环长度
                     int b_length = Hanois_List[Hanois_List.Count - 1].GetComponent<Hanois>().TLength;
                     if (a_length<b_length)
                     {
                        TranslateFunc();
                        PlayAudioClip(clip2);
                        if (Hanois_List.Count == GameManager.hanois.Length && this._index == 3)
                         {
                            GameManager.Victory();
                         }
                        if (Hanois_List.Count == GameManager.hanois.Length && this._index == 2)
                        {
                            GameManager.Victory();
                        }
                    }
                     else
                     {
                        PlayAudioClip(clip3);
                    }
                 }
             }
         }
 
     }
 
    /// <summary>
    /// 放置圆盘
    /// </summary>
     void TranslateFunc()
     {
         Hanois_List.Add(_Temp.GetComponent<Temp>().Hanois_Obj);//为泛型列表添加_Temp暂存的东西
         Hanois_List[Hanois_List.Count - 1].transform.position = new Vector3(transform.position.x,(float) (transform.position.y+(Hanois_List.Count)*0.037), transform.position.z);//让移动的圆环移动过去
         _Temp.GetComponent<Temp>().Hanois_Obj = null;//清空暂存
         _Temp.GetComponent<Temp>().isNull = true;//可以再次移动，_Temp是空的
         GameManager.AddScore();//步数增加
         PlayAudioClip(clip2);
    }

    /// <summary>
    /// 拿起圆盘
    /// </summary>
    void TakeHanoi()
    {
        Hanois_List[Hanois_List.Count - 1].transform.position = _Temp.transform.position;//移动位置
        _Temp.GetComponent<Temp>().Hanois_Obj = Hanois_List[Hanois_List.Count - 1];//Temp暂存圆环
        _Temp.GetComponent<Temp>().isNull = false;//Temp处已经有东西了
        Hanois_List.RemoveAt(Hanois_List.Count - 1);//移除在在最上面的圆环  
        PlayAudioClip(clip1);
    }

    //点击音效
    void PlayAudioClip(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }
}
