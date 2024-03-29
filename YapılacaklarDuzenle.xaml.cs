using System;
using Microsoft.Maui.Controls;
using MauiApp1.Models;

namespace MauiApp1
{
    public partial class YapılacaklarDuzenle : ContentPage
    {
        private Yapilacak task;
        private yapılacaklar parentPage;

    
        public YapılacaklarDuzenle(Yapilacak task, yapılacaklar parent)
        {
            InitializeComponent();
            // Initialize with default values or bind to a view model if necessary
     
            parentPage = parent;
            this.task = task ?? new Yapilacak();
            this.parentPage = parent;

            // Populate the fields with the existing task data
            txtGorev.Text = this.task.Gorev;
            txtDetay.Text = this.task.Detay;
            //DateTarih.Date = DateTime.Parse(this.task.Tarih);
            txtSaat.Text = this.task.Saat;

        }

        private async void OkClicked(object sender, EventArgs e)
        {
            var task = new Model
            {
                Gorev = txtGorev.Text,
                Detay = txtDetay.Text,
                Tarih = DateTarih.Date.ToString("d"),
                Saat = txtSaat.Text
            };

            var fireHelper = new FireHelper();
            await fireHelper.Add(task);

            await DisplayAlert("Başarılı", "Görev kaydedildi.", "OK");
            await Navigation.PopAsync();
        }

        private async void CancelClicked(object sender, EventArgs e)
        {
            // Logic to handle the "İptal" button click
            // Usually, you just pop the page without saving anything

            await Navigation.PopAsync();
        }
    }

    // Assuming you have a model class for your task
   
}
