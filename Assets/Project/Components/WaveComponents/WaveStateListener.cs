using UnityEngine;

public class WaveStateListener : MonoBehaviour
{
  private WaveController waveController;

  private EnemyWaveController enemyWaveController;
  private GameState currentGameState;
  private WaveController.WaveState currentWaveState;

  void Awake()
  {
    waveController = GetComponent<WaveController>();
    enemyWaveController = GetComponent<EnemyWaveController>();

  }

  private void Start()
  {
    // GameStateController.Instance.OnGameStateChanged += OnGameStateChanged;
    waveController.OnWaveStateChanged += OnWaveStateChanged;
  }

  private void OnDisable()
  {
    // GameStateController.Instance.OnGameStateChanged -= OnGameStateChanged;
    waveController.OnWaveStateChanged -= OnWaveStateChanged;
  }

  // private void OnGameStateChanged(GameState state)
  // {
  //   currentGameState = state;
  //   // EvaluateSpawning();
  // }

  private void OnWaveStateChanged(WaveController.WaveState state)
  {
    currentWaveState = state;
    EvaluateSpawning();
  }

  private void EvaluateSpawning()
  {
    bool shouldSpawn =

        currentWaveState == WaveController.WaveState.Running;

    if (shouldSpawn)
      enemyWaveController.SpawnEnemyWave();
    else
      enemyWaveController.StopSpawnEnemy();
  }
}