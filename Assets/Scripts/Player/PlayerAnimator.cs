using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private float actionInterval = 1f;
    private float actionTimer=0f;
    private bool ActionTriggered = false, ActionCanBeTriggered = true;

    public void TriggerRunning()
    {
        // Debug.Log("1");
        playerAnimator.SetBool("IsRunning", true);
    }
    public void TriggerTackling()
    {
        // Debug.Log("2");
        playerAnimator.SetTrigger("IsTackle");
    }
    public void TriggerCollapsing()
    {
        // Debug.Log("3");
        playerAnimator.SetBool("IsCollapse", true);
    }
    public void TriggerWinnning()
    {
        // Debug.Log("4");
        playerAnimator.SetBool("IsWinning", true);
    }
    public void TriggerJump()
    {
        if (ActionCanBeTriggered)
        {
            ActionTriggered = true;
            playerAnimator.SetTrigger("IsSliding");
            ActionCanBeTriggered = false;
        }
    }
    public void TriggerSlide()
    {
        if (ActionCanBeTriggered)
        {
            ActionTriggered = true;
            playerAnimator.SetTrigger("Jump");
            ActionCanBeTriggered = false;
        }
    }
    void Update()
    {
        if (ActionTriggered)
        {
            actionTimer += Time.deltaTime;
            if (actionTimer >= actionInterval)
            {
                actionTimer = 0f;
                ActionCanBeTriggered = true;
                ActionTriggered = false;
            }
        }
    }
}
