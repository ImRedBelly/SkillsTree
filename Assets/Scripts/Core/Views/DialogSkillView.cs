using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Views
{
    public class DialogSkillView : MonoBehaviour
    {
        public event Action ClickButtonCloseDialog;
        public event Action ClickButtonBuySkill;
        public event Action ClickButtonReversSkill;

        [SerializeField] private Button _buttonBuySkill;
        [SerializeField] private Button _buttonReverseSkill;
        [SerializeField] private Button _buttonCloseDialog;
        [Space] 
        [SerializeField] private Image _iconSkill;
        [SerializeField] private GameObject _panelPrice;
        [SerializeField] private TextMeshProUGUI _textNameSkill;
        [SerializeField] private TextMeshProUGUI _textDescriptionSkill;
        [SerializeField] private TextMeshProUGUI _textPriceSkill;


        private void OnEnable()
        {
            _buttonBuySkill.onClick.AddListener(OnClickButtonBuySkill);
            _buttonReverseSkill.onClick.AddListener(OnClickButtonReversSkill);
            _buttonCloseDialog.onClick.AddListener(OnClickButtonCloseDialog);
        }

        private void OnDisable()
        {
            _buttonBuySkill.onClick.RemoveListener(OnClickButtonBuySkill);
            _buttonReverseSkill.onClick.RemoveListener(OnClickButtonReversSkill);
            _buttonCloseDialog.onClick.RemoveListener(OnClickButtonCloseDialog);
        }

        public void UpdateIconSkill(Sprite iconSkill)
            => _iconSkill.sprite = iconSkill; 
        public void UpdateStatePanelPrice(bool state)
            => _panelPrice.SetActive(state);

        public void UpdateNameSkill(string nameSkill)
            => _textNameSkill.text = nameSkill;

        public void UpdateTextDescriptionSkill(string descriptionSkill)
            => _textDescriptionSkill.text = descriptionSkill;

        public void UpdateTextPriceSkill(string priceSkill)
            => _textPriceSkill.text = priceSkill;

        public void UpdateStateButtonBuySkill(bool state)
            => _buttonBuySkill.gameObject.SetActive(state);

        public void UpdateStateButtonReverseSkill(bool state)
            => _buttonReverseSkill.gameObject.SetActive(state);

        private void OnClickButtonBuySkill()
        {
            ClickButtonBuySkill?.Invoke();
        }

        private void OnClickButtonReversSkill()
        {
            ClickButtonReversSkill?.Invoke();
        }

        private void OnClickButtonCloseDialog()
        {
            ClickButtonCloseDialog?.Invoke();
        }
    }
}