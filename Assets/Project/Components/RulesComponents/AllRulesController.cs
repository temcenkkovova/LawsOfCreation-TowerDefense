using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllRulesController : MonoBehaviour
{
  public GameObject ruleSlotPrefab;
  public Transform gridParent;
  public List<RuleConfig> rules = new();

  void Start()
  {
    RebuildRules();
  }

  public void RebuildRules()
  {
    foreach (Transform child in gridParent)
      Destroy(child.gameObject);

    foreach (var item in rules)
    {
      GameObject slot = Instantiate(ruleSlotPrefab, gridParent);
      slot.GetComponent<RuleCardUI>().SetData(item);

    }
  }

  public void ChangeRulesList(RuleConfig rule)
  {
    if (rules.Contains(rule)) rules.Remove(rule);
    RebuildRules();
  }
  public void AddRuleToList(RuleConfig rule)
  {
    if (!rules.Contains(rule)) rules.Add(rule);
    RebuildRules();
  }
}


