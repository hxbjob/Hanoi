using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Reset :MonoBehaviour , IPointerClickHandler
{
    public void OnPointerClick(PointerEventData data)
    {
        // ���ó���
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
    }
}
