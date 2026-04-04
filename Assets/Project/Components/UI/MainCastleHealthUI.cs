using TMPro;
using UnityEngine;

public class MainCastleHealthUI : MonoBehaviour
{
  public TMP_Text healthField;
  public MainCastleHealth health;

  void Start()
  {
    if (!health) return;
    health.OnHealthChanged += ShowNewHealth;
  }

  public void ShowNewHealth(float amountHealth)
  {
    healthField.text = amountHealth.ToString();
  }
}