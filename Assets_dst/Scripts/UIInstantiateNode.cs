using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIInstantiateNode : MonoBehaviour, IPointerClickHandler, IPointerDownHandler
{
  public GameObject prefabState, prefabDecision, prefabLineRenderer;
  public GameObject transitionScrollView;
  public RectTransform contentBlock, transitionBlock, containerLineRenderer;
  public ListStateNodes nodes;

  // public LineManager lm;

  private void Start()
  {

  }

  public void OnPointerClick(PointerEventData eventData)
  {
    if (eventData.button == PointerEventData.InputButton.Right)
    {
      GameObject newState = (GameObject)Instantiate(prefabState, contentBlock.position, Quaternion.identity, contentBlock);

      nodes.stateList.Add(newState);
    }
  }

  public int GetIndex(GameObject nodeList)
  {
    int position = nodes.stateList.IndexOf(nodeList);
    return position;
  }

  public void OnPointerDown(PointerEventData eventData)
  {
    GameObject clickedObj = eventData.pointerCurrentRaycast.gameObject;

    int index = GameObjectToIndex(clickedObj);
    Debug.Log(index);
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
    GameObject newState = (GameObject)Instantiate(prefabDecision, contentBlock.position, Quaternion.identity, transitionBlock);
    prefabLineRenderer.GetComponent<AddingLinePoints>().stateLists.Clear();
    StartCoroutine(RefreshScrollView());
  }

  IEnumerator RefreshScrollView()
  {
    yield return new WaitForSeconds(0.1f);
    transitionScrollView.SetActive(false);
    yield return new WaitForSeconds(0.1f);
    transitionScrollView.SetActive(true);
  }

  public void RefreshLine()
  {
    Debug.Log("Refreshing line");
    foreach (var lineData in nodes.lineList)
    {
      lineData.GetComponent<AddingLinePoints>().AddNewPoint();
    }
  }
}
