using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatrolUI : MonoBehaviour
{
  public GameObject thisObj;
  public Button btnAddWaypoint;
  public RectTransform containerWaypoint;
  private UIInstantiateNode listNodes;

  // Start is called before the first frame update
  void Start()
  {
    listNodes = FindObjectOfType<UIInstantiateNode>();

    btnAddWaypoint.onClick.AddListener(() =>
    {
      listNodes.InstantiateWaypoint(containerWaypoint);
      LayoutRebuilder.ForceRebuildLayoutImmediate(gameObject.GetComponent<RectTransform>());
      LayoutRebuilder.ForceRebuildLayoutImmediate(gameObject.GetComponent<RectTransform>());
    });
  }
}
