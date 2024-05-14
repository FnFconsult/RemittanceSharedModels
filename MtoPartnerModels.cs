using System.ComponentModel.DataAnnotations;

namespace RemittanceSharedModels
{
    public class MtoUser : AuditFields
    {
        public long MoneyTransferOperatorId { get; set; }
        public virtual MoneyTransferOperator MoneyTransferOperator { get; set; }
        [MaxLength(128), Required]
        public string Name { get; set; }
        [MaxLength(128), Required]
        public string UserName { get; set; }
        [MaxLength(128)]
        public string? Email { get; set; }
        [MaxLength(128)]
        public string? PhoneNumber { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; }
        public string Hash { get; set; }
    }

    public class CreateMtoUser
    {
        public long MoneyTransferOperatorId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public bool IsActive { get; set; } = true;
        public string Password { get; set; }
    }

    public class UpdateMtoUser
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
