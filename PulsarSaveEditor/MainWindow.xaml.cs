using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace PulsarSaveEditor
{
    public partial class MainWindow : Window
    {
        private PulsarSaveFile pulsarFile;
        private int savedGalaxySeed;
        private int savedCurrentSectorID;
        private int savedCU_REP;
        private int savedAOG_REP;
        private int savedWD_REP;
        private int savedFB_REP;
        private int savedInfected_REP;
        private float savedHull;
        private int savedFBCrates;
        private int savedResearchMaterial_00;
        private int savedResearchMaterial_01;
        private int savedResearchMaterial_02;
        private int savedResearchMaterial_03;
        private int savedResearchMaterial_04;
        private int savedResearchMaterial_05;
        private int savedAtomizerItem;
        private int savedAtomizerItemLevel;
        private int StatStroke;
        private int Stats;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.CheckFileExists = true;
            openFileDialog.Multiselect = false;
            openFileDialog.Title = "Pick a PULSAR: Lost Colony save file.";

            openFileDialog.Filter = "PULSAR: Lost Colony save file|*.plsave";

            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                OpenFileName.Text = openFileDialog.FileName;
                pulsarFile = new PulsarSaveFile(openFileDialog.FileName);

                savedGalaxySeed = pulsarFile.GalaxySeed;
                CrewCredits_Text.Text = pulsarFile.CrewCredits.ToString();
                CrewLevel_Text.Text = pulsarFile.CrewLevel.ToString();
                CrewXP_Text.Text = pulsarFile.CrewXP.ToString();
                savedCurrentSectorID = pulsarFile.CurrentSectorID;
                IronMode_Checker.IsChecked = pulsarFile.IronmanMode;
                UpgradeMaterials_Text.Text = pulsarFile.UpgradeMaterials.ToString();
                savedCU_REP = pulsarFile.CU_REP;
                savedAOG_REP = pulsarFile.AOG_REP;
                savedWD_REP = pulsarFile.WD_REP;
                savedFB_REP = pulsarFile.FB_REP;
                savedInfected_REP = pulsarFile.Infected_REP;
                Fuel_Text.Text = pulsarFile.Fuel.ToString();
                savedHull = pulsarFile.Hull;
                savedFBCrates = pulsarFile.FBCrates;
                CoolantLevel_Text.Text = pulsarFile.CoolantLevel.ToString();
                ChaosLevel_Text.Text = pulsarFile.ChaosLevel.ToString();
                savedResearchMaterial_00 = pulsarFile.ResearchMaterial_00;
                savedResearchMaterial_01 = pulsarFile.ResearchMaterial_01;
                savedResearchMaterial_02 = pulsarFile.ResearchMaterial_02;
                savedResearchMaterial_03 = pulsarFile.ResearchMaterial_03;
                savedResearchMaterial_04 = pulsarFile.ResearchMaterial_04;
                savedResearchMaterial_05 = pulsarFile.ResearchMaterial_05;
                savedAtomizerItem = pulsarFile.AtomizerItem;
                savedAtomizerItemLevel = pulsarFile.AtomizerItemLevel;
            }
        }

        private void SaveAsButton_Click(object sender, RoutedEventArgs e)
        {
            if (pulsarFile != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.Title = "Save the new PULSAR: Lost Colony save file (must be different from the selected one).";

                saveFileDialog.Filter = "PULSAR: Lost Colony save file|*.plsave";

                saveFileDialog.InitialDirectory = pulsarFile.openFilePath;

                saveFileDialog.FileName = pulsarFile.openFilePath;

                bool? result = saveFileDialog.ShowDialog();
                if (result == true)
                {
                    if (pulsarFile != null)
                    {
                        pulsarFile.SaveAs(saveFileDialog.FileName,
                        savedGalaxySeed,
                        int.Parse(CrewCredits_Text.Text),
                        int.Parse(CrewLevel_Text.Text),
                        int.Parse(CrewXP_Text.Text),
                        savedCurrentSectorID,
                        (bool)IronMode_Checker.IsChecked,
                        int.Parse(UpgradeMaterials_Text.Text),
                        savedCU_REP,
                        savedAOG_REP,
                        savedWD_REP,
                        savedFB_REP,
                        savedInfected_REP,
                        int.Parse(Fuel_Text.Text),
                        savedHull,
                        savedFBCrates,
                        float.Parse(CoolantLevel_Text.Text),
                        float.Parse(ChaosLevel_Text.Text),
                        savedResearchMaterial_00,
                        savedResearchMaterial_01,
                        savedResearchMaterial_02,
                        savedResearchMaterial_03,
                        savedResearchMaterial_04,
                        savedResearchMaterial_05,
                        savedAtomizerItem,
                        savedAtomizerItemLevel);
                    }
                }
            }
            else
            {
                MessageBox.Show("You have to open a file first.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ChangeValue_Click(object sender, RoutedEventArgs e)
        {
            switch (StatStroke)
            {
                case 0:
                    savedCU_REP = int.Parse(Stat_00.Text);
                    savedAOG_REP = int.Parse(Stat_01.Text);
                    savedWD_REP = int.Parse(Stat_02.Text);
                    savedFB_REP = int.Parse(Stat_03.Text);
                    savedInfected_REP = int.Parse(Stat_04.Text);
                    break;
                case 1:
                    savedResearchMaterial_00 = int.Parse(Stat_00.Text);
                    savedResearchMaterial_01 = int.Parse(Stat_01.Text);
                    savedResearchMaterial_02 = int.Parse(Stat_02.Text);
                    savedResearchMaterial_03 = int.Parse(Stat_03.Text);
                    savedResearchMaterial_04 = int.Parse(Stat_04.Text);
                    savedResearchMaterial_05 = int.Parse(Stat_05.Text);
                    break;
                case 2:
                    savedGalaxySeed = int.Parse(Stat_00.Text);
                    savedCurrentSectorID = int.Parse(Stat_01.Text);
                    savedHull = int.Parse(Stat_02.Text);
                    savedFBCrates = int.Parse(Stat_03.Text);
                    savedAtomizerItem = int.Parse(Stat_04.Text);
                    savedAtomizerItemLevel = int.Parse(Stat_05.Text);
                    break;
                default:
                    break;
            }
        }

        private void TypeSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TypeSelector.SelectedIndex == 0)
            {
                StatStroke = 0;
                StatName_00.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF000000"));
                StatName_00.Text = "C.U.";
                Stat_00.Text = savedCU_REP.ToString();

                StatName_01.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF000000"));
                StatName_01.Text = "A.O.G.";
                Stat_01.Text = savedAOG_REP.ToString();

                StatName_02.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF000000"));
                StatName_02.Text = "W.D.";
                Stat_02.Text = savedWD_REP.ToString();

                StatName_03.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF000000"));
                StatName_03.Text = "F.B.";
                Stat_03.Text = savedFB_REP.ToString();

                StatName_04.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF000000"));
                StatName_04.Text = "Infected";
                Stat_04.Text = savedInfected_REP.ToString();
                Stats = 4;
            }
            if (TypeSelector.SelectedIndex == 1)
            {
                StatStroke = 1;
                StatName_00.Text = "";
                StatName_00.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4493BD"));
                StatName_00.Inlines.Add(new Bold(new Run("Stamans")));
                Stat_00.Text = savedResearchMaterial_00.ToString();

                StatName_01.Text = "";
                StatName_01.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#977C4F"));
                StatName_01.Inlines.Add(new Bold(new Run("Aedificiates")));
                Stat_01.Text = savedResearchMaterial_01.ToString();

                StatName_02.Text = "";
                StatName_02.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF70A56E"));
                StatName_02.Inlines.Add(new Bold(new Run("Aevameres")));
                Stat_02.Text = savedResearchMaterial_02.ToString();

                StatName_03.Text = "";
                StatName_03.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF732968"));
                StatName_03.Inlines.Add(new Bold(new Run("Sensusites")));
                Stat_03.Text = savedResearchMaterial_03.ToString();

                StatName_04.Text = "";
                StatName_04.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFAAA3A3"));
                StatName_04.Inlines.Add(new Bold(new Run("Mutoumates")));
                Stat_04.Text = savedResearchMaterial_04.ToString();

                StatName_05.Text = "";
                StatName_05.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF000000"));
                StatName_05.Inlines.Add(new Bold(new Run("Vortosites")));
                Stat_05.Text = savedResearchMaterial_05.ToString();
                Stats = 5;
            }
            if (TypeSelector.SelectedIndex == 2)
            {

                StatStroke = 2;
                StatName_00.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF000000"));
                StatName_00.Text = "Galaxy Seed";
                Stat_00.Text = savedGalaxySeed.ToString();

                StatName_01.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF000000"));
                StatName_01.Text = "Current Sector ID";
                Stat_01.Text = savedCurrentSectorID.ToString();

                StatName_02.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF000000"));
                StatName_02.Text = "Hull";
                Stat_02.Text = savedHull.ToString();

                StatName_03.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF000000"));
                StatName_03.Text = "F.B. Crates";
                Stat_03.Text = savedFBCrates.ToString();

                StatName_04.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF000000"));
                StatName_04.Text = "Atomizer Item";
                Stat_04.Text = savedAtomizerItem.ToString();

                StatName_05.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF000000"));
                StatName_05.Text = "Atomizer Item Level";
                Stat_05.Text = savedAtomizerItemLevel.ToString();
                Stats = 5;
            }
            StatName_00.Visibility = 0;
            Stat_00.Visibility = 0;
            StatName_01.Visibility = 0;
            Stat_01.Visibility = 0;
            StatName_02.Visibility = 0;
            Stat_02.Visibility = 0;
            StatName_03.Visibility = 0;
            Stat_03.Visibility = 0;
            if (Stats >= 4)
            {
                StatName_04.Visibility = 0;
                Stat_04.Visibility = 0;
            }
            else
            {
                StatName_04.Visibility = Visibility.Hidden;
                Stat_04.Visibility = Visibility.Hidden; ;
            }
            if (Stats == 5)
            {
                StatName_05.Visibility = 0;
                Stat_05.Visibility = 0;
            }
            else
            {
                StatName_05.Visibility = Visibility.Hidden;
                Stat_05.Visibility = Visibility.Hidden;
            }
        }
    }
}