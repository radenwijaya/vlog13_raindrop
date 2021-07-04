using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public int intensity;
    public int interval;

    private int check_interval;

    private Raindrop master_drop;

    private Human human;
    public int head_count;
    public int max_head_count;

    // Start is called before the first frame update
    void Start()
    {
        head_count = 0;
        check_interval = 0; 

        master_drop = FindObjectOfType<Raindrop>();
        master_drop.transform.position = new Vector2(Random.Range(-10f, 10f), Random.Range(5f, 6f));
        master_drop.master = true;
        create_rain();

        human = FindObjectOfType<Human>();
    }

    void create_rain()
    {
        for (int i = 0; i < intensity; i++)
        {
            Vector2 start_position = new Vector2(Random.Range(-10f, 10f), Random.Range(5f, 6f));
            Instantiate(master_drop, start_position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        check_interval++;
        if (check_interval == interval)
        {
            create_rain();
            check_interval = 0;
        }

        if ((human.OutOfFrame()) && (head_count < max_head_count))
        {
            Human new_human = Instantiate(human, new Vector2(-11f, -3.25f), Quaternion.identity);
            human = new_human;
            head_count++;
        }
        if (master_drop.first_hit)
            human.moving = true;
    }
}
