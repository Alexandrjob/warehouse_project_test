using System;
using System.Collections.Generic;
using System.Linq;

namespace WarehouseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pallet> pallets = GenerateSampleData();

            Console.WriteLine("--- Все паллеты, сгруппированные по сроку годности и отсортированные ---");
            var groupedPallets = pallets
                .GroupBy(p => p.ExpirationDate.Date)
                .OrderBy(g => g.Key)
                .ToList();

            foreach (var group in groupedPallets)
            {
                Console.WriteLine($"\nСрок годности: {group.Key:dd.MM.yyyy}");
                var sortedGroup = group.OrderBy(p => p.Weight).ToList();
                foreach (var pallet in sortedGroup)
                {
                    Console.WriteLine($"  Паллета ID: {pallet.Id.ToString().Substring(0, 8)}, Вес: {pallet.Weight:F2}кг, Объем: {pallet.Volume:F2}м³, Срок годности: {pallet.ExpirationDate:dd.MM.yyyy}");
                    foreach (var box in pallet.Boxes)
                    {
                        Console.WriteLine($"    Коробка ID: {box.Id.ToString().Substring(0, 8)}, Вес: {box.Weight:F2}кг, Объем: {box.Volume:F2}м³, Срок годности: {box.ExpirationDate:dd.MM.yyyy}");
                    }
                }
            }

            Console.WriteLine("\n--- 3 паллеты с наибольшим сроком годности, отсортированные по объему ---");
            var top3Pallets = pallets
                .OrderByDescending(p => p.ExpirationDate)
                .Take(3)
                .OrderBy(p => p.Volume)
                .ToList();

            foreach (var pallet in top3Pallets)
            {
                Console.WriteLine($"  Паллета ID: {pallet.Id.ToString().Substring(0, 8)}, Вес: {pallet.Weight:F2}кг, Объем: {pallet.Volume:F2}м³, Срок годности: {pallet.ExpirationDate:dd.MM.yyyy}");
                    foreach (var box in pallet.Boxes)
                    {
                        Console.WriteLine($"    Коробка ID: {box.Id.ToString().Substring(0, 8)}, Вес: {box.Weight:F2}кг, Объем: {box.Volume:F2}м³, Срок годности: {box.ExpirationDate:dd.MM.yyyy}");
                    }
            }
        }

        static List<Pallet> GenerateSampleData()
        {
            List<Pallet> pallets = new List<Pallet>();

            Pallet pallet1 = new Pallet(100, 100, 100);
            pallet1.AddBox(new Box(20, 20, 20, 5, expirationDate: new DateTime(2025, 7, 1)));
            pallet1.AddBox(new Box(30, 30, 30, 10, expirationDate: new DateTime(2025, 7, 5)));
            pallets.Add(pallet1);

            Pallet pallet2 = new Pallet(120, 120, 120);
            pallet2.AddBox(new Box(40, 40, 40, 15, productionDate: new DateTime(2025, 6, 1)));
            pallet2.AddBox(new Box(25, 25, 25, 8, productionDate: new DateTime(2025, 6, 10)));
            pallets.Add(pallet2);

            Pallet pallet3 = new Pallet(90, 90, 90);
            pallet3.AddBox(new Box(15, 15, 15, 3, productionDate: new DateTime(2025, 7, 1)));
            pallet3.AddBox(new Box(20, 20, 20, 7, productionDate: new DateTime(2025, 7, 5)));
            pallets.Add(pallet3);

            Pallet pallet4 = new Pallet(110, 110, 110);
            pallet4.AddBox(new Box(35, 35, 35, 12, expirationDate: new DateTime(2025, 8, 15)));
            pallets.Add(pallet4);

            Pallet pallet5 = new Pallet(130, 130, 130);
            pallet5.AddBox(new Box(50, 50, 50, 20, productionDate: new DateTime(2025, 8, 1)));
            pallets.Add(pallet5);

            return pallets;
        }
    }
}