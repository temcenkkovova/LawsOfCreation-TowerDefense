
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class RuleCard : MonoBehaviour
{
  public Image iconRule;
  public TMP_Text title;
  public TMP_Text typeOfRule;
  public TMP_Text description;
  public TMP_Text secondDescription;
  public TMP_Text tipOfRule;
  private RuleManager RuleManager;
  private RuleConfig config;
  public GameObject SelectedBtn;
  public GameObject RemoveBtn;

  void Start()
  {
    RuleManager.OnSelectedRuleChanged += HideSelectedButton;
    RuleManager.OnAllRulesChanged += ShowSelectedButton;
  }
  void OnDisable()
  {
    RuleManager.OnSelectedRuleChanged -= HideSelectedButton;
    RuleManager.OnAllRulesChanged -= ShowSelectedButton;
  }
  public void Init(RuleConfig rule, RuleManager manager)
  {
    iconRule.sprite = rule.icon;
    title.text = rule.title;
    //typeOfRule.text = rule.typeOfRule;
    typeOfRule.text = "Attack";
    description.text = rule.description;
    secondDescription.text = rule.description;
    //tipOfRule.text = rule.tip;
    tipOfRule.text = "Combine with Regen to make a durable tank";
    RuleManager = manager;
    config = rule;
  }

  public void HandleCardClick()
  {
    RuleManager.SelectedRule(config);
  }
  public void HandleClickRemove()
  {
    RuleManager.RemoveSelectedRule(config);
  }

  public void HideSelectedButton()
  {
    SelectedBtn.SetActive(false);
    RemoveBtn.SetActive(true);
  }
  public void ShowSelectedButton()
  {
    SelectedBtn.SetActive(true);
    RemoveBtn.SetActive(false);
  }
}