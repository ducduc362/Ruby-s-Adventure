using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestDetailUI : MonoBehaviour
{
  public static QuestDetailUI Instance { get; private set; }
  private TMP_Text quantityFixedRobot;
  private TMP_Text quantityRobot;

  // public string textOne
  void Awake()
  {
    Instance = this;

    gameObject.SetActive(false);

    quantityFixedRobot = transform.Find("FixedRobotText").GetComponent<TMP_Text>();
    quantityRobot = transform.Find("RobotText").GetComponent<TMP_Text>();

    int RobotQuantity = GameObject.FindGameObjectsWithTag("Robot").Length;
    quantityRobot.text = RobotQuantity.ToString();
  }

  private void Update()
  {
    int RobotQuantity = GameObject.FindGameObjectsWithTag("Robot").Length;
    int FixedRobotQuantity = GameObject.FindGameObjectsWithTag("FixedRobot").Length;
    quantityFixedRobot.text = FixedRobotQuantity + "/";

    if (RobotQuantity == 0)
    {
      gameObject.SetActive(false);
      QuestionCompleteUI.Instance.Show();
    }
  }

  public void Show()
  {
    gameObject.SetActive(true);
  }

}
