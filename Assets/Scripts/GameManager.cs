using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Этот скрипт позволяяет сохранять уровень, на котором игрок был в последний раз.
    public static GameManager Instance { get; private set; }

    private const string LAST_PLAYED_LEVEL = "LastPlayedLevel";

    public int LastPlayedLevel
    {
        get => PlayerPrefs.GetInt(key: LAST_PLAYED_LEVEL, defaultValue: 1);
        set => PlayerPrefs.SetInt(LAST_PLAYED_LEVEL, value);
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
