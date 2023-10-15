using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Lấy danh sách các ổ đĩa có sẵn trong hệ thống bằng cách sử dụng phương thức DriveInfo.GetDrives()
        DriveInfo[] drives = DriveInfo.GetDrives();
        // Duyệt qua từng ổ đĩa trong danh sách và hiển thị thông tin về mỗi ổ đĩa
        foreach (DriveInfo drive in drives)
        {
            Console.WriteLine("Ten o dia: " + drive.Name);
            Console.WriteLine("Loai o dia: " + drive.DriveType);
            Console.WriteLine("Dinh dang o dia: " + drive.DriveFormat);
            Console.WriteLine("Tong dung luong: " + ConvertBytesToGB(drive.TotalSize));
            Console.WriteLine("Dung luong con trong: " + ConvertBytesToGB(drive.AvailableFreeSpace));
            Console.WriteLine();

            // Hỏi người dùng có muốn tạo thư mục mới không
            Console.Write("Ban co muon tao thu muc moi khong? (Y/N): ");
            string createOption = Console.ReadLine();

            if (createOption.ToUpper() == "Y")
            {
                // Nhập tên thư mục mới
                Console.Write("Nhap ten thu muc moi: ");
                string newFolderName = Console.ReadLine();

                // Tao thu muc moi trong o dia
                string newFolderPath = Path.Combine(drive.Name, newFolderName);
                Directory.CreateDirectory(newFolderPath);
                Console.WriteLine("Da tao thu muc moi: " + newFolderPath);
            }

            // Hỏi người dùng có muốn đổi tên thư mục không
            Console.Write("Ban co muon doi ten thu muc khong? (Y/N): ");
            string renameOption = Console.ReadLine();

            if (renameOption.ToUpper() == "Y")
            {
                // Nhập tên thư mục muốn đổi
                Console.Write("Nhap ten thu muc muon doi ten: ");
                string oldFolderName = Console.ReadLine();

                // Nhập tên đổi thành
                Console.Write("Nhap ten moi: ");
                string newFolderName2 = Console.ReadLine();

                // Doi ten thu muc
                string oldFolderPath = Path.Combine(drive.Name, oldFolderName);
                string newFolderPath2 = Path.Combine(drive.Name, newFolderName2);
                Directory.Move(oldFolderPath, newFolderPath2);
                Console.WriteLine("Da doi ten thu muc: " + newFolderPath2);
            }

            Console.WriteLine();
        }
    }

    // Chuyển đổi từ byte sang GB, chỉ lấy 1 số sau dấu phẩy
    static string ConvertBytesToGB(long bytes)
    {
        double gbSize = (double)bytes / (1024 * 1024 * 1024);
        return gbSize.ToString("0.0");
    }
}