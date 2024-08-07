using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{

    public static Scene_Manager Instance;

    public void LoadNextScene(int ID)
    {
        
        SceneManager.LoadSceneAsync(ID);
    }




    public void ExitGame()
    {

        Application.Quit();

    }
}