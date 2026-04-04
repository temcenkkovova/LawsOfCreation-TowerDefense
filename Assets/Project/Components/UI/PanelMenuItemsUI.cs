using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PanelMenuItemsUI : MonoBehaviour
{
  public TMP_Text levelFieldText;
  public Castle castle;
  public Button updateButton;


  void OnEnable()
  {
    CoinRewards.Instance.OnChangeRewardCoin += RefreshUpdateButton;
  }

  void OnDisable()
  {
    if (castle != null)
      castle.OnLevelChanged -= OnLevelChanged;

    CoinRewards.Instance.OnChangeRewardCoin -= RefreshUpdateButton;
  }
  public void Init(Castle castleRef)
  {
    castle = castleRef;
    castle.OnLevelChanged += OnLevelChanged;

    RefreshAll();
  }
  public void HandleSellTower()
  {

    GameEconomy.Instance.TrySell(CastleSelectionController.Instance.current);
    TowerMenuUI.Instance.Close();
  }
  public void HandleUpgradeTower()
  {
    TowerUpgradeService.Instance.TryUpgradeTower(castle);
    levelFieldText.text = "Level : " + (castle.currentTowerLevel + 1);
  }

  public void RefreshUpdateButton()
  {
    if (!castle) return;
    bool canUpdate = TowerUpgradeService.Instance.CanUpdate(castle);
    Debug.Log(castle.currentTowerLevel);
    updateButton.interactable = canUpdate;

  }

  private void OnLevelChanged(int level)
  {
    RefreshAll();
  }

  private void RefreshAll()
  {
    levelFieldText.text = "Level : " + (castle.currentTowerLevel + 1);
    updateButton.interactable =
        TowerUpgradeService.Instance.CanUpdate(castle);
  }
}