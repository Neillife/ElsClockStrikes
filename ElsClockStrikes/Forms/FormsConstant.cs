using System;

namespace ElsClockStrikes.Forms
{
    public class FormsConstant
    {
        public static string titleName = "ElsClockStrikes | Author by DC:  .le._.vi.";
        public static string copyrightTag = "Copyright © 2024, Levi. All rights reserved.";
        public static int 小荊棘Time;
        public static int 雷射Time;
        public static int 荊棘延遲Time;
        public static int 控場Time;

        public static void init127Timer(string init小荊棘Time, string init雷射Time, string init荊棘延遲Time, string init控場Time)
        {
            小荊棘Time = Int32.Parse(init小荊棘Time);
            雷射Time = Int32.Parse(init雷射Time);
            荊棘延遲Time = Int32.Parse(init荊棘延遲Time);
            控場Time = Int32.Parse(init控場Time);
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
    }
}
