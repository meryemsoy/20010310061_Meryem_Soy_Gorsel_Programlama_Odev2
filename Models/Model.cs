using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class Model : INotifyPropertyChanged
    {
        private string id;
        public string ID
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged(nameof(ID));
                }
            }
        }

        private string gorev;
        public string Gorev
        {
            get { return gorev; }
            set
            {
                if (gorev != value)
                {
                    gorev = value;
                    OnPropertyChanged(nameof(Gorev));
                }
            }
        }

        private string detay;
        public string Detay
        {
            get { return detay; }
            set
            {
                if (detay != value)
                {
                    detay = value;
                    OnPropertyChanged(nameof(Detay));
                }
            }
        }

        private string tarih;
        public string Tarih
        {
            get { return tarih; }
            set
            {
                if (tarih != value)
                {
                    tarih = value;
                    OnPropertyChanged(nameof(Tarih));
                }
            }
        }

        private string saat;
        public string Saat
        {
            get { return saat; }
            set
            {
                if (saat != value)
                {
                    saat = value;
                    OnPropertyChanged(nameof(Saat));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
