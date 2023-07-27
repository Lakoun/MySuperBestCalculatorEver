using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBestDataClassEver.Helpers {
    public class IdHelper {
        public static string RndId(int l) {
            Random res = new Random();
            string str = "ABCDEFGHIJKLMNOPQSRTUVWXYZ0123456789";

            string randomstring = "";

            for (int i = 0; i < l; i++) {
                int x = res.Next(str.Length);
                randomstring = randomstring + str[x];
            }
            return randomstring;
        }

        public static string RndId(string? prefix, string type) {

            string Identifier = "";

            if (prefix != null) {
                Identifier = prefix;
            }

            switch (type) {
                case "SomeClass":
                    Identifier += RndId(7);
                    break;
                default:
                    Identifier += RndId(5);
                    return Identifier;
            }
            return Identifier;
        }

        public static string SepDateId(DateTime d) {
            return d.ToString("yyMMdd");
        }

    }
}
