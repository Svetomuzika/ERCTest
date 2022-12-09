namespace ERCTest.DAL.Models.Entities
{
    public class Resident
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public int PersonalAccountId { get; set; }
    }
}
