using System;
using UnityEngine;

public class RuleManager : MonoBehaviour
{
  private RuleController ruleController;
  private AllRulesController allRulesController;

  public RuleCard prefabCard;
  public Transform gridParent;
  public event Action OnSelectedRuleChanged;
  public event Action OnAllRulesChanged;

  void Awake()
  {
    ruleController = GetComponent<RuleController>();
    allRulesController = GetComponent<AllRulesController>();
  }

  public void SelectedRule(RuleConfig rule)
  {
    if (ruleController.currentChooseRules.Contains(rule)) return;
    if (ruleController.currentChooseRules.Count >= 3)
    {
      Debug.Log("You can selected only 3 rules");
      return;
    }
    ruleController.currentChooseRules.Add(rule);
    OnSelectedRuleChanged?.Invoke();
    ruleController.RebuildSelectedRules();
    allRulesController.ChangeRulesList(rule);
  }
  public void RemoveSelectedRule(RuleConfig removeRule)
  {
    if (ruleController.currentChooseRules.Contains(removeRule))
    {
      ruleController.currentChooseRules.Remove(removeRule);
      ruleController.RebuildSelectedRules();
      allRulesController.AddRuleToList(removeRule);
      OnAllRulesChanged?.Invoke();
    }
    else
    {
      Debug.Log("Rule does not founded to remove");
    }
  }

  public void OpenSelectedRule(RuleConfig rule)
  {
    foreach (Transform child in gridParent)
      Destroy(child.gameObject);
    RuleCard card = Instantiate(prefabCard, gridParent);
    card.Init(rule, this);
    if (ruleController.currentChooseRules.Contains(rule))
      card.HideSelectedButton();
    Debug.Log("You have this rule");
  }
}