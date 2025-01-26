using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HashChecker
{
    public partial class UCMain : UserControl
    {
        public UCMain()
        {
            InitializeComponent();
            PopulateCB();
            DisableHash();
        }

        private void PopulateCB()
        {
            _cbHashType.Items.Clear();

            foreach (EHashType ht in typeof(EHashType).GetEnumValues())
            {
                _cbHashType.Items.Add(ht.ToString());
            }
        }

        private void _btnSelFile_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                Filter = "All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };


            if (ofd.ShowDialog() == DialogResult.OK)
            {
                RegisterFile(ofd.FileName);
            }
            else
            {
                _tbFileSel.Text = "";
                Console.WriteLine("No File Selected");
            }



        }


        private void RegisterFile(String fileName)
        {
            _tbFileSel.Text = fileName;
            Console.WriteLine($"Selected File: {fileName}");
        }

        private void DisableHash()
        {
            _rtbHash.Enabled = false;
            _rtbHash.ReadOnly = true;
            _lblEnterHash.Text = "...";
            _btnCompare.Enabled = false;
        }

        private void _cbHashType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cbHashType.SelectedIndex < 0)
            {
                DisableHash();
                return;

            }


            _rtbHash.Enabled = true;
            _rtbHash.ReadOnly = false;

            _btnCompare.Enabled = true;

            _lblEnterHash.Text = $"Enter {_cbHashType.Text} Hash Below";



        }

        private void _btnCompare_Click(object sender, EventArgs e)
        {
            string filePath = _tbFileSel.Text;

            try
            {
                HashAlgorithmName algo;
                EHashType hashType;
                if (!Enum.TryParse(_cbHashType.Text, out hashType))
                {
                    throw new Exception("Could not unparse selected hash type into enum");
                }

                switch (hashType)
                {
                    case EHashType.SHA256:
                        algo = HashAlgorithmName.SHA256;
                        break;
                    case EHashType.SHA512:
                        algo = HashAlgorithmName.SHA512;
                        break;
                    default: throw new NotImplementedException("Unknown Algo Type Selected");
                }

                string hash = ComputeFileHash(filePath, algo);
                if (hash == _rtbHash.Text.Replace(" ", "").Replace("\n", "").Replace("\t", "").Replace("\r", "").ToUpper())
                {
                    MessageBox.Show("Entered Hash Matches Hash From File", "Successful Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Entered Hash Does Not Match Hash From File!", "Error Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                //Console.WriteLine($"SHA256 Hash: {hash}");
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred: {ex.Message}");
            }
        }

        private string ComputeFileHash(string filePath, HashAlgorithmName hashAlgorithm)
        {
            // Validate file existence
            if (!File.Exists(filePath))
                throw new FileNotFoundException("The specified file does not exist.", filePath);

            // Create a file stream
            using (FileStream stream = File.OpenRead(filePath))
            {
                // Choose the appropriate hash algorithm
                using (HashAlgorithm hash = HashAlgorithm.Create(hashAlgorithm.Name))
                {
                    if (hash == null)
                        throw new InvalidOperationException($"Hash algorithm {hashAlgorithm.Name} is not supported.");

                    // Compute the hash
                    byte[] hashBytes = hash.ComputeHash(stream);

                    // Convert to a hex string
                    return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
                }
            }
        }
    }
}
