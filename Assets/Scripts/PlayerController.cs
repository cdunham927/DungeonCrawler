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
    [SerializeField] float speed; //Player Speed Stat
    public float xp;
    public Image health_bar;
    public Text health;

    //Player total attack
    public float totalAttack;

    BattleController controller;
    public UIInventory uiStuff;
    public Item slot1Item;
    public Item slot2Item;

    //Spots to spawn the enemy(in front of the player)
    public GameObject[] enemySpawnPoints;

    //Keep track of the player moving
    public bool walking = false;

    void Awake()
    {
        bod = GetComponent<Rigidbody>();
        controller = GameObject.Find("BattleController").GetComponent<BattleController>();
        uiStuff = FindObjectOfType<UIInventory>();

        totalAttack = atk;
    }

    public void UseCurrentItem1()
    {
        //slot1Item.GetComponent<Item>().Use();
    }

    public void GetCurrentItems()
    {
        if (uiStuff != null && uiStuff.gameObject.activeInHierarchy)
        {
            slot1Item = uiStuff.GetSlotA();
            slot2Item = uiStuff.GetSlotB();
            if (slot1Item != null)
            {
                Debug.Log(slot1Item.name);
            }

            if (slot2Item != null)
            {
                Debug.Log(slot2Item.name);
            }
        }
    }

    public void Attack() 
    {
        if (controller.player_turn == true)
        {
            controller.canAttack = true;
        }
    }  

    public float spd;
    public float jumpSpd;
    Rigidbody bod;
    public float rotSpdX;
    public float rotSpdY;

    private void Update()
    {
        GetCurrentItems();

        float check = Input.GetAxis("Mouse X");
        //Debug.Log("Our x is " + check);
        float translation = Input.GetAxis("Mouse Y") * rotSpdY;
        float rotation = Input.GetAxis("Mouse X") * rotSpdX;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        if (controller.battle)
        {
            transform.Rotate(0, rotation, 0);
        }
        

        if (Cursor.lockState == CursorLockMode.None) Cursor.lockState = CursorLockMode.Confined;
        
        //Health
        health_bar.fillAmount = hp / maxHP;
        health.text = "Player HP: " + hp;

        if (hp <= 0) GameOver();
    }

    private void FixedUpdate()
    {
        if (controller.battle)
        {
            Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (movement.x != 0)
            {
                //Check for enemy encounter chance
                walking = true;
                bod.AddForce(transform.right * spd * Time.fixedDeltaTime * movement.x);
            }


            //Only jump when you're on the ground
            if (movement.y != 0)
            {
                //Check for enemy encounter chance
                walking = true;
                bod.AddForce(transform.forward * spd * Time.fixedDeltaTime * movement.y);
            }

            if (movement.x == 0 && movement.y == 0) walking = false;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                bod.AddForce(transform.up * jumpSpd);
            }
        }
        
    }
    public void TakeDamage(float dmg)
    {
        hp -= dmg;
    }
    public void GameOver()
    {
        SceneManager.LoadScene("JesseScene");
    }
}
