using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{
    [Header("Main stats")]
    [SerializeField] protected float hp;
    [SerializeField] protected float maxHP;
    [SerializeField] protected float atk;
    [SerializeField] protected float def;
    [SerializeField] protected float evade; 
    [Space]
    [Header("Stats for spawn rate")]
    [SerializeField] float spawnRate;
    [SerializeField] float buddySpawnRate;
    [Space]
    [Header("For attacking")]
    [Tooltip("Number from 0-1 that determines how often the enemy uses a special attack")]
    public float specialAttackChance;
    [SerializeField] protected bool canSpecialAttack = true;

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
