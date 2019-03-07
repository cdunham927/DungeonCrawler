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

    public virtual void MainAttack() { }
    public virtual void SecondaryAttack() { }
    public virtual void TakeDamage(float dmg) { }
    
}
