using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool isMoving = false;
    Player player;
    GameObject[] allGameObjects;
    AudioManager audio;
    public int numLayers = 4;
    public float sceneSpeed;
    private float enemyTimeCount = 0f,
        mountainTimeCount = 0f,
        cloudTimeCount = 0f;
    private int spawnNumber = 0;
    public GameObject monsterHappy, monsterSad, monsterAnger, monsterNeutral,
        mountain,
        cloud;

    public float enemySpawnFreq,
        mountainSpawnFreq,
        cloudSpawnFreq;
    public int level = 0;


    public Text countDistance;
    public float distance;

    // Use this for initialization
    void Start()
    {
        distance = 0;
        //countDistance.text = "Distance: " + (int)distance;
        player = GameObject.FindGameObjectWithTag("player").GetComponent<Player>();
        audio = GameObject.FindGameObjectWithTag("audiomanager").GetComponent<AudioManager>();

        allGameObjects = GameObject.FindObjectsOfType<GameObject>();
        if (level == 0)
        {
            level = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        string emotion = System.IO.File.ReadAllText("C:\\Users\\Osann\\OneDrive\\Documents\\unity\\AGrimJourneyToTheEastLands\\AGrimJourneyToTheEastLands\\EmotionHandler\\Game\\CheesyChiBalls\\Assets\\Resources\\Filed.txt");

        if (emotion == "Happiness")
        {
            isMoving = true;

        }

        if (isMoving)
        {
            enemyTimeCount += Time.deltaTime;

            distance += Time.deltaTime;
            //countDistance.text = "Distance: " + ((int)distance).ToString();
            if (distance > 10f && level == 1)
            {
                level += 1;
                audio.playLevelMusic(level);
            }
            else if (distance > 60f && level == 2)
            {
                level += 1;
                audio.playLevelMusic(level);
            }
            else if (distance > 90f && level == 3)
            {
                level += 1;
                audio.playLevelMusic(level);
            }
            else if (distance > 120f && level == 4)
            {
                level += 1;
                audio.playLevelMusic(level);
            }

            if (level == 1)
            {
                enemySpawnFreq = 0.4f;
                if (enemyTimeCount >= 1 / enemySpawnFreq)
                {
                    enemyTimeCount = 0;
                    spawnNumber += 1;
                    Instantiate(monsterHappy, new Vector2(10f, 4.2f * Mathf.Sin(spawnNumber * 0.2f * Mathf.PI)), Quaternion.identity);
                }

            }

            if (level == 2)
            {
                enemySpawnFreq = 0.8f;
                if (enemyTimeCount >= 1 / enemySpawnFreq)
                {
                    enemyTimeCount = 0;
                    spawnNumber += 1;
                    Instantiate(monsterSad, new Vector2(10f, 5), Quaternion.identity);
                    Instantiate(monsterHappy, new Vector2(10f, 4.2f * Mathf.Sin(spawnNumber * 0.2f * Mathf.PI)), Quaternion.identity);
                }

            }

            if (level == 3)
            {
                enemySpawnFreq = 1;
                if (enemyTimeCount >= 1 / enemySpawnFreq)
                {
                    enemyTimeCount = 0;
                    spawnNumber += 1;
                    Instantiate(monsterAnger, new Vector2(10f, Random.Range(-4f, 4f)), Quaternion.identity);
                }

            }

            if (level == 4)
            {
                enemySpawnFreq = 1.2f;
                if (enemyTimeCount >= 1 / enemySpawnFreq)
                {
                    enemyTimeCount = 0;
                    spawnNumber += 1;
                    Instantiate(monsterNeutral, new Vector2(10f, Random.Range(-4f, 4f)), Quaternion.identity);
                }

            }

            mountainTimeCount += Time.deltaTime;
            if (mountainTimeCount >= 1 / (0.1 * mountainSpawnFreq))
            {
                float mountainOffset = Random.Range(5.0f, 10f);
                mountainTimeCount = 0;
                Instantiate(mountain, new Vector2(10f + mountainOffset, -0.71f), Quaternion.identity);
            }

            cloudTimeCount += Time.deltaTime;
            if (cloudTimeCount >= 1 / (0.1 * cloudSpawnFreq))
            {
                float cloudXOffset = Random.Range(5.0f, 8.0f);
                float cloudYOffset = Random.Range(2f, 4f);
                cloudTimeCount = 0f;
                Instantiate(cloud, new Vector2(5f + cloudXOffset, cloudYOffset), Quaternion.identity);
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                player.moveUp();
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                player.moveDown();
            }

            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                player.moveLeft();
            }

            else if (Input.GetKey(KeyCode.RightArrow))
            {
                player.moveRight();
            }
        }
    }
    

}
