using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public int id;
    public string name;
    public string description;
    public Sprite icon;
    public Dictionary<string, float> stats = new Dictionary<string, float>();

    public enum Weapons { none, sword, axe, spear };
    public Weapons weaponType = Weapons.none;

    public Item(int id, string name, string description, Weapons type, Dictionary<string, float> stats)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.weaponType = type;
        this.icon = Resources.Load<Sprite>("ItemSprites/" + name);
        this.stats = stats;
    }

    public Item(Item item)
    {
        this.id = item.id;
        this.name = item.name;
        this.description = item.description;
        this.weaponType = item.weaponType;
        this.icon = Resources.Load<Sprite>("ItemSprites/" + item.name);
        this.stats = item.stats;
    }
}
