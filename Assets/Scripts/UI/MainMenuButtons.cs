using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject LoseScreen;
    public GameObject MainMenuButton;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
      
        SceneManager.LoadSceneAsync(1);
        

    }

    public void MainMenu()
    {
        LoseScreen.SetActive(false);
        MainMenuButton.SetActive(false);
        SceneManager.LoadSceneAsync(0);
        
    }

    public void Reset()
    {
        LoseScreen.SetActive(false);
        MainMenuButton.SetActive(false);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
