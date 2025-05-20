using System.ComponentModel.DataAnnotations;

namespace SchoolRegister.ViewModels.VM
{
    public class SendEmailToParentVm
    {
        [Required]
        public int SenderId { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public string Content { get; set; } = null!;
    }
}