using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    //Активация экранов победы и поражения
    public static GameUI Instance { get; private set; }

    [SerializeField] private GameObject loseScreen;
    [SerializeField] private GameObject winScreen;

    public void ShowLoseScreen()
    {
       loseScreen.SetActive(true);
    }

    public void ShowWinScreen()
    {
        winScreen.SetActive(true);
    }
}
