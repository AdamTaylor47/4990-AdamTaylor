using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadLevels : MonoBehaviour
{
    public string levelName;
    public GameObject trigger;
    private GameObject[] enemies;
    private GameObject playerGm;
    public GameObject spawn;
    private static int count = 0;
    private static int stage = 1;


    public List<string> levels = new List<string>
                {
                    "Level_1",
                    "Level_2",
                    "Level_3",
                    "Level_4",
                };
    public List<string> levelsTwo = new List<string>
                {
                    "Level_2.1",
                    "Level_2.2",
                    "Level_2.3",
                    "Level_2.4",
                };

    public void Awake()
    {
        trigger = GameObject.FindGameObjectWithTag("Trigger");
        spawn = GameObject.FindGameObjectWithTag("Spawn");


        //playerGm = GameObject.FindGameObjectWithTag("Player");


    }
    private void OnLevelWasLoaded(int level)
    {
        if (SceneManager.GetActiveScene().name == "Lobby")
        {
            stage = 1;
            count = 0;

        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (col.tag == ("Player") && enemies.Length==0)
        {
            if (stage == 1) 
            {

                count++;

                int index = Random.Range(0, levels.Count);

                if (count == 4)
                {
                    stage++;
                    SceneManager.LoadScene("Boss_1");
                    return;
                    
                }
                else
                {
                    SceneManager.LoadScene(levels[index]);
                    return;
                }
            }
            if (stage == 2)
            {

                count++;

                int index = Random.Range(0, levelsTwo.Count);

                if (count == 8)
                {
                    stage++;
                    SceneManager.LoadScene("Boss_2");
                    return;
                }
                else
                {
                    SceneManager.LoadScene(levelsTwo[index]);
                    return;
                }
            }



        }
    }
}

