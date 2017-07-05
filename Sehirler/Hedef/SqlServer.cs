using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Sehirler.Hedef
{
    public class SqlServer : IHedef
    {
        public StringBuilder iller { get; private set; } = new StringBuilder("SET IDENTITY_INSERT [sehiril] ON\r\nGO\r\nBEGIN TRANSACTION\r\n");
        public StringBuilder ilceler { get; private set; } = new StringBuilder("SET IDENTITY_INSERT [sehirilce] ON\r\nGO\r\nBEGIN TRANSACTION\r\n");
        public StringBuilder Semtler { get; private set; } = new StringBuilder("SET IDENTITY_INSERT [sehirsemt] ON\r\nGO\nBEGIN TRANSACTION\r\n");
        public StringBuilder Mahalleler { get; private set; } = new StringBuilder("SET IDENTITY_INSERT [sehirmahalle] ON\r\nGO\r\nBEGIN TRANSACTION\r\n");

        public string Sablon_il { get; private set; } = "INSERT INTO [sehiril] ([ID], [SehirAd]) VALUES ({0},'{1}');";
        public string Sablon_ilce { get; private set; } = "INSERT INTO [sehirilce] (ID, [SehirID], [IlceAd]) VALUES ({0},{1},'{2}');";
        public string Sablon_Semt { get; private set; } = "INSERT INTO [sehirsemt] (ID, [IlceID], [SemtAd]) VALUES ({0},{1},'{2}');";
        public string Sablon_Mahalle { get; private set; } = "INSERT INTO [sehirmahalle] (ID, [SemtID], [MahalleAd], [PostaKodu]) VALUES ({0},{1},N'{2}',{3});";

        public string Sablon_Commit { get; private set; } = "COMMIT TRANSACTION\r\nGO\r\nBEGIN TRANSACTION";

        public void Finish()
        {
            iller.AppendLine("\r\nCOMMIT TRANSACTION\r\nGO\r\nSET IDENTITY_INSERT [sehiril] OFF\r\nGO\r\n");
            ilceler.AppendLine("\r\nCOMMIT TRANSACTION\r\nGO\r\nSET IDENTITY_INSERT [sehirilce] OFF\r\nGO\r\n");
            Semtler.AppendLine("\r\nCOMMIT TRANSACTION\r\nGO\r\nSET IDENTITY_INSERT [sehirsemt] OFF\r\nGO\r\n");
            Mahalleler.AppendLine("\r\nCOMMIT TRANSACTION\r\nGO\r\nSET IDENTITY_INSERT [sehirmahalle] OFF\r\nGO\r\n");
            string klasor = Path.Combine(Application.StartupPath, "Sql Server");
            if (!Directory.Exists(klasor)) Directory.CreateDirectory(klasor);
            File.WriteAllText(Path.Combine(klasor, "iller.sql"), iller.ToString(), new UTF8Encoding(false));
            File.WriteAllText(Path.Combine(klasor, "ilceler.sql"), ilceler.ToString(), new UTF8Encoding(false));
            File.WriteAllText(Path.Combine(klasor, "semtler.sql"), Semtler.ToString(), new UTF8Encoding(false));
            File.WriteAllText(Path.Combine(klasor, "mahalle.sql"), Mahalleler.ToString(), new UTF8Encoding(false));
            if (!File.Exists(Path.Combine(klasor, "Sql_Server_Schema.sql")))
                File.WriteAllText(Path.Combine(klasor, "Sql_Server_Schema.sql"), Properties.Resources.sql_server_schema, new UTF8Encoding(false));
        }

        public string Replace(string value) => value.Replace("'", "''");
    }
}
