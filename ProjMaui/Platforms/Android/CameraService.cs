using Android.Content;
using Android.Provider;
using Microsoft.Maui.ApplicationModel;
using ProjMaui.Interfaces;

namespace CameraApp.Platforms.Android;

public class CameraService : ICameraService
{
    public async Task<FileResult> CapturePhotoAsync()
    {
        try
        {
            var photo = await MediaPicker.CapturePhotoAsync();
            return photo;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao capturar foto: {ex.Message}");
            throw;
        }
    }
}