﻿//biblioteki Unity
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class menu : MonoBehaviour
{
    //ta linia kodu odpowiada za to, że gdy osoba naciśnie przycisk „Start”, przenosi go na pierwszy poziom gry
   public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    //ta linia kodu odpowiada za to, że gdy osoba naciśnie przycisk „Exit”, gra się zamyka
    public void ExitGame()
    {
        Application.Quit();
    }
}
