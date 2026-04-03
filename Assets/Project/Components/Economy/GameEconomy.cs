using System;
using UnityEngine;

public class GameEconomy : MonoBehaviour
{
  public static GameEconomy Instance;
  public CoinRewards coinRewards;
  public float sellMultiplier = 0.7f;
  public TowerBuildController towerBuildController;
  public event Action OnSellTower;
  void Awake()
  {
    Instance = this;
  }
  public bool TrySpend(int price)
  {
    if (coinRewards.totalCoin >= price)
    {
      coinRewards.ChangeCoinAmount(price);
      return true;
    }
    else
    {
      return false;
    }
  }

  public int GetCoins()
  {
    return coinRewards.totalCoin;
  }

  public bool TrySell(ISellable item)
  {

    if (item == null) return false;

    int refund = Mathf.RoundToInt(item.GetSellValue() * sellMultiplier);
    coinRewards.ApplyReward(refund);
    item.OnSell();
    OnSellTower?.Invoke();
    towerBuildController.ChangeBuildedTowersAmount();
    return true;
  }

  public bool IsHasMoney(int amount)
  {
    if (coinRewards.totalCoin >= amount)
    {
      return true;
    }
    else
    {
      return false;
    }
  }
}