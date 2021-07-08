using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bhole1 : MonoBehaviour
{

    ParticleSystem ps;
    ParticleSystem RipplPs;
    bool pActive = true;
    float blackholeRate = 10f;
    CapsuleCollider2D cc2D;
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        RipplPs = gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
        cc2D = GetComponent<CapsuleCollider2D>();
        InvokeRepeating("b", 20f, blackholeRate);


    }


    void Update()
    {

    }
    void b()
    {
        if(pActive== true)
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
