using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GolemController : EnemyController
{
    BattleController controller;
    
    void Awake() 
    {
        controller = GameObject.Find("BattleController").GetComponent<BattleController>();
    }

    public override void MainAttack()
    {
        controller.player.TakeDamage(atk);
    }
    

    public override void SpecialAttack()
    {
        Debug.Log("Special Attack");
    }

    public override void TakeDamage(float dmg)
    {
        hp -= dmg;
    }

    public void DeadEnemy()
    {
        Destroy (gameObject);
    }

    private void Update()
    {
        if (hp <= 0)
        {
            DeadEnemy();
        }
    }
}
