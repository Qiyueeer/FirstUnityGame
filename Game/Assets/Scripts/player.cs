using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;



public class player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpAmount = 1;

    bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundlayer;
    public Animator anim;
    private int points;
    private int Food;
    public TMP_Text scoreDispaly;
    public Image Bar;
    public int MaxFood=3;
    public float fillAmount;
    public AudioSource huanchanSound;


    // Start is called before the first frame update
    void Start()
    {
        Bar.fillAmount = 0f;
        rb = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Foodbar();
        scoreDispaly.text = points.ToString();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                jump();
            }
        }
        else
        {
            anim.SetBool("Jump2", false);

        }
       


    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundlayer);
    }

    void jump()
    {
        rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        anim.SetBool("Jump2", true);
        huanchanSound.Play();

    }


    // ÄÜÁ¿Ìõfunction
    void Foodbar()
    {
        

        if (Food>=MaxFood && Input.GetKeyDown(KeyCode.Q))
        {
            Bar.fillAmount = 0f;
            Food = 0;
            Debug.Log("Attack");
            anim.SetBool("huanchan", true);
            StartCoroutine(huachan());
            GameObject mon = GameObject.Find("Monster");
            mon .transform.localPosition = new Vector3(mon.transform.localPosition.x-0.5f,mon.transform.localPosition.y, mon.transform.localPosition.z);


            //here is where you add your script for the enemy action- meaning when you release the bar something happens to the wolf 

        }


        if (Food <= MaxFood) //this is not a must but can be helpful
        {
            Debug.Log("food:" + Food);

        }
        else
        {
            Debug.Log("bar is full");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Point"))
        {
            points++;
            Debug.Log("points:" + points);

        }

        if (other.CompareTag("Food"))
        {
            Food++;
            if (Food <= MaxFood)
            Bar.fillAmount += 0.33f;
        }
        if (points > 15)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
      

    }

    IEnumerator huachan()
    {
        int i = 1;
        while (i > 0)
        {
            yield return new WaitForSeconds(1f);
            i--;
        }
        anim.SetBool("huanchan", false);

    }

}