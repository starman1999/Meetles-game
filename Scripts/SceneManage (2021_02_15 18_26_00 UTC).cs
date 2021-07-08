using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{

    public static SceneManage Instance;
    public Animator transitionAnim;
    void Awake()
    {
        Instance = this;
    }

    public void loadScene()
    {
        StartCoroutine(transitionScene());
    }
    IEnumerator transitionScene()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("GameScene");
    }


}
