using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : MonoBehaviour
{
  private int _currentWaypointIndex = 0;
  private float _speed = 2f;

  private float _waitTime = 2f;
  private float _waitCounter = 0f;
  private bool _waiting = false;

  private UIInstantiateNode _instantiateNode;

  private void Start()
  {
    _instantiateNode = FindObjectOfType<UIInstantiateNode>();
  }

  private void Update()
  {
    // if (_waiting)
    // {
    //   _waitCounter += Time.deltaTime;
    //   if (_waitCounter < _waitTime)
    //   {
    //     return;
    //   }
    //   _waiting = false;
    // }

    Vector2 point = _instantiateNode.nodes.waypointsList[_currentWaypointIndex];

    if (Vector3.Distance(transform.position, point) < 0.01f)
    {
      transform.position = point;
      // _waitCounter = 0.1f;
      // _waiting = true;

      _currentWaypointIndex++;
      if (_currentWaypointIndex == _instantiateNode.nodes.waypointsList.Count)
      {
        _currentWaypointIndex = 0;
      }
    }
    else
    {
      RotateTowards(point);
      transform.position = Vector3.MoveTowards(transform.position, point, _speed * Time.deltaTime);
    }
  }

  private void RotateTowards(Vector2 target)
  {
    Vector2 direction = (target - (Vector2)transform.position).normalized;
    var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    var offset = 90f;
    transform.rotation = Quaternion.Euler(Vector3.forward * (angle - offset));
  }
}
