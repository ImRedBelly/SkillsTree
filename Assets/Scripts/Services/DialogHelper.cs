using Setups;
using Zenject;
using UnityEngine;
using Core.Controllers;

namespace Services
{
    public class DialogHelper : MonoBehaviour
    {
        [SerializeField] private DialogSkillController _dialogSkillController;
        [SerializeField] private Transform _parentDialog;
        [Inject] private DiContainer _diContainer;

        private DialogSkillController _copyDialogSkill;

        public void InitializeDialogSkill(SkillSetup skillSetup)
        {
            if (_copyDialogSkill == null)
                CreateDialogSkill(skillSetup);
            _copyDialogSkill.Initialize(skillSetup);
        }

        private void CreateDialogSkill(SkillSetup skillSetup)
        {
            _copyDialogSkill = Instantiate(_dialogSkillController, _parentDialog);
            _diContainer.Inject(_copyDialogSkill);
        }
    }
}