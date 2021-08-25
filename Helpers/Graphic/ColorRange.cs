using System;
using System.Drawing;

namespace  Helpers.Graphic
{
    public static class ColorRange
    {
        public static String GetRGB(double range, short type = 1)
        {
            int R = 0;
            int G = 0;
            int B = 0;

            if (type == 1)
            {
                if (range < 0)
                {
                    R = 255;
                    G = 255;
                    B = 255;
                }
                else
            if (range <= 25)
                {
                    R = 255;
                    G = (int)Math.Round(range * 10.2);
                    R = 232;
                    G = 134;
                    B = 107;
                }
                else
            if (range <= 50)
                {
                    R = (int)Math.Round(255 - (range - 25) * 10.2);
                    G = 255;
                    R = 206;
                    G = 182;
                    B = 52;
                }
                else
            if (range <= 75)
                {
                    G = 255;
                    B = (int)Math.Round((range - 50) * 10.2);
                    R = 60;
                    G = 148;
                    B = 108;
                }
                else
                {
                    G = (int)Math.Round(255 - (range - 75) * 10.2);
                    B = 255;
                    R = 41;
                    G = 128;
                    B = 185;
                }
            }
            else if (type == 2)
            {
                if (range < 0)
                {
                    R = 255;
                    G = 255;
                    B = 255;
                }
                else if (range < 4)
                {
                    R = 223;
                    G = 226;
                    B = 245;
                }
                else if (range >= 4 && range <= 5)
                {
                    R = 175;
                    G = 206;
                    B = 224;
                }
                else if (range > 5 && range <= 7)
                {
                    R = 76;
                    G = 145;
                    B = 186;
                }
                else if (range > 7 && range <= 9)
                {
                    R = 0;
                    G = 118;
                    B = 182;
                }
                else if (range > 9 && range <= 12)
                {
                    R = 0;
                    G = 84;
                    B = 122;
                }
                else if (range > 12)
                {
                    R = 0;
                    G = 37;
                    B = 89;
                }
            }
            else
            if (type == 3)
            {
                if (range < 0)
                {
                    R = 255;
                    G = 255;
                    B = 255;
                }
                else
                if (range < 18.5)
                {
                    R = 250;
                    G = 249;
                    B = (int)Math.Round(171 - (range - 18.5) * 10);
                }
                else
            if (range < 25)
                {
                    R = (int)Math.Round(14 + (range - 18.5) * 20);
                    G = (int)Math.Round(177 + (range - 18.5) * 20);
                    B = (int)Math.Round(55 + (range - 18.5) * 20);
                }
                else
            if (range <= 30)
                {
                    R = 250;
                    G = (int)Math.Round(197 - (range - 25) * 10);
                    B = (int)Math.Round(164 - (range - 25) * 10);
                }
                else
                {
                    R = 255;
                    G = (int)Math.Round(148 - (range - 30) * 24);
                    B = (int)Math.Round(150 - (range - 30) * 24);
                }
            }
            else
            if (type == 4)
            {
                R = (int)Math.Round(125 + (range * 4));
                G = (int)Math.Round(255 - (range * 4));
                B = 0;
                if (R > 255) R = 255;
                if (G < 0) G = 0;
            }
            else
            if (type == 5)
            {
                if (range > 0 && range <= 50)
                {
                    R = 232;
                    G = 134;
                    B = 107;
                }
                else
                if (range > 50 && range <= 70)
                {
                    R = 206;
                    G = 182;
                    B = 52;
                }
                else
               if (range > 70 && range <= 90)
                {
                    R = 60;
                    G = 148;
                    B = 108;
                }
                else
                if (range >90 && range <= 100)
                {
                    R = 0;
                    G = 118;
                    B = 182;
                }
            }
            else
            if (type == 6)
            {
                if (range > 0 && range <= 80)
                {
                    R = 232;
                    G = 134;
                    B = 107;
                }
                else
                if (range > 80 && range <= 90)
                {
                    R = 206;
                    G = 182;
                    B = 52;
                }
                else
               if (range > 90 && range <= 95)
                {
                    R = 60;
                    G = 148;
                    B = 108;
                }
                else
                if (range > 95 && range <= 100)
                {
                    R = 0;
                    G = 118;
                    B = 182;
                }
            }


            string theHexColor = "#" + R.ToString("X2") + G.ToString("X2") + B.ToString("X2");
            return theHexColor;
        }

        
    }
}