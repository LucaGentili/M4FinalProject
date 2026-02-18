using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Menu : MonoBehaviour
{
    public void OnLoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OnMainMenuClick()
    {
        SceneManager.LoadScene("UI_Scene");
    }

    public void OpenUI()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
