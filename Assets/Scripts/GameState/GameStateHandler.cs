using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateHandler : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel, GameOverPanel, GameWonPanel,ResultPanel;
    public void PauseTheGame()
    {
        // Debug.Log("Game is Paused");
        pausePanel.SetActive(true);
        ResultPanel.SetActive(false);
        Time.timeScale = 0f;
    }
    public void ResumeTheGame()
    {
        pausePanel.SetActive(false);
        ResultPanel.SetActive(true);
        Time.timeScale = 1f;
    }
    public void ResetThePause()
    {
        Time.timeScale = 1f;
    }
    public void GameOver()
    {
        GameOverPanel.SetActive(true);
    }
    public void GameWon()
    {
        GameWonPanel.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // ResetThePause();
    }
}
