using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionDialogUI : MonoBehaviour
{
  public static QuestionDialogUI Instance { get; private set; }
  private TMP_Text question;
  private Button yesBtn;
  private Button noBtn;
  private void Awake()
  {
    Instance = this;
    question = transform.Find("Text").GetComponent<TMP_Text>();
    yesBtn = transform.Find("YesBtn").GetComponent<Button>();
    noBtn = transform.Find("NoBtn").GetComponent<Button>();

    Hide();
  }

  public void ShowQuestion(string questionText, Action yesAction, Action noAction)
  {
    gameObject.SetActive(true);

    question.text = questionText;

    yesBtn.onClick.AddListener(() =>
    {
      Hide();
      yesAction();
    });
    noBtn.onClick.AddListener(() =>
    {
      Hide();
      noAction();
    });
  }

  private void Hide()
  {
    gameObject.SetActive(false);
  }
}
