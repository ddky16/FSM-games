using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour
{
  UIInstantiateNode _delayNode;

  private void Start()
  {
    _delayNode = GameObject.FindObjectOfType<UIInstantiateNode>();
  }

  public void DelayCheck(float delayTime, GameObject component1, GameObject component2)
  {
    float currentTime = delayTime;

    currentTime -= Time.deltaTime;

    if (currentTime < 0)
    {
      component1.SetActive(false);
      component2.SetActive(true);
    }
  }

  private void Update()
  {
    DelayCheck(2, _delayNode.nodes.logicList[0], _delayNode.nodes.logicList[1]);
  }
}
