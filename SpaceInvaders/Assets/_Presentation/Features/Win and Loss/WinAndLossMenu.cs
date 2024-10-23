using UnityEngine;

public class WinAndLossMenu : MonoBehaviour
{
    [SerializeField] private EnemyCoordination enemyCoordination;
    [SerializeField] private Health playerHealth;

    [Header("UI")]
    [SerializeField] private GameObject winAndLossPanel;
    [SerializeField] private GameObject lossWindow;
    [SerializeField] private GameObject winWindow;

    [Space]
    [SerializeField] private GamePause gamePause;
    [SerializeField] private InputManager inputManager;

    private void Start()
    {
        winAndLossPanel.SetActive(false);
        winWindow.SetActive(false);
        lossWindow.SetActive(false);
    }

    private void OnEnable()
    {
        enemyCoordination.OnAllEnemiesDestroyed += Win;
        enemyCoordination.OnLowerBorderReached += Loss;
        playerHealth.OnHealthExpired += Loss;
    }

    private void OnDisable()
    {
        enemyCoordination.OnAllEnemiesDestroyed -= Win;
        enemyCoordination.OnLowerBorderReached -= Loss;
        playerHealth.OnHealthExpired -= Loss;
    }

    private void Loss()
    {
        inputManager.IsInputEnabled = false;
        gamePause.PauseGame();
        winAndLossPanel.SetActive(true);
        lossWindow.SetActive(true);
    }

    private void Win()
    {
        inputManager.IsInputEnabled = false;
        gamePause.PauseGame();
        winAndLossPanel.SetActive(true);
        winWindow.SetActive(true);
    }
}
