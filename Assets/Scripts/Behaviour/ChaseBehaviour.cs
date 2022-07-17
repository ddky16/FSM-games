using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBehaviour : MonoBehaviour
{
  private GameObject target;
  private float speed = 2f;
  private float minDistance = 1f;
  private float range;

  private void Start()
  {
    target = GameObject.FindWithTag("Enemy");
  }

  // Update is called once per frame
  void Update()
  {
    if (Vector3.Distance(transform.position, target.transform.position) > 1f)
    {
      ChaseEnemy();
    }
  }

  private void ChaseEnemy()
  {
    transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    RotateTowards(target.transform.position);
  }

  private void RotateTowards(Vector2 target)
  {
    Vector2 direction = (target - (Vector2)transform.position).normalized;
    var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    var offset = 90f;
    transform.rotation = Quaternion.Euler(Vector3.forward * (angle - offset));
  }
}
