using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chiball : MonoBehaviour {
    public float chiSpeed;
    private string type;
    SpriteRenderer m_SpriteRenderer;
    Sprite anger, sad, happy, neutral;

    // Use this for initialization
    void Start () {
        anger = Resources.Load<Sprite>("Sprites/cheeseball-anger");
        sad = Resources.Load<Sprite>("Sprites/cheeseball-sad");
        happy = Resources.Load<Sprite>("Sprites/cheeseball-happy");
        neutral = Resources.Load<Sprite>("Sprites/cheeseball-neutral");
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {

        transform.Translate(chiSpeed * Vector2.right * Time.deltaTime);
        switch (type)
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

    void OnTriggerEnter2D(Collider2D target)
    {
        if (((target.tag == "happyEnemy") && (type=="Happiness"))
            | ((target.tag == "sadEnemy") && (type == "Sadness"))
            | ((target.tag == "neutralEnemy") && (type == "Neutral"))
            | ((target.tag == "angerEnemy") && (type == "Anger")))
        {
            Destroy(target.gameObject);
        }        
    }

    public void typeSetter(string emotion) {
        type = emotion;
    }
}
