using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIInstantiateNode : MonoBehaviour
{
  [Header("Prefabs")]
  public GameObject prefabIdleState;
  public GameObject prefabPatrolState;
  public GameObject prefabAttackState;
  public GameObject prefabChaseState;
  public GameObject prefabFleeState;
  public GameObject prefabCustomState;
  public GameObject prefabWaypointField;
  public GameObject prefabDecision, prefabLineRenderer;

  [Header("Panel")]
  public GameObject transitionScrollView;
  public RectTransform contentBlock, containerLineRenderer;
  public GameObject transitionBlock;

  [Header("Data")]
  public ListData nodes;
  private GameObject tank;
  private UIInstantiateNode nodesData;

  private void Start()
  {
    tank = GameObject.Find("Tank");
  }
  private void FixedUpdate()
  {
    EventManager eventManager = FindObjectOfType<EventManager>();
    bool check = eventManager.HitWallCheck(tank);
    Debug.Log(check);
  }

  public void SpawnIdleState()
  {
    GameObject newState = (GameObject)Instantiate(prefabIdleState, contentBlock.position, Quaternion.identity, contentBlock);
    newState.name = "Idle State";

    nodes.stateList.Add(newState);
  }

  public void SpawnPatrolState()
  {
    GameObject newState = (GameObject)Instantiate(prefabPatrolState, contentBlock.position, Quaternion.identity, contentBlock);
    newState.name = "Patrol State";

    nodes.stateList.Add(newState);
  }

  public void SpawnAttackState()
  {
    GameObject newState = (GameObject)Instantiate(prefabAttackState, contentBlock.position, Quaternion.identity, contentBlock);
    newState.name = "Attack State";

    nodes.stateList.Add(newState);
  }

  public void SpawnChaseState()
  {
    GameObject newState = (GameObject)Instantiate(prefabChaseState, contentBlock.position, Quaternion.identity, contentBlock);
    newState.name = "Chase State";

    nodes.stateList.Add(newState);
  }

  public void SpawnFleeState()
  {
    GameObject newState = (GameObject)Instantiate(prefabFleeState, contentBlock.position, Quaternion.identity, contentBlock);
    newState.name = "Flee State";

    nodes.stateList.Add(newState);
  }

  public void SpawnCustomState()
  {
    GameObject newState = (GameObject)Instantiate(prefabCustomState, contentBlock.position, Quaternion.identity, contentBlock);
    newState.name = "Custom State";

    nodes.stateList.Add(newState);
  }

  public int GetIndex(GameObject nodeList)
  {
    int position = nodes.stateList.IndexOf(nodeList);
    return position;
  }

  int GameObjectToIndex(GameObject targetObj)
  {
    for (int i = 0; i < nodes.stateList.Count; i++)
    {
      //Check if GameObject is in the List
      if (nodes.stateList[i] == targetObj)
      {
        //It is. Return the current index
        return i;
      }
    }
    return -1;
  }

  public void InstantiateDecisionObject()
  {
    GameObject newState = (GameObject)Instantiate(prefabDecision, contentBlock.position, Quaternion.identity, transitionBlock.GetComponent<RectTransform>());
    newState.name = "Decision";

    nodes.transitionDataList.Add(newState);

    prefabLineRenderer.GetComponent<AddingLinePoints>().stateLists.Clear();

    LayoutRebuilder.ForceRebuildLayoutImmediate(transitionScrollView.GetComponent<RectTransform>());
    LayoutRebuilder.ForceRebuildLayoutImmediate(transitionScrollView.GetComponent<RectTransform>());
  }

  public void InstantiateWaypoint(RectTransform container)
  {
    GameObject newWaypoints = (GameObject)Instantiate(prefabWaypointField, contentBlock.position, Quaternion.identity, container);
  }

  public void RefreshLine()
  {
    foreach (var lineData in nodes.lineList)
    {
      lineData.GetComponent<AddingLinePoints>().AddNewPoint();
    }
  }

  public void ClearState()
  {
    foreach (GameObject stateData in nodes.stateList)
    {
      Destroy(stateData);
    }
    foreach (GameObject lineData in nodes.lineList)
    {
      Destroy(lineData);
    }
    nodes.waypointsList.Clear();
    nodes.stateList.Clear();
    ClearLines();
  }

  public void ClearLines()
  {
    foreach (GameObject lineData in nodes.lineList)
    {
      Destroy(lineData);
    }

    foreach (GameObject transitionData in nodes.transitionDataList)
    {
      Destroy(transitionData);
    }

    nodes.lineList.Clear();
    nodes.transitionDataList.Clear();
  }
}
