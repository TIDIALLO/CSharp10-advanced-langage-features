﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using WarehouseManagementSystem.Business;
using WarehouseManagementSystem.Domain;

namespace WarehouseManagementSystem.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public OrderProcessor Processor { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            PopulateGrid();

            Processor = new();
        }
        private void PopulateGrid()
        {
            #region Load the orders
            IEnumerable<Order> orders =
                JsonSerializer.Deserialize<Order[]>(
                    File.ReadAllText("orders.json")
                )!;
            #endregion

            var summaries = orders.Select(order =>
            {
                return new
                {
                    Order = order.OrderNumber,
                    Items = order.LineItems.Count(),
                    Total = order.LineItems.Sum(item => item.Price),
                    order.IsReadyForShipment
                };
            });

            var orderedSummaries =
                summaries.OrderBy(summary => summary.Total);

            Orders.ItemsSource = orderedSummaries;
        }
        private void ProcessOrder_Click(object sender, 
            RoutedEventArgs e)
        {
            foreach(var bitmap in LoadImages())
            {
                using (bitmap)
                {
                    Debug.WriteLine($"{bitmap.Size}");
                }
            }



            //// Order is now an anonymous type!
            //var order = Orders.SelectedItem as Order ?? new();

            //var receipt = new ReceiptWindow(Processor);
            //receipt.Owner = this;
            //receipt.Show();

            //Processor.Process(order);
        }

        public IEnumerable<Bitmap> LoadImages()
        {
            foreach(var file in Directory.GetFiles("albums"))
            {
                var data = File.ReadAllBytes(file);

                using var stream = new MemoryStream(data);

                yield return new Bitmap(stream);
            }
        }
    }
}
