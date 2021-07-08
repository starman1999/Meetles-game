using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hole : MonoBehaviour
{
     Image fillBar;
    GameObject progressBar;
    Animator animator;
     public BoxCollider2D holecollider;
    public ParticleSystem dust;
    bool brokenBrick;
    AudioSource audiosource;
    public AudioClip breakSound;
    public AudioClip buildSound;
    public AudioClip lifeSound;
     float brickTime = 3.5f;
    Coroutine m_MyCoroutineReference;

    public static Hole Instance;
    GameObject theBar;


    public GameObject floatingText;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
        progressBar = GameObject.FindGameObjectWithTag("fillBar");
        fillBar = progressBar.transform.GetChild(1).GetComponent<Image>();
        animator = GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();


    }


    void showFloatingText(float amount, Transform ShowScoreHere)
    {
        var go = Instantiate(floatingText, ShowScoreHere.position, Quaternion.identity);
        go.GetComponent<MeshRenderer>().sortingOrder = 20;


    }
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)){

            if (gameObject.activeInHierarchy && brokenBrick == false)
            {
                Score.Instance.changeScore(1);
                fillAmount(0.01f);
                showFloatingText(10, gameObject.transform);
                dust.Play();
                audiosource.PlayOneShot(breakSound);
                holecollider.enabled = false;
                gameObject.layer = 0;
                animator.SetTrigger("break");
                brokenBrick = true;

                m_MyCoroutineReference = StartCoroutine(buildBrick());

                //gameObject.SetActive(false);
            }
            else
            {
                if( brokenBrick == true)
                {
                    StopCoroutine(m_MyCoroutineReference);
                    audiosource.PlayOneShot(buildSound);

                    holecollider.enabled = true;
                    gameObject.layer = 12;

                    animator.SetTrigger("build");
                    brokenBrick = false;
                }
                
            }

        }
        
    }
    IEnumerator buildBrick()
    {
        yield return new WaitForSeconds(brickTime);
        animator.SetTrigger("build");
        audiosource.PlayOneShot(buildSound);

        holecollider.enabled = true;
        gameObject.layer = 12;
        brokenBrick = false;
        yield return null;

    }

    public void fillAmount(float amount)
    {

        StartCoroutine(BarScale());
        fillBar.fillAmount += amount;
        if (fillBar.fillAmount == 1)
        {
            fillBar.fillAmount = 0f;
            Lives.Instance.changeLives(1);
            audiosource.PlayOneShot(lifeSound);
        }

    }

    IEnumerator BarScale()
    {
        theBar = GameObject.Find("ProgressBar");
        theBar.transform.localScale = new Vector3(0.6f, 0.9f, 0);
        yield return new WaitForSeconds(0.1f);
        theBar.transform.localScale = new Vector3(1f, 1f, 0);


    }
}
