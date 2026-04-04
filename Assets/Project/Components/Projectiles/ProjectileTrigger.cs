using UnityEngine;

public class ProjectileTrigger : MonoBehaviour
{
  private Projectile projectile;
  void Start()
  {
    projectile = GetComponent<Projectile>();
  }

  public void OnTriggerEnter(Collider other)
  {

    bool target = other.tag == "Enemy";
    if (!target) return;
    Debug.Log(other.GetComponent<IDamageable>());
    projectile.attack.ReleaseAttack(other.GetComponent<IDamageable>());
    Destroy(transform.gameObject);

  }
}

