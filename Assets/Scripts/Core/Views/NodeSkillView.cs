using System;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Views
{
    public class NodeSkillView : MonoBehaviour
    {
        public event Action ClickButtonSkill;

        [SerializeField] private Button _buttonSkill;
        [SerializeField] private Image _iconSkill, _iconBackground;


        protected virtual void OnEnable()
        {
            _buttonSkill.onClick.AddListener(OnClickButtonSkill);
        }

        protected virtual void OnDisable()
        {
            _buttonSkill.onClick.RemoveListener(OnClickButtonSkill);
        }

        public void UpdateIconSkill(Sprite iconSkill) => _iconSkill.sprite = iconSkill;
        public void UpdateColorBackground(Color color) => _iconBackground.color = color;
        private void OnClickButtonSkill()
        {
            ClickButtonSkill?.Invoke();
        }
    }
}