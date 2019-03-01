using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    Text tooltipText;

    void Start()
    {
        tooltipText = GetComponentInChildren<Text>();
        gameObject.SetActive(false);
    }

    public void GenerateTooltip(Item item)
    {
        string statText = "";
        if (item.stats.Count > 0)
        {
            foreach (var stat in item.stats)
            {
                statText += stat.Key.ToString() + ":" + stat.Value + "\n";
            }
        }
        string tooltip = string.Format("<b>{0}</b>\n{1}\n\n{2}", item.name, item.description, statText);
        tooltipText.text = tooltip;
        gameObject.SetActive(true);
    }
}
