using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class SceneManager : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene(1);

    }

    public void QuitGame()
    {
        Debug.Log("Closing out the game!");
        Application.Quit();

    }



}
