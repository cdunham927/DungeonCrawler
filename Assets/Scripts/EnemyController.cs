using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class EnemyController : MonoBehaviour
{
    [Header("Main stats")]
    [SerializeField] public float hp;
    [SerializeField] protected float maxHP;
    [SerializeField] protected float atk;
    [SerializeField] protected float def;
    [SerializeField] protected float evade; 
    [SerializeField] protected float xp;
    [Space]
    [Header("Stats for spawn rate")]
    public float spawnRate;
    [Range(0, 1)]
    public float buddySpawnRate;
    [Range(2, 3)]
    public int buddySpawnNumber;
    [Space]
    [Header("For attacking")]
    [Tooltip("Number from 0-1 that determines how often the enemy uses a special attack")]
    public float specialAttackChance;
    [SerializeField] public bool canSpecialAttack = true;

    //For Enemy inventory
    GameObject enemyCanvas;
    EnemyInventory enemyInventory;

    //For enemy UI
    public Image health_bar;
    public Text health;

    //Controllers for taking damage
    BattleController bCon;
    PlayerController pCon;

    private void Awake()
    {
        bCon = FindObjectOfType<BattleController>();
        pCon = FindObjectOfType<PlayerController>();
        enemyCanvas = GameObject.Find("EnemyCanvas");
        enemyInventory = GetComponent<EnemyInventory>();

        health_bar = GetComponentInChildren<Image>();
        health = health_bar.GetComponentInChildren<Text>();
    }

    public virtual void MainAttack() { }
    public virtual void SpecialAttack() { }
    public virtual void TakeDamage(float dmg) { }

    public void ChooseAttack()
    {
        if (Random.value < specialAttackChance && canSpecialAttack)
        {
            SpecialAttack();
        }
        else
        {
            MainAttack();
        }
    }
}
