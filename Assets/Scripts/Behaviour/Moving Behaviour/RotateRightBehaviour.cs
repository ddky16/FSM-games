using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRightBehaviour : MonoBehaviour
{
  GameObject tank;

  // Start is called before the first frame update
  void Awake()
  {
    tank = GameObject.Find("Tank");
    RotateRight();
  }

  // Update is called once per frame
  void Update()
  {

  }

  void RotateRight()
  {
    transform.Rotate(new Vector3(0f, 0f, -90f));
  }
}
