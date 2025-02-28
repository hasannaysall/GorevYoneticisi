namespace GorevYoneticisi.Models
{
    public class Kullanici
    {
        public int Id { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public List<Gorev> Gorevler { get; set; }
    }
}
