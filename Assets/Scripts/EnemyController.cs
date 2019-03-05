using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{
    [Header("Main stats")]
    [SerializeField] float hp;
    [SerializeField] float atk;
    [SerializeField] float def;
    [SerializeField] float evade;
    [Space]
    [Header("Stats for spawn rate")]
    [SerializeField] float spawnRate;
    [SerializeField] float buddySpawnRate;

    public virtual void MainAttack() { }
    public virtual void SecondaryAttack() { }
}
