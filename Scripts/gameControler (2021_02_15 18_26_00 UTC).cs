using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControler : MonoBehaviour
{
    float sTime = 13f;
    float SpawnTimer;
    GameObject Alien;

    bool spawnNextOne = true;

    CircleCollider2D alienCollider;

    // Start is called before the first frame update
    void Start()
    {
        SpawnTimer = sTime;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnTimer -= Time.deltaTime;

       
        if (SpawnTimer <=0)
        {
            SpawnTimer = sTime;
            if (spawnNextOne == true)
            {
                sTime = sTime - 0.6f;

            }
            spawnNextOne = !spawnNextOne;
            if (sTime < 3.5f)
            {
                sTime = 3.5f;
            }
            Alien = ObjectPooler.Instance.GetAlien();
            if (Alien != null)
            {
                SpriteRenderer sp;
                sp = Alien.GetComponent<SpriteRenderer>();
                sp.flipX = false;

                alienCollider = Alien.GetComponent<CircleCollider2D>();
                alienCollider.enabled = true;
                Reset(Alien);

            }
        }
      
    }

    void Reset( GameObject go)
    {
        

        go.transform.localScale = new Vector3(0.25f, 0.25f, 0f); ;

        Alien.transform.position = gameObject.transform.position;
        go.SetActive(true);
        
  

    }

   
}
