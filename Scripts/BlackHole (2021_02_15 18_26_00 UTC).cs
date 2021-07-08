using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip scream;
    int hitNumber = 1;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Alien2" || other.transform.tag == "Alien3"|| other.transform.tag == "Alien1")
        {
            hitNumber--;
            if(hitNumber > -1)
            {
                Lives.Instance.changeLives(-1);
                audioSource.PlayOneShot(scream);
            }
           

        }
        
    }


    void OnTriggerExit2D(Collider2D other)
    {

        hitNumber = 1;
    }

}
