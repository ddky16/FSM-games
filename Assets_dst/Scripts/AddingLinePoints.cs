using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddingLinePoints : MonoBehaviour
{
  public UnityEngine.UI.Extensions.UILineRenderer LineRenderer;
  public List<RectTransform> stateLists = new List<RectTransform>();
  [HideInInspector]
  public List<Vector2> linePointList;

  public void AddNewPoint()
  {
    linePointList.Clear();
    foreach (var state in stateLists)
    {
      var point = new Vector2(state.anchoredPosition.x, state.anchoredPosition.y);
      linePointList.Add(point);
    }
    LineRenderer.Points = linePointList.ToArray();
  }

  public void RefreshPoint()
  {
    foreach (var state in stateLists)
    {
      var point = new Vector2(state.anchoredPosition.x, state.anchoredPosition.y);
      linePointList.Add(point);
    }
    LineRenderer.Points = linePointList.ToArray();
  }

  private void Start()
  {
    linePointList = new List<Vector2>();
    AddNewPoint();
  }
}
