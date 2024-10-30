using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;

namespace QLDAXayDung
{
    internal static class Program
    {
        public static int maTK = 0;
        public static string password = "";
        public static string connectionString = "Data Source=DESKTOP-LENCOKI;Initial Catalog=TTCSN;Integrated Security=True;Encrypt=False;";
        public static bool KiemTraGiaTri<T>(T trongSo, List<T> danhSach)
        {
            return !danhSach.Contains(trongSo);
        }
        [STAThread]
        static void Main()
        {
            // Set the license context for EPPlus
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new fLogin());
        }
    }
}
