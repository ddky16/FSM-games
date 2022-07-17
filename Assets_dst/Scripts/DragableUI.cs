using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragableUI : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
  private RectTransform rectTransform;
  private Canvas canvas;
  [SerializeField]
  private Image imageState;
  private Color backgroundColor;
  private UIInstantiateNode nodesData;

  private void Start()
  {
    nodesData = FindObjectOfType<UIInstantiateNode>();
    rectTransform = GetComponent<RectTransform>();
    canvas = FindObjectOfType<Canvas>();
    backgroundColor = imageState.color;
  }

  public void OnBeginDrag(PointerEventData eventData)
  {
    backgroundColor.a = 0.4f;
    imageState.color = backgroundColor;
  }

  public void OnDrag(PointerEventData eventData)
  {
    rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
  }

  public void OnEndDrag(PointerEventData eventData)
  {
    backgroundColor.a = 1f;
    imageState.color = backgroundColor;

    nodesData.RefreshLine();
  }
}
