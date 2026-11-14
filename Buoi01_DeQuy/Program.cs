using System;

namespace Buoi01_DeQuy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("========================================");
            Console.WriteLine("   BÀI THỰC HÀNH BUỔI 01 - ĐỆ QUY");
            Console.WriteLine("   Sinh viên: Lê Chí Trường - MSV: 12425053");
            Console.WriteLine("========================================\n");

            Console.WriteLine("=== Bài 1: Tính tổng S(n) = 1 + 2 + ... + n ===");
            Bai1();
            Console.WriteLine();

            Console.WriteLine("=== Bài 2: Tính tổng bình phương S(n) = 1^2 + 2^2 + ... + n^2 ===");
            Bai2();
            Console.WriteLine();

            Console.WriteLine("=== Bài 3: Tính tổng nghịch đảo S(n) = 1 + 1/2 + ... + 1/n ===");
            Bai3();
            Console.WriteLine();

            Console.WriteLine("=== Bài 4: Tính lũy thừa x^n ===");
            Bai4();
            Console.WriteLine();

            Console.WriteLine("=== Bài 5: Tìm ước số lẻ lớn nhất của số nguyên dương n ===");
            Bai5();
            Console.WriteLine();

            Console.WriteLine("=== Bài 6: Tìm ước chung lớn nhất (Euclid) của a và b ===");
            Bai6();
            Console.WriteLine();

            Console.WriteLine("=== Bài 7: Đếm số lượng chữ số của số nguyên dương n ===");
            Bai7();
            Console.WriteLine();

            Console.WriteLine("=== Bài 8: Tính S(n) = sqrt(1 + sqrt(2 + ... + sqrt(n))) ===");
            Bai8();
            Console.WriteLine();

            Console.WriteLine("================ Hoàn thành ================");
        }

        // ==================== BÀI 1 ====================
        // Tính tổng S(n) = 1 + 2 + ... + n
        static int TongS1(int n)
        {
            if (n <= 0) return 0;
            return TongS1(n - 1) + n;
        }

        static void Bai1()
        {
            int n = ReadInt("Nhập số n", 5);
            Console.WriteLine($"Tổng S({n}) = 1 + 2 + ... + {n} là: {TongS1(n)}");
        }

        // ==================== BÀI 2 ====================
        // Tính tổng bình phương S(n) = 1^2 + 2^2 + ... + n^2
        static long TongBinhPhuong(int n)
        {
            if (n <= 1) return 1;
            return TongBinhPhuong(n - 1) + (long)n * n;
        }

        static void Bai2()
        {
            int n = ReadInt("Nhập n", 5);
            Console.WriteLine($"Tổng bình phương S({n}) = 1^2 + 2^2 + ... + {n}^2 là: {TongBinhPhuong(n)}");
        }

        // ==================== BÀI 3 ====================
        // Tính tổng nghịch đảo S(n) = 1 + 1/2 + 1/3 + ... + 1/n
        static double TongNghichDao(int n)
        {
            if (n <= 1) return 1.0;
            return TongNghichDao(n - 1) + 1.0 / n;
        }

        static void Bai3()
        {
            int n = ReadInt("Nhập n", 5);
            Console.WriteLine($"Tổng nghịch đảo S({n}) = 1 + 1/2 + ... + 1/{n} là: {TongNghichDao(n):F4}");
        }

        // ==================== BÀI 4 ====================
        // Tính lũy thừa x^n bằng đệ quy
        static double LuyThua(double x, int n)
        {
            if (n == 0) return 1;
            if (n > 0) return x * LuyThua(x, n - 1);
            return 1.0 / LuyThua(x, -n);
        }

        static void Bai4()
        {
            double x = ReadDouble("Nhập x", 2);
            int n = ReadInt("Nhập n", 3);
            Console.WriteLine($"Lũy thừa {x}^{n} là: {LuyThua(x, n)}");
        }

        // ==================== BÀI 5 ====================
        // Tìm ước số lẻ lớn nhất của số nguyên dương n
        static int UocLeLonNhat(int n)
        {
            if (n % 2 != 0) return n;
            return UocLeLonNhat(n / 2);
        }

        static void Bai5()
        {
            int n = ReadInt("Nhập n", 100);
            Console.WriteLine($"Ước số lẻ lớn nhất của {n} là: {UocLeLonNhat(n)}");
        }

        // ==================== BÀI 6 ====================
        // Tìm ước chung lớn nhất của a và b (thuật toán Euclid)
        static int UCLN(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            if (b == 0) return a;
            return UCLN(b, a % b);
        }

        static void Bai6()
        {
            int a = ReadInt("Nhập a", 48);
            int b = ReadInt("Nhập b", 18);
            Console.WriteLine($"Ước chung lớn nhất của {a} và {b} (Euclid) là: {UCLN(a, b)}");
        }

        // ==================== BÀI 7 ====================
        // Đếm số lượng chữ số của số nguyên dương n
        static int DemChuSo(int n)
        {
            n = Math.Abs(n);
            if (n < 10) return 1;
            return DemChuSo(n / 10) + 1;
        }

        static void Bai7()
        {
            int n = ReadInt("Nhập n", 12345);
            Console.WriteLine($"Số chữ số của {n} là: {DemChuSo(n)}");
        }

        // ==================== BÀI 8 ====================
        // Tính S(n) = sqrt(1 + sqrt(2 + ... + sqrt(n)))
        static double CanBacHai(int i, int n)
        {
            if (i == n) return Math.Sqrt(n);
            return Math.Sqrt(i + CanBacHai(i + 1, n));
        }

        static double TinhCan(int n)
        {
            if (n <= 0) return 0;
            return CanBacHai(1, n);
        }

        static void Bai8()
        {
            int n = ReadInt("Nhập n", 5);
            Console.WriteLine($"Kết quả S({n}) = sqrt(1 + sqrt(2 + ... + sqrt({n}))) là: {TinhCan(n):F6}");
        }

        // ==================== HÀM HỖ TRỢ NHẬP DỮ LIỆU ====================
        static int ReadInt(string prompt, int defaultValue)
        {
            Console.Write($"{prompt} (mặc định {defaultValue}): ");
            string? line = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
            {
                Console.WriteLine(defaultValue);
                return defaultValue;
            }
            if (int.TryParse(line.Trim(), out int val))
            {
                return val;
            }
            Console.WriteLine($"Giá trị nhập không hợp lệ, dùng giá trị mặc định: {defaultValue}");
            return defaultValue;
        }

        static double ReadDouble(string prompt, double defaultValue)
        {
            Console.Write($"{prompt} (mặc định {defaultValue}): ");
            string? line = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
            {
                Console.WriteLine(defaultValue);
                return defaultValue;
            }
            if (double.TryParse(line.Trim(), out double val))
            {
                return val;
            }
            Console.WriteLine($"Giá trị nhập không hợp lệ, dùng giá trị mặc định: {defaultValue}");
            return defaultValue;
        }
    }
}
