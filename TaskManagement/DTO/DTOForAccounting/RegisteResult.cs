namespace TaskManagement.DTO.DTOForAccounting
{
    public class RegisteResult
    {
        public string Massage { get; set; }
        public bool IsAuthanticated { get; set; }
        public string Token { get; set; }
        public DateTime expiration { get; set; }
    }
}
