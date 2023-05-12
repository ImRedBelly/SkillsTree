using System;
using System.Linq;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;

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

        public List<SkillSetup> nextSkillSetups;

        public StateSkill GetStateSkill() => GameController.Insatance.SkillsDataModel.GetStateSkill(keySkill);

        public bool CantReversSkill() => nextSkillSetups.Any(x =>
            GameController.Insatance.SkillsDataModel.GetSkill(x.keySkill).incomingPurchasedNodesCount == 1 &&
            x.GetStateSkill() == StateSkill.Open);

        public bool CanBuySkill() =>
            GameController.Insatance.SkillsDataModel.GetSkill(keySkill).incomingPurchasedNodesCount != 0;

        public void UpgradeSkill()
        {
            var skillDataModel = GameController.Insatance.SkillsDataModel;
            foreach (var nextSkill in nextSkillSetups)
                skillDataModel.GetSkill(nextSkill.keySkill).incomingPurchasedNodesCount++;

            skillDataModel.SetStateSkill(keySkill, StateSkill.Open);
            OnBuySkill?.Invoke();
        }

        public void ReverseSkill()
        {
            var skillDataModel = GameController.Insatance.SkillsDataModel;
            foreach (var nextSkill in nextSkillSetups)
                skillDataModel.GetSkill(nextSkill.keySkill).incomingPurchasedNodesCount--;

            skillDataModel.SetStateSkill(keySkill, StateSkill.Close);
            OnReverseSkill?.Invoke();
        }
    }
}