using System;
using System.Collections;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CastleAttackController : MonoBehaviour
{
  private AttackConfig attackConfig;
  private CastleShoot castleShoot;
  private float radiusSqr;
  private float checkTimer;
  public float checkInterval = 0.2f;
  private Enemy currentTarget;
  private float shootTimer;
  void Awake()
  {
    castleShoot = GetComponent<CastleShoot>();
  }
  void Update()
  {
    checkTimer += Time.deltaTime;
    if (checkTimer >= checkInterval)
    {
      checkTimer = 0;
      if (currentTarget == null || (currentTarget.transform.position - transform.position).sqrMagnitude > radiusSqr)
      {
        currentTarget = FindEnemy();
      }
      if (currentTarget == null)
      {
        currentTarget = null;
      }
    }
  }

  public Enemy FindEnemy()
  {
    var enemies = EnemyWaveController.Instance.ActiveEnemies;
    Enemy target = null;
    float closestDistance = float.MaxValue;

    foreach (Enemy enemy in enemies)
    {
      float dist = (enemy.transform.position - transform.position).sqrMagnitude;
      if (dist < radiusSqr && dist < closestDistance)
      {
        closestDistance = dist;
        target = enemy;
      }
    }
    return target;
  }

  void FixedUpdate()
  {
    if (currentTarget == null) return;

    shootTimer += Time.deltaTime;

    if (shootTimer >= attackConfig.attackInterval)
    {
      shootTimer = 0;
      castleShoot.Shoot(currentTarget.transform);
    }
  }
  public void SetConfigData(AttackConfig config)
  {
    attackConfig = config;
    radiusSqr = attackConfig.radiusAttack * attackConfig.radiusAttack;
  }
}