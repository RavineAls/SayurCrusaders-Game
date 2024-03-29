using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    void Start() {
        Cursor.lockState = CursorLockMode.None;
    }

    public void GotoMainScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GotoGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GotoHelp()
    {
        SceneManager.LoadScene("HelpMenu");
    }
    public void GotoWeapon()
    {
        SceneManager.LoadScene("WeaponMenu");
    }
    public void CloseApp()
    {
        Application.Quit();
    }
}