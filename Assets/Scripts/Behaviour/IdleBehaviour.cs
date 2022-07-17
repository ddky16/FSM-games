using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehaviour : MonoBehaviour
{
  float timeCountdown = 3f;
  float currentTime = 0f;

  // Update is called once per frame
  void Update()
  {
    currentTime -= Time.deltaTime;
    if (currentTime < 0)
    {
      transform.Rotate(0, 0, 90);
      currentTime = timeCountdown;
    }
  }
}
