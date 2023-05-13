using System;
using System.Linq;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using Services;
using Zenject;

namespace Setups
{
    [CreateAssetMenu(fileName = "Skill", menuName = "Skill/SkillSetup")]
    public class SkillSetup : ScriptableObject
    {
        public event Action OnBuySkill;
        public event Action OnReverseSkill;
        public TypeSkill typeSkill;
        public string keySkill;

        [PreviewField(50)] public Sprite iconSkill;

        [ShowIf(nameof(typeSkill), TypeSkill.Second)]
        public int priceSkill;

        [SerializeField] public List<SkillSetup> nextSkillSetups;
        private DataHelper _dataHelper;

        public void Initialize(DataHelper dataHelper)
        {
            _dataHelper = dataHelper;
        }

        public StateSkill GetStateSkill() => _dataHelper.SkillsDataModel.GetStateSkill(keySkill);

        public bool CantReversSkill() => nextSkillSetups.Any(x =>
            _dataHelper.SkillsDataModel.GetSkill(x.keySkill).incomingPurchasedNodesCount == 1 &&
            x.GetStateSkill() == StateSkill.Open);

        public bool CanBuySkill() =>
            _dataHelper.SkillsDataModel.GetSkill(keySkill).incomingPurchasedNodesCount != 0;

        public void UpgradeSkill()
        {
            var skillDataModel = _dataHelper.SkillsDataModel;
            foreach (var nextSkill in nextSkillSetups)
                skillDataModel.GetSkill(nextSkill.keySkill).incomingPurchasedNodesCount++;

            skillDataModel.SetStateSkill(keySkill, StateSkill.Open);
            OnBuySkill?.Invoke();
        }

        public void ReverseSkill()
        {
            if (typeSkill == TypeSkill.Main) return;

            var skillDataModel = _dataHelper.SkillsDataModel;
            var skillPointDataModel = _dataHelper.SkillPointDataModel;
            foreach (var nextSkill in nextSkillSetups)
                skillDataModel.GetSkill(nextSkill.keySkill).incomingPurchasedNodesCount--;


            skillPointDataModel.AppendSkillPoint(priceSkill);
            skillDataModel.SetStateSkill(keySkill, StateSkill.Close);
            OnReverseSkill?.Invoke();
        }

        public void ForceReverse()
        {
            if (GetStateSkill() == StateSkill.Close)
                return;

            ReverseSkill();
            foreach (var nextSkill in nextSkillSetups)
                nextSkill.ForceReverse();
        }
    }
}