using System;
using UnityEngine;

public class CastleShoot : MonoBehaviour
{
  [SerializeField] private ProjectileConfig projectileConfig;
  [SerializeField] private Transform projectileStartPoint;
  [NonSerialized] public Attack attack;

  void Start()
  {
    attack = GetComponent<Attack>();
  }
  public void Shoot(Transform target)
  {

    if (projectileConfig == null && target == null) return;

    Vector3 dir = (target.position - transform.position).normalized;
    // if (dir.sqrMagnitude > 0.001f)
    //   transform.rotation = Quaternion.LookRotation(dir);

    Projectile projectile = Instantiate(projectileConfig.prefab, projectileStartPoint.position, projectileStartPoint.rotation);

    projectile.Init(projectileConfig, target, attack);
  }
}