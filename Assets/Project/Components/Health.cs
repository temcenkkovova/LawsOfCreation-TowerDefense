using System;
using Unity.Collections;
using UnityEngine;

public abstract class Health : MonoBehaviour, IDamageable
{
  //[SerializeField] private float maxHealth;
  public float currentHealth;

  public float CurrentHealth => currentHealth;

  public event Action<float> OnHealthChanged;
  public event Action OnDeath;

  public void Init(float amount)
  {

    currentHealth = amount;
    OnHealthChanged?.Invoke(currentHealth);

  }
  public void TakeDamage(float amount)
  {

    Debug.Log("Amount damage" + amount);
    if (currentHealth <= amount)
    {

      currentHealth = 0f;
      OnHealthChanged?.Invoke(currentHealth);
      Die();
    }
    else
    {
      currentHealth -= amount;
      OnHealthChanged?.Invoke(currentHealth);
    }

  }
  protected virtual void Die()
  {
    Debug.Log("tt");
    OnDeath?.Invoke();
  }
}