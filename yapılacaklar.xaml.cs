using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using Firebase.Database;
using Firebase.Database.Query;
using MauiApp1.Models;

namespace MauiApp1
{
    public partial class yapılacaklar : ContentPage
    {
        public ObservableCollection<Yapilacak> Items { get; private set; }
        private FirebaseClient firebaseClient;
        public yapılacaklar()
        {
            InitializeComponent();

            Items = new ObservableCollection<Yapilacak>
            {
                // Example item
               // new Yapilacak { ID = 1, Gorev = "Örnek Görev", Detay = "Detaylar burada", Tarih = "6/7/2023", Saat = "11:00 AM" }
            };
            firebaseClient = new FirebaseClient("https://fireteat-1b189-default-rtdb.firebaseio.com/");
            listyapılacaklar.ItemsSource = Items;
        }

        private void YapılacakEkle_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new YapılacaklarDuzenle());
            // Navigate to a new page to add a task
            
        }

        private async void YapılacakYukle_Clicked(object sender, EventArgs e)
        {
            var fireHelper = new FireHelper();
            var dataFromFirebase = await fireHelper.GetAll();

            // Update the ObservableCollection with data from Firebase
            Items.Clear();
            foreach (var item in dataFromFirebase)
            {
                Items.Add(new Yapilacak
                {
                    ID =    item.ID,
                    Gorev = item.Gorev,
                    Detay = item.Detay,
                    Tarih = item.Tarih,
                    Saat =  item.Saat
                });
            }
        }

        private void YapılacakDuzenle_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new YapılacaklarDuzenle());
            // Cast sender to ImageButton to access the CommandParameter
            var button = sender as ImageButton;
            var taskId = (int)button.CommandParameter;

            // Navigate to a new page to edit the task with the given ID
            Console.WriteLine($"Edit task with ID: {taskId}");
        }

        private void YapılacakSil_Clicked(object sender, EventArgs e)
        {
            // Cast sender to ImageButton to access the CommandParameter
            var button = sender as ImageButton;
            var taskId = (int)button.CommandParameter;

            // Confirm with the user and delete the task with the given ID
            var toDelete = Items.FirstOrDefault(t => t.ID == taskId.ToString());
            if (toDelete != null)
            {
                Items.Remove(toDelete);
                Console.WriteLine($"Deleted task with ID: {taskId}");
            }
        }

    }

    public class Yapilacak
    {
        public string ID { get; set; }
        public string Gorev { get; set; }
        public string Detay { get; set; }
        public string Tarih { get; set; }
        public string Saat { get; set; }
    }
   
}

