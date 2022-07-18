using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTankWin : MonoBehaviour
{
  int count = 0;
  public GameObject panelWin;

  private void Update()
  {
    if (count == 4) panelWin.SetActive(true);
    Debug.Log(count);
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("checkpoint"))
    {
      count += 1;
      return;
    }
  }
}
