using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raindrop : MonoBehaviour
{
    public bool master;
    public Rigidbody2D rb;

    public float gust;

    public bool first_hit;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        master = false;
        first_hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(gust, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") 
            if (master)
            {
                transform.position = new Vector2(Random.Range(-10f, 10f), Random.Range(5f, 6f));
                first_hit = true;
            }
            else
            {
                Destroy(gameObject);
            }
        if (collision.gameObject.tag == "Player")
            if (master)
            {
                transform.position = new Vector2(Random.Range(-10f, 10f), Random.Range(5f, 6f));
            }
            else
            {
                Destroy(gameObject);
            }
    }
}
