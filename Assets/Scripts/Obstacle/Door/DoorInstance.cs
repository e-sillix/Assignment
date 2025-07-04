using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DoorInstance : MonoBehaviour
{
    [SerializeField] private string DoorExpression;
    [SerializeField] private TextMeshProUGUI DoorExpressionText;


    void Start()
    {
        UpdateDoorText();
    }
    void UpdateDoorText()
    {
        DoorExpressionText.text = DoorExpression;
    }

    public string ReturnDoorExpression()
    {
        return DoorExpression;
    }
}
