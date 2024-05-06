using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    public void QuitGame() 
    {
        Application.Quit();

        //comentario para teste
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
