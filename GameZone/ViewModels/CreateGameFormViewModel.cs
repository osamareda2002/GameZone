using GameZone.Attributes;
using GameZone.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace GameZone.ViewModels
{
    public class CreateGameFormViewModel : GameFormViewModel
    {
        [AllowedExtensions(FileSettings.AllowedExtensions), MaxFileSize(FileSettings.MaxFileSizeInBytes)]
        public IFormFile Cover { get; set; } = default!;
    }
}
