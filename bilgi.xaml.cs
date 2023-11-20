namespace MauiApp1;

public partial class bilgi : ContentPage
{
	public bilgi()
	{
		InitializeComponent();
	}
    void BoySlider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        double newValue = e.NewValue;
        int roundedValue = (int)Math.Round(newValue);
        boyLabel.Text = $"{newValue}cm";
    }

    void KiloSlider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        double newValue = e.NewValue;
        kiloLabel.Text = $"{newValue}kg";
    }
    private  void TamamButton_Clicked(object sender, EventArgs e)
	{
        DisplayAlert("Bilgi", "Bilgileriniz kaydedildi!", "OK");

        // Giriþ alanlarýný ve etiketleri sýfýrla
        entryad.Text = string.Empty;
        entrysoyad.Text = string.Empty;
        entrytelefon.Text = string.Empty;
        entrymail.Text = string.Empty;
        boyLabel.Text = "175cm";
        kiloLabel.Text = "50kg";
    }
}