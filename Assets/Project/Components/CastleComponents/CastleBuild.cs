using UnityEngine;

public class CastleBuild : MonoBehaviour
{
  public Castle TowerPrefab;

  public void BuildTower(Transform buildPos)
  {
    if (!TowerPrefab || !buildPos) return;
    Castle castle = Instantiate(TowerPrefab, buildPos.position, buildPos.rotation);
  }

}