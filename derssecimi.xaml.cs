namespace MauiApp1;

public partial class derssecimi : ContentPage
{
	public derssecimi()
	{
		InitializeComponent();
	}

    private async void KaydetButton_Clicked(object sender, EventArgs e)
    {
        string secilenDersler = "Se�ilen dersler: \n";
        if (g�rsel.IsChecked)
            secilenDersler += "G�rsel Programlama, \n ";
        if (mikro.IsChecked)
            secilenDersler += "Mikroi�lemciler, \n";
        if (makine.IsChecked)
            secilenDersler += "Makine ��renmesi, \n";
        if (analog.IsChecked)
            secilenDersler += "Analog Haberle�me, \n";
        if (sinyaller.IsChecked)
            secilenDersler += "Sinyaller ve Sistemler, \n";
        if (m�hendislik.IsChecked)
            secilenDersler += "M�hendislik Bitirme, \n";

        if (!string.IsNullOrEmpty(secilenDersler))
        {
            secilenDersler = secilenDersler.Remove(secilenDersler.Length - 2); // Son virg�l� kald�r�n
            await DisplayAlert("Se�ilen Dersler", secilenDersler, "OK");
        }
        else
        {
            await DisplayAlert("Uyar�", "L�tfen bir ders se�in.", "OK");
        }

        // DisplayAlert'ten sonra CheckBox'lar� temizleyin
        g�rsel.IsChecked = false;
        mikro.IsChecked = false;
        makine.IsChecked = false;
        analog.IsChecked = false;
        sinyaller.IsChecked = false;
        m�hendislik.IsChecked = false;
    }
}
