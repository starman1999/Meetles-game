using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnThreeAliens : MonoBehaviour
{
    public GameObject alien1;
    public GameObject alien2;

    public GameObject alien3;
    public GameObject alien4;
    public GameObject alien5;
    public GameObject alien6;
    public GameObject alien7;
    public GameObject alien8;
    public GameObject alien9;
    public GameObject alien10;


    // Start is called before the first frame update
    void Start()
    {

        Invoke("spawn", 24f);
        Invoke("spawn2", 72f);
        Invoke("spawn3", 158f);


    }

    void spawn()
    {
        alien1.SetActive(true);
        alien2.SetActive(true);
        alien3.SetActive(true);
        alien4.SetActive(true);

    }

    void spawn2()
    {
        alien5.SetActive(true);
        alien6.SetActive(true);
        alien7.SetActive(true);

    }

    void spawn3()
    {
        alien8.SetActive(true);
        alien9.SetActive(true);
        alien10.SetActive(true);

    }
}
