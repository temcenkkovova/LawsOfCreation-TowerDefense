using System;
using TMPro;
using UnityEngine;

public class TowerSlot : MonoBehaviour
{
  public TMP_Text text;
  private TowerConfig config;
  private TowerBuildController buildController;


  public void Init(TowerConfig config, TowerBuildController controller)
  {
    this.config = config;
    buildController = controller;
    text.text = config.name + " cost " + config.cost.ToString();
  }

  public void HandleClick()
  {
    buildController.Init(config);
    buildController.HandleSlotClick();
  }

}