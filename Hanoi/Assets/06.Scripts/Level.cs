using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public AudioSource Music_BG;
    public AudioSource Sound;

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

    //返回按钮
    public void Back()
    {
        Sound.Play();
        SceneManager.LoadScene("Menu");
    }

    //关卡按钮
    public void LevelSix()
    {
        Sound.Play();
        SceneManager.LoadScene("Hanoi6");
    }
    public void LevelFive()
    {
        Sound.Play();
        SceneManager.LoadScene("Hanoi5");
    }
    public void LevelFour()
    {
        Sound.Play();
        SceneManager.LoadScene("Hanoi4");
    }
    public void LevelThree()
    {
        Sound.Play();
        SceneManager.LoadScene("Hanoi3");
    }
    public void LevelTow()
    {
        Sound.Play();
        SceneManager.LoadScene("Hanoi2");
    }
    public void LevelOne()
    {
        Sound.Play();
        SceneManager.LoadScene("Hanoi1");
    }
}
