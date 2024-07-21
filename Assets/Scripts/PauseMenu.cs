using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI; // Reference to the options menu UI
    public GameObject mouseLookScriptObject;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (optionsMenuUI.activeSelf)
            {
                CloseOptionsMenu();
            }
            else if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
        EnableMouseLookScript();
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        DisableMouseLookScript();
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        GameIsPaused = false;
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player has Quit the game");
    }

    public void OpenOptionsMenu()
    {
        optionsMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
    }

    public void CloseOptionsMenu()
    {
        optionsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    private void EnableMouseLookScript()
    {
        MouseLook mouseLookScript = mouseLookScriptObject.GetComponent<MouseLook>();
        if (mouseLookScript != null)
        {
            mouseLookScript.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void DisableMouseLookScript()
    {
        MouseLook mouseLookScript = mouseLookScriptObject.GetComponent<MouseLook>();
        if (mouseLookScript != null)
        {
            mouseLookScript.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
