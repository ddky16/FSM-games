using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlockNodeBehavior : MonoBehaviour
{
  [Header("State Header")]
  public GameObject stateTitle;
  private UIInstantiateNode listNodes;
  [HideInInspector]
  public RectTransform containerBlocks;

  [Header("State Editable")]
  public GameObject renameField;
  public Button btnConfirmRenameField;
  public Button btnCancelRenameField;
  public Button btnEditStateName;
  public TMP_InputField renameInputField;

  [Header("Logic Field")]
  public GameObject addLogicState;
  public GameObject hideLogicState;
  public GameObject logicOptions;
  public Button pickLogic;
  public TMP_Dropdown logicDropdownList;

  [Header("Logic Manager")]
  public List<GameObject> logicPrefabs = new List<GameObject>();
  public RectTransform logicContainer;

  private void Start()
  {
    containerBlocks = GameObject.Find("Content").GetComponent<RectTransform>();
    listNodes = FindObjectOfType<UIInstantiateNode>();

    addLogicState.GetComponent<Button>().onClick.AddListener(() =>
    {
      OpenFormAddNewLogic();
    });

    hideLogicState.GetComponent<Button>().onClick.AddListener(() =>
    {
      HideFormAddNewLogic();
    });

    pickLogic.onClick.AddListener(() =>
    {
      int valueChosen = logicDropdownList.value;
      var newLogic = Instantiate(logicPrefabs[valueChosen], transform.position, Quaternion.identity, logicContainer);

      HideFormAddNewLogic();
    });

    btnEditStateName.onClick.AddListener(() =>
    {
      renameField.SetActive(true);
      stateTitle.SetActive(false);
    });

    btnConfirmRenameField.onClick.AddListener(() =>
    {
      stateTitle.GetComponent<TMP_Text>().text = renameInputField.text;
      renameField.SetActive(false);
      stateTitle.SetActive(true);
    });

    btnCancelRenameField.onClick.AddListener(() =>
    {
      renameField.SetActive(false);
      stateTitle.SetActive(true);
    });
  }

  private void HideFormAddNewLogic()
  {
    logicOptions.SetActive(false);
    hideLogicState.SetActive(false);
    addLogicState.SetActive(true);
  }

  private void OpenFormAddNewLogic()
  {
    logicOptions.SetActive(true);
    hideLogicState.SetActive(true);
    addLogicState.SetActive(false);
  }
}
