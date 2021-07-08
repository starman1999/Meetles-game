using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;

    public List<GameObject> AlienList;
  

    public GameObject Alien01;
    public GameObject Alien02;
    public GameObject Alien03;

    public int AliensNumber = 15;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        AlienList = new List<GameObject>();
       


        for (int i = 0; i < AliensNumber; i++)
        {
            GameObject obj = (GameObject)Instantiate(Alien01);
            GameObject obj2 = (GameObject)Instantiate(Alien02);
            GameObject obj3 = (GameObject)Instantiate(Alien03);


            obj.SetActive(false);
            obj2.SetActive(false);

            obj3.SetActive(false);

            AlienList.Add(obj);
            AlienList.Add(obj2);
            AlienList.Add(obj3);

        }


    }

    public GameObject GetAlien()
    {
        for (int i = 0; i < AlienList.Count; i++)
        {
            if (!AlienList[i].activeInHierarchy)
            {
                AlienList[i].transform.localScale = new Vector3(0.25f, 0.25f, 0f);
                return AlienList[i];
            }
        }

        return null;
    }


}
