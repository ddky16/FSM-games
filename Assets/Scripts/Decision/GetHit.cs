using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHit : MonoBehaviour
{
  public bool getHit;

  // GET HIT BULLET
  private void OnCollisionEnter2D(Collision2D other)
  {
    var collider = other.gameObject.tag;
    if (collider == "Bullet")
    {
      getHit = true;
    }
  }
}
