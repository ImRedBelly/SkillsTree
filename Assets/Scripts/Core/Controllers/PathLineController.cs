using Setups; 
using Core.Views;
using UnityEngine;

namespace Core.Controllers
{
    public class PathLineController : MonoBehaviour
    {
        [SerializeField] private SkillSetup[] _skillDataNodes;
        [SerializeField] private PathLineView _pathLineView;
        [SerializeField] private Gradient _activateColor, _deactivateColor;

        [SerializeField] private Transform[] pointsLine;
        private void Start()
        {
            CheckStatePathLine();
        }

        private void OnEnable()
        {
            foreach (var skillData in _skillDataNodes)
                skillData.OnBuySkill += CheckStatePathLine;
            foreach (var skillData in _skillDataNodes)
                skillData.OnReverseSkill += CheckStatePathLine;
        }

        private void OnDisable()
        {
            foreach (var skillData in _skillDataNodes)
                skillData.OnBuySkill -= CheckStatePathLine;
            foreach (var skillData in _skillDataNodes)
                skillData.OnReverseSkill -= CheckStatePathLine;
        }

        public void UpdateLine()
        {
            if (pointsLine.Length < 1) return;
            _pathLineView.UpdateLine(pointsLine);
        }


        private void CheckStatePathLine()
        {
            bool state = false;
            foreach (var skillData in _skillDataNodes)
            {
                state = skillData.GetStateSkill() == StateSkill.Open;
                if (!state) break;
            }

            _pathLineView.UpdateColorPathLine(state ? _activateColor : _deactivateColor);
        }
    }
}