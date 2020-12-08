# Blob Storing using Blob Storing Database Provider

## Create a new Project

```bash
abp new AbpBlobStoreDatabase -u blazor
```

## Adding Blob Storing Module

Open a command prompt (terminal) in the folder containing your solution (.sln) file and run the following command:

```bash
abp add-module Volo.Abp.BlobStoring.Database
```

This action will add the module dependencies and also module migration. After this action, run FileActionsDemo.DbMigrator to update the database.

## Setting up Blob Storage

BLOB Storage system works with Containers. Before we can use blob storage, we need to create our blob container.

Create a class  **MyFileContainer.cs** at the **AbpBlobStoreDatabase.Domain** project.

```csharp
using Volo.Abp.BlobStoring;

namespace AbpBlobStoreDatabase
{
    [BlobContainerName("my-file-container")]
    public class MyFileContainer
    {

    }
}
```

## Create Application Layer

Before the creating Application Service, we need to create some DTOs that used by Application Service.

Create following DTOs in **AbpBlobStoreDatabase.Application.Contracts** project.

*BlobDto

```csharp
namespace AbpBlobStoreDatabase
{
    public class BlobDto
    {
        public byte[] Content { get; set; }

        public string Name { get; set; }
    }
}
```

* GetBlobRequestDto

```csharp
using System.ComponentModel.DataAnnotations;

namespace AbpBlobStoreDatabase
{
    public class GetBlobRequestDto
    {
        [Required]
        public string Name { get; set; } 
    }
}
```

* SaveBlobInputDto

```csharp
using System.ComponentModel.DataAnnotations;

namespace AbpBlobStoreDatabase
{
    public class SaveBlobInputDto
    {
        public byte[] Content { get; set; }
        [Required] 
        public string Name { get; set; }
    }
}
```

* Create **IFileAppService** interface in the **Application.Contracts** project.

```csharp
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AbpBlobStoreDatabase
{
    public interface IFileAppService  : IApplicationService
    {
        Task SaveBlobAsync(SaveBlobInputDto input);
        Task<BlobDto> GetBlobAsync(GetBlobRequestDto input);
    }
}
```

* Open a command prompt in the **Application** project and run the command below.
  
```bash
dotnet add package volo.abp.blobstoring
```

* Create **FileAppService** class in the **Application** project.

```csharp
using System.Threading.Tasks;
using AbpBlobStoreDatabase.Domain;
using Volo.Abp.Application.Services;
using Volo.Abp.BlobStoring;

namespace AbpBlobStoreDatabase
{
  public class FileAppService : ApplicationService, IFileAppService
  {
    private readonly IBlobContainer<MyFileContainer> _fileContainer;

    public FileAppService(IBlobContainer<MyFileContainer> fileContainer)
    {
      _fileContainer = fileContainer;
    }

    public async Task<BlobDto> GetBlobAsync(GetBlobRequestDto input)
    {
      var blob = await _fileContainer.GetAllBytesAsync(input.Name);
      return new BlobDto { Name = input.Name, Content = blob };

    }

    public async Task SaveBlobAsync(SaveBlobInputDto input)
    {
      await _fileContainer.SaveAsync(input.Name, input.Content, true);
    }
  }
}
```

As you see in previous code block, we inject **IBlobContainer\<MyFileContainer\>** to our app service. It will handle all blob actions.

* **SaveBlobAsync** method uses **SaveAsync** of **IBlobContainer\<MyFileContainer\>** to save the given blob to the database, this is a simple example so we don't check is there any file exist with same name. We sent blob name, blob content and true for overrideExisting parameter.

* **GetBlobAsync** method is uses **GetAllBytesAsync** of **IBlobContainer\<MyFileContainer\>** to get blob content from the database by name.

## Create User Interface

* Index.razor

```html
@page "/"
<Row Class="mb-4">
    <Column ColumnSize="ColumnSize.Is6">
        <h3>Save Image To Database</h3>
        <p>
            <InputFile OnChange="@OnInputFileChange" />
        </p>
        @if (imageDataUrls.Count > 0)
        {
            <h4>Images</h4>
            <div class="card" style="width:30rem;">
                <div class="card-body">
                    @foreach (var imageDataUrl in imageDataUrls)
                    {
                        <img class="rounded m-1" src="@imageDataUrl" />
                    }
                </div>
            </div>
        }
    </Column>
</Row>
<hr>
<Row Class="mb-4">
    <Column ColumnSize="ColumnSize.Is6">
        <h3>Get Image From Database</h3>
        <div class="card" style="width:30rem;">
            <div class="card-body">
                <img class="rounded m-1" src="@GetImage" />
            </div>
            <div class="card-footer">
                <button class="btn btn-primary" @onclick="@GetImageFromDb">GetImage</button>
            </div>
        </div>
    </Column>
</Row>
```

* Index.razor.cs

```csharp
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
```
