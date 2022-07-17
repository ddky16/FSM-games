using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class TankBehaviour : MonoBehaviour
{
  [HideInInspector]
  public float speedMovement = 2f;
  [HideInInspector]
  public int health = 80;

  [Header("UI Stats")]
  [SerializeField]
  private TMP_Text healthText;
  [SerializeField]
  private TMP_Text textPosX;
  [SerializeField]
  private TMP_Text textPosY;

  Rigidbody2D _rigidbody2D;

  // Start is called before the first frame update
  void Start()
  {
    _rigidbody2D = GetComponent<Rigidbody2D>();
  }

  void Update()
  {
    healthText.text = "Health : " + health.ToString();
    textPosX.text = "PosX : " + GetTankPosX().ToString();
    textPosY.text = "PosY : " + GetTankPosY().ToString();
  }

  private void FixedUpdate()
  {
    RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 5f);
    Debug.DrawRay(transform.position, hit.point, Color.red);
  }

  public int GetHealth()
  {
    return health;
  }

  int GetTankPosX()
  {
    int PosX = (int)transform.position.x;
    return PosX;
  }

  int GetTankPosY()
  {
    int PosY = (int)transform.position.y;
    return PosY;
  }
}
