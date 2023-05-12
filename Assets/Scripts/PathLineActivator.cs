using Setups;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class PathLineActivator : MonoBehaviour
{
    [SerializeField] private Image iconPath;
    [SerializeField] private SkillSetup[] skillDataNodes;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform[] pointsLine;
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

    public void UpdateLine()
    {
        if (pointsLine.Length < 1) return;
        lineRenderer.SetPosition(0, pointsLine[0].position);
        lineRenderer.SetPosition(1, pointsLine[1].position);
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