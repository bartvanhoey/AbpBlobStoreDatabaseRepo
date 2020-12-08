using System.ComponentModel.DataAnnotations;

namespace AbpBlobStoreDatabase.Application.Contracts
{
   public class SaveBlobInputDto
    {
        public byte[] Content { get; set; }

        [Required]
        public string Name { get; set; }
    }
}