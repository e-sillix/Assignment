using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private GameObject LevelMenuPanel, StartPanel;
    public void PlayIsClicked()
    {
        LevelMenuPanel.SetActive(true);
        StartPanel.SetActive(false);
    }
    public void BackIsClicked()
    {
        StartPanel.SetActive(true);
        LevelMenuPanel.SetActive(false);
    }
    public void QuitIsClicked()
    {
        Application.Quit();
    }
    public void LevelIsClicked()
    {
        SceneManager.LoadScene("Level1");
    }
    public void MenuIsClicked()
    {
        SceneManager.LoadScene("Starting");
    }
}
