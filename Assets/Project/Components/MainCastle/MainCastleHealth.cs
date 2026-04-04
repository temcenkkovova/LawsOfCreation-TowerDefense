using UnityEngine;

public class MainCastleHealth : Health
{

  void Start()
  {

  }

  protected override void Die()
  {
    //base.Die();
    Debug.Log("Main Castle Died");
    GameStateController.Instance.SetState(GameState.GameOver);
  }
}