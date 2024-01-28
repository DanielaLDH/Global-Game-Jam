using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [SerializeField]
    GameObject inGameMenu, characterSheet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region SceneManagement
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void InGameMenu()
    {
        inGameMenu.gameObject.SetActive(true);
    }

    public void CloseInGameMenu()
    {
        inGameMenu.gameObject.SetActive(false);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Battle()
    {
        SceneManager.LoadScene(2);
    }

    public void CharacterSheet()
    {
        characterSheet.gameObject.SetActive(true);
    }
    public void CloseCharacterSheet()
    {
        characterSheet.gameObject.SetActive(false);
    }

    #endregion
}
