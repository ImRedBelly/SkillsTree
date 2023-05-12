using Setups;
using System.Linq;
using UnityEngine;
using OdinNode.Scripts;
using Sirenix.OdinInspector;

namespace OdinNode.SkillGraph
{
    public class SkillDataNode : Node
    {
        [InlineEditor] public SkillSetup skillSetup;

        [field: Input(connectionType = ConnectionType.Multiple, backingValue = ShowBackingValue.Never), SerializeField]
        private SkillDataNode inputSkillNode;

        [field: Output(connectionType = ConnectionType.Multiple, backingValue = ShowBackingValue.Never), SerializeField]
        private SkillDataNode outputSkillNode;


        [Button]
        private void Init()
        {
            var nodePort = GetOutputPort(nameof(outputSkillNode)).GetConnections();

            skillSetup.nextSkillSetups = nodePort.Select(x => x.node as SkillDataNode)
                .Select(x => x.skillSetup).ToList();
        }
    }
}