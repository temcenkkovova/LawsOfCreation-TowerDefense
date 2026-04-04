using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Управляет только активными правилами */
public class RuleController : MonoBehaviour
{

  [NonSerialized] public List<RuleConfig> currentChooseRules = new();
  public GameObject ruleSlotPrefab;
  public Transform gridParent;

  public void SetRule(RuleConfig rule)
  {
    if (currentChooseRules.Contains(rule)) return;
    currentChooseRules.Add(rule);
    RebuildSelectedRules();

  }
  public void RemoveCurrentRules()
  {
    currentChooseRules.Clear();
  }
  public void RebuildSelectedRules()
  {
    foreach (Transform child in gridParent)
      Destroy(child.gameObject);


    foreach (var item in currentChooseRules)
    {
      GameObject slot = Instantiate(ruleSlotPrefab, gridParent);
      slot.GetComponent<RuleCardUI>().SetData(item);

    }
  }
}