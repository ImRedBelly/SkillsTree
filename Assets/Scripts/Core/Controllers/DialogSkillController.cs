using Setups;
using Core.Views;
using UnityEngine;

namespace Core.Controllers
{
    public class DialogSkillController : MonoBehaviour
    {
        [SerializeField] private DialogSkillView _dialogSkillView;
        private SkillSetup _skillSetup;

        private void OnEnable()
        {
            _dialogSkillView.ClickButtonBuySkill += OnBuySkill;
            _dialogSkillView.ClickButtonReversSkill += OnReversSkill;
            _dialogSkillView.ClickButtonCloseDialog += OnCloseDialog;
        }

        private void OnDisable()
        {
            _dialogSkillView.ClickButtonBuySkill -= OnBuySkill;
            _dialogSkillView.ClickButtonReversSkill -= OnReversSkill;
            _dialogSkillView.ClickButtonCloseDialog -= OnCloseDialog;
        }

        public void Initialize(SkillSetup skillSetup)
        {
            _skillSetup = skillSetup;
            UpdateViewDialog();
        }

        private void UpdateViewDialog()
        {
            _dialogSkillView.UpdateNameSkill(_skillSetup.keySkill);
            _dialogSkillView.UpdateTextDescriptionSkill(_skillSetup.keySkill);
            _dialogSkillView.UpdateTextPriceSkill(_skillSetup.priceSkill.ToString());
            _dialogSkillView.UpdateIconSkill(_skillSetup.iconSkill);


            var state = _skillSetup.GetStateSkill();
            var typeSecond = _skillSetup.typeSkill == TypeSkill.Second;
            _dialogSkillView.UpdateStateButtonBuySkill(state == StateSkill.Close && typeSecond);
            _dialogSkillView.UpdateStateButtonReverseSkill(state == StateSkill.Open && typeSecond);
        }

        private void OnBuySkill()
        {
            var skillDataModel = GameController.Insatance.SkillPointDataModel;
            if (_skillSetup.priceSkill <= skillDataModel.GetSkillPoint() && _skillSetup.CanBuySkill())
            {
                skillDataModel.SpendSkillPoint(_skillSetup.priceSkill);
                _skillSetup.UpgradeSkill();
                UpdateViewDialog();
            }
        }

        private void OnReversSkill()
        {
            var skillDataModel = GameController.Insatance.SkillPointDataModel;
            if (_skillSetup.CantReversSkill()) return;

            skillDataModel.AppendSkillPoint(_skillSetup.priceSkill);
            _skillSetup.ReverseSkill();
            UpdateViewDialog();
        }

        private void OnCloseDialog()
        {
            Destroy(gameObject);
        }
    }
}