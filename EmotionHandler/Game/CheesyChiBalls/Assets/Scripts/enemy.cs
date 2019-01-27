using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour


{
    public int level;
    public float enemySpeed;



    // Start is called before the first frame update
    void Start()
    {

        if (enemySpeed == 0)
        {
            enemySpeed = 2.4f;
        }
        //bool isFirstLoop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "happyEnemy")
        {
            transform.position = new Vector2(transform.position.x + enemySpeed * -1 * Time.deltaTime, 4 * Mathf.Sin(transform.position.x + enemySpeed * -1 * Time.deltaTime));
        }
        else if (gameObject.tag == "sadEnemy")
        {
            transform.position = new Vector2(transform.position.x + enemySpeed * -1 * Time.deltaTime, 12 * Mathf.Cos(Mathf.Cos(transform.position.x + enemySpeed * -1 * Time.deltaTime)) - 10);
        }
        else if (gameObject.tag == "neutralEnemy")
        {
            transform.Translate(enemySpeed * Vector2.left * Time.deltaTime);
        }
        else if (gameObject.tag == "angerEnemy")
        {
            transform.Translate(enemySpeed * 2 * Vector2.left * Time.deltaTime);
        }

    }

}

