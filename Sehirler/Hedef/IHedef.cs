using System.Text;

namespace Sehirler.Hedef
{
    public interface IHedef
    {
        StringBuilder ilceler { get; }
        StringBuilder iller { get; }
        StringBuilder Mahalleler { get; }
        string Sablon_Commit { get; }
        string Sablon_il { get; }
        string Sablon_ilce { get; }
        string Sablon_Mahalle { get; }
        string Sablon_Semt { get; }
        StringBuilder Semtler { get; }

        void Finish();
        string Replace(string value);
    }
}