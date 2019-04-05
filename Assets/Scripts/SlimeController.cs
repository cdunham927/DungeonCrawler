using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeController : EnemyController
{
    BattleController controller;
    PlayerController pCon;

    void Awake()
    {
        controller = GameObject.Find("BattleController").GetComponent<BattleController>();
        pCon = FindObjectOfType<PlayerController>();

        health_bar = GetComponentInChildren<Image>();
        health = health_bar.GetComponentInChildren<Text>();
    }

    public override void MainAttack()
    {
        controller.player.TakeDamage(atk);
    }

    public override void SpecialAttack()
    {
        //The slimes special attack splits it into 3 slimes, 
        //dividing its health among them
        if (hp >= 3 && controller.enemies.Count < 3)
        {
            float splitHp = Mathf.RoundToInt(hp / 3);
            hp = splitHp;
            EnemyController oSlime = Instantiate(gameObject, pCon.enemySpawnPoints[1].transform).GetComponent<EnemyController>();
            oSlime.hp = splitHp;
            oSlime.canSpecialAttack = false;
            EnemyController oSlime2 = Instantiate(gameObject, pCon.enemySpawnPoints[2].transform).GetComponent<EnemyController>();
            oSlime2.hp = splitHp;
            oSlime2.canSpecialAttack = false;
        }
        else if (hp >= 2 && controller.enemies.Count < 2)
        {
            float splitHp = Mathf.RoundToInt(hp / 2);
            EnemyController oSlime = Instantiate(gameObject, pCon.enemySpawnPoints[1].transform).GetComponent<EnemyController>();
            oSlime.hp = splitHp;
            oSlime.canSpecialAttack = false;
        }
        else {
            //Slime doesn't have enough health to split
        }
        canSpecialAttack = false;
    }

    public override void TakeDamage(float dmg)
    {
        hp -= dmg;
    }

    public void DeadEnemy()
    {
        controller.RemoveEnemy(this);
        Destroy(gameObject);
    }

    private void Update()
    {
        //Health
        health_bar.fillAmount = hp / maxHP;
        health.text = "Slime HP: " + hp;
        if (hp <= 0)
        {
            DeadEnemy();
            pCon.xp += xp;
        }
    }
}
