using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject PauseMenu;
    public GameObject Settings;
    public bool Paused;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Paused == false && Input.GetKeyDown(KeyCode.P))
        {

           
            Paused = true;
            PauseGame();

        }


    }

    public void ResumeGame()
    {

        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
        Paused = false;

    }

    public void InGameQuit()
    {
        Time.timeScale = 1f;
        Paused = false;
        PauseMenu.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);

    }

    public void PauseGame()
    {

        if(Paused == true)
        {

            Time.timeScale = 0f;
            PauseMenu.SetActive(true);

        }

    }

    public void OptionsMenu()
    {

        PauseMenu.SetActive(false);
        Settings.SetActive(true);

    }

    public void BackButton()
    {

        PauseMenu.SetActive(true);
        Settings.SetActive(false);

    }

}
