using System;

namespace ElsClockStrikes.Forms
{
    public class FormsConstant
    {
        public const string titleName = "ElsClockStrikes | Author by DC:  .le._.vi.";
        public static string copyrightTag = $"Copyright © {DateTime.Today.Year}, Levi. All rights reserved.";
        public const string sourceCodeGitHubURL = "https://github.com/Neillife/ElsClockStrikes";
        public const string configININame = "config.ini";
        public const string config127R3SectionName = "127R3";
        public const string config156R1SectionName = "156R1";
        public const string config156R3SectionName = "156R3";
        public const string configCustomizeSectionName = "customize";
        public const string configGlobalSectionName = "global";
        public static int 小荊棘Time;
        public static int 雷射Time;
        public static int 荊棘延遲Time;
        public static int 控場Time;
        public static int 大招Time;
        public static int 大刺Time;
        public static int 翻桌Time;
        public static int R1156控場Time;
        public static int 大黑Time;
        public static int 陰陽陣Time;
        public static int 三連Time;
        public static int R3156控場Time;
        public static int indexForCustomizeName = 0;
        public const int LayoutSign = 327;
        public const int FormSizeOffset = 75;
        public const int ControlLayoutOffset = 72;
        public const string timeLeftLabelBaseName = "CustomizeTimeLeftLabelName";
        public const string hotKeyLabelBaseName = "CustomizeHotKeyLabelName";
        public const string mechanicLabelBaseName = "CustomizeMechanicLabelName";
        public const string comboBoxBaseName = "CustomizeComboBoxName";
        public const string textBoxBaseName = "CustomizeTextBoxName";
        public const string buttonBaseName = "CustomizeButtonName";
        public const string timerBaseName = "CustomizeTimerName";
        public const string audioPlayerButtonBaseName = "CustomizeAudioPlayer";

        public static void init127Timer(string init小荊棘Time, string init雷射Time, string init荊棘延遲Time, string init控場Time)
        {
            小荊棘Time = Int32.Parse(init小荊棘Time);
            雷射Time = Int32.Parse(init雷射Time);
            荊棘延遲Time = Int32.Parse(init荊棘延遲Time);
            控場Time = Int32.Parse(init控場Time);
        }

        public static void init156R1Timer(string init大招Time, string init大刺Time, string init翻桌Time, string initR1156控場Time)
        {
            大招Time = Int32.Parse(init大招Time);
            大刺Time = Int32.Parse(init大刺Time);
            翻桌Time = Int32.Parse(init翻桌Time);
            R1156控場Time = Int32.Parse(initR1156控場Time);
        }

        public static void init156R3Timer(string init大黑Time, string init陰陽陣Time, string init三連Time, string initR3156控場Time)
        {
            大黑Time = Int32.Parse(init大黑Time);
            陰陽陣Time = Int32.Parse(init陰陽陣Time);
            三連Time = Int32.Parse(init三連Time);
            R3156控場Time = Int32.Parse(initR3156控場Time);
        }

        public static void set小荊棘Time(string time)
        {
            小荊棘Time = Int32.Parse(time);
        }

        public static void set雷射Time(string time)
        {
            雷射Time = Int32.Parse(time);
        }

        public static void set荊棘延遲Time(string time)
        {
            荊棘延遲Time = Int32.Parse(time);
        }

        public static void set控場Time(string time)
        {
            控場Time = Int32.Parse(time);
        }

        public static void set大招Time(string time)
        {
            大招Time = Int32.Parse(time);
        }

        public static void set大刺Time(string time)
        {
            大刺Time = Int32.Parse(time);
        }

        public static void set翻桌Time(string time)
        {
            翻桌Time = Int32.Parse(time);
        }

        public static void setR1156控場Time(string time)
        {
            R1156控場Time = Int32.Parse(time);
        }

        public static void set大黑Time(string time)
        {
            大黑Time = Int32.Parse(time);
        }

        public static void set陰陽陣Time(string time)
        {
            陰陽陣Time = Int32.Parse(time);
        }

        public static void set三連Time(string time)
        {
            三連Time = Int32.Parse(time);
        }

        public static void setR3156控場Time(string time)
        {
            R3156控場Time = Int32.Parse(time);
        }
    }
}
