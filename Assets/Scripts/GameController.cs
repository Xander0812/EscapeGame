using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //Все основные фунции хранятся в этом скрипте.
    //Он отвечает за спаун игрока, смену уровней и действия после победы и поражения.

    [SerializeField] private Vector3 playerSpawnPosition;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject player;

    public static GameController Instance { get; private set; }
    public GameUI GameUI { get; private set; }

    private void Awake()
    {
        Instance = this;
        GameUI = GetComponent<GameUI>();
    }
    private void Start()
    {
        StartCoroutine(SpawnPlayer(1f));
    }

    IEnumerator SpawnPlayer(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        Instantiate(playerPrefab, playerSpawnPosition, Quaternion.identity);
    }
    public IEnumerator GameOverSequenceCorutine(bool win)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().playerSpeed = 0;

        if (win)
        {
            yield return new WaitForSecondsRealtime(0.2f);
            GameUI.ShowWinScreen();
        }
        else
        {
            GameUI.ShowLoseScreen();
        }
    }

    public void StartGameOverSequence(bool win)
    {
        StartCoroutine("GameOverSequenceCorutine", win);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
    public void NextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex <= 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
            GameManager.Instance.LastPlayedLevel = SceneManager.GetActiveScene().buildIndex + 1;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2, LoadSceneMode.Single);
            GameManager.Instance.LastPlayedLevel = SceneManager.GetActiveScene().buildIndex - 2;
        }
    }
}
