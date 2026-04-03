using System;
using UnityEngine;

public class CoinRewards : MonoBehaviour
{
  public int totalCoin;
  public event Action OnChangeRewardCoin;
  public static CoinRewards Instance;
  void Awake()
  {
    Instance = this;
  }

  void Start()
  {
    totalCoin = 500;
    OnChangeRewardCoin?.Invoke();
  }
  public void ApplyReward(int reward)
  {
    totalCoin += reward;
    OnChangeRewardCoin?.Invoke();
  }

  public void ChangeCoinAmount(int amount)
  {
    totalCoin -= amount;
    OnChangeRewardCoin?.Invoke();
  }
}