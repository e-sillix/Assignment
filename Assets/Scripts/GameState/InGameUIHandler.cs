using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject MovingArrowPanel, PauseButton;
    public void GameStarted()
    {
        MovingArrowPanel.SetActive(false);
        PauseButton.SetActive(true);
    }
    
}
