using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool isMoving = false;
    public string emotion;
    public float playerSpeed;
    public GameObject chiball;
    public float ballFreq;
    private float chiCount = 0;
    public  int lives = 6;
    SpriteRenderer m_SpriteRenderer;
    Sprite anger, sad, happy, neutral;
    // Use this for initialization
    void Start()
    {
        anger = Resources.Load<Sprite>("Sprites/monk-anger");
        sad = Resources.Load<Sprite>("Sprites/monk-sad");
        happy = Resources.Load<Sprite>("Sprites/monk-happy");
        neutral = Resources.Load<Sprite>("Sprites/monk-neutral");
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        emotion = System.IO.File.ReadAllText("C:\\Users\\Osann\\OneDrive\\Documents\\unity\\AGrimJourneyToTheEastLands\\AGrimJourneyToTheEastLands\\EmotionHandler\\Game\\CheesyChiBalls\\Assets\\Resources\\Filed.txt");

        if (emotion == "Happiness")
        {
            isMoving = true;
        }

        if (isMoving) { 
            //GameObject.FindGameObjectWithTag("scenery").GetComponent<Parallax>().emotion = "Happiness";
            chiCount += Time.deltaTime;
            if (chiCount >= 1 / ballFreq)
            {
                chiCount = 0;
                var newChiball = Instantiate(chiball, transform.position, Quaternion.identity);
                var scr = newChiball.GetComponent<Chiball>();
                scr.typeSetter(emotion);
            }
            switch (emotion)
            {
                case "Happiness":
                    m_SpriteRenderer.sprite = happy;
                    break;
                case "Sadness":
                    m_SpriteRenderer.sprite = sad;
                    break;
                case "Neutral":
                    m_SpriteRenderer.sprite = neutral;
                    break;
                case "Anger":
                    m_SpriteRenderer.sprite = anger;
                    break;
            }
        }
    }

    public void moveUp()
    {
        transform.Translate(playerSpeed * Vector2.up * Time.deltaTime);
    }

    public void moveDown()
    {
        transform.Translate(playerSpeed * Vector2.down * Time.deltaTime);
    }

    public void moveLeft()
    {
        transform.Translate(playerSpeed * Vector2.left * Time.deltaTime);
    }

    public void moveRight()
    {
        transform.Translate(playerSpeed * Vector2.right * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if ((target.tag == "happyEnemy") 
            | (target.tag == "sadEnemy")
            | (target.tag == "neutralEnemy") 
            | (target.tag == "angerEnemy")) {
            lives--;
            Debug.Log(lives);
            Destroy(target.gameObject);
        }
    }

}