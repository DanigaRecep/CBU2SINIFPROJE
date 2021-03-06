﻿using System.Linq;
using System.Windows;
using System.Windows.Controls;

using CBU2SINIFPROJE.BLL.ExtensionMethods;
using CBU2SINIFPROJE.BLL.Interfaces;
using CBU2SINIFPROJE.Core.Enums;
using CBU2SINIFPROJE.Entities.Concrete;
using CBU2SINIFPROJE.ViewModels.OfficeWorker;

namespace CBU2SINIFPROJE.WPFUI.Windows
{
    /// <summary>
    /// Interaction logic for OfWWindow.xaml
    /// </summary>
    public partial class OfWWindow : Window
    {
        private readonly IGenericService<OfficeWorker> genericOfwService;
        public bool IsSaved { get; set; }
        public bool EditMode { get; set; }
        public OfWWindow(IGenericService<OfficeWorker> genericOfwService)
        {
            InitializeComponent();
            this.genericOfwService = genericOfwService;
            btn_Submit.Click += Btn_Submit_Click;
        }

        private void Btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            OfWAddModel model = DataContext.Cast<OfWAddModel>();
            if (!model.IsNull())
            {
                model.Position = int.Parse(cb_Positions.SelectedItem.Cast<ComboBoxItem>().Tag.Cast<string>()).Cast<Position>();
                OfficeWorker entity = new()
                {
                    Id = model.Id,
                    Position = model.Position,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Salary = model.Salary,
                    Adress = new(model.Adress.City, model.Adress.Town, model.Adress.AdressDetail)
                };
                if (EditMode)
                    genericOfwService.Update(entity);
                else
                    genericOfwService.Add(entity);
                IsSaved = true;
                MessageBox.Show("Kaydedildi");
                Close();
            }
        }
    }
}
