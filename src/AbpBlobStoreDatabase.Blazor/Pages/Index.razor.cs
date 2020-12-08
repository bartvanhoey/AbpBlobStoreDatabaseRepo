using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AbpBlobStoreDatabase.Application.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace AbpBlobStoreDatabase.Blazor.Pages
{
  public partial class Index
  {

    [Inject] protected IFileAppService FileAppService { get; set; }
    private IList<string> imageDataUrls = new List<string>();
    private string GetImage;

    private async Task OnInputFileChange(InputFileChangeEventArgs e)
    {
      var maxAllowedFiles = 1;
      var format = "image/jpeg";

      foreach (var imageFile in e.GetMultipleFiles(maxAllowedFiles))
      {
        var resizedImageFile = await imageFile.RequestImageFileAsync(format, 100, 100);
        var buffer = new byte[resizedImageFile.Size];
        await resizedImageFile.OpenReadStream().ReadAsync(buffer);

        // await FileAppService.SaveBlobAsync(new SaveBlobInputDto { Name = imageFile.Name, Content = buffer });
        await FileAppService.SaveBlobAsync(new SaveBlobInputDto { Name = "MyImageNme.jpeg", Content = buffer });

        var imageDataUrl = $"data:{format};base64,{Convert.ToBase64String(buffer)}";
        imageDataUrls.Add(imageDataUrl);
      }
    }

    private async Task GetImageFromDb()
    {
      var format = "image/jpeg";
      var blob = await FileAppService.GetBlobAsync(new GetBlobRequestDto { Name = "MyImageNme.jpeg" });

      GetImage = $"data:{format};base64,{Convert.ToBase64String(blob.Content)}";

    }
  }
}

