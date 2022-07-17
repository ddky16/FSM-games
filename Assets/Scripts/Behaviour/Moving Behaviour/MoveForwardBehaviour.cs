using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardBehaviour : MonoBehaviour
{
  GameObject tank;

  // Start is called before the first frame update
  void Start()
  {
    tank = GameObject.Find("Tank");
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    MoveUp();
  }

  void MoveUp()
  {
    tank.GetComponent<Rigidbody2D>().velocity = transform.up * tank.GetComponent<TankBehaviour>().speedMovement;
  }
}
