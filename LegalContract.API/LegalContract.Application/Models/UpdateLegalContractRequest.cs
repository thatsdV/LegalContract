namespace LegalContract.Application.Models
{
    public class UpdateLegalContractRequest
    {
        public int Id { get; set; }

        public string Author { get; set; }

        public string EntityName { get; set; }

        public string Description { get; set; }
    }
}
