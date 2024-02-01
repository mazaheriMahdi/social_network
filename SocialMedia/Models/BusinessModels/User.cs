using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Models.BusinessModels;

public class User
{
    public long Id { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string UniversityLocation { get; set; }
    public string Field { get; set; }
    public string Workplace { get; set; }
    public string[] Specialties { get; set; }
    public long[] ConnectionId { get; set; }
}