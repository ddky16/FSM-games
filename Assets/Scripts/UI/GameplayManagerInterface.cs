using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameplayManagerInterface : MonoBehaviour
{
  [Header("Button Panel Interaction")]
  public GameObject btnShowPanelTransition;
  public GameObject btnHidePanelNodes;
  public GameObject btnShowPanelNodes;

  [Header("Panel Interaction")]
  public GameObject panelTransition, panelNodesContent;

  // Start is called before the first frame update
  void Start()
  {
    bool isActivated = false;
    btnShowPanelTransition.GetComponent<Button>().onClick.AddListener(() =>
    {
      if (!isActivated)
      {
        panelTransition.GetComponent<RectTransform>().DOAnchorPos(new Vector2(450, -360), 0.4f);
        isActivated = true;
      }
      else
      {
        panelTransition.GetComponent<RectTransform>().DOAnchorPos(new Vector2(830, -360), 0.4f);
        isActivated = false;
      }
    });
    btnHidePanelNodes.GetComponent<Button>().onClick.AddListener(() =>
    {
      panelNodesContent.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-1280, 0), 0.4f);
      panelTransition.SetActive(false);
    });
    btnShowPanelNodes.GetComponent<Button>().onClick.AddListener(() =>
    {
      panelNodesContent.GetComponent<RectTransform>().DOAnchorPos(Vector2.zero, 0.4f);
      panelTransition.SetActive(true);
    });
  }
}
