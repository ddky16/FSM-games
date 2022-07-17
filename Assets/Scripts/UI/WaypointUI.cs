using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaypointUI : MonoBehaviour
{
  public GameObject chosenPosXValue;
  public GameObject chosenPosYValue;
  public GameObject inputPosXValue;
  public GameObject inputPosYValue;
  public GameObject btnConfirm;
  private UIInstantiateNode dataVectors;

  // Start is called before the first frame update
  void Start()
  {
    dataVectors = FindObjectOfType<UIInstantiateNode>();

    btnConfirm.GetComponent<Button>().onClick.AddListener(() =>
    {
      var xPos = inputPosXValue.GetComponent<TMP_InputField>().text;
      var yPos = inputPosYValue.GetComponent<TMP_InputField>().text;

      chosenPosXValue.GetComponent<TMP_Text>().text = xPos;
      chosenPosYValue.GetComponent<TMP_Text>().text = yPos;

      chosenPosXValue.SetActive(true);
      chosenPosYValue.SetActive(true);

      inputPosXValue.SetActive(false);
      inputPosYValue.SetActive(false);

      dataVectors.nodes.waypointsList.Add(new Vector2(float.Parse(xPos), float.Parse(yPos)));
      btnConfirm.SetActive(false);

      LayoutRebuilder.ForceRebuildLayoutImmediate(gameObject.GetComponent<RectTransform>());
      LayoutRebuilder.ForceRebuildLayoutImmediate(gameObject.GetComponent<RectTransform>());
    });
  }
}
