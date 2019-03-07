using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float hp;
    [SerializeField] float maxHP;
    [SerializeField] float atk;
    [SerializeField] float def;
    [SerializeField] float speed; //Player Speed Stat
    public Image health_bar;
    public Text health;

    BattleController controller;

    public void Attack() 
    {
        if (controller.player_turn == true)
        {
            controller.enemy.TakeDamage(atk);
            controller.player_turn = false;
        }
    }  

    public float spd;
    public float jumpSpd;
    Rigidbody bod;
    public float rotSpdX;
    public float rotSpdY;

    private void Awake()
    {
        bod = GetComponent<Rigidbody>();
        controller = GameObject.Find("BattleController").GetComponent<BattleController>();
    }

    private void Update()
    {
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
    }

    private void FixedUpdate()
    {
        if (controller.battle)
        {
            Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (movement.x != 0)
            {
                //Check for enemy encounter chance

                bod.AddForce(transform.right * spd * Time.fixedDeltaTime * movement.x);
            }
            if (movement.y != 0)
            {
                //Check for enemy encounter chance

                bod.AddForce(transform.forward * spd * Time.fixedDeltaTime * movement.y);
            }

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

    }
}
