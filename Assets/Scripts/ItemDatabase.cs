using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase database;
    public List<Item> items = new List<Item>();

    private void Awake()
    {
        if (database == null)
        {
            database = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);

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
            new Item(0, "Sword", "Stab things. Handle with care.", Item.Weapons.sword,
            new Dictionary<string, float>
            {
                { "Atk", 3 },
                { "Def", 0 },
                { "Stam", 2 },
                { "Rare", 1 },
                { "Cost", 10 }
            }),
            
            new Item(1, "Shield", "Block attacks. Not good for much else.", Item.Weapons.none,
            new Dictionary<string, float>
            {
                { "Def", 2 },
                { "Stam", 1 },
                { "Rare", 2 },
                { "Cost", 8 }
            }),
            
            new Item(2, "Potion", "Low on health? This should help a smidge.", Item.Weapons.none,
            new Dictionary<string, float>
            {
                { "Healing", 5 },
                { "Rare", 1 },
                { "Cost", 5 }
            }),

            new Item(3, "Buckler", "Weaker shield.", Item.Weapons.none,
            new Dictionary<string, float>
            {
                { "Def", 1 },
                { "Stam", 1 },
                { "Rare", 1 },
                { "Cost", 5 }
            }),

            new Item(4, "Axe", "Very sharp. Dangerous in the right hands.", Item.Weapons.axe,
            new Dictionary<string, float>
            {
                { "Def", 1 },
                { "Stam", 1 },
                { "Rare", 1 },
                { "Cost", 5 }
            }),

            new Item(5, "Spear", "Long, easy to thrust. Stick with the pointy end.", Item.Weapons.spear,
            new Dictionary<string, float>
            {
                { "Def", 1 },
                { "Stam", 1 },
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
