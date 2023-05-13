using Setups;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Controllers
{
    public class ReversAllSkillsController : MonoBehaviour
    {
        [SerializeField] private SkillSetup _mainSkillSetup;
        [SerializeField] private Button _buttonReversAllSkill;

        private void Start()
        {
            _buttonReversAllSkill.onClick.AddListener(OnReversAllSkills);
        }

        private void OnReversAllSkills()
        {
            _mainSkillSetup.ForceReverse();
        }
    }
}