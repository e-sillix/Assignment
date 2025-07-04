using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WallInstance : MonoBehaviour
{
    [SerializeField] private int wallPower;
    [SerializeField] private TextMeshProUGUI wallPowerText;
    [SerializeField] private GameObject WallBreaking;


    void Start()
    {
        UpdateWallText();
    }
    void UpdateWallText()
    {
        wallPowerText.text = wallPower.ToString();
    }

    public int ReturnWallPower()
    {
        return wallPower;
    }

    public void WallPassed()
    {
        Instantiate(WallBreaking, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
