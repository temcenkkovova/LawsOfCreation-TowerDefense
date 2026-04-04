using System;
using UnityEngine;

public class Attack : MonoBehaviour, IDamageSource
{
  [NonSerialized] public AttackConfig attackConfig;
  public float damageModification = 0f;
  public void SetDamage(AttackConfig config)
  {
    attackConfig = config;
  }

  public void SetModifier(float damage)
  {
    damageModification = damage;
  }
  public float GetDamage()
  {
    if (!attackConfig) return 0f;
    return attackConfig.attackDamage + damageModification;
  }
  public void ReleaseAttack(IDamageable damageable)
  {


    if (damageable == null) return;

    damageable.TakeDamage(GetDamage());
  }
}