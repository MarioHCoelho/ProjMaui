using Microsoft.Maui.Controls;
using ProjMaui.Interfaces;

namespace ProjMaui;


public partial class MainPage : ContentPage
{
    private readonly ICameraService _cameraService;

    public MainPage(ICameraService cameraService)
    {
        InitializeComponent();
        _cameraService = cameraService;
    }

    private async void OnTakePhotoClicked(object? sender, EventArgs e)
    {
        try
        {
            //Verirfica e solicita permissões
            var status = await Permissions.CheckStatusAsync<Permissions.Camera>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.Camera>();
                if (status != PermissionStatus.Granted)
                {
                    await DisplayAlert("Permissão Negada", "Por favor garanta a permissão da cãmera para tirar fotos", "OK");
                    return;
                }
            }
            var photo = await _cameraService.CapturePhotoAsync();
            
            if (photo != null)
            {
                // Carrega a imagem para visualização
                var stream = await photo.OpenReadAsync();
                imagePreview.Source = ImageSource.FromStream(() => stream);
                lblStatus.Text = $"Foto capturada: {photo.FileName}";
            }
            
            
        }
        catch (Exception ex)
        {
            lblStatus.Text = $"Erro: {ex.Message}";
        }
    }
}