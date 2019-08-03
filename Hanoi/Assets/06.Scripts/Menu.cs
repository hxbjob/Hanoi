using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioSource Music_BG;
    public AudioSource Sound;

    private bool bGameScene = false;
    private bool bExit = false;

    void Update()
    {
        if (bGameScene)
        {
            if (!Sound.isPlaying)
            {
                SceneManager.LoadScene("Level");
            }
        }
        if (bExit)
        {
            if (!Sound.isPlaying)
            {
                Application.Quit();
            }
        }
    }

    //开始按钮
    public void StartBtn()
    {
        Sound.Play();
        bGameScene = true;
    }

    //退出按钮
    public void Exitbtn()
    {
        Sound.Play();
        bExit = true;
    }

    //声音按钮
    public void MusicBG(bool Select)
    {
        if (Select)
        {
            Sound.Play();
            Music_BG.Play();
        }
        else
        {
            Sound.Play();
            Music_BG.Stop();
        }
    }
}
