using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class EnemyEncounter : MonoBehaviour
{
    [SerializeField] int enemyEncounterNumber; //this is the current number chosen
    [SerializeField] int maxNumber = 50; //this is the max number the randomizer can get to
    [Tooltip("Lists need to be sorted from lowest to highest spawn rate")]
    public List<EnemyController> enemies;
    [Range(1, 10)] [SerializeField] float timeBetweenRandomNumberCalls = 2f;// all are serialized for testing purposes
    float timeholder;
    PlayerController pCont;
    BattleController battle;

    //For ui
    public GameObject battleCanvas;

    void Start()
    {
        timeholder = timeBetweenRandomNumberCalls;
        pCont = GetComponent<PlayerController>();
        battle = FindObjectOfType<BattleController>();
    }

    void Update()
    {
        encounterChance();
    }

    void encounterChance()
    {
        while (pCont.walking && Time.time >= timeholder)
        {

            enemyEncounterNumber = Random.Range(1, maxNumber + 1); //max number is exclusive so adding one makes the true max set to whatever maxNumber is
            print("Number called");
            
            foreach (EnemyController enemy in enemies)
            {
                if (enemyEncounterNumber < enemy.spawnRate)
                {
                    Debug.Log(enemyEncounterNumber);
                    Debug.Log(enemy.name);
                    //Add enemy to battle controller and start battle here
                    battle.battle = false;
                    pCont.walking = false;
                    //Determine if more than one enemy spawns
                    if (Random.value <= enemy.buddySpawnRate)
                    {
                        for (int i = 0; i < enemy.buddySpawnNumber; i++)
                        {
                            EnemyController enem = Instantiate(enemy, pCont.enemySpawnPoints[i].transform).GetComponent<EnemyController>();
                            battle.enemies.Add(enem);
                            //enem.transform.SetParent(null);
                        }
                        battleCanvas.SetActive(true);
                        break;
                    }
                    //Only one enemy spawns
                    else
                    {
                        EnemyController enem = Instantiate(enemy, pCont.enemySpawnPoints[0].transform).GetComponent<EnemyController>();
                        battle.enemies.Add(enem);
                        //enem.transform.SetParent(null);
                        battleCanvas.SetActive(true);
                        break;
                    }
                }
            }
            enemyEncounterNumber = 10000;
            timeholder = Time.time + timeBetweenRandomNumberCalls;
        }
    }
}
