namespace MauiApp1;

public partial class nothesabı : ContentPage
{
    int not1, not2, not3;
    float ort;
    public nothesabı()
    {
        InitializeComponent();
    }
    private void Button_Clicked(object sender, EventArgs e)
    {
        if (int.TryParse(entrynot1.Text, out not1) &&
            int.TryParse(entrynot2.Text, out not2) &&
            int.TryParse(entrynot3.Text, out not3))
        {
            // Calculate the average
            ort = (not1 + not2 + not3) / 3.0f;

            // Get the entered name and surname
            string ad = entryad.Text;
            string soyad = entrysoyad.Text;

            // Show the alert without awaiting the result
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await DisplayAlert("Notunuz:", $"Ad Soyad: {ad} {soyad}\nOrtalamanız: {ort}", "OK", "Cancel");

                // Process the result based on the user's choice
                if (result)
                {
                    entryad.Text = string.Empty;
                    entrysoyad.Text = string.Empty;
                    entrynot1.Text = string.Empty;
                    entrynot2.Text = string.Empty;
                    entrynot3.Text = string.Empty;
                }
                else
                {
                    // If Cancel is pressed, keep the current state
                }
            });
        }
        else
        {
            // Display an alert if parsing fails
            DisplayAlert("Hata", "Lütfen geçerli notlar giriniz.", "OK");
        }
    }
}