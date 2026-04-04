using UnityEngine;
[CreateAssetMenu(menuName = "Rules/Rule")]
public abstract class RuleConfig : ScriptableObject, IRule
{
  public int indexRule;
  public string description;
  public string title;
  public Sprite icon;

  public abstract void Apply(Enemy enemy);

}