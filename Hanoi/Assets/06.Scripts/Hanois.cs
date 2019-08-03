using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hanois : MonoBehaviour
{
    [SerializeField]
    private int t_Length;//圆环的大小

     public int TLength
    {
        get
        {
            return t_Length;
        }
    }
}
