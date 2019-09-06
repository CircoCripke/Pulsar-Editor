using System;
using System.IO;
using System.Windows;

namespace PulsarSaveEditor
{
    class PulsarSaveFile
    {
        public string openFilePath;
        public int SaveVerID;
        public int GalaxySeed;
        public int CrewCredits;
        public int CrewLevel;
        public int CrewXP;
        public int CurrentSectorID;
        public bool IronmanMode;
        public int UpgradeMaterials;
        public int CU_REP;
        public int AOG_REP;
        public int WD_REP;
        public int FB_REP;
        public int Infected_REP;
        public int Fuel;
        public float Hull;
        public int FBCrates;
        public float CoolantLevel;
        public float ChaosLevel;
        public int ResearchMaterial_00;
        public int ResearchMaterial_01;
        public int ResearchMaterial_02;
        public int ResearchMaterial_03;
        public int ResearchMaterial_04;
        public int ResearchMaterial_05;
        public int AtomizerItem;
        public int AtomizerItemLevel;

        public PulsarSaveFile(string path)
        {
            openFilePath = path;

            FileStream fs = File.Open(openFilePath, FileMode.Open);
            StreamReader encoding = new StreamReader(fs, true);
            BinaryReader br = new BinaryReader(fs, encoding.CurrentEncoding);

            try
            {
                SaveVerID = br.ReadInt32();
                br.ReadInt32();
                br.ReadInt64();
                GalaxySeed = br.ReadInt32();
                br.ReadSingle();
                CrewCredits = br.ReadInt32();
                CrewLevel = br.ReadInt32();
                CrewXP = br.ReadInt32();
                CurrentSectorID = br.ReadInt32();
                IronmanMode = br.ReadBoolean();
                if (SaveVerID >= 30)
                {
                    br.ReadInt32();
                }
                if (SaveVerID >= 33)
                {
                    br.ReadBoolean();
                }
                if (SaveVerID >= 33)
                {
                    br.ReadInt32();
                }
                if (SaveVerID >= 31)
                {
                    br.ReadBoolean();
                }
                if (SaveVerID >= 38)
                {
                    UpgradeMaterials = br.ReadInt32();
                }
                if (SaveVerID >= 39)
                {
                    br.ReadInt32();
                }
                CU_REP = br.ReadInt32();
                AOG_REP = br.ReadInt32();
                WD_REP = br.ReadInt32();
                FB_REP = br.ReadInt32();
                Infected_REP = br.ReadInt32();
                if (SaveVerID >= 32)
                {
                    br.ReadBoolean();
                }
                if (SaveVerID >= 44)
                {
                    br.ReadBoolean();
                    br.ReadInt32();
                    br.ReadInt32();
                    br.ReadInt32();
                }
                //Storm
                if (SaveVerID >= 42)
                {
                    br.ReadSingle();
                    br.ReadSingle();
                    br.ReadSingle();
                }
                //Race
                if (SaveVerID >= 37)
                {
                    br.ReadInt32();
                    br.ReadInt32();
                    br.ReadInt32();
                }
                br.ReadString();
                br.ReadString();
                br.ReadInt32();
                Fuel = br.ReadInt32();
                Hull = br.ReadSingle();
                if (SaveVerID >= 30)
                {
                    FBCrates = br.ReadInt32();
                }
                CoolantLevel = br.ReadSingle();
                //Ship Data
                if (SaveVerID >= 32)
                {
                    int count = br.ReadInt32();
                    br.ReadBytes(count);
                }
                //Components
                int NumComponents = br.ReadInt32();
                for (int i = 0; i < NumComponents; i++)
                {
                    br.ReadUInt32();
                    br.ReadInt32();
                    br.ReadInt16();
                }
                if (SaveVerID > 29)
                {
                    int num3 = br.ReadInt32();
                    for (int j = 0; j < num3; j++)
                    {
                        br.ReadUInt32();
                        br.ReadSingle();
                        br.ReadSingle();
                        br.ReadSingle();
                    }
                }
                //Locker
                for (int k = 0; k < 5; k++)
                {
                    int num4 = br.ReadInt32();
                    for (int l = 0; l < num4; l++)
                    {
                        br.ReadInt32();
                        br.ReadInt32();
                        br.ReadInt32();
                    }
                }
                //Factions
                int num5 = br.ReadInt32();
                for (int m = 0; m < num5; m++)
                {
                    br.ReadInt32();
                    br.ReadSingle();
                    br.ReadSingle();
                }
                ChaosLevel = br.ReadSingle();
                br.ReadInt64();
                br.ReadInt64();
                br.ReadInt32();
                br.ReadInt32();
                ResearchMaterial_00 = br.ReadInt32();
                ResearchMaterial_01 = br.ReadInt32();
                ResearchMaterial_02 = br.ReadInt32();
                ResearchMaterial_03 = br.ReadInt32();
                ResearchMaterial_04 = br.ReadInt32();
                ResearchMaterial_05 = br.ReadInt32();
                int num6 = br.ReadInt32();
                //Atomizer Items
                for (int n = 0; n < num6; n++)
                {
                    AtomizerItem = br.ReadInt32();
                    br.ReadInt32();
                    AtomizerItemLevel = br.ReadInt32();
                }
            }
            catch (EndOfStreamException eose)
            {

            }
            finally
            {
                br.Close();
                encoding.Close();
                fs.Close();
            }
        }

        internal void SaveAs(string fileName, int newGalaxySeed, int newCrewCredits, int newCrewLevel, int newCrewXP, int newCurrentSectorID,
            bool newIronmanMode, int newUpgradeMaterials, int newCU_REP, int newAOG_REP, int newWD_REP, int newFB_REP, int newInfected_REP,
            int newFuel, float newHull, int newFBCrates, float newCoolantLevel, float newChaosLevel, int newResearchMaterial_00,
            int newResearchMaterial_01, int newResearchMaterial_02, int newResearchMaterial_03, int newResearchMaterial_04,
            int newResearchMaterial_05, int newAtomizerItem, int newAtomizerItemLevel)
        {
            if (!fileName.Equals(openFilePath))
            {
                File.Copy(openFilePath, fileName);

                FileStream fs = File.Open(fileName, FileMode.Open);
                StreamReader encoding = new StreamReader(fs, true);
                BinaryReader br = new BinaryReader(fs, encoding.CurrentEncoding);
                BinaryWriter bw = new BinaryWriter(fs, encoding.CurrentEncoding);

                try
                {
                    br.ReadInt32();
                    br.ReadInt32();
                    br.ReadInt64();
                    bw.Write(newGalaxySeed);
                    br.ReadSingle();
                    bw.Write(newCrewCredits);
                    bw.Write(newCrewLevel);
                    bw.Write(newCrewXP);
                    bw.Write(newCurrentSectorID);
                    bw.Write(newIronmanMode);
                    if (SaveVerID >= 30)
                    {
                        br.ReadInt32();
                    }
                    if (SaveVerID >= 33)
                    {
                        br.ReadBoolean();
                    }
                    if (SaveVerID >= 33)
                    {
                        br.ReadInt32();
                    }
                    if (SaveVerID >= 31)
                    {
                        br.ReadBoolean();
                    }
                    if (SaveVerID >= 38)
                    {
                        bw.Write(newUpgradeMaterials);
                    }
                    if (SaveVerID >= 39)
                    {
                        br.ReadInt32();
                    }
                    bw.Write(newCU_REP);
                    bw.Write(newAOG_REP);
                    bw.Write(newWD_REP);
                    bw.Write(newFB_REP);
                    bw.Write(newInfected_REP);
                    if (SaveVerID >= 32)
                    {
                        br.ReadBoolean();
                    }
                    if (SaveVerID >= 44)
                    {
                        br.ReadBoolean();
                        br.ReadInt32();
                        br.ReadInt32();
                        br.ReadInt32();
                    }
                    //Storm
                    if (SaveVerID >= 42)
                    {
                        br.ReadSingle();
                        br.ReadSingle();
                        br.ReadSingle();
                    }
                    //Race
                    if (SaveVerID >= 37)
                    {
                        br.ReadInt32();
                        br.ReadInt32();
                        br.ReadInt32();
                    }
                    br.ReadString();
                    br.ReadString();
                    br.ReadInt32();
                    bw.Write(newFuel);
                    bw.Write(newHull);
                    if (SaveVerID >= 30)
                    {
                        bw.Write(newFBCrates);
                    }
                    bw.Write(newCoolantLevel);
                    //Ship Data
                    if (SaveVerID >= 32)
                    {
                        int count = br.ReadInt32();
                        br.ReadBytes(count);
                    }
                    //Components
                    int NumComponents = br.ReadInt32();
                    for (int i = 0; i < NumComponents; i++)
                    {
                        br.ReadUInt32();
                        br.ReadInt32();
                        br.ReadInt16();
                    }
                    if (SaveVerID > 29)
                    {
                        int num3 = br.ReadInt32();
                        for (int j = 0; j < num3; j++)
                        {
                            br.ReadUInt32();
                            br.ReadSingle();
                            br.ReadSingle();
                            br.ReadSingle();
                        }
                    }
                    //Locker
                    for (int k = 0; k < 5; k++)
                    {
                        int num4 = br.ReadInt32();
                        for (int l = 0; l < num4; l++)
                        {
                            br.ReadInt32();
                            br.ReadInt32();
                            br.ReadInt32();
                        }
                    }
                    //Factions
                    int num5 = br.ReadInt32();
                    for (int m = 0; m < num5; m++)
                    {
                        br.ReadInt32();
                        br.ReadSingle();
                        br.ReadSingle();
                    }
                    bw.Write(newChaosLevel);
                    br.ReadInt64();
                    br.ReadInt64();
                    br.ReadInt32();
                    br.ReadInt32();
                    bw.Write(newResearchMaterial_00);
                    bw.Write(newResearchMaterial_01);
                    bw.Write(newResearchMaterial_02);
                    bw.Write(newResearchMaterial_03);
                    bw.Write(newResearchMaterial_04);
                    bw.Write(newResearchMaterial_05);
                    int num6 = br.ReadInt32();
                    //Atomizer Items
                    for (int n = 0; n < num6; n++)
                    {
                        bw.Write(newAtomizerItem);
                        br.ReadInt32();
                        bw.Write(newAtomizerItemLevel);
                    }
                }
                catch (EndOfStreamException eose)
                {
                    MessageBox.Show("Error while reading file. The file is perhaps corrupted.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error while reading file. " + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                finally
                {
                    br.Close();
                    encoding.Close();
                    fs.Close();
                    bw.Close();
                }
            }
            else
            {
                MessageBox.Show("Cannot overwrite the same file.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
