using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Khởi tạo danh sách các vật phẩm
        List<Item> items = new List<Item>
        {
            new Item { Value = 60, Weight = 10 },
            new Item { Value = 100, Weight = 20 },
            new Item { Value = 120, Weight = 30 }
        };

        // Thiết lập sức chứa của ba lô
        int capacity = 50;

        // Gọi hàm để tính giá trị tối đa và in kết quả
        double maxValue = GreedyKnapsack(capacity, items);
        Console.WriteLine("Gia tri toi da co the chua trong ba lô = " + maxValue);
    }

    // Định nghĩa lớp Item (Vật phẩm)
    public class Item
    {
        public int Value { get; set; }  // Giá trị của vật phẩm
        public int Weight { get; set; } // Trọng lượng của vật phẩm
        public double Ratio { get { return (double)Value / Weight; } } // Tỷ lệ giá trị trên trọng lượng
    }

    // Hàm giải quyết bài toán ba lô theo thuật toán tham lam
    public static double GreedyKnapsack(int capacity, List<Item> items)
    {
        // Sắp xếp các vật phẩm theo tỷ lệ giá trị trên trọng lượng giảm dần
        items.Sort((x, y) => y.Ratio.CompareTo(x.Ratio));

        double totalValue = 0;  // Tổng giá trị
        int currentWeight = 0;  // Trọng lượng hiện tại của ba lô

        foreach (var item in items)
        {
            if (currentWeight + item.Weight <= capacity)
            {
                // Nếu có thể thêm toàn bộ vật phẩm vào ba lô
                currentWeight += item.Weight;
                totalValue += item.Value;
            }
            else
            {
                // Nếu không thể thêm toàn bộ, thêm phần còn lại
                int remainingWeight = capacity - currentWeight;
                totalValue += item.Value * ((double)remainingWeight / item.Weight);
                break;
            }
        }

        return totalValue;  // Trả về tổng giá trị lớn nhất
    }
}
