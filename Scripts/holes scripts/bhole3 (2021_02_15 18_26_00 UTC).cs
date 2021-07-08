using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bhole3 : MonoBehaviour
{

    ParticleSystem ps;
    ParticleSystem RipplPs;

    float blackholeRate = 40f;
    CapsuleCollider2D cc2D;

    void Start()
    {
        cc2D = GetComponent<CapsuleCollider2D>();
        cc2D.enabled = false;
        RipplPs = gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();

        ps = GetComponent<ParticleSystem>();
        ps.Stop();
        InvokeRepeating("b", 300f, blackholeRate);

    }


    void b()
    {



        StartCoroutine(ripples());



    }

    IEnumerator ripples()
    {
        RipplPs.Play();
        yield return new WaitForSeconds(3.5f);
        ps.Play();
        cc2D.enabled = true;
    }


}
