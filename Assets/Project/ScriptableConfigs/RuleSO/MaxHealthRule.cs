

using UnityEngine;
[CreateAssetMenu(menuName = "Rules/Rule MaxHealthRule")]
public class MaxHealthRule : RuleConfig
{
  public int MaxHealth;
  public Vector3 scalePrefab;

  public override void Apply(Enemy enemy)
  {
    enemy.health.Init(MaxHealth);
    enemy.transform.localScale += scalePrefab;
  }
}