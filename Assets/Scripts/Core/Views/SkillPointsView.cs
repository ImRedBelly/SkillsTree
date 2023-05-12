using TMPro;
using UnityEngine;

namespace Core.Views
{
    public class SkillPointsView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textSkillPoints;

        public void UpdateTextSkillPoints(int skillPoints) => _textSkillPoints.text = skillPoints.ToString();
    }
}