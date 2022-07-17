using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Utils : MonoBehaviour
{
  [Header("space between menu items")]
  [SerializeField] Vector2 spacing;

  [Space]
  [Header("Main button rotation")]
  [SerializeField] bool enableRotation;
  [SerializeField] float rotationDuration;
  [SerializeField] Ease rotationEase;

  [Space]
  [Header("Animation")]
  [SerializeField] float expandDuration;
  [SerializeField] float collapseDuration;
  [SerializeField] Ease expandEase;
  [SerializeField] Ease collapseEase;

  [Space]
  [Header("Fading")]
  [SerializeField] float expandFadeDuration;
  [SerializeField] float collapseFadeDuration;

  Button mainButton;
  UtilsItem[] menuItems;

  //is menu opened or not
  bool isExpanded = false;

  Vector2 mainButtonPosition;
  int itemsCount;

  private void Start()
  {
    itemsCount = transform.childCount - 1;
    menuItems = new UtilsItem[itemsCount];

    for (int i = 0; i < itemsCount; i++)
    {
      // +1 to ignore the main button
      menuItems[i] = transform.GetChild(i + 1).GetComponent<UtilsItem>();
    }

    mainButton = transform.GetChild(0).GetComponent<Button>();
    mainButton.onClick.AddListener(ToggleMenu);
    //SetAsLastSibling () to make sure that the main button will be always at the top layer
    mainButton.transform.SetAsLastSibling();

    mainButtonPosition = mainButton.GetComponent<RectTransform>().anchoredPosition;

    //set all menu items position to mainButtonPosition
    ResetPositions();
  }
  void ResetPositions()
  {
    for (int i = 0; i < itemsCount; i++)
    {
      menuItems[i].rectTransform.anchoredPosition = mainButtonPosition;
    }
  }

  void ToggleMenu()
  {
    isExpanded = !isExpanded;

    if (isExpanded)
    {
      //menu opened
      for (int i = 0; i < itemsCount; i++)
      {
        menuItems[i].rectTransform.DOAnchorPos(mainButtonPosition + spacing * (i + 1), expandDuration).SetEase(expandEase);
        //Fade to alpha=1 starting from alpha=0 immediately
        menuItems[i].image.DOFade(1f, expandFadeDuration).From(0f);
      }
      if (enableRotation)
        mainButton.transform
          .DORotate(Vector3.forward * 135f, rotationDuration)
          .From(Vector3.zero)
          .SetEase(rotationEase);
    }
    else
    {
      //menu closed
      for (int i = 0; i < itemsCount; i++)
      {
        menuItems[i].rectTransform.DOAnchorPos(mainButtonPosition, collapseDuration).SetEase(collapseEase);
        //Fade to alpha=0
        menuItems[i].image.DOFade(0f, collapseFadeDuration);
      }
      if (enableRotation)
        mainButton.transform
          .DORotate(Vector3.forward * 270f, rotationDuration)
          .From(Vector3.zero)
          .SetEase(rotationEase);
    }
  }

  void OnDestroy()
  {
    //remove click listener to avoid memory leaks
    mainButton.onClick.RemoveListener(ToggleMenu);
  }
}
