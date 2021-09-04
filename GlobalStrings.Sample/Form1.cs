using System;
using GlobalStrings;
using System.Windows.Forms;
using GlobalStrings.Sample.Strings;
using System.Drawing;
using GlobalStrings.Util.Types;

namespace GlobalStrings.Sample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Languages.Init();
            Globalization.Globalization<string, int, string>.GetGlobalizationInstance().LangTextObserver += Form1_LangTextObserver;
            Globalization.Globalization<string, int, string>.GetGlobalizationInstance().StartGlobalization();
            Load += (_, _) => cmbLanguages.SelectedIndex = 0;
        }

        private void Form1_LangTextObserver(object sender, UpdateModeEventArgs updateModeEventArgs)
        {
            btnSizeDemo.Size = updateModeEventArgs.lang switch
            {
                "pt_br" => new Size(200, 23),
                "en" => new Size(190, 23)
            };
            lblTextPlaceholder.Text = Globalization.Globalization<string, int, string>.GetGlobalizationInstance().SetText("Home", 0);
            btnChangeLang.Text = Globalization.Globalization<string, int, string>.GetGlobalizationInstance().SetText("Home", 1);
            btnSizeDemo.Text = Globalization.Globalization<string, int, string>.GetGlobalizationInstance().SetText("Home", 2);
        }

        private void btnChangeLang_Click(object sender, EventArgs e)
        {
            string keyLang = cmbLanguages.SelectedItem.ToString() == "Português (Brasil)" ? "pt_br" : "en";

            Globalization.Globalization<string, int, string>.GetGlobalizationInstance().UpdateLang(keyLang);
        }
    }
}
