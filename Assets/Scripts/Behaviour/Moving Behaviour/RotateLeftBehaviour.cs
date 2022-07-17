using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLeftBehaviour : MonoBehaviour
{
  GameObject tank;

  // Start is called before the first frame update
  void Awake()
  {
    tank = GameObject.Find("Tank");
    RotateLeft();
  }

  // Update is called once per frame
  void Update()
  {

  }

  void RotateLeft()
  {
    tank.transform.Rotate(new Vector3(0f, 0f, 90f));
  }
}
