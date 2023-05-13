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

        public void CreateDialogSkill(SkillSetup skillSetup)
        {
            var dialog = Instantiate(_dialogSkillController, _parentDialog);
            _diContainer.Inject(dialog);
            dialog.Initialize(skillSetup);
        }
    }
}