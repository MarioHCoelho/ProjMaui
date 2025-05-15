using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Media;
namespace ProjMaui.Interfaces;

public interface ICameraService
{
    Task<FileResult> CapturePhotoAsync();
}