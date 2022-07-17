using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class TankBehaviour : MonoBehaviour
{
  [SerializeField]
  private float speedMovement = 0f;
  [SerializeField]
  private float speedRotation = 0f;
  [SerializeField]
  private int health = 0;
  [SerializeField]
  private int bulletDamage = 0;
  [SerializeField]
  private float bulletSpeed = 0f;
  [SerializeField]
  private GameObject bulletPrefab;

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
    StartCoroutine(SequenceState());
  }

  void Update()
  {
    healthText.text = "Health : " + health.ToString();
    textPosX.text = "PosX : " + GetTankPosX().ToString();
    textPosY.text = "PosY : " + GetTankPosY().ToString();
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    // MoveForward(2f);
  }

  IEnumerator SequenceState()
  {
    while (true)
    {
      StartCoroutine(MoveUp(2f));
      yield return new WaitForSeconds(3f);
      RotateLeft();
      yield return new WaitForSeconds(1f);
      StartCoroutine(MoveUp(3f));
      yield return new WaitForSeconds(4f);
      RotateLeft();
      yield return new WaitForSeconds(1f);
      StartCoroutine(MoveUp(2f));
      yield return new WaitForSeconds(3f);
      RotateLeft();
      yield return new WaitForSeconds(1f);
      StartCoroutine(MoveUp(3f));
      yield return new WaitForSeconds(4f);
    }
  }

  #region MOVING UP
  IEnumerator MoveUp(float timeToMove)
  {
    _rigidbody2D.velocity = transform.up * speedMovement;
    yield return new WaitForSeconds(timeToMove);
    _rigidbody2D.velocity = Vector3.zero;
  }
  #endregion

  #region MOVING DOWN
  IEnumerator MoveDown(float timeToMove)
  {
    _rigidbody2D.velocity = -transform.up * speedMovement * Time.deltaTime;
    yield return new WaitForSeconds(timeToMove);
    _rigidbody2D.velocity = Vector3.zero;
  }
  #endregion

  #region ROTATING GAME OBJECT
  void RotateLeft()
  {
    transform.Rotate(new Vector3(0f, 0f, 90f));
  }

  void RotateRight()
  {
    transform.Rotate(new Vector3(0f, 0f, -90f));
  }
  #endregion

  void BarrelShoot()
  {
    Instantiate(bulletPrefab, transform.position, Quaternion.identity);
  }

  #region GETTING GAME OBJECT POSITION
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

  void OnCollisionEnter2D(Collision2D other)
  {
    Debug.Log(other.gameObject.name);
  }
  #endregion
}
