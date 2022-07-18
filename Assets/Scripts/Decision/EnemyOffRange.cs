using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOffRange : MonoBehaviour
{
  // ENEMY ON RANGE
  private void OnTriggerExit2D(Collider2D other, GameObject component1, GameObject component2)
  {
    var collider = other.gameObject.tag;
    if (collider == "Enemy")
    {
      component1.SetActive(false);
      component2.SetActive(true);
    }
  }
}
