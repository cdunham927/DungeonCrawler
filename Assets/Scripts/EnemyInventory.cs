using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInventory : MonoBehaviour
{
    public List<Item> enemyItems = new List<Item>();
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

        //GiveItem(0);
    }

    public void GiveItem(int id)
    {
        Item itemToAdd = ItemDatabase.database.GetItem(id);
        enemyItems.Add(itemToAdd);
        inventoryUI.AddNewItem(itemToAdd);
        Debug.Log("Added: " + itemToAdd.name);
    }

    public void GiveItem(string name)
    {
        Item itemToAdd = ItemDatabase.database.GetItem(name);
        enemyItems.Add(itemToAdd);
        inventoryUI.AddNewItem(itemToAdd);
    }

    public Item CheckForItem(int id)
    {
        return enemyItems.Find(item => item.id == id);
    }

    public Item CheckForItem(string id)
    {
        return enemyItems.Find(item => item.name == name);
    }

    public void RemoveItem(int id)
    {
        Item itemToRemove = CheckForItem(id);
        if (itemToRemove != null)
        {
            enemyItems.Remove(itemToRemove);
            inventoryUI.RemoveItem(itemToRemove);
        }
    }
}
