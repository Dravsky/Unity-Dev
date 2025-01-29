using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject winUI;
    [SerializeField] GameObject loseUI;

    enum eState
    {
        TITLE,
        GAME,
        WIN,
        LOSE
    }

    eState state = eState.TITLE;

    private void Awake()
    {
        instance = this;
        winUI.SetActive(false);
        loseUI.SetActive(false);
    }

    void Update()
    {
        switch (state)
        {
            case eState.TITLE:
                titleUI.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    OnStartGame();
                }
                break;
            case eState.GAME:
                break;
            case eState.WIN:
                winUI.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    RestartScene();
                }
                break;
            case eState.LOSE:
                loseUI.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    RestartScene();
                }
                break;
            default:
                break;
        }
    }

    public void OnStartGame()
    {
        titleUI.SetActive(false);
        state = eState.GAME;
    }

    public void SetGameOver()
    { 
        state = eState.LOSE; 
    }

    public void SetGameWin()
    {
        state = eState.WIN;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
