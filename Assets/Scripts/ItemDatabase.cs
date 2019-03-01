using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    private void Awake()
    {
        BuildDatabase();
    }

    public Item GetItem(int id)
    {
        return items.Find(item => item.id == id);
    }

    public Item GetItem(string name)
    {
        return items.Find(item => item.name == name);
    }

    void BuildDatabase()
    {
        items = new List<Item>()
        {
            new Item(0, "Sword", "Stab things. Handle with care.",
            new Dictionary<string, int>
            {
                { "Atk", 3 },
                { "Def", 0 },
                { "Stam", 2 },
                { "Rare", 1 },
                { "Cost", 10 }
            }),
            
            new Item(1, "Shield", "Block attacks. Not good for much else.",
            new Dictionary<string, int>
            {
                { "Def", 2 },
                { "Stam", 1 },
                { "Rare", 1 },
                { "Cost", 8 }
            }),
            
            new Item(2, "Potion", "Low on health? This should help a smidge.",
            new Dictionary<string, int>
            {
                { "Healing", 5 },
                { "Rare", 1 },
                { "Cost", 5 }
            })
        };
    }

    public void AddToDatabase(Item item)
    {
        items.Add(item);
    }
}
