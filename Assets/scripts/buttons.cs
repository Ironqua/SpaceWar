using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void quýt()
    {
        Application.Quit();
}

  


    public void starting()
    {
        SceneManager.LoadScene("GAME");

    }
}
