using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
   
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
}
