namespace ATS.Models
{
    //Абонент
    public class Subscriber
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
        public virtual ICollection<Debts> Debts { get; set; }
    }
}
