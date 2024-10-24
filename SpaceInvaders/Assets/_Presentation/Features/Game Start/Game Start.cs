using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private GamePause gamePause;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private EnemyCoordination enemyCoordination;
    [SerializeField] private Health playerHealth;
    [SerializeField] private Player player;
    [SerializeField] private Vector3 defaultPlayerPosition;

    void Start()
    {
        gamePause.PauseGame();
        inputManager.IsInputEnabled = false;
    }

    public void StartGame()
    {
        enemyCoordination.DestroyAllEnemies();
        player.transform.position = defaultPlayerPosition;
        playerHealth.ResetHealth();
        inputManager.IsInputEnabled = true;
        enemyCoordination.StartEnemies();
        gamePause.UnpauseGame();
    }
}
