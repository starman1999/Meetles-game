using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bhole4 : MonoBehaviour
{

    ParticleSystem ps;
    ParticleSystem RipplPs;

    bool pActive = true;
    float blackholeRate = 50f;
    CapsuleCollider2D cc2D;


    void Start()
    {
        cc2D = GetComponent<CapsuleCollider2D>();
        RipplPs = gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();

        ps = GetComponent<ParticleSystem>();
        InvokeRepeating("b", 0f, blackholeRate);

    }


    void Update()
    {

    }
    void b()
    {
        if (pActive == true)
        {

            ps.Stop();
            cc2D.enabled = false;

            pActive = !pActive;

        }
        else
        {


            StartCoroutine(ripples());



            pActive = !pActive;

        }
    }
    IEnumerator ripples()
    {
        RipplPs.Play();
        yield return new WaitForSeconds(3.5f);
        ps.Play();
        cc2D.enabled = true;
    }


}

