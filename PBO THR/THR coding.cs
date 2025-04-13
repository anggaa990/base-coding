using System;

namespace SistemManajemenKaryawan
{
    // Kelas Induk
    public class Karyawan
    {
        private string nama;
        private string id;
        private double gajiPokok;

        public string Nama
        {
            get { return nama; }
            set { nama = value; }
        }

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public double GajiPokok
        {
            get { return gajiPokok; }
            set { gajiPokok = value; }
        }

        public virtual double HitungGaji()
        {
            return gajiPokok;
        }
    }

    // Karyawan Tetap
    public class KaryawanTetap : Karyawan
    {
        private const double BonusTetap = 500000;

        public override double HitungGaji()
        {
            return GajiPokok + BonusTetap;
        }
    }

    // Karyawan Kontrak
    public class KaryawanKontrak : Karyawan
    {
        private const double PotonganKontrak = 200000;

        public override double HitungGaji()
        {
            return GajiPokok - PotonganKontrak;
        }
    }

    // Karyawan Magang
    public class KaryawanMagang : Karyawan
    {
        public override double HitungGaji()
        {
            return GajiPokok;
        }
    }

    // Program Utama
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Masukkan jenis karyawan (Tetap/Kontrak/Magang): ");
            string jenis = Console.ReadLine().Trim().ToLower();

            Console.Write("Masukkan Nama: ");
            string nama = Console.ReadLine();

            Console.Write("Masukkan ID: ");
            string id = Console.ReadLine();

            Console.Write("Masukkan Gaji Pokok: ");
            double gajiPokok = Convert.ToDouble(Console.ReadLine());

            Karyawan karyawan;

            switch (jenis)
            {
                case "tetap":
                    karyawan = new KaryawanTetap();
                    break;
                case "kontrak":
                    karyawan = new KaryawanKontrak();
                    break;
                case "magang":
                    karyawan = new KaryawanMagang();
                    break;
                default:
                    Console.WriteLine("Jenis karyawan tidak dikenali.");
                    return;
            }

            karyawan.Nama = nama;
            karyawan.ID = id;
            karyawan.GajiPokok = gajiPokok;

            Console.WriteLine("\nData Karyawan:");
            Console.WriteLine("Nama       : " + karyawan.Nama);
            Console.WriteLine("ID         : " + karyawan.ID);
            Console.WriteLine("Gaji Pokok : " + karyawan.GajiPokok);
            Console.WriteLine("Gaji Akhir : " + karyawan.HitungGaji());
        }
    }
}
