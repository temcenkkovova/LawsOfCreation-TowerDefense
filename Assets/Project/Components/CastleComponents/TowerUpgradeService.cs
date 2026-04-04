using UnityEngine;

public class TowerUpgradeService : MonoBehaviour
{
  public GameEconomy gameEconomy;
  public static TowerUpgradeService Instance;


  void Awake()
  {
    Instance = this;
  }


  public void TryUpgradeTower(Castle castle)
  {


    if (!castle.IsNextLevel) return;
    if (gameEconomy.TrySpend(castle.UpdateCost))
    {

      castle.ApplyLevel(castle.currentTowerLevel + 1);

    }
  }

  public bool CanUpdate(Castle castle)
  {

    return gameEconomy.IsHasMoney(castle.UpdateCost);



  }

}