using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour
{

    public GameObject pausemenu;
    public Animator transitionAnim;
     AudioSource audioSource;
    bool disabled =true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if(disabled == true)
            {
                Pausem();
                disabled = !disabled;


            }
            else
            {
                Resume();
                disabled = !disabled;

            }

        }

    }


    public void Resume()
    {
        Time.timeScale = 1f;
        audioSource.Play();

        pausemenu.SetActive(false);

    }


    public void MainMenu()
    {
        Time.timeScale = 1f;

        StartCoroutine(transitionScene());


    }

    public void Pausem()
    {
        Time.timeScale = 0f;
        audioSource.Pause();

        pausemenu.SetActive(true);
    }


    IEnumerator transitionScene()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MainMenu");
    }
}
