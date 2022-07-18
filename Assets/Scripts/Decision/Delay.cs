using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour
{
  UIInstantiateNode _delayNode;
  float delayTime = 2;
  float currentTime = 0;

  private void Start()
  {
    _delayNode = GameObject.FindObjectOfType<UIInstantiateNode>();
    _delayNode.nodes.logicList[0].SetActive(true);
    _delayNode.nodes.logicList[1].SetActive(false);
    currentTime = delayTime;
  }

  private void Update()
  {
    currentTime -= Time.deltaTime;

    if (currentTime < 0)
    {
      print("done");
      _delayNode.nodes.logicList[0].SetActive(false);
      _delayNode.nodes.logicList[1].SetActive(true);
    }
  }

  public void DelayCheck(float delayTime, GameObject component1, GameObject component2)
  {

  }

}
