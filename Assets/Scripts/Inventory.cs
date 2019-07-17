using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> playerItems = new List<Item>();
    GameObject inventoryCanvas;
    public GameObject uiInventoryPrefab;
    public UIInventory inventoryUI;
    [SerializeField] Transform spawnPos;
    PlayerController pcon;
    SpecialAttack special;

    private void Awake()
    {
        pcon = FindObjectOfType<PlayerController>();
        special = FindObjectOfType<SpecialAttack>();

        inventoryCanvas = GameObject.Find("InventoryCanvas");
        GameObject obj = Instantiate(uiInventoryPrefab, spawnPos);
        inventoryUI = obj.GetComponent<UIInventory>();
        pcon.uiStuff = inventoryUI;
        inventoryUI.transform.SetParent(inventoryCanvas.transform);

        GiveItem(0);

        //RemoveItem(1);

        obj.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.gameObject.SetActive(!inventoryUI.gameObject.activeSelf);
        }
    }

    public void GiveItem(int id)
    {
        Item itemToAdd = ItemDatabase.database.GetItem(id);
        playerItems.Add(itemToAdd);
        inventoryUI.AddNewItem(itemToAdd);

        //If the item is in the first two slots of the inventory
        if (playerItems.Count < 3)
        {
            if (special.curWeapon == SpecialAttack.Weapons.none)
            {
                //Equip sword
                if (itemToAdd.weaponType == Item.Weapons.sword)
                {
                    special.curWeapon = SpecialAttack.Weapons.sword;
                }
                //Equip axe
                if (itemToAdd.weaponType == Item.Weapons.axe)
                {
                    special.curWeapon = SpecialAttack.Weapons.axe;
                }
                //Equip spear
                if (itemToAdd.weaponType == Item.Weapons.spear)
                {
                    special.curWeapon = SpecialAttack.Weapons.spear;
                }
            }
        }
    }

    public void GiveItem(string name)
    {
        Item itemToAdd = ItemDatabase.database.GetItem(name);
        playerItems.Add(itemToAdd);
        inventoryUI.AddNewItem(itemToAdd);
    }

    public Item CheckForItem(int id)
    {
        return playerItems.Find(item => item.id == id);
    }

    public Item CheckForItem(string id)
    {
        return playerItems.Find(item => item.name == name);
    }

    public void RemoveItem(int id)
    {
        Item itemToRemove = CheckForItem(id);
        if (itemToRemove != null)
        {
            playerItems.Remove(itemToRemove);
            inventoryUI.RemoveItem(itemToRemove);
        }
    }
}
