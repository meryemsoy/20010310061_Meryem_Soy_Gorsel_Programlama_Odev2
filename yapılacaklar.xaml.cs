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
            Navigation.PushAsync(new YapılacaklarDuzenle(new Yapilacak(), this));
            // Navigate to a new page to add a task
            
        }
        private string deletedItemId;
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
                    ID = item.ID,
                    Gorev = item.Gorev,
                    Detay = item.Detay,
                    Tarih = item.Tarih,
                    Saat = item.Saat
                });
            }

            // Koleksiyonu güncelledikten sonra silinen öğeyi tekrar kontrol et
            var deletedItem = Items.FirstOrDefault(t => t.ID == deletedItemId); // Silinen öğenin ID'sini belirlemeniz gerekiyor
            if (deletedItem != null)
            {
                Items.Remove(deletedItem);
                Console.WriteLine($"Deleted task with ID: {deletedItemId}");
            }
        }

        private void YapılacakDuzenle_Clicked(object sender, EventArgs e)
        {
            // Cast sender to ImageButton to access the CommandParameter
            var button = sender as ImageButton;
            var taskId = button.CommandParameter.ToString();

            // Find the task to edit
            var selectedTask = Items.FirstOrDefault(t => t.ID == taskId);

            if (selectedTask != null)
            {
                // Navigate to a new page to edit the task with the given ID
                Navigation.PushAsync(new YapılacaklarDuzenle(   selectedTask, this));
            }
            else
            {
                Console.WriteLine($"Task with ID {taskId} not found for editing.");
            }
        }

        private  async void YapılacakSil_Clicked(object sender, EventArgs e)
        {
            // Cast sender to ImageButton to access the CommandParameter
            var button = sender as ImageButton;
            var taskId = button.CommandParameter.ToString();

            // Confirm with the user and delete the task with the given ID
            var toDelete = Items.FirstOrDefault(t => t.ID == taskId.ToString());
            if (toDelete != null)
            {
                // Silme işlemi başarılı bir şekilde gerçekleşiyor mu?
                var fireHelper = new FireHelper();
                fireHelper.DeleteOne(taskId);

                // Koleksiyondan da sil
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

