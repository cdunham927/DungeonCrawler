using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    public static Tooltip tool;
    Text tooltipText;

    void Awake()
    {
        if (tool == null)
        {
            tool = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);

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

    private void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 5f);
    }
}
