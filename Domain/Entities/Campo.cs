namespace Domain.Entities
{
    public class Campo : EntityBase
    {
        public int IdLayout { get; private set; }
        public string De { get; private set; }
        public string Para { get; private set; }
        public Layout Layout { get; private set; }

        public Campo()
        {

        }

        public Campo(string de, string para, Layout layout)
        {
            De = de;
            Para = para;
            Layout = layout;
        }
    }
}
