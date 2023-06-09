namespace TUTOR_NET105_SU23.B2.DAL.Entities
{
    public class Role
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; }
        public int Status { get; set; }
        // 1 Role - N User
        // 1 User - 1 Role
        public virtual ICollection<User>? Users { get; set; }
    }
}
