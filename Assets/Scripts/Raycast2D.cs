using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast2D : MonoBehaviour
{
  private GameObject tank;

  private void Start()
  {
    tank = GameObject.Find("Tank Raycast");
  }

  private void FixedUpdate()
  {
    CheckWall(tank);
  }

  private void CheckWall(GameObject tank)
  {
    float laserLength = 0.1f;
    RaycastHit2D hit = Physics2D.Raycast(tank.transform.position, tank.transform.up, laserLength);

    if (hit.collider != null)
    {
      Debug.Log("Hitting: " + hit.collider.tag);
    }

    Debug.DrawRay(tank.transform.position, tank.transform.up * laserLength, Color.red);
  }
}
