namespace GERNALE_WEB_APP.Core.Model
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<int> Students { get; set; } = [];
    }
}
