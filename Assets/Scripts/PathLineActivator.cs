using UnityEngine;
using UnityEngine.UI;

public class PathLineActivator : MonoBehaviour
{
    [SerializeField] private Image iconPath;
    [SerializeField] private ButtonSkillController[] buttonsCheck;
    [SerializeField] private Color activateColor, deactivateColor;

    private void Start()
    {
        CheckStatePathLine();
    }

    private void OnEnable()
    {
        foreach (var buttonSkill in buttonsCheck)
            buttonSkill.OnUpdateSkill += CheckStatePathLine;
    }

    private void OnDisable()
    {
        foreach (var buttonSkill in buttonsCheck)
            buttonSkill.OnUpdateSkill -= CheckStatePathLine;
    }

    private void CheckStatePathLine()
    {
        bool state = false;
        foreach (var buttonSkill in buttonsCheck)
        {
            state = buttonSkill.stateSkill == 2;
            if (!state) break;
        }

        iconPath.color = state ? activateColor : deactivateColor;
    }
}