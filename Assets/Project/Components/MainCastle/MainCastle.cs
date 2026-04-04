using UnityEngine;

public class MainCastle : MonoBehaviour
{

  public CastleConfig castleConfig;
  public MainCastleHealth health;
  private Attack attack;
  private CastleAttackController castleAttackController;

  void Start()
  {
    Init();
  }

  public void Init()
  {
    health.Init(castleConfig.Health);
    attack = GetComponent<Attack>();
    attack.SetDamage(castleConfig.attackConfig);
    castleAttackController = GetComponent<CastleAttackController>();
    castleAttackController.SetConfigData(castleConfig.attackConfig);
  }

}