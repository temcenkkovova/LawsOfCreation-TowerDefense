using System;
using UnityEngine;


public class Castle : MonoBehaviour, ISellable, ITowerSelectable
{
  public TowerConfig config;

  public CastleHealth health;
  public int BuyCost => config.cost;
  public int UpdateCost => config.levels[currentTowerLevel].updateCost;
  public bool IsNextLevel => currentTowerLevel + 1 < config.levels.Length ? true : false;
  private Attack attack;
  private CastleAttackController castleAttackController;
  public event Action<Castle> OnSelected;
  public event Action<int> OnLevelChanged;
  public int currentTowerLevel;
  public Transform VisualRoot;


  [NonSerialized] public BuildSpot buildSpot;

  void Start()
  {
    if (!buildSpot) return;
    buildSpot.ShowTowerSpot(false);
  }
  public void SetConfig(TowerConfig castleConfig)
  {
    config = castleConfig;
    attack = GetComponent<Attack>();
    castleAttackController = GetComponent<CastleAttackController>();
    ApplyLevel(0);
  }
  public void ApplyLevel(int indexLevel)
  {

    currentTowerLevel = indexLevel;
    GameObject visualPrefab = config.levels[currentTowerLevel].visualPrefab;


    TowerLevel levelData = config.levels[currentTowerLevel];
    health.Init(levelData.Health);
    attack.SetDamage(levelData.attackConfig);
    castleAttackController.SetConfigData(levelData.attackConfig);

    if (VisualRoot.childCount > 0)
    {
      var children = VisualRoot.GetChild(0).gameObject;
      Destroy(children);
      Instantiate(visualPrefab, VisualRoot);
    }
    else
    {
      Instantiate(visualPrefab, VisualRoot);
    }
    OnLevelChanged?.Invoke(currentTowerLevel);


  }
  public int GetSellValue()
  {
    return BuyCost;
  }
  public void OnSell()
  {
    buildSpot.spotCastle = null;
    buildSpot.ShowTowerSpot(true);
    Destroy(gameObject);

  }
  public void SetTowerSpot(BuildSpot spot)
  {
    buildSpot = spot;
  }

  public void Selected()
  {

    OnSelected?.Invoke(this);
  }

}