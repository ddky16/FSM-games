using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DecisionManager : MonoBehaviour
{
  [Header("General Decision Manager")]
  public GameObject titleDecisionText;
  public GameObject decisionChoiceDropdown;
  public GameObject startStateChoiceDropdown;
  public GameObject endStateChoiceDropdown;
  public GameObject startStateChoiceText;
  public GameObject endStateChoiceText;

  [Header("Boolean Decision Manager")]
  public GameObject fieldBoolean;
  public GameObject optionBooleanDropdown;
  public GameObject btnAcceptEventBoolean;

  [Header("Statement Decision Manager")]
  public GameObject fieldStatement;
  public GameObject optionStatementDropdown;
  public GameObject optionArithmeticDropdown;
  public GameObject inputFieldLimitStatement;
  public GameObject btnAcceptEventStatement;

  [Header("General Button Decision Manager")]
  public GameObject btnAcceptEvent;
  public GameObject btnConfirmDecision;

  private UIInstantiateNode nodesData;

  // Start is called before the first frame update
  void Start()
  {
    nodesData = FindObjectOfType<UIInstantiateNode>();

    startStateChoiceDropdown.GetComponent<TMP_Dropdown>().ClearOptions();
    endStateChoiceDropdown.GetComponent<TMP_Dropdown>().ClearOptions();

    for (int i = 0; i < nodesData.nodes.stateList.Count; i++)
    {
      startStateChoiceDropdown.GetComponent<TMP_Dropdown>().options.Add(new TMP_Dropdown.OptionData() { text = nodesData.nodes.stateList[i].name });
      endStateChoiceDropdown.GetComponent<TMP_Dropdown>().options.Add(new TMP_Dropdown.OptionData() { text = nodesData.nodes.stateList[i].name });
    }

    btnAcceptEvent.GetComponent<Button>().onClick.AddListener(() =>
    {
      int chosenValueDecision = decisionChoiceDropdown.GetComponent<TMP_Dropdown>().value;

      switch (chosenValueDecision)
      {
        case 0:
          fieldBoolean.SetActive(true);
          break;
        case 1:
          fieldStatement.SetActive(true);
          break;
      }

      decisionChoiceDropdown.GetComponent<TMP_Dropdown>().enabled = false;
      btnAcceptEvent.SetActive(false);
    });

    btnAcceptEventBoolean.GetComponent<Button>().onClick.AddListener(() =>
    {
      int chosenValueBooleanCondition = optionBooleanDropdown.GetComponent<TMP_Dropdown>().value;

      optionBooleanDropdown.GetComponent<TMP_Dropdown>().enabled = false;
      btnAcceptEventBoolean.SetActive(false);
    });

    btnAcceptEventStatement.GetComponent<Button>().onClick.AddListener(() =>
    {
      int chosenValueStatementCondition = optionStatementDropdown.GetComponent<TMP_Dropdown>().value;
      int chosenValueArithmeticCondition = optionArithmeticDropdown.GetComponent<TMP_Dropdown>().value;
      string limitUserGiven = inputFieldLimitStatement.GetComponent<TMP_InputField>().text;

      optionStatementDropdown.GetComponent<TMP_Dropdown>().enabled = false;
      optionArithmeticDropdown.GetComponent<TMP_Dropdown>().enabled = false;
      inputFieldLimitStatement.GetComponent<TMP_InputField>().enabled = false;

      btnAcceptEventStatement.SetActive(false);
    });

    btnConfirmDecision.GetComponent<Button>().onClick.AddListener(() =>
    {
      int startPos = startStateChoiceDropdown.GetComponent<TMP_Dropdown>().value;
      int endPos = endStateChoiceDropdown.GetComponent<TMP_Dropdown>().value;

      startStateChoiceText.GetComponent<TMP_Text>().text = startStateChoiceDropdown.GetComponent<TMP_Dropdown>().options[startStateChoiceDropdown.GetComponent<TMP_Dropdown>().value].text;
      endStateChoiceText.GetComponent<TMP_Text>().text = endStateChoiceDropdown.GetComponent<TMP_Dropdown>().options[endStateChoiceDropdown.GetComponent<TMP_Dropdown>().value].text;

      startStateChoiceDropdown.SetActive(false);
      endStateChoiceDropdown.SetActive(false);

      startStateChoiceText.SetActive(true);
      endStateChoiceText.SetActive(true);

      nodesData.prefabLineRenderer.GetComponent<AddingLinePoints>().stateLists.Add(nodesData.nodes.stateList[startPos].GetComponent<RectTransform>());
      nodesData.prefabLineRenderer.GetComponent<AddingLinePoints>().stateLists.Add(nodesData.nodes.stateList[endPos].GetComponent<RectTransform>());
      nodesData.prefabLineRenderer.GetComponent<AddingLinePoints>().AddNewPoint();

      GameObject newDecisionLine = Instantiate(nodesData.prefabLineRenderer, new Vector3(0, 0, 0), Quaternion.identity, nodesData.containerLineRenderer);

      nodesData.nodes.lineList.Add(newDecisionLine);

      btnConfirmDecision.SetActive(false);
    });
  }
}
