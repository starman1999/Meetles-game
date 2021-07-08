using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipControler : MonoBehaviour
{
    Rigidbody2D rb2D;
    Animator animator;
    CapsuleCollider2D ufoCollider;

    public GameObject floatingText;
    public GameObject WrongText;
    

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        ufoCollider = GetComponent<CapsuleCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(gameObject.transform.tag == "Ufo1")
        {
            if (other.transform.tag == "Alien1")
            {
                showFloatingText(10, other.transform);
                Score.Instance.changeScore(10);
                Hole.Instance.fillAmount(0.05f);
                Score.Instance.Saves(1);

                StartCoroutine(disableCollision());
                animator.SetTrigger("enter");

            }
            else
            {
                if(other.transform.tag == "Alien2"|| other.transform.tag == "Alien3")
                {
                    Debug.Log("wrong ship 1");
                    showWrongText(10, other.transform);
                    Score.Instance.changeScore(-10);
                }
               

            }
        }
        if (gameObject.transform.tag == "Ufo2")
        {
            if (other.transform.tag == "Alien2")
            {
                showFloatingText(10, other.transform);
                Score.Instance.changeScore(10);
                Score.Instance.Saves(1);
                Hole.Instance.fillAmount(0.05f);

                StartCoroutine(disableCollision());
                animator.SetTrigger("enter");

            }
            else
            {
                if (other.transform.tag == "Alien1" || other.transform.tag == "Alien3")
                {
                    Debug.Log("wrong ship 1");
                    showWrongText(10, other.transform);
                    Score.Instance.changeScore(-10);
                }


            }
        }

        if (gameObject.transform.tag == "Ufo3")
        {
            if (other.transform.tag == "Alien3")
            {
                showFloatingText(10, other.transform);
                Score.Instance.changeScore(10);
                Hole.Instance.fillAmount(0.05f);

                Score.Instance.Saves(1);

                StartCoroutine(disableCollision());
                animator.SetTrigger("enter");

            }
            else
            {
                if (other.transform.tag == "Alien2" || other.transform.tag == "Alien1")
                {
                    Debug.Log("wrong ship 1");
                    showWrongText(10, other.transform);
                    Score.Instance.changeScore(-10);
                }



            }
        }

    }

    void showFloatingText(float amount, Transform ShowScoreHere)
    {
        var go = Instantiate(floatingText, ShowScoreHere.position, Quaternion.identity);
        go.GetComponent<MeshRenderer>().sortingOrder = 10;

        go.GetComponent<TextMesh>().text = "+" + amount.ToString();

    }


    void showWrongText(float amount, Transform ShowScoreHere)
    {
        var go = Instantiate(WrongText, ShowScoreHere.position, Quaternion.identity);
        go.GetComponent<MeshRenderer>().sortingOrder = 10;

        go.GetComponent<TextMesh>().text = "-" + amount.ToString();

    }

    IEnumerator disableCollision()
    {
        ufoCollider.enabled = false;
        yield return new WaitForSeconds(5f);
        ufoCollider.enabled = true;

    }

    


}
