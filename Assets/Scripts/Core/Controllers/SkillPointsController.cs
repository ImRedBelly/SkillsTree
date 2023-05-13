using Zenject;
using Services;
using Core.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Controllers
{
    public class SkillPointsController : MonoBehaviour
    {
        [SerializeField] private SkillPointsView _skillPointsView;
        [SerializeField] private Button _buttonAddSkillPoint;

        [Inject] private DataHelper _dataHelper;

        private void Start()
        {
            _buttonAddSkillPoint.onClick.AddListener(OnAppendSkillPoint);
            _dataHelper.SkillPointDataModel.OnChangeSkillPoints += UpdateViewSkillPoints;
            UpdateViewSkillPoints();
        }


        private void OnDisable()
        {
            _dataHelper.SkillPointDataModel.OnChangeSkillPoints -= UpdateViewSkillPoints;
        }

        private void UpdateViewSkillPoints()
        {
            _skillPointsView.UpdateTextSkillPoints(_dataHelper.SkillPointDataModel.GetSkillPoint());
        }

        private void OnAppendSkillPoint()
        {
            _dataHelper.SkillPointDataModel.AppendSkillPoint(1);
        }
    }
}