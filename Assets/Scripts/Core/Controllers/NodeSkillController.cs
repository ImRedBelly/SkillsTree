using Setups;
using Core.Views;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Core.Controllers
{
    public class NodeSkillController : MonoBehaviour
    {
        [SerializeField] protected SkillSetup _skillSetup;
        [SerializeField] private NodeSkillView _nodeSkillView;

        private void OnEnable()
        {
            _nodeSkillView.ClickButtonSkill += OpenSkillDialog;
        }


        [Button]
        public void GetVAlues()
        {
          
        }
        private void Start()
        {
            UpdateViewNode();
        }

        private void OnDisable()
        {
            _nodeSkillView.ClickButtonSkill -= OpenSkillDialog;
        }

        private void UpdateViewNode()
        {
            _nodeSkillView.UpdateIconSkill(_skillSetup.iconSkill);
        }

        private void OpenSkillDialog()
        {
            GameController.Insatance.CreateDialogSkill(_skillSetup);
        }
    }
}