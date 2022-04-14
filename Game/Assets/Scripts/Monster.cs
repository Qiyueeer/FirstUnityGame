using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Monster : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log(other.name);
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOver");

        }


    }

}


