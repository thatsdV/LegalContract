namespace LegalContract.Domain.Entities
{
    public class LegalContract
    {
        public string Id { get; set; }

        public string Author { get; set; }

        public string EntityName { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
