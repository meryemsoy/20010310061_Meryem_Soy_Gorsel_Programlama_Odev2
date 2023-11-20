namespace MauiApp1;

public partial class derssecimi : ContentPage
{
	public derssecimi()
	{
		InitializeComponent();
	}

    private async void KaydetButton_Clicked(object sender, EventArgs e)
    {
        string secilenDersler = "Seçilen dersler: \n";
        if (görsel.IsChecked)
            secilenDersler += "Görsel Programlama, \n ";
        if (mikro.IsChecked)
            secilenDersler += "Mikroiþlemciler, \n";
        if (makine.IsChecked)
            secilenDersler += "Makine Öðrenmesi, \n";
        if (analog.IsChecked)
            secilenDersler += "Analog Haberleþme, \n";
        if (sinyaller.IsChecked)
            secilenDersler += "Sinyaller ve Sistemler, \n";
        if (mühendislik.IsChecked)
            secilenDersler += "Mühendislik Bitirme, \n";

        if (!string.IsNullOrEmpty(secilenDersler))
        {
            secilenDersler = secilenDersler.Remove(secilenDersler.Length - 2); // Son virgülü kaldýrýn
            await DisplayAlert("Seçilen Dersler", secilenDersler, "OK");
        }
        else
        {
            await DisplayAlert("Uyarý", "Lütfen bir ders seçin.", "OK");
        }

        // DisplayAlert'ten sonra CheckBox'larý temizleyin
        görsel.IsChecked = false;
        mikro.IsChecked = false;
        makine.IsChecked = false;
        analog.IsChecked = false;
        sinyaller.IsChecked = false;
        mühendislik.IsChecked = false;
    }
}
