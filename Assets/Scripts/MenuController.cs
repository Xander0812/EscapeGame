using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    //Выбор уровней главного меню
    public void Level1()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        GameManager.Instance.LastPlayedLevel = 1;
    }
    public void Level2()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
        GameManager.Instance.LastPlayedLevel = 2;
    }
    public void Level3()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Single);
        GameManager.Instance.LastPlayedLevel = 3;
    }
    public void LastPlayedLevel()
    {
        SceneManager.LoadScene(GameManager.Instance.LastPlayedLevel, LoadSceneMode.Single);
    }
}
