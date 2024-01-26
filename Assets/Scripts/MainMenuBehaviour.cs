using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehaviour : MonoBehaviour
{
    // Variables

    // The empty object containing the main menu assets
    [SerializeField] GameObject mainMenuObject;

    // The empty object containing the credits menu assets
    [SerializeField] GameObject creditsMenuObject;

    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene(1);
    }

    public void OnQuitButtonClicked()
    {
        Application.Quit();
        Debug.Log("Quit application");
    }

    public void OnCreditsButtonClicked()
    {
        mainMenuObject.SetActive(false);
        creditsMenuObject.SetActive(true);
    }

    public void OnBackButtonClicked()
    {
        mainMenuObject.SetActive(true);
        creditsMenuObject.SetActive(false);
    }
}
