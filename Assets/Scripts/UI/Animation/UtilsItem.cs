using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UtilsItem : MonoBehaviour
{
  public Image image;
  [HideInInspector]
  public RectTransform rectTransform;

  Utils utils;

  Button button;

  int indexItems;

  private void Awake()
  {
    image = GetComponent<Image>();
    rectTransform = GetComponent<RectTransform>();

    utils = rectTransform.parent.GetComponent<Utils>();

    indexItems = rectTransform.GetSiblingIndex() - 1;

    button = GetComponent<Button>();
  }
}
