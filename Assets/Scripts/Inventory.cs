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

    private void Awake()
    {
        inventoryCanvas = GameObject.Find("InventoryCanvas");
        GameObject obj = Instantiate(uiInventoryPrefab, spawnPos);
        inventoryUI = obj.GetComponent<UIInventory>();
        inventoryUI.transform.SetParent(inventoryCanvas.transform);

        GiveItem(0);
        GiveItem("Shield");

        //RemoveItem(1);
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
        Debug.Log("Added: " + itemToAdd.name);
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
