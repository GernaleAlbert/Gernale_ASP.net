using GERNALE_WEB_APP.Core.Model;

namespace GERNALE_WEB_APP.Core.Interface
{
    public interface ISectionService
    {
        void AddSection(Section section);
        List<Section> GetAllSections();
        Section GetSectionById(int id);
        void SaveSection(Section section);
    }
}
