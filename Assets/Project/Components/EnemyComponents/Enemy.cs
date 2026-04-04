using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

  [NonSerialized] public EnemyConfig enemyConfig;
  [NonSerialized] public List<RuleConfig> ruleModification;
  [NonSerialized] public EnemyHealth health;
  [NonSerialized] public Attack damage;



  [NonSerialized] public EnemyMovement enemyMovement;
  [NonSerialized] public EnemyAnimationController animationController;

  [NonSerialized] public EnemyAttackController enemyAttackController;

  void Awake()
  {
    health = GetComponent<EnemyHealth>();
    enemyMovement = GetComponent<EnemyMovement>();
    damage = GetComponent<Attack>();
    animationController = GetComponent<EnemyAnimationController>();
    enemyAttackController = GetComponent<EnemyAttackController>();
  }

  public void SetData(EnemyConfig config, List<RuleConfig> rules, MainCastle targetData, List<Vector3> path)
  {
    if (!health || !enemyMovement || !damage)
    {
      Debug.Log("Enemy components missing");
      return;
    }
    enemyConfig = config;
    health.Init(enemyConfig.maxHealth);

    enemyMovement.OnSpeedChanged += animationController.UpdateMoveSpeed;

    animationController.Initialize(enemyConfig.speed);
    enemyMovement.SetDataMovement(enemyConfig.speed, targetData.transform, path);
    enemyAttackController.Init(targetData);


    damage.SetDamage(enemyConfig.attackConfig);
    ruleModification = rules;
    ApplyRules();
  }

  public void ApplyRules()
  {
    ruleModification.ForEach(rule => rule.Apply(this));
  }
  private void OnDestroy()
  {
    enemyMovement.OnSpeedChanged -= animationController.UpdateMoveSpeed;
  }

  public void InitPosition(Vector3 position)
  {
    transform.position = position;
  }

  void OnEnable()
  {
    EnemyWaveController.Instance.Register(this);
  }

  void OnDisable()
  {
    EnemyWaveController.Instance.Unregister(this);
  }
}