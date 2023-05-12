using Setups;
using DataModels;
using UnityEngine;
using Core.Controllers;

public class GameController : MonoBehaviour
{
    public static GameController Insatance;
    public SkillsDataModel SkillsDataModel { get; } = new SkillsDataModel();
    public SkillPointDataModel SkillPointDataModel { get; } = new SkillPointDataModel();

    [SerializeField] private DialogSkillController _dialogSkillController;
    [SerializeField] private Transform _parentDialog;

    private void Awake()
    {
        if (Insatance == null)
            Insatance = this;
        else
            Destroy(this);
    }

    public void CreateDialogSkill(SkillSetup skillSetup)
    {
        var dialog = Instantiate(_dialogSkillController, _parentDialog);
        dialog.Initialize(skillSetup);
    }
}