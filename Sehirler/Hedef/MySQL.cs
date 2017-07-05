using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Sehirler.Hedef
{
    public class MySQL : IHedef
    {
        public StringBuilder iller { get; private set; } = new StringBuilder("START TRANSACTION;\r\n");
        public StringBuilder ilceler { get; private set; } = new StringBuilder("START TRANSACTION;\r\n");
        public StringBuilder Semtler { get; private set; } = new StringBuilder("START TRANSACTION;\r\n");
        public StringBuilder Mahalleler { get; private set; } = new StringBuilder("START TRANSACTION;\r\n");

        public string Sablon_il { get; private set; } = "INSERT INTO sehiril (ID, SehirAd) VALUES ({0},'{1}');";
        public string Sablon_ilce { get; private set; } = "INSERT INTO sehirilce (ID, SehirID, IlceAd) VALUES ({0},{1},'{2}');";
        public string Sablon_Semt { get; private set; } = "INSERT INTO sehirsemt (ID, IlceID, SemtAd) VALUES ({0},{1},'{2}');";
        public string Sablon_Mahalle { get; private set; } = "INSERT INTO sehirmahalle (ID, SemtID, MahalleAd, PostaKodu) VALUES ({0},{1},'{2}',{3});";

        public string Sablon_Commit { get; private set; } = "COMMIT;\r\nSTART TRANSACTION;";

        public void Finish()
        {
            iller.AppendLine("COMMIT;");
            ilceler.AppendLine("COMMIT;");
            Semtler.AppendLine("COMMIT;");
            Mahalleler.AppendLine("COMMIT;");

            string klasor = Path.Combine(Application.StartupPath, "MySQL");
            if (!Directory.Exists(klasor)) Directory.CreateDirectory(klasor);
            File.WriteAllText(Path.Combine(klasor, "iller.sql"), iller.ToString(), new UTF8Encoding(false));
            File.WriteAllText(Path.Combine(klasor, "ilceler.sql"), ilceler.ToString(), new UTF8Encoding(false));
            File.WriteAllText(Path.Combine(klasor, "semtler.sql"), Semtler.ToString(), new UTF8Encoding(false));
            File.WriteAllText(Path.Combine(klasor, "mahalle.sql"), Mahalleler.ToString(), new UTF8Encoding(false));
            if (!File.Exists(Path.Combine(klasor, "MySQL_Schema.sql")))
                File.WriteAllText(Path.Combine(klasor, "MySQL_Schema.sql"), Properties.Resources.mysql_schema, new UTF8Encoding(false));
        }

        public string Replace(string value) => AddSlashes(value);

        /// <summary>
        /// Returns a string with backslashes before characters that need to be quoted
        /// </summary>
        /// <param name="InputTxt">Text string need to be escape with slashes</param>
        public static string AddSlashes(string InputTxt)
        {
            // List of characters handled:
            // \000 null
            // \010 backspace
            // \011 horizontal tab
            // \012 new line
            // \015 carriage return
            // \032 substitute
            // \042 double quote
            // \047 single quote
            // \134 backslash
            // \140 grave accent

            string Result = InputTxt;

            try
            {
                Result = System.Text.RegularExpressions.Regex.Replace(InputTxt, @"[\000\010\011\012\015\032\042\047\134\140]", "\\$0");
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            return Result;
        }
    }
}
