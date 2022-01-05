using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionCompleteUI : MonoBehaviour
{
  public static QuestionCompleteUI Instance { get; private set; }

  public float displayTime = 2.0f;
  float timerDisplay;
  private void Awake()
  {
    Instance = this;
  }

  void Start()
  {
    gameObject.SetActive(false);
    timerDisplay = -1.0f;
  }

  void Update()
  {
    if (timerDisplay >= 0)
    {
      timerDisplay -= Time.deltaTime;
      if (timerDisplay < 0)
      {
        gameObject.SetActive(false);
      }
    }
  }

  public void Show()
  {
    timerDisplay = displayTime;
    gameObject.SetActive(true);
  }
}
