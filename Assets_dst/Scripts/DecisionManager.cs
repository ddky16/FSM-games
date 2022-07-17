using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DecisionManager : MonoBehaviour
{
  public GameObject titleDecisionText;
  public GameObject decisionChoiceDropdown;
  public GameObject startStateChoiceDropdown;
  public GameObject endStateChoiceDropdown;
  public GameObject startStateChoiceText;
  public GameObject endStateChoiceText;
  public GameObject confirmDecision;

  private UIInstantiateNode nodesData;

  // Start is called before the first frame update
  void Start()
  {
    nodesData = FindObjectOfType<UIInstantiateNode>();

    startStateChoiceDropdown.GetComponent<TMP_Dropdown>().ClearOptions();
    endStateChoiceDropdown.GetComponent<TMP_Dropdown>().ClearOptions();

    for (int i = 0; i < nodesData.nodes.stateList.Count; i++)
    {
      startStateChoiceDropdown.GetComponent<TMP_Dropdown>().options.Add(new TMP_Dropdown.OptionData() { text = i.ToString() });
      endStateChoiceDropdown.GetComponent<TMP_Dropdown>().options.Add(new TMP_Dropdown.OptionData() { text = i.ToString() });
    }

    confirmDecision.GetComponent<Button>().onClick.AddListener(() =>
    {
      var chosenDecision = decisionChoiceDropdown.GetComponent<TMP_Dropdown>().options[decisionChoiceDropdown.GetComponent<TMP_Dropdown>().value].text;
      titleDecisionText.GetComponent<TMP_Text>().text = chosenDecision;
      titleDecisionText.SetActive(true);
      decisionChoiceDropdown.SetActive(false);

      var startPos = startStateChoiceDropdown.GetComponent<TMP_Dropdown>().value;
      var endPos = endStateChoiceDropdown.GetComponent<TMP_Dropdown>().value;

      nodesData.prefabLineRenderer.GetComponent<AddingLinePoints>().stateLists.Add(nodesData.nodes.stateList[startPos].GetComponent<RectTransform>());
      nodesData.prefabLineRenderer.GetComponent<AddingLinePoints>().stateLists.Add(nodesData.nodes.stateList[endPos].GetComponent<RectTransform>());
      nodesData.prefabLineRenderer.GetComponent<AddingLinePoints>().AddNewPoint();

      GameObject newDecisionLine = Instantiate(nodesData.prefabLineRenderer, new Vector3(0, 0, 0), Quaternion.identity, nodesData.containerLineRenderer);

      nodesData.nodes.lineList.Add(newDecisionLine);

      confirmDecision.SetActive(false);
    });
  }
}
