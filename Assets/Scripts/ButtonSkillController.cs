using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSkillController : MonoBehaviour
{
    public int stateSkill = 0;
    public event Action OnUpdateSkill;
    [SerializeField] private Button buttonViewSkill;
    [SerializeField] private Image iconSkill, iconBackground;

    [SerializeField] private ButtonSkillController[] buttonSkill;
    [SerializeField] private Color activateColor, deactivateColor;

    void Start()
    {
        buttonViewSkill.onClick.AddListener(ActivateButton);
        UpdateViewButton();
    }

    public void ActivateButton()
    {
        stateSkill = 2;
        OnUpdateSkill?.Invoke();
        for (int i = 0; i < buttonSkill.Length; i++)
        {
            buttonSkill[i].stateSkill = 1;
            buttonSkill[i].UpdateViewButton();
        }

        UpdateViewButton();
    }

    public void UpdateViewButton()
    {
        switch (stateSkill)
        {
            case 0:
                iconBackground.color = deactivateColor;
                break;
            case 1:
                iconBackground.color = deactivateColor;
                break;
            case 2:
                iconBackground.color = activateColor;
                break;
        }
    }
}