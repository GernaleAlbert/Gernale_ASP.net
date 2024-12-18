using GERNALE_WEB_APP.Core.Interface;
using GERNALE_WEB_APP.Core.Model;

namespace GERNALE_WEB_APP.Infrastructure.Repository
{
    public class SectionRepository : ISectionService
    {
        public void AddSection(Section section)
        {
            MyDatabase.sections.Add(section);
        }

        public List<Section> GetAllSections()
        {
            return MyDatabase.sections;
        }

        public Section GetSectionById(int id)
        {
            return MyDatabase.sections.Find(x => x.Id == id);
        }

        public void SaveSection(Section section)
        {
            int index = MyDatabase.sections.FindIndex(x => x.Id == section.Id);
            MyDatabase.sections[index] = section;
        }
    }
}
