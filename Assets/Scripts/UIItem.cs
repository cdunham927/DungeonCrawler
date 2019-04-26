using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;
    Image spriteImage;
    GameObject inventoryCanvas;
    private UIItem selectedItem;
    PlayerController pcon;

    private void Awake()
    {
        pcon = FindObjectOfType<PlayerController>();
        inventoryCanvas = GameObject.Find("InventoryCanvas");
        selectedItem = GameObject.Find("SelectedItem").GetComponent<UIItem>();
        spriteImage = GetComponent<Image>();
        UpdateItem(null);
    }

    public void UpdateItem(Item item)
    {
        this.item = item;
        if (item != null)
        {
            spriteImage.color = Color.white;
            spriteImage.sprite = item.icon;
        }
        else
        {
            spriteImage.color = Color.clear;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (this.item != null)
        {
            if (selectedItem.item != null)
            {
                Item clone = new Item(selectedItem.item);
                selectedItem.transform.position = new Vector3(transform.position.x, transform.position.y, 5);
                selectedItem.UpdateItem(this.item);
                UpdateItem(clone);
                pcon.GetCurrentItems();
            }
            else
            {
                selectedItem.UpdateItem(this.item);
                UpdateItem(null);
                pcon.GetCurrentItems();
            }
        }
        else if (selectedItem.item != null)
        {
            UpdateItem(selectedItem.item);
            selectedItem.UpdateItem(null);
            pcon.GetCurrentItems();
        }
        {
            
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (this.item != null)
        {

            selectedItem.gameObject.transform.SetParent(null);
            selectedItem.gameObject.transform.SetParent(inventoryCanvas.transform);
            Tooltip.tool.gameObject.transform.SetParent(null);
            Tooltip.tool.gameObject.transform.SetParent(inventoryCanvas.transform);
            Tooltip.tool.GenerateTooltip(this.item);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.tool.gameObject.SetActive(false);
    }
}
