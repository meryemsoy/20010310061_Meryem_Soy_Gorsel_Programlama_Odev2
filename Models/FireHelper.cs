using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MauiApp1.Models;

namespace MauiApp1.Models
{
        public class FireHelper
        {
            FirebaseClient Fire = new FirebaseClient("https://fireteat-1b189-default-rtdb.firebaseio.com/");


            public async Task<bool> Add(Model model)
            {
                var res = await Fire.Child("St").PostAsync(model);
                if (res != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public async Task<List<Model>> GetAll()
            {
                try
                {
                    var firebaseData = await Fire.Child("St").OnceAsync<Model>();

                    var res = firebaseData.Select(x => new Model
                    {
                        Gorev = x.Object.Gorev,
                        Detay = x.Object.Detay,
                        Tarih = x.Object.Tarih,
                        Saat = x.Object.Saat,
                        ID = x.Key
                    }).ToList();

                    return res;
                }
                catch (Exception ex)
                {
                    // Handle the exception, for example, log it or throw it again
                    Console.WriteLine($"Error retrieving data: {ex.Message}");
                    throw;
                }
            }

            public async void DeleteOne(string ID)
            {
                await Fire.Child("St").Child(ID).DeleteAsync();
            }

            public async void UpdateOne(string id, Model model)
            {
                await Fire.Child("St").Child(id).PutAsync<Model>(model);
            }

        }
       



}
