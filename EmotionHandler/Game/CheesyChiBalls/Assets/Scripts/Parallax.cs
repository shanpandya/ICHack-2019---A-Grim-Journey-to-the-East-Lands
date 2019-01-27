using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

    public float scrollSpeed;
    bool isMoving = false;
    //public string emotion;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //emotion = GameObject.FindGameObjectWithTag("player").GetComponent<Player>().emotion;
        string emotion = System.IO.File.ReadAllText("C:\\Users\\Osann\\OneDrive\\Documents\\unity\\AGrimJourneyToTheEastLands\\AGrimJourneyToTheEastLands\\EmotionHandler\\Game\\CheesyChiBalls\\Assets\\Resources\\Filed.txt");
        Debug.Log(emotion);
        if (emotion == "Happiness")
        {
            isMoving = true;
        
        }

        if (isMoving)
        {
            transform.Translate(scrollSpeed * Vector2.left * Time.deltaTime);
        }

    }
}
