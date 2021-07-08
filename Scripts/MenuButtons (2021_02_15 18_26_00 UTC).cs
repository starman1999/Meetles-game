using System;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class MenuButtons : MonoBehaviour
{

    public Animator transitionAnim;

    public void LoadGame()
    {
        StartCoroutine(transitionScene());

    }

      public void Quit()
    {
      Application.Quit();
    }


  

    public void Twitter()
    {
        Application.OpenURL("https://twitter.com/MounirDev9");
    }


    IEnumerator transitionScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene("GameScene");
    }

  
}
