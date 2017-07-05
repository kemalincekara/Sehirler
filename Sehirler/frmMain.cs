using Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Sehirler
{
    public partial class frmMain : Form
    {
        public string Adres { get; set; }
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnGozat_Click(object sender, EventArgs e)
        {
            using (var ac = new OpenFileDialog()
            {
                Filter = "Excel Dosyası (*.xlsx)|*.xlsx"
            })
            {
                if (ac.ShowDialog() != DialogResult.OK) return;
                grpKaydet.Enabled = grpKaydet.Visible = true;
                txtAdres.Text = ac.FileName;
            }
        }

        private void btnSqlServer_Click(object sender, EventArgs e)
        {
            Baslat(new Hedef.SqlServer());
        }

        private void btnMySQL_Click(object sender, EventArgs e)
        {
            Baslat(new Hedef.MySQL());
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://postakodu.ptt.gov.tr/Dosyalar/pk_list.zip");
        }
        private void Baslat(Hedef.IHedef hedef)
        {
            if (string.IsNullOrEmpty(txtAdres.Text) || !File.Exists(txtAdres.Text)) return;

            grpKaydet.Enabled = grpDosyaSec.Enabled = false;
            lblDurum.Text = "Durum : Lütfen, bekleyiniz...";
            Application.DoEvents();

            var dbData = new Dictionary<string, Dictionary<string, List<string[]>>>();
            int ilCount, ilceCount, semtCount, mahCount, sqlLinear = 500,
 ilce_id, semt_id = 0, mah_id;
            ilCount = ilceCount = semtCount = mahCount = 0;
            ilce_id = mah_id = 1;

            using (FileStream stream = File.Open(txtAdres.Text, FileMode.Open, FileAccess.Read))
            using (IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream))
            {
                excelReader.IsFirstRowAsColumnNames = true;
                var dbDataa = new Dictionary<string, Dictionary<string, List<string[]>>>();
                using (DataSet workbook = excelReader.AsDataSet())
                    foreach (DataRow item in workbook.Tables[0].Rows)
                    {
                        Application.DoEvents();
                        string il = item[0]?.ToString()?.Trim() ?? string.Empty,
                            ilce = item[1]?.ToString()?.Trim() ?? string.Empty,
                            semt_bucak_belde = item[2]?.ToString()?.Trim() ?? string.Empty,
                            mahalle = item[3]?.ToString()?.Trim() ?? string.Empty,
                            postaKodu = item[4]?.ToString()?.Trim() ?? string.Empty;
                        var semt_m_pk = new string[] { semt_bucak_belde, mahalle, postaKodu };
                        if (dbData.ContainsKey(il))
                            if (dbData[il].ContainsKey(ilce))
                                dbData[il][ilce].Add(semt_m_pk);
                            else
                                dbData[il].Add(ilce, new List<string[]>() { semt_m_pk });
                        else
                            dbData.Add(il, new Dictionary<string, List<string[]>>
                            {
                                { ilce, new List<string[]>() { semt_m_pk } }
                            });
                    }
                foreach (var ilAdi in dbData)
                {
                    Application.DoEvents();
                    string il_id = GetilPlaka[ilAdi.Key];
                    if (ilCount >= sqlLinear)
                    {
                        ilCount = 1;
                        hedef.iller.AppendLine(hedef.Sablon_Commit);
                    }

                    hedef.iller.AppendFormat(hedef.Sablon_il, il_id, hedef.Replace(ilAdi.Key));
                    hedef.iller.AppendLine();
                    foreach (var ilceAdi in ilAdi.Value)
                    {
                        Application.DoEvents();
                        if (ilceCount >= sqlLinear)
                        {
                            ilceCount = 1;
                            hedef.ilceler.AppendLine(hedef.Sablon_Commit);
                        }
                        hedef.ilceler.AppendFormat(hedef.Sablon_ilce, ilce_id, il_id, hedef.Replace(ilceAdi.Key));
                        hedef.ilceler.AppendLine();
                        int sx = 0;
                        string currentSemt = string.Empty;
                        foreach (var semt_mah_pk in ilceAdi.Value)
                        {
                            Application.DoEvents();
                            string semtAdi = semt_mah_pk[0],
                                mahAdi = semt_mah_pk[1],
                                pkKodu = semt_mah_pk[2];
                            if (sx < 1 || currentSemt != semtAdi)
                            {
                                if (semtCount >= sqlLinear)
                                {
                                    semtCount = 1;
                                    hedef.Semtler.AppendLine(hedef.Sablon_Commit);
                                }
                                currentSemt = semtAdi;
                                semt_id++;
                                hedef.Semtler.AppendFormat(hedef.Sablon_Semt, semt_id, ilce_id, hedef.Replace(currentSemt));
                                hedef.Semtler.AppendLine();
                                semtCount++;
                            }
                            if (mahCount >= sqlLinear)
                            {
                                mahCount = 1;
                                hedef.Mahalleler.AppendLine(hedef.Sablon_Commit);
                            }
                            hedef.Mahalleler.AppendFormat(hedef.Sablon_Mahalle, mah_id, semt_id, hedef.Replace(mahAdi), pkKodu);
                            hedef.Mahalleler.AppendLine();
                            sx++;
                            mah_id++;
                            mahCount++;
                        }
                        ilce_id++;
                        ilceCount++;
                    }
                    ilCount++;
                }
            }
            hedef.Finish();
            grpKaydet.Enabled = grpDosyaSec.Enabled = true;
            lblDurum.Text = "Durum : İşlem Tamamlanmıştır.";
        }

        #region " il plaka "
        public static Dictionary<string, string> GetilPlaka =>
            new Dictionary<string, string>()
            {
                { "ADANA", "1" },
                { "ADIYAMAN", "2" },
                { "AFYONKARAHİSAR", "3" },
                { "AĞRI", "4" },
                { "AMASYA", "5" },
                { "ANKARA", "6" },
                { "ANTALYA", "7" },
                { "ARTVİN", "8" },
                { "AYDIN", "9" },
                { "BALIKESİR", "10" },
                { "BİLECİK", "11" },
                { "BİNGÖL", "12" },
                { "BİTLİS", "13" },
                { "BOLU", "14" },
                { "BURDUR", "15" },
                { "BURSA", "16" },
                { "ÇANAKKALE", "17" },
                { "ÇANKIRI", "18" },
                { "ÇORUM", "19" },
                { "DENİZLİ", "20" },
                { "DİYARBAKIR", "21" },
                { "EDİRNE", "22" },
                { "ELAZIĞ", "23" },
                { "ERZİNCAN", "24" },
                { "ERZURUM", "25" },
                { "ESKİŞEHİR", "26" },
                { "GAZİANTEP", "27" },
                { "GİRESUN", "28" },
                { "GÜMÜŞHANE", "29" },
                { "HAKKARİ", "30" },
                { "HATAY", "31" },
                { "ISPARTA", "32" },
                { "MERSİN", "33" },
                { "İSTANBUL", "34" },
                { "İZMİR", "35" },
                { "KARS", "36" },
                { "KASTAMONU", "37" },
                { "KAYSERİ", "38" },
                { "KIRKLARELİ", "39" },
                { "KIRŞEHİR", "40" },
                { "KOCAELİ", "41" },
                { "KONYA", "42" },
                { "KÜTAHYA", "43" },
                { "MALATYA", "44" },
                { "MANİSA", "45" },
                { "KAHRAMANMARAŞ", "46" },
                { "MARDİN", "47" },
                { "MUĞLA", "48" },
                { "MUŞ", "49" },
                { "NEVŞEHİR", "50" },
                { "NİĞDE", "51" },
                { "ORDU", "52" },
                { "RİZE", "53" },
                { "SAKARYA", "54" },
                { "SAMSUN", "55" },
                { "SİİRT", "56" },
                { "SİNOP", "57" },
                { "SİVAS", "58" },
                { "TEKİRDAĞ", "59" },
                { "TOKAT", "60" },
                { "TRABZON", "61" },
                { "TUNCELİ", "62" },
                { "ŞANLIURFA", "63" },
                { "UŞAK", "64" },
                { "VAN", "65" },
                { "YOZGAT", "66" },
                { "ZONGULDAK", "67" },
                { "AKSARAY", "68" },
                { "BAYBURT", "69" },
                { "KARAMAN", "70" },
                { "KIRIKKALE", "71" },
                { "BATMAN", "72" },
                { "ŞIRNAK", "73" },
                { "BARTIN", "74" },
                { "ARDAHAN", "75" },
                { "IĞDIR", "76" },
                { "YALOVA", "77" },
                { "KARABÜK", "78" },
                { "KİLİS", "79" },
                { "OSMANİYE", "80" },
                { "DÜZCE", "81" }
            };
        #endregion

    }
}
