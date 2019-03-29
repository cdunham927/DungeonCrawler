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
    public Image healthBar;
    public Text healthText;

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
                    EnemyController enem = Instantiate(enemy).GetComponent<EnemyController>();
                    battle.enemies.Add(enem);
                    enemy.health_bar = healthBar;
                    enemy.health = healthText;
                    break;
                }
            }

            timeholder = Time.time + timeBetweenRandomNumberCalls;
        }
    }
}
