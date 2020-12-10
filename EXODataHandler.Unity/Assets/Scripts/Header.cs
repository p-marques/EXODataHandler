using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Header : MonoBehaviour
{
    [SerializeField]
    private GameObject linkedDataZone;
    public GameObject LinkedDataZone { get => linkedDataZone; set => linkedDataZone = value; }

private string[] input;

    private GameObject inputField;
    private TextMeshProUGUI inputFieldText;
    private Header(GameObject linkeddatazone)
    {
        linkeddatazone = linkedDataZone;
        inputField = gameObject.transform.GetChild(3).gameObject;
        inputFieldText = gameObject.GetComponentInChildren<TextMeshProUGUI>();


    }
    public void Buttons()
    {
        for (int i = 0; i < 50; i++)
        {
            LinkedDataZone.transform.GetChild(0).SetSiblingIndex(49 - i);
        }
    }
}
