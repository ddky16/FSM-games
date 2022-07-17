using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EventManager : MonoBehaviour
{
  public bool enemyOnRange = false;
  public bool getHit = false;

  // ENEMY ON RANGE
  private void OnTriggerEnter2D(Collider2D other)
  {
    var collider = other.gameObject.tag;
    if (collider == "Enemy")
    {
      enemyOnRange = true;
    }
  }

  //ENEMY OFF RANGE
  private void OnTriggerExit2D(Collider2D other)
  {
    var collider = other.gameObject.tag;
    if (collider == "Enemy")
    {
      enemyOnRange = false;
    }
  }

  // GET HIT BULLET
  private void OnCollisionEnter2D(Collision2D other)
  {
    var collider = other.gameObject.tag;
    if (collider == "Bullet")
    {
      getHit = true;
    }
  }

  public bool HitWallCheck(GameObject tank)
  {
    float laserLength = 0.1f;
    RaycastHit2D hit = Physics2D.Raycast(tank.transform.position, tank.transform.up, laserLength);

    if (hit.collider != null)
    {
      if (hit.collider.tag == "Wall")
      {
        return true;
      }
    }

    Debug.DrawRay(tank.transform.position, tank.transform.up * laserLength, Color.red);
    return false;
  }

  public bool Health(TankBehaviour tank, TMP_Dropdown inputStatement)
  {
    int health = tank.GetHealth();

    if (health == inputStatement.value)
    {
      return true;
    }

    return false;
  }

  public bool Delay(float delayTime)
  {
    float currentTime = delayTime;

    currentTime -= Time.deltaTime;

    if (currentTime < 0)
    {
      return true;
    }

    return false;
  }

  public bool Shoot(int shootingCount, TMP_Dropdown inputStatement)
  {
    if (shootingCount == inputStatement.value)
    {
      return true;
    }

    return false;
  }
}
