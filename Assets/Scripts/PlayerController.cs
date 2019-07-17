using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float hp;
    [SerializeField] float maxHP;
    [SerializeField] float atk;
    [SerializeField] float def;
    public int level = 1;
    public float xp;
    public Image health_bar;
    public Text health;
    public Image xpBar;
    public Text expText;
    public Text statText;
    public Text levelText;

    //Player total attack and defense
    public float totalAttack;
    public float totalDef;

    BattleController controller;
    public UIInventory uiStuff;
    public Item slot1Item;
    public Item slot2Item;

    //Spots to spawn the enemy(in front of the player)
    public GameObject[] enemySpawnPoints;

    SpecialAttack special;

    //Keep track of the player moving
    public bool walking = false;

    public LayerMask groundMask;

    void Awake()
    {
        special = GetComponent<SpecialAttack>();
        bod = GetComponent<Rigidbody>();
        controller = GameObject.Find("BattleController").GetComponent<BattleController>();

        GetCurrentItems();
        totalAttack = atk;

        GetItemAttack();
        GetItemDefense();
    }

    public void GetCurrentItems()
    {
        if (uiStuff != null)
        {
            slot1Item = uiStuff.GetSlotA();
            slot2Item = uiStuff.UIItems[1].item;
        }
    }

    public void Attack() 
    {
        if (controller.player_turn == true)
        {
            controller.canAttack = true;
        }
        
        if (slot1Item == null)
        {
            GetCurrentItems();
        }
        float defe = GetItemDefense();
        float mod = GetItemAttack();

        totalDef = defe + def;
        totalAttack = atk + mod;
    }

    float GetItemAttack()
    {
        float mod = 0;
        float mod2 = 0;
        if (slot1Item != null) slot1Item.stats.TryGetValue("Atk", out mod);
        if (slot2Item != null) slot2Item.stats.TryGetValue("Atk", out mod2);
        return mod + mod2;
    }

    float GetItemDefense()
    {
        float mod = 0;
        float mod2 = 0;
        if (slot1Item != null) slot1Item.stats.TryGetValue("Def", out mod);
        if (slot2Item != null) slot2Item.stats.TryGetValue("Def", out mod2);
        return mod + mod2;
    }

    public float spd;
    public float jumpSpd;
    Rigidbody bod;
    public float rotSpdX;
    public float rotSpdY;

    public void LevelUp ()
    {
        int r = Random.Range(0, 3);

        if (r == 0) 
        {
            maxHP += 10;
        }
        else if (r == 1) 
        {
            atk += 1;
        }
        else 
        {
            def += 1;
        }
        level++;
        xp = 0;
        hp = maxHP;
    }

    private void Update()
    {
        if (uiStuff == null)
            uiStuff = FindObjectOfType<UIInventory>();

        if (controller.battle && !controller.paused)
        {
            float check = Input.GetAxis("Mouse X");
            //Debug.Log("Our x is " + check);
            float translation = Input.GetAxis("Mouse Y") * rotSpdY;
            float rotation = Input.GetAxis("Mouse X") * rotSpdX;

            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;

            transform.Rotate(0, rotation, 0);
        }
        

        if (Cursor.lockState == CursorLockMode.None) Cursor.lockState = CursorLockMode.Confined;
        
        //Health and other UI stuff
        health_bar.fillAmount = hp / maxHP;
        xpBar.fillAmount = xp / 35f;
        health.text = "HP: " + hp + "/" + maxHP;
        expText.text = "Exp: " + xp + "/" + 35;
        statText.text = "Atk: " + totalAttack + "\t\tDef: " + totalDef;
        levelText.text = "Level " + level + " Knight";

        if (hp <= 0) GameOver();

        //Dev cheats
        if (Application.isEditor)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                hp = maxHP;
                atk = 25;
            }

            if (Input.GetKey(KeyCode.L))
            {
                xp += 1;
            }
        }

        //Level up
        if (xp >= 35)
        {
            LevelUp();
        }


        if (Input.GetMouseButtonDown(0) && controller.canAttack)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    Debug.Log(hit.collider.gameObject.name);

                    hit.collider.gameObject.GetComponent<EnemyController>().TakeDamage(totalAttack);
                    controller.canAttack = false;
                    controller.player_turn = !controller.player_turn;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (controller.battle && !controller.paused)
        {
            Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (movement.x != 0)
            {
                //Check for enemy encounter chance
                walking = true;
                bod.AddForce(transform.right * spd * Time.fixedDeltaTime * movement.x);
            }


            //Only jump when you're on the ground
            if (Physics.Raycast(transform.position, Vector3.down, groundMask) && movement.y != 0)
            {
                //Check for enemy encounter chance
                walking = true;
                bod.AddForce(transform.forward * spd * Time.fixedDeltaTime * movement.y);
            }

            if (movement.x == 0 && movement.y == 0) walking = false;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                //bod.AddForce(transform.up * jumpSpd);
            }
        }
        
    }
    public void TakeDamage(float dmg)
    {
        hp -= dmg;
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Play()
    {
        SceneManager.LoadScene("ColeScene");
    }

    public void QuitGame ()
    {
        Application.Quit();
    }

    public void sword_attack()
    {
        if (controller.player_turn)
        {
            controller.UpdateLog("You let loose on all nearby enemies!");
            foreach (EnemyController enem in controller.enemies)
            {
                totalAttack = (atk + GetItemAttack());
                enem.TakeDamage(totalAttack);
            }

            controller.player_turn = false;
        }
    }

    public void axe_hit(float multi)
    {
        if (controller.player_turn == true)
        {
            controller.canAttack = true;
        }
        controller.UpdateLog("You wind up a powerful swing!\n");
        totalAttack = Mathf.Round((atk + GetItemAttack()) * multi);
    }

    public void spear_attack()
    {
        int counter = 0;

        controller.UpdateLog("You unleash a flurry of attacks!\n");

        int attack_amount = Random.Range(2, 4);
        while (attack_amount >= counter)
        {
            totalAttack = (atk + GetItemAttack());
            EnemyController enemToAtk = controller.enemies[Random.Range(0, controller.enemies.Count)];
            enemToAtk.TakeDamage(totalAttack);
            counter++;
        }
        //counter = 0;
    }
}
