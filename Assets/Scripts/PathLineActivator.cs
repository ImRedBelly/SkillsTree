using UnityEngine;
using UnityEngine.UI;
using OdinNode.SkillGraph;
using Setups;

public class PathLineActivator : MonoBehaviour
{
    [SerializeField] private Image iconPath;
    [SerializeField] private SkillSetup[] skillDataNodes;
    [SerializeField] private Color activateColor, deactivateColor;

    private void Start()
    {
        CheckStatePathLine();
    }

    private void OnEnable()
    {
        foreach (var skillData in skillDataNodes)
            skillData.OnBuySkill += CheckStatePathLine;
        foreach (var skillData in skillDataNodes)
            skillData.OnReverseSkill += CheckStatePathLine;
    }

    private void OnDisable()
    {
        foreach (var skillData in skillDataNodes)
            skillData.OnBuySkill -= CheckStatePathLine;
        foreach (var skillData in skillDataNodes)
            skillData.OnReverseSkill -= CheckStatePathLine;
    }

    private void CheckStatePathLine()
    {
        bool state = false;
        foreach (var skillData in skillDataNodes)
        {
            state = skillData.GetStateSkill() == StateSkill.Open;
            if (!state) break;
        }

        iconPath.color = state ? activateColor : deactivateColor;
    }
}