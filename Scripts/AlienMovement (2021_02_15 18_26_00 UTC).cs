using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AlienMovement : MonoBehaviour
{
    Rigidbody2D rb2D;

    float direction = 1f;
    // attribu 
    float speed = 2f;
    float speedabsorb = 2.2f;
    GameObject BH;

    Animator animator;
    SpriteRenderer sp;
     CircleCollider2D AlienCollider;
    BoxCollider2D AlienBoxCollider;
    AudioSource audioSource;

    public AudioClip flipSound;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        AlienCollider = GetComponent<CircleCollider2D>();
        AlienBoxCollider = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();

    }

    void OnCollisionEnter2D (Collision2D Other)
    {
        if(Other.transform.tag == "Ufo1" || Other.transform.tag == "Ufo2" || Other.transform.tag == "Ufo3")
        {
            gameObject.SetActive(false);
            /*if (sp.flipX == true)
            {
                sp.flipX = false;

            }*/
        }
    }

    void OnMouseOver()
    {

        if (Input.GetMouseButtonDown(0))
        {
            

            if (gameObject.activeInHierarchy )
            {
                audioSource.PlayOneShot(flipSound);
                direction = -direction;
            }
        }

    }


    void OnCollisionEnter2D(Collision2D Other)
    {
        if (Other.transform.tag == "wall")
        {
            Speed = 0f;
            /*if (sp.flipX == true)
            {
                sp.flipX = false;

            }*/
        }
    }
    Vector2 target = new Vector2(0, 0);

    public float Speed { get => speed; set => speed = value; }

    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.transform.tag == "wall")
        {
            direction = -direction;
        }

        if (Other.transform.tag == "blackHole")
        {
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 position = rb2D.position;

        Vector2 offset = new Vector3(0.1f, 0);

        RaycastHit2D hit = Physics2D.Raycast(rb2D.position - offset, -Vector2.up, 0.7f, LayerMask.GetMask("wall"));

        Debug.DrawRay(rb2D.position + offset, new Vector3(0, -0.7f, 0), Color.green);


        RaycastHit2D hitBlackHole = Physics2D.Raycast(rb2D.position, -Vector2.up, 1f, LayerMask.GetMask("blackHole"));
        RaycastHit2D hitBlackHoleLeft = Physics2D.Raycast(rb2D.position, Vector2.left, 0.35f, LayerMask.GetMask("blackHole"));
        RaycastHit2D hitBlackHoleRight = Physics2D.Raycast(rb2D.position, Vector2.right, 0.35f, LayerMask.GetMask("blackHole"));

        if (hitBlackHole.collider != null ) //|| hitBlackHoleLeft.collider != null || hitBlackHoleRight.collider != null)
        {
            BH = hitBlackHole.transform.gameObject;
            Speed = 0f;
            AlienCollider.enabled = false;
            animator.SetTrigger("absorbed");

            transform.position = Vector2.MoveTowards(transform.position, BH.transform.position, speedabsorb * Time.deltaTime);
            StartCoroutine(DisactiveAlien());

        }
        if (hitBlackHoleLeft.collider != null) //|| hitBlackHoleLeft.collider != null || hitBlackHoleRight.collider != null)
        {
            BH = hitBlackHoleLeft.transform.gameObject;
            Speed = 0f;
            AlienCollider.enabled = false;

            animator.SetTrigger("absorbed");

            transform.position = Vector2.MoveTowards(transform.position, BH.transform.position, speedabsorb * Time.deltaTime);
            StartCoroutine(DisactiveAlien());

        }
        if (hitBlackHoleRight.collider != null) //|| hitBlackHoleLeft.collider != null || hitBlackHoleRight.collider != null)
        {
           
            BH = hitBlackHoleRight.transform.gameObject;
            Speed = 0f;
            AlienCollider.enabled = false;

            animator.SetTrigger("absorbed");

            transform.position = Vector2.MoveTowards(transform.position, BH.transform.position, speedabsorb * Time.deltaTime);
            StartCoroutine(DisactiveAlien());
           

        }

        if (  (hit.collider == null ) )
        {
           
           
            Speed = 0f;

            animator.SetTrigger("falling");

        }
        else
        {
            if((hit.collider != null) )
            {
                
                animator.ResetTrigger("falling");

                Speed = 2f;
            }
        
        }

        //position.x += Time.deltaTime * speed * direction ;
        //transform.Translate(Vector2.right * speed * Time.deltaTime * direction);
        // rb2D.MovePosition(position);
        rb2D.velocity = new Vector2 (Speed*direction, 0);
        animator.SetFloat("MoveX", -direction);

       // if (position.x >= 6.8f || position.x <= -7.5f) direction = -direction; 
    }

    IEnumerator DisactiveAlien()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    } 
}
