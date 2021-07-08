using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallFloatText : MonoBehaviour
{
    float destroyTime = 0.65f;
    Vector3 RandomizeIntensity;
    void Start()
    {


        RandomizeIntensity = new Vector3(0.5f, 0.5f, 0);
        transform.position += new Vector3(Random.Range(-RandomizeIntensity.x, RandomizeIntensity.x), Random.Range(-RandomizeIntensity.y, RandomizeIntensity.y),
  Random.Range(-RandomizeIntensity.z, RandomizeIntensity.z));
        Destroy(gameObject, destroyTime);


    }
}
