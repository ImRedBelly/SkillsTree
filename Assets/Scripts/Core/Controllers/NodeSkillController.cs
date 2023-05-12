using Setups;
using Core.Views;
using UnityEngine;

namespace Core.Controllers
{
    public class NodeSkillController : MonoBehaviour
    {
        [SerializeField] protected SkillSetup _skillSetup;
        [SerializeField] private NodeSkillView _nodeSkillView;
        [SerializeField] private Color _activateColor, _deactivateColor;

        private void OnEnable()
        {
            _skillSetup.OnBuySkill += UpdateViewNode;
            _skillSetup.OnReverseSkill += UpdateViewNode;
            _nodeSkillView.ClickButtonSkill += OpenSkillDialog;
        }

        private void Start()
        {
            if (_skillSetup.typeSkill == TypeSkill.Main)
                _skillSetup.UpgradeSkill();

            UpdateViewNode();
        }

        private void OnDisable()
        {
            _skillSetup.OnBuySkill -= UpdateViewNode;
            _skillSetup.OnReverseSkill -= UpdateViewNode;
            _nodeSkillView.ClickButtonSkill -= OpenSkillDialog;
        }

        private void UpdateViewNode()
        {
            _nodeSkillView.UpdateIconSkill(_skillSetup.iconSkill);
            _nodeSkillView.UpdateColorBackground(_skillSetup.GetStateSkill() == StateSkill.Open
                ? _activateColor
                : _deactivateColor);
        }

        private void OpenSkillDialog()
        {
            GameController.Insatance.CreateDialogSkill(_skillSetup);
        }
    }
}