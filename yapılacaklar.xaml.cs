using System.Collections.ObjectModel;

namespace MauiApp1;

public partial class yapılacaklar : ContentPage
{
    public ObservableCollection<TodoItem> Yapılacaklar { get; set; }

    public yapılacaklar()
	{
		InitializeComponent();
        Yapılacaklar = new ObservableCollection<TodoItem>();
        yapılacaklarListesi.ItemsSource = Yapılacaklar;
    }
    private void YapılacakEkle(object sender, EventArgs e)
    {
        string yeniYapılacak = yeniYapılacakEnty.Text;
        if (!string.IsNullOrEmpty(yeniYapılacak))
        {
            Yapılacaklar.Add(new TodoItem { İçerik = yeniYapılacak });
            yeniYapılacakEnty.Text = string.Empty;
            BindingContext = this;
        }
    }

    private void SilButton_Clicked(object sender, EventArgs e)
    {
        var selectedItems = Yapılacaklar.Where(item => item.Tamamlandı).ToList();
        foreach (var item in selectedItems)
        {
            Yapılacaklar.Remove(item);
        }
    }
    public class TodoItem
    {
        public string İçerik { get; set; }
        public bool Tamamlandı { get; set; }
    }
}