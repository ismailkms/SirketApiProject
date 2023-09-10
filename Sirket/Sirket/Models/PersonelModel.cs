namespace Sirket.Models
{
    public class PersonelModel
    {
        public int Id { get; set; }
        public string PersonelAdi { get; set; }
        public string KullaniciAdi { get; set; }
        public string Password { get; set; }
        public int DepartmanId { get; set; }
        public int RoleId { get; set; }
        public PersonelRole Role { get; set; }
    }

    public class PersonelRole
    {
        public int Id { get; set; }
        public string RoleAdi { get; set; }
    }
}
