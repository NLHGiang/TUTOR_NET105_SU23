namespace TUTOR_NET105_SU23.B2.DAL.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public Guid? RoleId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Status { get; set; }

        public virtual Role? Role { get; set; }
    }
}
