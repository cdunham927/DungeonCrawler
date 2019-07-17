using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleScript : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("ColeScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
