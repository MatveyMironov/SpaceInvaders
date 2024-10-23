using UnityEngine;

public class WinAndLossMenu : MonoBehaviour
{
    [SerializeField] private EnemyCoordination enemyCoordination;
    [SerializeField] private Health playerHealth;

    [Header("UI")]
    [SerializeField] private GameObject winAndLossPanel;
    [SerializeField] private GameObject winWindow;
    [SerializeField] private GameObject lossWindow;

    [Space]
    [SerializeField] private GamePause gamePause;

    private void Start()
    {
        winAndLossPanel.SetActive(false);
        winWindow.SetActive(false);
        lossWindow.SetActive(false);
    }

    private void OnEnable()
    {
        enemyCoordination.OnLowerBorderReached += Loss;
        playerHealth.OnHealthExpired += Loss;
    }

    private void OnDisable()
    {
        enemyCoordination.OnLowerBorderReached -= Loss;
        playerHealth.OnHealthExpired -= Loss;
    }

    private void Loss()
    {
        gamePause.PauseGame();
        winAndLossPanel.SetActive(true);
        lossWindow.SetActive(true);
    }
}
