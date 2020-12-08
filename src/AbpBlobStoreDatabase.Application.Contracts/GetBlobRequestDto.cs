using System.ComponentModel.DataAnnotations;

namespace AbpBlobStoreDatabase.Application.Contracts
{
   public class GetBlobRequestDto
    {
        [Required]
        public string Name { get; set; }
    }
}