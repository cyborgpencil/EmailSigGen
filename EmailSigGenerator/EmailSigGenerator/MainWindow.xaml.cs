using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace EmailSigGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string defaultText =
                "Thank You.\n" +
                "\n(name) | (title) | (dept) | Mimbres Memorial Hospital & Nursing Home" +
                "\n900 W. Ash St, Deming, NM 88031 | Office: 575-546-5800 ext: (ext) | email: (first_last)@chs.net | http:// www.mimbresmemorial.com";

        string emailSuffix = "@chs.net";

        string phonePreffix = @"575-546-";
        string phoneExtension = "5800";

        public MainWindow()
        {
            InitializeComponent();

            LoadDefaultSig(@"Default Sig", @"\DefaultEmailSig.txt");

        }

        public void LoadDefaultSig(string foldername, string filename)
        {

            CreateDefaultFolders(foldername);
            CreateDefaultFile(foldername + filename);

            LoadSigIntoApp(foldername, filename);
        }

        public void CreateDefaultFolders(string foldername)
        {
            if (!Directory.Exists(foldername))
            {
                Directory.CreateDirectory(foldername);
            }
        }

        public void CreateDefaultFile(string defaultESig)
        {
            if (!File.Exists(defaultESig))
            {
                
                File.WriteAllText(defaultESig, defaultText);
            }
        }

        public void LoadSigIntoApp(string foldername, string filename)
        {
            string sig = File.ReadAllText(foldername + filename);
            txtBxSig.Text = sig;
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            SetEmail();
            SetExtention();
            Generate();
        }

        public void SetEmail()
        {
            if (txtbxEmail.IsEnabled == false)
            {
                string email = txtbxFirstName.Text.Trim() + "_" + txtbxLastName.Text.Trim() + emailSuffix.Trim();
                txtbxEmail.Text = email.Trim();
                txtbxEmail.Text.Trim();
            }
        }

        public void Generate()
        {
            defaultText =
                "Thank You.\n" +
                "\n"+ txtbxFirstName.Text + " " + txtbxLastName.Text + " | " + cbbxTitle.Text +" | " + cbbxDeparment.Text + " | Mimbres Memorial Hospital & Nursing Home" +
                "\n900 W. Ash St, Deming, NM 88031 | Office: "+ txtbxPhone.Text +" ext: " + phoneExtension + " | " + txtbxEmail.Text.Trim() + " | http:// www.mimbresmemorial.com";

            txtBxSig.Text = defaultText;
        }
       
        public void SetExtention()
        {
            if (txtbxPhone.IsEnabled == false)
            {
                switch (cbbxDeparment.Text)
                {
                    case "Administration":
                        phoneExtension = "5803";
                        break;
                    case "Accounting":
                        phoneExtension = "5857";
                        break;
                    case "Bio-Med":
                        phoneExtension = "1328";
                        break;
                    case "Case Management":
                        phoneExtension = "5887";
                        break;
                    case "Dietary":
                        phoneExtension = "5864";
                        break;
                    case "ER":
                        phoneExtension = "5881";
                        break;
                    case "Facilities":
                        phoneExtension = "1304";
                        break;
                    case "Maintainance":
                        phoneExtension = "6506";
                        break;
                    case "HR":
                        phoneExtension = "5867";
                        break;
                    case "IS":
                        phoneExtension = "5818";
                        break;
                    case "ICU":
                        phoneExtension = "5860";
                        break;
                    case "Lab":
                        phoneExtension = "5869";
                        break;
                    case "Materials":
                        phoneExtension = "5882";
                        break;
                    case "Medical Records":
                        phoneExtension = "5809";
                        break;
                    case @"Med/Surg":
                        phoneExtension = "5804";
                        break;
                    case "Nursing Admin":
                        phoneExtension = "5851";
                        break;
                    case "NH":
                        phoneExtension = "5886";
                        break;
                    case "OB":
                        phoneExtension = "5856";
                        break;
                    case "Rehab":
                        phoneExtension = "2291";
                        break;
                    case "Pharmacy":
                        phoneExtension = "5850";
                        break;
                    case "Quality":
                        phoneExtension = "5440";
                        break;
                    case "Radiology":
                        phoneExtension = "5872";
                        break;
                    case "Registration":
                        phoneExtension = "5879";
                        break;
                    case "Respiratory":
                        phoneExtension = "5868";
                        break;
                    case "Surgery":
                        phoneExtension = "5855";
                        break;
                    case "Clinic":
                        phoneExtension = "7200";
                        break;
                    default:
                        phoneExtension = "5800";
                        break;
                }
                txtbxPhone.Text = phonePreffix + phoneExtension;
            }
            
        }

        private void chbxEmailEnable_Click(object sender, RoutedEventArgs e)
        {
            if (chbxEmailEnable.IsChecked == true)
            {
                txtbxEmail.IsEnabled = true;
            }
            else
                txtbxEmail.IsEnabled = false;
        }

        private void chbxPhoneEnable_Click(object sender, RoutedEventArgs e)
        {
            if ( chbxPhoneEnable.IsChecked == true)
            {
                txtbxPhone.IsEnabled = true;
            }
            else
                txtbxPhone.IsEnabled = false;
        }


    }
}
