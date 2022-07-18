using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitWall : MonoBehaviour
{
  public bool HitWallCheck(GameObject tank, GameObject component1, GameObject component2)
  {
    float laserLength = 0.1f;
    RaycastHit2D hit = Physics2D.Raycast(tank.transform.position, tank.transform.up, laserLength);

    if (hit.collider != null)
    {
      if (hit.collider.tag == "Wall")
      {
        component1.SetActive(false);
        component2.SetActive(true);
      }
    }

    Debug.DrawRay(tank.transform.position, tank.transform.up * laserLength, Color.red);
    return false;
  }
}
