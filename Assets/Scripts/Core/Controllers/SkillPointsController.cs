using Core.Views;
using DataModels;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Controllers
{
    public class SkillPointsController : MonoBehaviour
    {
        [SerializeField] private SkillPointsView _skillPointsView;
        [SerializeField] private Button _buttonAddSkillPoint;

        private SkillPointDataModel _skillPointDataModel;

        private void Start()
        {
            _buttonAddSkillPoint.onClick.AddListener(OnAppendSkillPoint);
            _skillPointDataModel = GameController.Insatance.SkillPointDataModel;
            _skillPointDataModel.OnChangeSkillPoints += UpdateViewSkillPoints;
            UpdateViewSkillPoints();
        }


        private void OnDisable()
        {
            _skillPointDataModel.OnChangeSkillPoints -= UpdateViewSkillPoints;
        }

        private void UpdateViewSkillPoints()
        {
            _skillPointsView.UpdateTextSkillPoints(_skillPointDataModel.GetSkillPoint());
        }

        private void OnAppendSkillPoint()
        {
            _skillPointDataModel.AppendSkillPoint(1);
        }
    }
}