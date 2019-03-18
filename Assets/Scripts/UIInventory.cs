using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public List<UIItem> UIItems = new List<UIItem>();
    public GameObject slotPrefab;
    public Transform slotPanel;

    [Range(1, 16)]
    public int inventorySlots = 16;

    private void Awake()
    {
        for (int i = 0; i < inventorySlots; i++)
        {
            GameObject obj = Instantiate(slotPrefab);
            obj.transform.SetParent(slotPanel);
            UIItems.Add(obj.GetComponentInChildren<UIItem>());
            //if (i < 2)
            //{
                //obj.GetComponent<Image>().color = Color.blue;
            //}
        }
    }

    public Item GetSlotA()
    {
        return UIItems[0].item;
    }

    public Item GetSlotB()
    {
        return UIItems[1].item;
    }

    public void UpdateSlot(int slot, Item item)
    {
        UIItems[slot].UpdateItem(item);
    }

    public void AddNewItem(Item item)
    {
        UpdateSlot(UIItems.FindIndex(i => i.item == null), item);
    }

    public void RemoveItem(Item item)
    {
        UpdateSlot(UIItems.FindIndex(i => i.item == item), null);
    }
}
