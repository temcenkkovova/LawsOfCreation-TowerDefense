using UnityEngine;

public class CastleRange : MonoBehaviour
{
  private Castle castle;

  void Awake()
  {
    castle = GetComponent<Castle>();
  }
}