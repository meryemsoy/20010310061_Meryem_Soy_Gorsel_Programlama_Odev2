using MauiApp1.Models;

using System.Collections.ObjectModel;
using System.Text.Json;
namespace MauiApp1;

public partial class hava_durumu : ContentPage
{
    public hava_durumu() 
    { 
        InitializeComponent();
        if (File.Exists(fileName))
        {
            string data = File.ReadAllText(fileName);
            Sehirler =JsonSerializer.Deserialize<ObservableCollection<SehirlerHavaDurumu>>(data);
        }
        else
        {
            Sehirler.Add(new SehirlerHavaDurumu() { Name = "BARTIN" });
        }

        listCity.ItemsSource = Sehirler;
        
    }
    string fileName = Path.Combine(FileSystem.Current.AppDataDirectory, "hdata.json");
    ObservableCollection<SehirlerHavaDurumu> Sehirler = new ObservableCollection<SehirlerHavaDurumu>();
    private async void Ekle_Clicked(object sender, EventArgs e)
    {
        string sehir = await DisplayPromptAsync("Şehir:", "Şehir ismi", "OK", "Cancel");
        sehir = sehir.ToUpper(System.Globalization.CultureInfo.CurrentCulture);
        sehir = sehir.Replace('Ç', 'C');
        sehir = sehir.Replace('Ğ', 'G');
        sehir = sehir.Replace('İ', 'I');
        sehir = sehir.Replace('Ö', 'O');
        sehir = sehir.Replace('Ü', 'U');
        sehir = sehir.Replace('Ş', 'S');

        Sehirler.Add(new SehirlerHavaDurumu() { Name =sehir});
        string data = JsonSerializer.Serialize(Sehirler);
        File.WriteAllText(fileName, data);
       
    }

    public void Yukle_Clicked(object sender, EventArgs e)
    {
        refreshView.IsRefreshing = true;
    }
    public async void Sil_Clicked(object sender, EventArgs e)
    {
        var button = sender as ImageButton;

        if (button != null)
        {
            var info = Sehirler.First(o => o.Name == button.CommandParameter.ToString());
            var control = await DisplayAlert("Silinsin mi ?", "Silmeyi onayla", "Tamam", "Iptal");

            if (control)
            {
                Sehirler.Remove(info);
                string data = System.Text.Json.JsonSerializer.Serialize(Sehirler);
                File.WriteAllText(fileName, data);
            }
        }
    }
    private void refreshView_Refreshing(object sender, EventArgs e)
    {
        refreshView.IsRefreshing = true;
    }
}
public class SehirHavaDurumu
{
    public string Name { get; set; }

    public string Source => $"https://www.mgm.gov.tr/sunum/tahmin-klasik-5070.aspx?m={Name}&basla=1&bitir=5&rC=111&rZ=fff";
}