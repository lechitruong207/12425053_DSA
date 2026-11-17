using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buoi02_DanhSach
{
    struct NhanVien
    {
        public string MaNV;
        public string Hoten;
        public int Namsinh;
        public string Phongban;
        public int LuongCB;
        public int Thuong;
        public int ThucLinh => LuongCB + Thuong;
    }

    class Node
    {
        public int Info;
        public Node Link;
        public Node(int info)
        {
            Info = info;
            Link = null;
        }
    }

    class DNode
    {
        public string Data;
        public DNode Prev;
        public DNode Next;
        public DNode(string data)
        {
            Data = data;
            Prev = null;
            Next = null;
        }
    }

    class Bai1
    {
        static int[] a = new int[] { 10, 20, 30, 40, 50 };

        static void CauA()
        {
            Console.Write("Nhập số phần tử n: ");
            int n = int.Parse(Console.ReadLine());
            a = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"a[{i}] = ");
                a[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Đã nhập xong mảng!");
        }

        static void CauB()
        {
            Console.Write("Danh sách hiện tại: ");
            for (int i = 0; i < a.Length; i++) Console.Write(a[i] + " ");
            Console.WriteLine();
        }

        static void CauC()
        {
            Console.Write("Nhập giá trị x cần chèn: ");
            int x = int.Parse(Console.ReadLine());
            Console.Write($"Nhập vị trí k cần chèn (0 -> {a.Length}): ");
            int k = int.Parse(Console.ReadLine());

            if (k >= 0 && k <= a.Length)
            {
                int[] tmp = new int[a.Length + 1];
                for (int i = 0; i < k; i++) tmp[i] = a[i];
                tmp[k] = x;
                for (int i = k; i < a.Length; i++) tmp[i + 1] = a[i];
                a = tmp;
                Console.WriteLine($"Đã chèn {x} vào vị trí {k}!");
                CauB();
            }
            else Console.WriteLine("Vị trí k không hợp lệ!");
        }

        public static void Run()
        {
            while (true)
            {
                Console.WriteLine("\n--- BÀI 1: MẢNG 1 CHIỀU ---");
                Console.WriteLine("a. Nhập danh sách từ bàn phím | b. Hiển thị | c. Chèn x vào vị trí k | 0. Quay lại");
                Console.Write("Chọn: ");
                switch (Console.ReadLine()?.ToLower())
                {
                    case "a": CauA(); break;
                    case "b": CauB(); break;
                    case "c": CauC(); break;
                    case "0": return;
                }
            }
        }
    }

    class Bai2
    {
        static NhanVien[] DS = new NhanVien[]
        {
            new NhanVien { MaNV = "NV01", Hoten = "Nguyễn Văn An", Namsinh = 1995, Phongban = "IT", LuongCB = 12000000, Thuong = 1500000 },
            new NhanVien { MaNV = "NV03", Hoten = "Trần Thị Bình", Namsinh = 1998, Phongban = "Kế toán", LuongCB = 8000000, Thuong = 1000000 },
            new NhanVien { MaNV = "NV02", Hoten = "Lê Hoàng Cường", Namsinh = 1996, Phongban = "IT", LuongCB = 8000000, Thuong = 2000000 },
            new NhanVien { MaNV = "NV04", Hoten = "Phạm Minh Dung", Namsinh = 1999, Phongban = "Nhân sự", LuongCB = 10000000, Thuong = 1200000 }
        };

        static int ThucLinh(int i) => DS[i].LuongCB + DS[i].Thuong;

        public static void Run()
        {
            while (true)
            {
                Console.WriteLine("\n--- BÀI 2: QUẢN LÝ NHÂN VIÊN ---");
                Console.WriteLine("a. Tổng thực lĩnh | b. Lương CB thấp nhất | c. Đếm thưởng >= 1.2tr | d. Sắp xếp | e. Tăng lương 5% | 0. Quay lại");
                Console.Write("Chọn: ");
                switch (Console.ReadLine()?.ToLower())
                {
                    case "a":
                        long tong = 0;
                        for (int i = 0; i < DS.Length; i++) tong += ThucLinh(i);
                        Console.WriteLine($"Tổng thực lĩnh: {tong:N0} VNĐ");
                        break;
                    case "b":
                        int minL = DS.Min(nv => nv.LuongCB);
                        Console.WriteLine($"Lương CB thấp nhất ({minL:N0} VNĐ):");
                        foreach (var nv in DS.Where(x => x.LuongCB == minL))
                            Console.WriteLine($" - {nv.MaNV} | {nv.Hoten} | {nv.Phongban}");
                        break;
                    case "c":
                        Console.WriteLine($"Số NV thưởng >= 1.200.000: {DS.Count(nv => nv.Thuong >= 1200000)}");
                        break;
                    case "d":
                        var sx = (NhanVien[])DS.Clone();
                        for (int i = 0; i < sx.Length - 1; i++)
                            for (int j = i + 1; j < sx.Length; j++)
                            {
                                int cmp = string.Compare(sx[i].Phongban, sx[j].Phongban, StringComparison.Ordinal);
                                if (cmp > 0 || (cmp == 0 && string.Compare(sx[i].MaNV, sx[j].MaNV, StringComparison.Ordinal) < 0))
                                { var t = sx[i]; sx[i] = sx[j]; sx[j] = t; }
                            }
                        foreach (var nv in sx) Console.WriteLine($" - {nv.Phongban,-8} | {nv.MaNV} | {nv.Hoten}");
                        break;
                    case "e":
                        for (int i = 0; i < DS.Length; i++)
                        {
                            DS[i].LuongCB = (int)(DS[i].LuongCB * 1.05);
                            Console.WriteLine($" - {DS[i].MaNV} | {DS[i].Hoten} | Lương CB mới: {DS[i].LuongCB:N0}");
                        }
                        break;
                    case "0": return;
                }
            }
        }
    }

    class Bai3
    {
        static int[,] a = { { 2, -4, 7 }, { 5, 6, 1 }, { 9, 3, 8 } };

        public static void Run()
        {
            int n = a.GetLength(0);
            while (true)
            {
                Console.WriteLine("\n--- BÀI 3: MA TRẬN VUÔNG ---");
                Console.WriteLine("a. Tổng phần tử | b. Dương nhỏ nhất | c. Tổng chéo phụ | d. Chéo chính tăng dần | 0. Quay lại");
                Console.Write("Chọn: ");
                switch (Console.ReadLine()?.ToLower())
                {
                    case "a":
                        int s = 0;
                        foreach (int x in a) s += x;
                        Console.WriteLine($"Tổng: {s}");
                        break;
                    case "b":
                        int minD = int.MaxValue;
                        foreach (int x in a) if (x > 0 && x < minD) minD = x;
                        Console.WriteLine($"Dương nhỏ nhất: {minD}");
                        break;
                    case "c":
                        int cp = 0;
                        for (int i = 0; i < n; i++) cp += a[i, n - 1 - i];
                        Console.WriteLine($"Tổng đường chéo phụ: {cp}");
                        break;
                    case "d":
                        bool tang = true;
                        for (int i = 0; i < n - 1; i++) if (a[i, i] >= a[i + 1, i + 1]) tang = false;
                        Console.WriteLine($"Đường chéo chính tăng dần: {tang}");
                        break;
                    case "0": return;
                }
            }
        }
    }

    class Bai4
    {
        public static void ThemCuoi(ref Node head, int val)
        {
            Node newNode = new Node(val);
            if (head == null) { head = newNode; return; }
            Node p = head;
            while (p.Link != null) p = p.Link;
            p.Link = newNode;
        }

        public static void InDSLK(Node head)
        {
            for (Node p = head; p != null; p = p.Link) Console.Write(p.Info + " -> ");
            Console.WriteLine("null");
        }

        public static void Run()
        {
            Node pHead = null;
            foreach (int v in new[] { 5, 12, 3, 12, 8, 20 }) ThemCuoi(ref pHead, v);
            while (true)
            {
                Console.Write("\n--- BÀI 4: DSLK ĐƠN (DƯƠNG) --- Danh sách: ");
                InDSLK(pHead);
                Console.WriteLine("a. Đếm số bằng x | b. Dương nhỏ nhất | c. Xóa x đầu tiên | 0. Quay lại");
                Console.Write("Chọn: ");
                switch (Console.ReadLine()?.ToLower())
                {
                    case "a":
                        Console.Write("Nhập x: "); int x1 = int.Parse(Console.ReadLine()), d = 0;
                        for (Node p = pHead; p != null; p = p.Link) if (p.Info == x1) d++;
                        Console.WriteLine($"Số lượng bằng {x1}: {d}");
                        break;
                    case "b":
                        int minD = int.MaxValue;
                        for (Node p = pHead; p != null; p = p.Link) if (p.Info > 0 && p.Info < minD) minD = p.Info;
                        Console.WriteLine($"Dương nhỏ nhất: {minD}");
                        break;
                    case "c":
                        Console.Write("Nhập x cần xóa: "); int x2 = int.Parse(Console.ReadLine());
                        Node curr = pHead, prev = null;
                        while (curr != null && curr.Info != x2) { prev = curr; curr = curr.Link; }
                        if (curr != null) { if (prev == null) pHead = curr.Link; else prev.Link = curr.Link; }
                        break;
                    case "0": return;
                }
            }
        }
    }

    class Bai5
    {
        static bool KTNT(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++) if (n % i == 0) return false;
            return true;
        }

        public static void Run()
        {
            Node l = null;
            foreach (int v in new[] { -5, 7, 0, 12, -3, 7, 2, 15 }) Bai4.ThemCuoi(ref l, v);
            while (true)
            {
                Console.Write("\n--- BÀI 5: DSLK ĐƠN (SỐ NGUYÊN) --- Danh sách: ");
                Bai4.InDSLK(l);
                Console.WriteLine("a. Max | b. Tổng | c. Đếm SNT | d. Âm/Dương/0 | e. Đếm x | f. Dương min | 0. Quay lại");
                Console.Write("Chọn: ");
                switch (Console.ReadLine()?.ToLower())
                {
                    case "a":
                        int max = int.MinValue;
                        for (Node p = l; p != null; p = p.Link) if (p.Info > max) max = p.Info;
                        Console.WriteLine($"Max: {max}");
                        break;
                    case "b":
                        int sum = 0;
                        for (Node p = l; p != null; p = p.Link) sum += p.Info;
                        Console.WriteLine($"Tổng: {sum}");
                        break;
                    case "c":
                        int nt = 0;
                        for (Node p = l; p != null; p = p.Link) if (KTNT(p.Info)) nt++;
                        Console.WriteLine($"Số nguyên tố: {nt}");
                        break;
                    case "d":
                        int am = 0, duong = 0, khong = 0;
                        for (Node p = l; p != null; p = p.Link)
                            if (p.Info < 0) am++; else if (p.Info > 0) duong++; else khong++;
                        Console.WriteLine($"Âm: {am}, Dương: {duong}, Số 0: {khong}");
                        break;
                    case "e":
                        Console.Write("Nhập x: "); int x = int.Parse(Console.ReadLine()), dx = 0;
                        for (Node p = l; p != null; p = p.Link) if (p.Info == x) dx++;
                        Console.WriteLine($"Số lượng bằng {x}: {dx}");
                        break;
                    case "f":
                        int minD = int.MaxValue;
                        for (Node p = l; p != null; p = p.Link) if (p.Info > 0 && p.Info < minD) minD = p.Info;
                        Console.WriteLine($"Dương nhỏ nhất: {minD}");
                        break;
                    case "0": return;
                }
            }
        }
    }

    class Bai7
    {
        public static void Run()
        {
            Console.WriteLine("\n--- BÀI 7: QUẢN LÝ NHIỆT ĐỘ ---");
            Console.Write("Nhập số ngày n (hoặc nhấn Enter để dùng mẫu 7 ngày): ");
            string inp = Console.ReadLine();
            double[] temps;

            if (string.IsNullOrWhiteSpace(inp))
                temps = new double[] { 28.5, 30.0, 32.2, 29.8, 27.0, 31.5, 33.0 };
            else
            {
                int n = int.Parse(inp);
                temps = new double[n];
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"Nhiệt độ ngày {i + 1}: ");
                    temps[i] = double.Parse(Console.ReadLine());
                }
            }

            double max = temps[0], min = temps[0], tong = 0;
            int ngayMax = 1, ngayMin = 1;
            for (int i = 0; i < temps.Length; i++)
            {
                tong += temps[i];
                if (temps[i] > max) { max = temps[i]; ngayMax = i + 1; }
                if (temps[i] < min) { min = temps[i]; ngayMin = i + 1; }
            }

            Console.WriteLine("Dữ liệu nhiệt độ: " + string.Join(", ", temps));
            Console.WriteLine($"- Ngày nhiệt độ cao nhất: Ngày {ngayMax} ({max}°C)");
            Console.WriteLine($"- Ngày nhiệt độ thấp nhất: Ngày {ngayMin} ({min}°C)");
            Console.WriteLine($"- Nhiệt độ trung bình: {(tong / temps.Length):F2}°C");
        }
    }

    class Bai8
    {
        public static void Run()
        {
            Console.WriteLine("\n--- BÀI 8: THỐNG KÊ TỪ ---");
            Console.Write("Nhập chuỗi văn bản (Enter để dùng mẫu): ");
            string text = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(text))
                text = "Học cấu trúc dữ liệu và giải thuật, học lập trình C# rất thú vị!";

            StringBuilder sb = new StringBuilder();
            foreach (char c in text.ToLower())
            {
                if (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)) sb.Append(c);
            }

            string[] words = sb.ToString().Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> freq = new Dictionary<string, int>();
            foreach (string w in words)
            {
                if (freq.ContainsKey(w)) freq[w]++;
                else freq[w] = 1;
            }

            Console.WriteLine($"Văn bản: \"{text}\"");
            Console.WriteLine("Tần suất xuất hiện của từng từ:");
            foreach (var item in freq.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($" - {item.Key,-15}: {item.Value} lần");
            }
        }
    }

    class Bai9
    {
        static bool LaSoNguyenTo(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++) if (n % i == 0) return false;
            return true;
        }

        static bool LaSoHoanHao(int n)
        {
            if (n <= 1) return false;
            int sum = 1;
            for (int i = 2; i <= n / 2; i++) if (n % i == 0) sum += i;
            return sum == n;
        }

        public static void Run()
        {
            Console.WriteLine("\n--- BÀI 9: XỬ LÝ SỐ NGUYÊN ---");
            Console.Write("Nhập dãy số nguyên cách nhau dấu cách (Enter dùng mẫu): ");
            string inp = Console.ReadLine();
            int[] arr = string.IsNullOrWhiteSpace(inp)
                ? new int[] { 2, 6, 7, 10, 13, 28, 15, 4, 29 }
                : inp.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Console.WriteLine("Dãy số: " + string.Join(" ", arr));
            Console.WriteLine("- Các số nguyên tố: " + string.Join(" ", arr.Where(LaSoNguyenTo)));
            Console.WriteLine("- Các số chẵn: " + string.Join(" ", arr.Where(x => x % 2 == 0)));
            Console.WriteLine("- Các số hoàn hảo: " + string.Join(" ", arr.Where(LaSoHoanHao)));
        }
    }

    class Bai10
    {
        public static void Run()
        {
            Console.WriteLine("\n--- BÀI 10: MA TRẬN XOẮN ỐC ---");
            int[,] mat = {
                {  1,  2,  3,  4 },
                {  5,  6,  7,  8 },
                {  9, 10, 11, 12 },
                { 13, 14, 15, 16 }
            };

            int m = mat.GetLength(0), n = mat.GetLength(1);
            Console.WriteLine("Ma trận gốc 4x4:");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++) Console.Write($"{mat[i, j],4}");
                Console.WriteLine();
            }

            int top = 0, bottom = m - 1, left = 0, right = n - 1;
            Console.Write("Duyệt xoắn ốc: ");
            while (top <= bottom && left <= right)
            {
                for (int i = left; i <= right; i++) Console.Write(mat[top, i] + " ");
                top++;

                for (int i = top; i <= bottom; i++) Console.Write(mat[i, right] + " ");
                right--;

                if (top <= bottom)
                {
                    for (int i = right; i >= left; i--) Console.Write(mat[bottom, i] + " ");
                    bottom--;
                }

                if (left <= right)
                {
                    for (int i = bottom; i >= top; i--) Console.Write(mat[i, left] + " ");
                    left++;
                }
            }
            Console.WriteLine();
        }
    }

    class Bai11
    {
        static bool LaMaTranDonVi(int[,] a)
        {
            int n = a.GetLength(0);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if ((i == j && a[i, j] != 1) || (i != j && a[i, j] != 0)) return false;
            return true;
        }

        static bool LaMaTranDoiXung(int[,] a)
        {
            int n = a.GetLength(0);
            for (int i = 0; i < n; i++)
                for (int j = i + 1; j < n; j++)
                    if (a[i, j] != a[j, i]) return false;
            return true;
        }

        public static void Run()
        {
            Console.WriteLine("\n--- BÀI 11: MA TRẬN ĐẶC BIỆT ---");
            int[,] m1 = { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
            int[,] m2 = { { 1, 2, 3 }, { 2, 4, 5 }, { 3, 5, 6 } };

            Console.WriteLine($"Ma trận 1 -> Đơn vị: {LaMaTranDonVi(m1)}, Đối xứng: {LaMaTranDoiXung(m1)}");
            Console.WriteLine($"Ma trận 2 -> Đơn vị: {LaMaTranDonVi(m2)}, Đối xứng: {LaMaTranDoiXung(m2)}");
        }
    }

    class Bai12
    {
        public static void Run()
        {
            Console.WriteLine("\n--- BÀI 12: GAME MINESWEEPER ---");
            Console.Write("Nhập số dòng m (mặc định 5): ");
            string sm = Console.ReadLine();
            int m = string.IsNullOrWhiteSpace(sm) ? 5 : int.Parse(sm);

            Console.Write("Nhập số cột n (mặc định 5): ");
            string sn = Console.ReadLine();
            int n = string.IsNullOrWhiteSpace(sn) ? 5 : int.Parse(sn);

            int soMin = (m * n) / 5;
            char[,] board = new char[m, n];
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++) board[i, j] = '.';

            Random rnd = new Random();
            int placed = 0;
            while (placed < soMin)
            {
                int r = rnd.Next(m), c = rnd.Next(n);
                if (board[r, c] != '*') { board[r, c] = '*'; placed++; }
            }

            int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

            Console.WriteLine($"Bảng Minesweeper {m}x{n} ({soMin} mìn):");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (board[i, j] == '*') Console.Write(" * ");
                    else
                    {
                        int count = 0;
                        for (int k = 0; k < 8; k++)
                        {
                            int ni = i + dx[k], nj = j + dy[k];
                            if (ni >= 0 && ni < m && nj >= 0 && nj < n && board[ni, nj] == '*') count++;
                        }
                        Console.Write($" {count} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }

    class Bai13
    {
        static Node DaoNguoc(Node head)
        {
            Node prev = null, current = head, next = null;
            while (current != null)
            {
                next = current.Link;
                current.Link = prev;
                prev = current;
                current = next;
            }
            return prev;
        }

        public static void Run()
        {
            Console.WriteLine("\n--- BÀI 13: ĐẢO NGƯỢC DSLK ĐƠN ---");
            Node head = null;
            foreach (int x in new[] { 10, 20, 30, 40, 50 }) Bai4.ThemCuoi(ref head, x);

            Console.Write("Ban đầu:   "); Bai4.InDSLK(head);
            head = DaoNguoc(head);
            Console.Write("Đảo ngược: "); Bai4.InDSLK(head);
        }
    }

    class Bai14
    {
        static Node GopHaiDSLK(Node l1, Node l2)
        {
            Node dummy = new Node(0);
            Node tail = dummy;

            while (l1 != null && l2 != null)
            {
                if (l1.Info <= l2.Info)
                {
                    tail.Link = l1;
                    l1 = l1.Link;
                }
                else
                {
                    tail.Link = l2;
                    l2 = l2.Link;
                }
                tail = tail.Link;
            }
            tail.Link = (l1 != null) ? l1 : l2;
            return dummy.Link;
        }

        public static void Run()
        {
            Console.WriteLine("\n--- BÀI 14: GỘP HAI DSLK ĐÃ SẮP XẾP ---");
            Node l1 = null, l2 = null;
            foreach (int x in new[] { 1, 4, 7, 10 }) Bai4.ThemCuoi(ref l1, x);
            foreach (int x in new[] { 2, 3, 6, 8, 12 }) Bai4.ThemCuoi(ref l2, x);

            Console.Write("Danh sách 1: "); Bai4.InDSLK(l1);
            Console.Write("Danh sách 2: "); Bai4.InDSLK(l2);
            Node merged = GopHaiDSLK(l1, l2);
            Console.Write("Sau khi gộp: "); Bai4.InDSLK(merged);
        }
    }

    class Bai15
    {
        static bool CoChuTrinh(Node head)
        {
            Node slow = head, fast = head;
            while (fast != null && fast.Link != null)
            {
                slow = slow.Link;
                fast = fast.Link.Link;
                if (slow == fast) return true;
            }
            return false;
        }

        public static void Run()
        {
            Console.WriteLine("\n--- BÀI 15: PHÁT HIỆN CHU TRÌNH (FLOYD) ---");
            Node n2 = new Node(2), n3 = new Node(3), n4 = new Node(4), n5 = new Node(5), n6 = new Node(6);
            n2.Link = n3; n3.Link = n4; n4.Link = n5; n5.Link = n6; n6.Link = n2;

            Node listThuong = null;
            foreach (int x in new[] { 1, 2, 3, 4 }) Bai4.ThemCuoi(ref listThuong, x);

            Console.WriteLine($"Danh sách 1 (2->3->4->5->6->2) có chu trình: {CoChuTrinh(n2)}");
            Console.WriteLine($"Danh sách 2 (1->2->3->4->null) có chu trình: {CoChuTrinh(listThuong)}");
        }
    }

    class Bai16
    {
        public static void Run()
        {
            Console.WriteLine("\n--- BÀI 16: LỊCH SỬ DUYỆT WEB ---");
            DNode current = new DNode("google.com");

            void Visit(string url)
            {
                DNode newNode = new DNode(url);
                current.Next = newNode;
                newNode.Prev = current;
                current = newNode;
                Console.WriteLine($"Truy cập: {current.Data}");
            }

            Visit("github.com");
            Visit("utehy.edu.vn");

            while (true)
            {
                Console.WriteLine($"\nTrang hiện tại: [{current.Data}]");
                Console.WriteLine("1. Truy cập trang mới | 2. Back | 3. Forward | 0. Quay lại");
                Console.Write("Chọn: ");
                string c = Console.ReadLine();
                if (c == "1") { Console.Write("Nhập URL: "); Visit(Console.ReadLine()); }
                else if (c == "2")
                {
                    if (current.Prev != null) { current = current.Prev; Console.WriteLine($"Back -> {current.Data}"); }
                    else Console.WriteLine("Không thể Back thêm!");
                }
                else if (c == "3")
                {
                    if (current.Next != null) { current = current.Next; Console.WriteLine($"Forward -> {current.Data}"); }
                    else Console.WriteLine("Không thể Forward thêm!");
                }
                else if (c == "0") return;
            }
        }
    }

    class Bai17
    {
        public static void Run()
        {
            Console.WriteLine("\n--- BÀI 17: PLAYLIST NHẠC ---");
            DNode head = null, tail = null, current = null;

            void ThemBai(string ten)
            {
                DNode node = new DNode(ten);
                if (head == null) { head = tail = current = node; }
                else { tail.Next = node; node.Prev = tail; tail = node; }
            }

            ThemBai("Lạc Trôi - Sơn Tùng M-TP");
            ThemBai("Nàng Thơ - Hoàng Dũng");
            ThemBai("Cắt Đôi Nỗi Sầu - Tăng Duy Tân");

            while (true)
            {
                Console.WriteLine($"\nĐang phát: {(current != null ? current.Data : "Trống")}");
                Console.WriteLine("1. Next | 2. Previous | 3. Thêm bài | 4. Xóa bài đang phát | 0. Quay lại");
                Console.Write("Chọn: ");
                string c = Console.ReadLine();
                if (c == "1")
                {
                    if (current?.Next != null) current = current.Next;
                    else Console.WriteLine("Đã ở cuối playlist!");
                }
                else if (c == "2")
                {
                    if (current?.Prev != null) current = current.Prev;
                    else Console.WriteLine("Đã ở đầu playlist!");
                }
                else if (c == "3")
                {
                    Console.Write("Tên bài hát: "); ThemBai(Console.ReadLine());
                    Console.WriteLine("Đã thêm vào cuối playlist!");
                }
                else if (c == "4" && current != null)
                {
                    Console.WriteLine($"Đã xóa: {current.Data}");
                    if (current.Prev != null) current.Prev.Next = current.Next; else head = current.Next;
                    if (current.Next != null) current.Next.Prev = current.Prev; else tail = current.Prev;
                    current = current.Next ?? current.Prev;
                }
                else if (c == "0") return;
            }
        }
    }

    class Bai18
    {
        public static void Run()
        {
            Console.WriteLine("\n--- BÀI 18: HỆ THỐNG ĐẶT HÀNG ---");
            DNode s1 = new DNode("Chờ xử lý");
            DNode s2 = new DNode("Đang giao");
            DNode s3 = new DNode("Hoàn thành");
            s1.Next = s2; s2.Prev = s1;
            s2.Next = s3; s3.Prev = s2;

            DNode trangThaiHienTai = s1;
            string maDon = "DH_12425044";

            while (true)
            {
                Console.WriteLine($"\nĐơn hàng [{maDon}] - Trạng thái hiện tại: >>> {trangThaiHienTai.Data} <<<");
                Console.WriteLine("1. Chuyển trạng thái tiếp theo | 2. Lùi lại trạng thái trước | 0. Quay lại");
                Console.Write("Chọn: ");
                string c = Console.ReadLine();
                if (c == "1")
                {
                    if (trangThaiHienTai.Next != null) trangThaiHienTai = trangThaiHienTai.Next;
                    else Console.WriteLine("Đơn hàng đã hoàn thành!");
                }
                else if (c == "2")
                {
                    if (trangThaiHienTai.Prev != null) trangThaiHienTai = trangThaiHienTai.Prev;
                    else Console.WriteLine("Đơn hàng đang ở trạng thái ban đầu!");
                }
                else if (c == "0") return;
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            while (true)
            {
                Console.WriteLine("\n================ BUỔI 02: MẢNG & DANH SÁCH LIÊN KẾT ================");
                Console.WriteLine("  [Phần 1: Bài tập cơ bản]");
                Console.WriteLine("   1. Bài 1 : Mảng 1 chiều (Nhập, hiển thị, chèn x)");
                Console.WriteLine("   2. Bài 2 : Quản lý nhân viên (Struct)");
                Console.WriteLine("   3. Bài 3 : Ma trận vuông");
                Console.WriteLine("   4. Bài 4 : DSLK đơn số nguyên dương");
                Console.WriteLine("   5. Bài 5 : DSLK đơn số nguyên");
                Console.WriteLine("  [Phần 2: Bài tập tự thực hành]");
                Console.WriteLine("   7. Bài 7 : Quản lý nhiệt độ");
                Console.WriteLine("   8. Bài 8 : Thống kê tần suất từ");
                Console.WriteLine("   9. Bài 9 : Xử lý số nguyên (SNT, Chẵn, Hoàn hảo)");
                Console.WriteLine("  10. Bài 10: Ma trận xoắn ốc");
                Console.WriteLine("  11. Bài 11: Ma trận đặc biệt (Đơn vị & Đối xứng)");
                Console.WriteLine("  12. Bài 12: Game Minesweeper");
                Console.WriteLine("  13. Bài 13: Đảo ngược danh sách liên kết đơn");
                Console.WriteLine("  14. Bài 14: Gộp hai danh sách liên kết đã sắp xếp");
                Console.WriteLine("  15. Bài 15: Phát hiện chu trình (Floyd Rùa & Thỏ)");
                Console.WriteLine("  16. Bài 16: Hệ thống lịch sử duyệt web (DSLK kép)");
                Console.WriteLine("  17. Bài 17: Playlist nhạc (DSLK kép)");
                Console.WriteLine("  18. Bài 18: Hệ thống đặt hàng (DSLK kép)");
                Console.WriteLine("   0. Thoát");
                Console.Write("Chọn số thứ tự bài muốn chạy: ");

                switch (Console.ReadLine())
                {
                    case "1": Bai1.Run(); break;
                    case "2": Bai2.Run(); break;
                    case "3": Bai3.Run(); break;
                    case "4": Bai4.Run(); break;
                    case "5": Bai5.Run(); break;
                    case "7": Bai7.Run(); break;
                    case "8": Bai8.Run(); break;
                    case "9": Bai9.Run(); break;
                    case "10": Bai10.Run(); break;
                    case "11": Bai11.Run(); break;
                    case "12": Bai12.Run(); break;
                    case "13": Bai13.Run(); break;
                    case "14": Bai14.Run(); break;
                    case "15": Bai15.Run(); break;
                    case "16": Bai16.Run(); break;
                    case "17": Bai17.Run(); break;
                    case "18": Bai18.Run(); break;
                    case "0": return;
                    default: Console.WriteLine("Lựa chọn không hợp lệ!"); break;
                }
            }
        }
    }
}
