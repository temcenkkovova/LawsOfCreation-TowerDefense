using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveController : MonoBehaviour
{

  public RuleController ruleController;
  public List<EnemyConfig> Enemies = new();
  private List<Enemy> spawnedEnemies = new();
  [NonSerialized] public List<Enemy> ActiveEnemies = new();
  private List<Vector3> enemiesPaths = new();
  public MainCastle target;
  private float spawnInterval = 2f;
  private Coroutine spawnCoroutine;
  public event Action OnAllEnemiesDefeated;
  private bool spawningFinished;
  public CoinRewards coinRewards;
  public static EnemyWaveController Instance;

  void Awake()
  {
    Instance = this;
  }
  public void Register(Enemy enemy)
  {
    Debug.Log("Added");
    ActiveEnemies.Add(enemy);
  }
  public void Unregister(Enemy enemy)
  {
    if (ActiveEnemies.Contains(enemy))
      ActiveEnemies.Remove(enemy);
  }
  public void SetEnemyWave(List<EnemyConfig> enemies, List<Vector3> path)
  {

    Enemies = enemies;
    enemiesPaths = new List<Vector3>(path);

  }

  public void SpawnEnemyWave()
  {

    spawnCoroutine = StartCoroutine(SpawnEnemyCoroutine());
  }
  public void StopSpawnEnemy()
  {
    if (spawnCoroutine == null) return;

    StopCoroutine(spawnCoroutine);
  }

  void OnDisable()
  {
    StopSpawnEnemy();

    //   spawnedEnemies.ForEach(item =>
    // {
    //   item.GetComponent<Health>().OnDeath -= () => HandleEnemyDeath(item);
    // });
    spawnedEnemies.Clear();



    enemiesPaths.Clear();

    Debug.Log("Was disabled");
  }
  private IEnumerator SpawnEnemyCoroutine()
  {
    yield return new WaitForSeconds(1f);
    if (Enemies == null) yield break;

    spawningFinished = false;
    foreach (var item in Enemies)
    {
      if (item == null || item.prefab == null)
      {
        Debug.LogWarning("EnemyConfig or prefab missing");
        continue;
      }
      EnemyConfig config = item;
      Enemy enemy = Instantiate(config.prefab);

      spawnedEnemies.Add(enemy);
      if (target == null) yield break;
      if (enemiesPaths[0] != null)
      {

        enemy.InitPosition(enemiesPaths[0]);
        enemy.SetData(item, new List<RuleConfig>(ruleController.currentChooseRules), target, enemiesPaths);
      }


      enemy.health.OnDeath += () => HandleEnemyDeath(enemy);

      if (spawnedEnemies.Count == Enemies.Count) spawningFinished = true;

      // new List<RuleConfig>(ruleController.currentChooseRules) именно так для того что бы обезопасить список от проблем когда я буду его очищать , удалять , добавлять 
      yield return new WaitForSeconds(spawnInterval);
    }
  }
  public void HandleEnemyDeath(Enemy enemy)
  {

    if (!enemy || !spawnedEnemies.Contains(enemy)) return;
    enemy.health.OnDeath -= () => HandleEnemyDeath(enemy);
    coinRewards.ApplyReward(enemy.enemyConfig.coinReward);
    spawnedEnemies.Remove(enemy);
    if (spawnedEnemies.Count == 0)
    {

      OnAllEnemiesDefeated?.Invoke();
    }
  }
}