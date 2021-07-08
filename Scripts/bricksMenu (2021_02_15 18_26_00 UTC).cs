using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class bricksMenu : MonoBehaviour
{

    public Animator transitionAnim;
    public void back()
    {
        StartCoroutine(transitionScene());
    }


    IEnumerator transitionScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene("MainMenu");
    }
}
