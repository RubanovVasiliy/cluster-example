using System.ComponentModel.DataAnnotations;

namespace virtualization;

public class User
{
    [Key] public Guid Id { get; set; }
    public string Usermane { get; set; }   
    public string Password { get; set; }
    public int Age { get; set; }
    public DateTime RegistryDate { get; set; }
}