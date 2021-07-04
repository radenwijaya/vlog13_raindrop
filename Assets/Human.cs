using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    public int run_speed;
    public Rigidbody2D rb;

    public int hit_count;
    public bool moving;

    private bool end;

    // Start is called before the first frame update
    void Start()
    {
        hit_count = 0;

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool OutOfFrame()
    {
        return (transform.position.x > 12);
    }

    void FixedUpdate()
    {
        if (OutOfFrame())
        {
            if (!end)
            {
                end = true;
                Debug.Log(hit_count);
            }
        }
        else
        if (moving) 
            rb.velocity = new Vector2(run_speed, 0);        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rain")
        {
            hit_count++;
        }
    }
}
