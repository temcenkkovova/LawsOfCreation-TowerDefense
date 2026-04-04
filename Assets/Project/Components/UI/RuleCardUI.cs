using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RuleCardUI : MonoBehaviour, IPointerClickHandler
{
  private RuleConfig ruleConfig;
  public static event Action<RuleConfig> OnRuleChoose;
  public TMP_Text titleTextField;
  public TMP_Text descriptionTextField;
  public Image imageField;
  public void OnPointerClick(PointerEventData eventData)
  {
    OnRuleChoose?.Invoke(ruleConfig);

  }

  public void SetData(RuleConfig rule) // добавляю ruleConfig при создание карточки через код
  {
    ruleConfig = rule;
    titleTextField.text = rule.title;
    descriptionTextField.text = rule.description;
    imageField.sprite = rule.icon;
  }
}