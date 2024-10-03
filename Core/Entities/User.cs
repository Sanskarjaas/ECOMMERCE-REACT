namespace Core.Entities
{
    public class User : BaseEntity
    {
        public string name{get;set;}
        public string email{get;set;}
        public long phone{get;set;}
        public string password {get;set;}

    }
}