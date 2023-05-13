using DataModels;

namespace Services
{
    public class DataHelper
    {
        public SkillsDataModel SkillsDataModel { get; } = new SkillsDataModel();
        public SkillPointDataModel SkillPointDataModel { get; } = new SkillPointDataModel();
    }
}