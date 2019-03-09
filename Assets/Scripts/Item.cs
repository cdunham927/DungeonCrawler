using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public int id;
    public string name;
    public string description;
    public Sprite icon;
    public Dictionary<string, int> stats = new Dictionary<string, int>();

    public enum Actions { attack, heal };
    public Actions itemAction = Actions.attack;

    public Item(int id, string name, string description, Dictionary<string, int> stats)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.icon = Resources.Load<Sprite>("ItemSprites/" + name);
        this.stats = stats;
    }

    public Item(Item item)
    {
        this.id = item.id;
        this.name = item.name;
        this.description = item.description;
        this.icon = Resources.Load<Sprite>("ItemSprites/" + item.name);
        this.stats = item.stats;
    }

    public void Use()
    {
        switch(itemAction)
        {
            case Actions.attack:
                AttackItem();
                break;
            case Actions.heal:
                HealItem();
                break;
        }
    }

    void AttackItem()
    {

    }

    void HealItem()
    {

    }
}
