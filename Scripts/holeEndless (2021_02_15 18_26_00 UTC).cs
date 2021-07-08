using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holeEndless : MonoBehaviour
{

    Animator animator;
    bool brokenBrick;
    AudioSource audiosource;
    public AudioClip breakSound;
    public AudioClip buildSound;
    float brickTime = 6f;
    Coroutine m_MyCoroutineReference;




    void Start()
    {

        animator = GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();
    }


   
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (gameObject.activeInHierarchy && brokenBrick == false)
            {

                audiosource.PlayOneShot(breakSound);
                animator.SetTrigger("break");
                brokenBrick = true;

                m_MyCoroutineReference = StartCoroutine(buildBrick());

                //gameObject.SetActive(false);
            }
            else
            {
                if (brokenBrick == true)
                {
                    StopCoroutine(m_MyCoroutineReference);
                    audiosource.PlayOneShot(buildSound);


                    animator.SetTrigger("build");
                    brokenBrick = false;
                }

            }

        }

    }
    IEnumerator buildBrick()
    {
        yield return new WaitForSeconds(brickTime);
        animator.SetTrigger("build");
        audiosource.PlayOneShot(buildSound);

        brokenBrick = false;
        yield return null;

    }
}
