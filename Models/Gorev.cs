namespace GorevYoneticisi.Models
{
    public class Gorev
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }
        public bool Tamamlandi { get; set; }
        public int KullaniciId { get; set; }
        public Kullanici? Kullanici { get; set; }
    }
}
