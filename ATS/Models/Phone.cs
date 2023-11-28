namespace ATS.Models
{
    //инфа а phone
    public class Phone
    {
        public int Id { get; set; }
        public string PhoneModel { get; set; }
        public string PhoneNumber { get; set; }
        public int SubscriberId { get; set; }
        public virtual Subscriber Subscriber { get; set; }
    }
}
