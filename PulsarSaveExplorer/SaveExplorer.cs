using System;
using System.Collections.Generic;
using System.IO;

namespace PulsarSaveExplorer
{
    class SaveExplorer
    {
        static void Main(string[] args)
        {
            FileStream fsIn1 = File.Open("Save1.plsave", FileMode.Open);
            StreamReader encoding = new StreamReader(fsIn1, true);
            BinaryReader brIn1 = new BinaryReader(fsIn1, encoding.CurrentEncoding);

            FileStream fsIn2 = File.Open("Save2.plsave", FileMode.Open);
            StreamReader encoding2 = new StreamReader(fsIn2, true);
            BinaryReader brIn2 = new BinaryReader(fsIn2, encoding2.CurrentEncoding);

            List<BinaryReader> readers = new List<BinaryReader>();

            readers.Add(brIn1);
            readers.Add(brIn2);

            foreach (BinaryReader br in readers)
            {
                try
                {
                    int SaveVerID = br.ReadInt32();
                    Write("GalaxySaveVerID", br.ReadInt32());
                    Write("SavedDateTime", br.ReadInt64());
                    Write("GalaxySeed", br.ReadInt32());
                    Write("GameTime", br.ReadSingle());
                    Write("CrewCredits", br.ReadInt32());
                    Write("CrewLevel", br.ReadInt32());
                    Write("CrewXP", br.ReadInt32());
                    Write("CurrentSectorID", br.ReadInt32());
                    Write("IronmanMode", br.ReadBoolean());
                    if (SaveVerID >= 30)
                    {
                        Write("BiscuitsSold", br.ReadInt32());
                    }
                    if (SaveVerID >= 33)
                    {
                        Write("WonFBContest", br.ReadBoolean());
                    }
                    if (SaveVerID >= 33)
                    {
                        Write("WhenContestEnded", br.ReadInt32());
                    }
                    if (SaveVerID >= 31)
                    {
                        Write("BBAvailable", br.ReadBoolean());
                    }
                    if (SaveVerID >= 38)
                    {
                        Write("UpgradeMats", br.ReadInt32());
                    }
                    if (SaveVerID >= 39)
                    {
                        Write("ItemUpgradeHash", br.ReadInt32());
                    }
                    Write("C.U. REP", br.ReadInt32());
                    Write("A.O.G REP", br.ReadInt32());
                    Write("W.D REP", br.ReadInt32());
                    Write("F.B REP", br.ReadInt32());
                    Write("Infected REP", br.ReadInt32());
                    if (SaveVerID >= 32)
                    {
                        Write("BContestOver", br.ReadBoolean());
                    }
                    if (SaveVerID >= 44)
                    {
                        Write("PacifistRun", br.ReadBoolean());
                        Write("CreditsSpent", br.ReadInt32());
                        Write("PerfectBiscuitStreak", br.ReadInt32());
                        Write("BlindJumpCount", br.ReadInt32());
                    }
                    if (SaveVerID >= 42)
                    {
                        Write("Storm_x", br.ReadSingle());
                        Write("Storm_y", br.ReadSingle());
                        Write("Storm_z", br.ReadSingle());
                    }
                    if (SaveVerID >= 37)
                    {
                        Write("RacesWon", br.ReadInt32());
                        Write("RacesLost", br.ReadInt32());
                        Write("RacesStarted", br.ReadInt32());
                    }
                    Write("GameName", br.ReadString());
                    Write("ShipName", br.ReadString());
                    Write("ShipType", br.ReadInt32());
                    Write("Fuel", br.ReadInt32());
                    Write("Hull", br.ReadSingle());
                    if (SaveVerID >= 30)
                    {
                        Write("FBCrates", br.ReadInt32());
                    }
                    Write("CoolantLevel", br.ReadSingle());
                    if (SaveVerID >= 32)
                    {
                        int count = br.ReadInt32();
                        Write("AdditionalShipData", br.ReadBytes(count));
                    }
                    int NumComponents = br.ReadInt32();
                    Write("Components Installed", NumComponents.ToString());
                    for (int i = 0; i < NumComponents; i++)
                    {
                        uint Hash = br.ReadUInt32();
                        int SortID = br.ReadInt32();
                        short value = br.ReadInt16();
                        Write(Hash.ToString(), SortID.ToString());
                        Write(Hash.ToString(), value.ToString());
                    }
                    if (SaveVerID > 29)
                    {
                        int num3 = br.ReadInt32();
                        for (int j = 0; j < num3; j++)
                        {
                            uint hash = br.ReadUInt32();
                            float x = br.ReadSingle();
                            float y = br.ReadSingle();
                            float z = br.ReadSingle();
                        }
                    }
                    for (int k = 0; k < 5; k++)
                    {
                        int num4 = br.ReadInt32();
                        for (int l = 0; l < num4; l++)
                        {
                            int ItemType = br.ReadInt32();
                            int SubType = br.ReadInt32();
                            int Level = br.ReadInt32();
                        }
                    }
                    int num5 = br.ReadInt32();
                    Write("Factions in Galaxy", num5.ToString());
                    for (int m = 0; m < num5; m++)
                    {
                        int FacID = br.ReadInt32();
                        float FacSpreadLimit = br.ReadSingle();
                        float FacSpreadFactor = br.ReadSingle();
                    }
                    Write("ChaosLevel", br.ReadSingle());
                    Write("ActChaosEv", br.ReadInt64());
                    Write("TalLockSt", br.ReadInt64());
                    Write("TalToRes", br.ReadInt32());
                    Write("JumpsToRes", br.ReadInt32());
                    Write("ResMat_00", br.ReadInt32());
                    Write("ResMat_01", br.ReadInt32());
                    Write("ResMat_02", br.ReadInt32());
                    Write("ResMat_03", br.ReadInt32());
                    Write("ResMat_04", br.ReadInt32());
                    Write("ResMat_05", br.ReadInt32());
                    int num6 = br.ReadInt32();
                    Write("In Atomizer: ", num6.ToString());
                    for (int n = 0; n < num6; n++)
                    {
                        Write("ItemType", br.ReadInt32());
                        Write("SubType", br.ReadInt32());
                        Write("Level", br.ReadInt32());
                    }
                    if (SaveVerID > 30)
                    {
                        for (int num11 = 0; num11 < 5; num11++)
                        {
                            bool flag = br.ReadBoolean();
                            if (flag)
                            {
                                Write("TalentPointsAvailable", br.ReadInt32());
                                if (SaveVerID >= 43)
                                {
                                    Write("SurvivalBonusCounter", br.ReadInt32());
                                }
                                int num12 = br.ReadInt32();
                                for (int num13 = 0; num13 < num12; num13++)
                                {
                                    int Talents = br.ReadInt32();
                                }
                                int num14 = br.ReadInt32();
                                //Inventory
                                for (int num15 = 0; num15 < num14; num15++)
                                {
                                    int ItemType = br.ReadInt32();
                                    int SubType = br.ReadInt32();
                                    int Level = br.ReadInt32();
                                    int OptionalEquipID = br.ReadInt32();
                                }
                            }
                        }
                    }
                    int CrewFactionID = br.ReadInt32();
                    bool PlayerShipIsFlagged = br.ReadBoolean();
                    bool PlayerShipIsRevealed = br.ReadBoolean();
                    bool LongRangeCommsDisabled = br.ReadBoolean();


                    int num16 = br.ReadInt32();
                    for (int num17 = 0; num17 < num16; num17++)
                    {
                        br.ReadInt32();
                    }
                    int SelectedShipTypeID = br.ReadInt32();
                    int ServerShipIDCounter = br.ReadInt32();
                    int num18 = br.ReadInt32();
                    for (int num19 = 0; num19 < num18; num19++)
                    {
                        int num20 = br.ReadInt32();
                        if (num20 != 0)
                        {
                            if (num20 == 1)
                            {
                                bool Hostile = br.ReadBoolean();
                                string ActorID = br.ReadString();
                                Write("ShipName", br.ReadString());
                                bool SpecialActionCompleted = br.ReadBoolean();
                                int num21 = br.ReadInt32();
                                for (int num22 = 0; num22 < num21; num22++)
                                {
                                    br.ReadInt32();
                                }
                            }
                            else
                            {
                                bool Hostile = br.ReadBoolean();
                                string ActorID = br.ReadString();
                                string NPCName = br.ReadString();
                            }
                            int num23 = br.ReadInt32();
                            for (int num24 = 0; num24 < num23; num24++)
                            {
                                br.ReadInt32();
                            }
                        }
                    }

                    int num25 = br.ReadInt32();
                    for (int num26 = 0; num26 < num25; num26++)
                    {
                        int ShipType = br.ReadInt32();
                        int FactionID = br.ReadInt32();
                        bool IsDestroyed = br.ReadBoolean();
                        Write("SectorID", br.ReadInt32());
                        Write("ShipName", br.ReadString());
                        int num27 = br.ReadInt32();
                        for (int num28 = 0; num28 < num27; num28++)
                        {
                            int CompLevel = br.ReadInt32();
                            int CompTypeToReplace = br.ReadInt32();
                            int CompSubType = br.ReadInt32();
                            int CompType = br.ReadInt32();
                            bool ReplaceExistingComp = br.ReadBoolean();
                            int CompSubTypeToReplace = br.ReadInt32();
                            int SlotNumberToReplace = br.ReadInt32();
                            bool IsCargo = br.ReadBoolean();
                        }
                    }
                }
                catch (EndOfStreamException eose)
                {

                }

                Console.WriteLine("--------------------------------");
            }

            Console.Read();

        }

        private static void Write(String name, object value)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                name = "Unknown";
            }

            Console.WriteLine(String.Format("{0, -15}", name + ":") + value);
        }
    }
}
