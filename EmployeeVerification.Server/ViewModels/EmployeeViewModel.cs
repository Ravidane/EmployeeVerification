using System.ComponentModel.DataAnnotations;

namespace EmployeeVerification.Server.ViewModels;

public class EmployeeViewModel
{
    [Required]
    public long EmployeeID { get; set; }
    [Required]
    public required string ValidationCode { get; set; }
    [Required]
    public required string CompanyName { get; set; }
}