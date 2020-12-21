using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLPKDKTN.Utility
{
    public class Helper
    {
        //Hàm format tiền
        public static string formatMoney(double money,string unit)
        {
            string m = money.ToString();
            string result = "";
            int count = 0;
            for(int i = m.Length - 1; i >=0; i--)
            {
                count++;
                result = m[i] + result;
                if (count % 3 == 0&&i!=0)
                {
                    result = "," + result;
                }
            }
            return result+" "+unit;
        }

        //Hàm cắt tên từ họ và tên
        public static string getName(string name)
        {
            string[] result = name.Split(' ');
            return result[result.Length-1].ToString();
        }
    }
}