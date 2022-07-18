using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
  TankBehaviour tank;

  private void Start()
  {
    tank = GameObject.FindObjectOfType<TankBehaviour>();
  }

  public void HealthCheck(float value, GameObject component1, GameObject component2)
  {
    int health = tank.GetHealth();

    if (health == value)
    {
      component1.SetActive(false);
      component2.SetActive(true);
    }
  }
}
