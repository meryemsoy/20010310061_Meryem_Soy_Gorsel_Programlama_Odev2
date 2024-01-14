namespace MauiApp1;

public partial class HaberlerDetails : ContentPage
{
	Item haber;
	public HaberlerDetails(Item item)
	{
		InitializeComponent();
		haber = item;
		webView.Source = item.link;
	}

    private async void Share_Clicked(object sender, EventArgs e)
    {
		await ShareUri(haber.link, Share.Default);
    }

	public async Task ShareUri(string uri,IShare share)
	{
		await Share.RequestAsync(new ShareTextRequest
		{
			Uri = uri,
			Title= haber.title,
		}
			);
	}
}