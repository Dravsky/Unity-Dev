using UnityEngine;

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
    float timer = 0;

    private void Awake()
    {
        instance = this;
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
                print("WIN!!!!!!!");
                break;
            case eState.LOSE:
                print("DEADDD!");
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
}
