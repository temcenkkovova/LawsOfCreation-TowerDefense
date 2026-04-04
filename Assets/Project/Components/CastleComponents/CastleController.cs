// using System;
// using System.Collections.Generic;
// using System.Linq;
// using UnityEngine;

// public class CastleController : MonoBehaviour
// {

//   [NonSerialized] public CastleAttackController castleAttack; // надо на будущее что бы при паузе останавливать атаку башен 
//   public event Action OnTarget;

//   public List<IDamageable> targets = new();
//   private Health targetHealth;
//   public IDamageable CurrentTarget => targets.FirstOrDefault();
//   public Transform targetTransform => (CurrentTarget as MonoBehaviour)?.transform;




//   void Update()
//   {

//   }


//   public void OnTriggerEnter(Collider other)
//   {

//     if (other.tag == "Enemy")
//     {

//       IDamageable damageableTarget = other.GetComponent<IDamageable>();

//       if (!targets.Contains(damageableTarget))
//       {
//         targets.Add(damageableTarget);
//         OnTarget?.Invoke();
//       }




//       targetHealth = other.GetComponent<Health>();
//       targetHealth.OnDeath += () =>
//       {

//         RemoveTarget(damageableTarget);
//         // targetHealth.OnDeath -= RemoveTarget;
//       };


//     }
//   }
//   public void RemoveTarget(IDamageable target)
//   {
//     if (targets.Contains(target))
//     {

//       targets.Remove(target);
//       OnTarget?.Invoke();
//     }
//   }

//   public void OnTriggerExit(Collider other)
//   {
//     if (other.tag == "Enemy")
//     {
//       IDamageable damageableTarget = other.GetComponent<IDamageable>();
//       RemoveTarget(damageableTarget);
//     }
//   }
// }