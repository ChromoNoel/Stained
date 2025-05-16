using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Stained
{
    public class Berlo
    {
        public string PersonalID;
        public string Name;
        public DateOnly Dateofbirth;
        public int PostalCode;
        public string City;
        public string Address;
        public string County;

        public Berlo(string id, string name, string dob, string post, string city, string address, string county)
        {
            PersonalID = id;
            Name = name;
            Dateofbirth = DateOnly.Parse(dob);
            PostalCode = Convert.ToInt32(post);
            City = city;
            Address = address;
            County = county;
        }
    }

    public class Laptop
    {
        public string Invnumber;
        public string Model;
        public int RAM;
        public string Color;

        public Laptop(string invnumber, string model, string rAM, string color)
        {
            Invnumber = invnumber;
            Model = model;
            RAM = Convert.ToInt32(rAM);
            Color = color;
        }

        public override string ToString()
        {
            return $"{Invnumber} {Model} {Color}";
        }
    }
    public class Berles
    {
        public Berlo berlo;
        public Laptop laptop;
        public int DailyFee;
        public int Deposit;
        public DateOnly StartDate;
        public DateOnly EndDate;
        public bool UseDeposit;
        public double Uptime;

        public Berles(string Line)
        {
            string[] line = Line.Split(";");
            berlo = new Berlo(
                line[0], line[1], line[2], line[3], line[4], line[5], line[8]
            );
            laptop = new Laptop(
                line[6], line[7], line[9], line[10]
            );
            DailyFee = Convert.ToInt32(line[11]);
            Deposit = Convert.ToInt32(line[12]);
            StartDate = DateOnly.Parse(line[13]);
            EndDate = DateOnly.Parse(line[14]);
            UseDeposit = Convert.ToBoolean(Convert.ToInt32(line[15]));
            Uptime = Convert.ToDouble(line[16]);
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Berles> berlesek = new List<Berles>();
            StreamReader reader = new StreamReader("laptoprentals2022.csv");
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                berlesek.Add(new Berles(reader.ReadLine()));
            }

            var leltarNums = berlesek.Select((Berles berles) => berles.laptop.Invnumber).Distinct();
            foreach (string leltarNum in leltarNums)
            {
                leltariszamlista.Items.Add(leltarNum);
            }
        }

        
    }
}