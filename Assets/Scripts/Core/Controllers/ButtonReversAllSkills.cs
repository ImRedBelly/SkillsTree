using Setups;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Core.Controllers
{
    public class ButtonReversAllSkills : MonoBehaviour
    {
        [SerializeField] private SkillSetup _mainSkillSetup;
        [SerializeField] private Button _buttonReversAllSkill;
        private List<SkillSetup> _skillSetupsForReverse = new List<SkillSetup>(10);

        private void Start()
        {
            _buttonReversAllSkill.onClick.AddListener(OnReversAllSkills);

           
        }

        private void OnReversAllSkills()
        {
            _mainSkillSetup.ForceReverse();
          //  FindAllSkillForReverse(_mainSkillSetup.nextSkillSetups);
        }

        private void FindAllSkillForReverse(List<SkillSetup> skillSetups)
        {
            if (skillSetups.Count > 0)
            {
                var newSkillsForRevers = new List<SkillSetup>();
                foreach (var skillSetup in skillSetups)
                {
                    if (!_skillSetupsForReverse.Contains(skillSetup) 
                        && skillSetup.GetStateSkill() == StateSkill.Open)
                    {
                        newSkillsForRevers.Add(skillSetup);
                        _skillSetupsForReverse.Add(skillSetup);
                    }
                }

                FindAllSkillForReverse(newSkillsForRevers.SelectMany(x => x.nextSkillSetups).ToList());
            }
            else
                ReverseAllSkill();
        }

        private void ReverseAllSkill()
        {
            foreach (var skillSetup in _skillSetupsForReverse)
                skillSetup.ReverseSkill();

            _skillSetupsForReverse.Clear();
        }
    }
}