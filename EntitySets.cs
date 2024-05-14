using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RemittanceSharedModels
{
    public class HasId
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
    }

    public class AuditFields : HasId
    {
        //[Required]
        [Description("User who created the record")]
        public string CreatedBy { get; set; }
        //[Required]
        [Description("The last user who modified the record")]
        public string ModifiedBy { get; set; }
        [Description("Date the record was created")]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow.ToUniversalTime();
        [Description("Last date the record was modified")]
        public DateTimeOffset ModifiedAt { get; set; } = DateTimeOffset.UtcNow.ToUniversalTime();
    }

    public class LookUp : AuditFields
    {
        [Description("The value of the name property of the record")]
        [MaxLength(128), Required]
        public string Name { get; set; }
        [Description("Notes associated with the record")]
        [MaxLength(128)]
        public string Notes { get; set; }
    }
    /// <summary>
    /// Role class defines the role structure in the database schema
    /// </summary>
    public class Role : IdentityRole
    {
        [Description("Date the record was created")]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow.ToUniversalTime();
        [Description("Last date the record was modified")]
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow.ToUniversalTime();
        [Description("Deleted state of the record")]
        public bool IsDeleted { get; set; } = false;
        [Description("Collection of users with this role")]
        public virtual ICollection<UserRole> UserRoles { get; set; }
        [Description("Collection of role claims")]
        public virtual ICollection<RoleClaim> RoleClaims { get; set; }
        [NotMapped]
        public List<string> Claims { get; set; }
        [Description("Locked records can't be deleted or updated")]
        public bool Locked { get; set; } = false;
        public string Notes { get; set; }
    }

    public class RoleClaim : IdentityRoleClaim<string>
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
        public virtual Role Role { get; set; }
    }
    /// <summary>
    /// User class defines the user structure in the database schema
    /// </summary>
    public class User : IdentityUser
    {
        [MaxLength(128), Required]
        public string Name { get; set; }
        [Description("Date the record was created")]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow.ToUniversalTime();
        [Description("Last date the record was modified")]
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow.ToUniversalTime();
        [Description("Deleted state of the record")]
        public bool IsDeleted { get; set; } = false;
        [Description("Locked records can't be deleted or updated")]
        public bool Locked { get; set; } = true;
        [Description("Hidden records won't be included in the list")]
        public bool Hidden { get; set; } = false;
        [Description("Collection of user claims")]
        public virtual ICollection<UserClaim> Claims { get; set; }
        [Description("Collection of user logins")]
        public virtual ICollection<UserLogin> Logins { get; set; }
        [Description("Collection of user tokens")]
        public virtual ICollection<UserToken> Tokens { get; set; }
        [Description("Collection of role user roles")]
        public virtual ICollection<UserRole> UserRoles { get; set; }
        [NotMapped]
        public string Password { get; set; }
        [NotMapped]
        public string Role { get; set; }
    }

    public class UserClaim : IdentityUserClaim<string>
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
        public virtual User User { get; set; }
    }

    public class UserLogin : IdentityUserLogin<string>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public virtual User User { get; set; }
    }

    public class UserRole : IdentityUserRole<string>
    {
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }

    public class UserToken : IdentityUserToken<string>
    {
        public virtual User User { get; set; }
    }

    public class AppSetting : AuditFields
    {
        [MaxLength(128), Required]
        public string Name { get; set; }
        public string Value { get; set; }
    }
    /// <summary>
    /// Message class defines the message structure in the database schema
    /// </summary>
    public class Message : HasId
    {
        [MaxLength(128), Required]
        [Description("Message Recipient")]
        public string Recipient { get; set; }
        [MaxLength(128)]
        [Description("Message Recipient Name")]
        public string Name { get; set; }
        [MaxLength(128)]
        [Description("Message Subject")]
        public string Subject { get; set; }
        [Required]
        [Description("Message Text")]
        public string Text { get; set; }
        [Description("Message Status. Enum: Sent, Recieved, Failed")]
        public MessageStatus Status { get; set; }
        [Description("Message Type. Enum: SMS and Email ")]
        public MessageType Type { get; set; } = MessageType.Sms;
        [MaxLength(5000)]
        [Description("Message Response")]
        public string Response { get; set; }
        [Description("Timestamp")]
        public DateTimeOffset TimeStamp { get; set; }
        [Description("SentTime")]
        public DateTimeOffset? SentTime { get; set; }
        public string? BulkId { get; set; }
        public string? MessageId { get; set; }
        [NotMapped]
        public string Attachment { get; set; }
    }

    public enum MessageType
    {
        Sms,
        Email
    }
    public enum MessageStatus
    {
        Pending,
        Sent,
        Received,
        Failed,
        Delivered
    }

    /// <summary>
    /// IdType class defines the IdType structure in the database schema
    /// </summary>
    public class IdType : LookUp
    {
        [Required, MaxLength(50)]
        [Description("Id Type Code")]
        public string Code { get; set; }
    }

    public class Currency : LookUp
    {
        [Required, MaxLength(50)]
        public string Number { get; set; }
        [MaxLength(50)]
        [Description("Currency Code")]
        public string Code { get; set; }
    }

    public class PaymentFailureReason : LookUp
    {
    }

    public class PaymentFailureRecommendation : LookUp
    {
    }


    public class CurrencyVm
    {
        public long Id { get; set; }
        [Description("The value of the symbol property of the record")]
        [Required, MaxLength(50)]
        public string Number { get; set; }

        [Description("The value of the name property of the record")]
        [MaxLength(128)]
        public string Name { get; set; }
        [Description("Notes associated with the record")]
        [MaxLength(128)]
        public string Notes { get; set; }
        [MaxLength(50)]
        [Description("Currency Code")]
        public string Code { get; set; }
    }

    public class Country : LookUp
    {
        [MaxLength(128)]
        [Description("Id Country Alpha 2 Code")]
        public string Alpha2Code { get; set; }

        [MaxLength(128)]
        [Description("Id Country Alpha 3 Code")]
        public string Alpha3Code { get; set; }

        [MaxLength(128)]
        [Description("Id Country Numeric Code")]
        public string NumericCode { get; set; }
    }

    public class CountryVm
    {
        public long Id { get; set; }
        [MaxLength(2)]
        [Description("Id Country Alpha 2 Code")]
        public string Alpha2Code { get; set; }

        [MaxLength(3)]
        [Description("Id Country Alpha 3 Code")]
        public string Alpha3Code { get; set; }

        [MaxLength(4)]
        [Description("Id Country Numeric Code")]
        public string NumericCode { get; set; }

        [Description("The value of the name property of the record")]
        [MaxLength(128)]
        public string Name { get; set; }
        [Description("Notes associated with the record")]
        [MaxLength(128)]
        public string Notes { get; set; }
    }

    public class Bank : LookUp
    {
        public string SortCode { get; set; }
        public string RoutingCode { get; set; }
        public virtual List<BankBranch> Branches { get; set; }
    }
    public class BankVm
    {
        /// <summary>
        /// A unique Id for the record.
        /// </summary>
        /// <example>1</example>
        public long Id { get; set; }
        [MaxLength(50)]
        [Description("Bank Code")]
        public string Code { get; set; }

        [Description("The value of the name property of the record")]
        [MaxLength(128)]
        public string Name { get; set; }
        [Description("Notes associated with the record")]
        [MaxLength(128)]
        public string Notes { get; set; }
        public string Type { get; set; }
    }
    public class BankBranch : LookUp
    {
        [MaxLength(50)]
        [Description("Bank Branch Code")]
        public string Code { get; set; }
        public long BankId { get; set; }
        public virtual Bank Bank { get; set; }
        [MaxLength(128)]
        public string Location { get; set; }
    }

    public class BankBranchVm
    {
        public long Id { get; set; }
        [MaxLength(50)]
        [Description("Bank Branch Code")]
        public string Code { get; set; }

        [Description("The value of the name property of the record")]
        [MaxLength(128)]
        public string Name { get; set; }
        [Description("Location associated with the record")]
        [MaxLength(128)]
        public string Location { get; set; }
        public long BankId { get; set; }
        [Description("Name of the Associated Bank")]
        [MaxLength(128)]
        public string Bank { get; set; }
    }

    public class MoneyTransferOperator : AuditFields
    {
        [Required, MaxLength(256)]
        public string Name { get; set; }
        [Required, MaxLength(32)]
        public string Code { get; set; }
        [MaxLength(6)]
        public string? Abbrev { get; set; }
        //[Required, MaxLength(64)]
        //public string Location { get; set; }
        //[MaxLength(512)]
        //public string Address { get; set; }
        //[MaxLength(128)]
        //public string ContactPersonName { get; set; }
        //[MaxLength(64)]
        //public string ContactPhoneNumber { get; set; }
        //[MaxLength(64)]
        //public string ContactEmail { get; set; }
        public bool IsActive { get; set; }
        public long CountryId { get; set; }
        public virtual Country Country { get; set; }
        public string AuthToken { get; set; }
        public string AuthPin { get; set; }
        public double Balance { get; set; }
        public double Limit { get; set; }
        public double Threshold { get; set; }
    }

    public class MoneyTransferOperatorVm : HasId
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Abbrev { get; set; }
        //public string Location { get; set; }
        //public string Address { get; set; }
        //public string ContactPersonName { get; set; }
        //public string ContactPhoneNumber { get; set; }
        //public string ContactEmail { get; set; }
        public bool IsActive { get; set; }
        public long CountryId { get; set; }
        public double Balance { get; set; }
        public double Limit { get; set; }
        public double Threshold { get; set; }
    }

    public class MoneyTransferOperatorAccountBalanceAdjustment : AuditFields
    {
        public DateTimeOffset Date { get; set; }
        public long MoneyTransferOperatorId { get; set; }
        public virtual MoneyTransferOperator MoneyTransferOperator { get; set; }
        public string Narrative { get; set; }
        public double Amount { get; set; }
        public string Type { get; set; } //Debit/Credit
        public double? Balance { get; set; }
        public DateTimeOffset? VettedOn { get; set; }
        public string? VettedBy { get; set; }
        public string? VettingNotes { get; set; }
        public VettingStatus VettingStatus { get; set; } = VettingStatus.Pending;
    }

    public class MtoStatementVM
    {
        public DateTimeOffset Date { get; set; }
        public string Narrative { get; set; }
        public double Balance { get; set; } = 0;
        public double Debit { get; set; } = 0;
        public double Credit { get; set; } = 0;
    }
    public class MoneyTransferOperatorAccountAdjustmentVm
    {
        public DateTimeOffset Date { get; set; }
        public long MoneyTransferOperatorId { get; set; }
        public string Narrative { get; set; }
        public double Amount { get; set; }
    }

    public class RejectAccountAction
    {
        public long Id { get; set; }
        public string? Notes { get; set; }
    }

    public class MoneyTransferOperatorAccountLimitAdjustment : AuditFields
    {
        public DateTimeOffset Date { get; set; }
        public long MoneyTransferOperatorId { get; set; }
        public virtual MoneyTransferOperator MoneyTransferOperator { get; set; }
        public string Narrative { get; set; }
        public double NewLimit { get; set; }
        public DateTimeOffset? VettedOn { get; set; }
        public string? VettedBy { get; set; }
        public string? VettingNotes { get; set; }
        public VettingStatus VettingStatus { get; set; } = VettingStatus.Pending;
    }

    public enum VettingStatus
    {
        Pending,
        Approved,
        Rejected
    }

    public class MoneyTransferOperatorAccountLimitAdjustmentVm
    {
        public DateTimeOffset Date { get; set; }
        public long MoneyTransferOperatorId { get; set; }
        public string Narrative { get; set; }
        public double NewLimit { get; set; }
    }

    public class MoneyTransferOperatorAccountThresholdAdjustment : AuditFields
    {
        public DateTimeOffset Date { get; set; }
        public long MoneyTransferOperatorId { get; set; }
        public virtual MoneyTransferOperator MoneyTransferOperator { get; set; }
        public string Narrative { get; set; }
        public double NewThreshold { get; set; }
        public DateTimeOffset? VettedOn { get; set; }
        public string? VettedBy { get; set; }
        public string? VettingNotes { get; set; }
        public VettingStatus VettingStatus { get; set; } = VettingStatus.Pending;
    }

    public class MoneyTransferOperatorAccountThresholdAdjustmentVm
    {
        public DateTimeOffset Date { get; set; }
        public long MoneyTransferOperatorId { get; set; }
        public string Narrative { get; set; }
        public double NewThreshold { get; set; }
    }

    public class SetMoneyTransferOperatorAuthPinVm
    {
        public long MoneyTransferOperatorId { get; set; }
        public string NewPin { get; set; }
    }

    /// <summary>
    /// SystemLog class defines the system log structure in the database schema
    /// </summary>
    public class SystemLog : HasId
    {
        [Description("The log date")]
        public DateTimeOffset Date { get; set; } = DateTimeOffset.UtcNow;
        [Description("The user who made the log")]
        public string User { get; set; }
        [Description("The payload")]
        public string Payload { get; set; }
        [Description("Model involed")]
        public string Model { get; set; }
        [Description("Log notes")]
        public string Notes { get; set; }
        [Description("The system log type")]
        public SystemLogType Type { get; set; }
    }

    public enum SystemLogType
    {
        Login,
        Logout,
        PasswordChange,
        PasswordReset,
        Insert,
        Update,
        Delete,
        Upload,
        Download
    }

    [Index(new[] { nameof(TransactionId), nameof(MoneyTransferOperatorId) }, IsUnique = true)]
    public class TransactionRequest : AuditFields
    {
        [Required]
        public long MoneyTransferOperatorId { get; set; }
        public virtual MoneyTransferOperator MoneyTransferOperator { get; set; }
        [Required]
        public string TransactionId { get; set; }
        [Required, MaxLength(64)]
        public string Reference { get; set; }
        public DateTimeOffset Date { get; set; } = DateTimeOffset.UtcNow;
        
        [Required, MaxLength(64)]
        public string PIN { get; set; }
        public string CountryFrom { get; set; }
        public string CountryTo { get; set; }
        public string BeneficiaryQuestion { get; set; }
        public string BeneficiaryAnswer { get; set; }
        public string? PaymentInstructions { get; set; }
        public string OriginalCurrency { get; set; }
        public double OriginalAmount { get; set; }
        public string PaymentCurrency { get; set; }
        public double PaymentAmount { get; set; }
        public string CommissionCurrency { get; set; }
        public double CommissionAmount { get; set; }
        public string BeneficiaryId { get; set; }
        public string BeneficiaryFullName { get; set; }
        public string BeneficiaryFirstName { get; set; }
        public string? BeneficiaryMiddleName { get; set; }
        public string BeneficiaryLastName { get; set; }
        public string? BeneficiaryAddress { get; set; }
        public string? BeneficiaryCity { get; set; }
        public string BeneficiaryCountry { get; set; }
        public string? BeneficiaryPhoneNumber { get; set; }
        public string? BeneficiaryEmail { get; set; }
        public string? BeneficiarySex { get; set; }
        public string? BeneficiaryIdType { get; set; }
        public string? BeneficiaryIdNumber { get; set; }
        public string? BeneficiaryTaxId { get; set; }
        public string? CustomerId { get; set; }
        public string CustomerFullName { get; set; }
        public string CustomerFirstName { get; set; }
        public string? CustomerMiddleName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerCountry { get; set; }
        public string? CustomerIdType { get; set; }
        public string? CustomerIdNumber { get; set; }
        public string? CustomerIdIssuedBy { get; set; }
        public string? CustomerIdIssueCountry { get; set; }
        public DateTimeOffset? CustomerIdIssuedDate { get; set; }
        public DateTimeOffset? CustomerIdExpirationDate { get; set; }
        public string? CustomerCountryOfBirth { get; set; }
        public string CustomerNationality { get; set; }
        public DateTimeOffset? CustomerDateOfBirth { get; set; }
        public string CustomerOccupation { get; set; }
        public string CustomerSourceOfFunds { get; set; }
        public string? CustomerSex { get; set; }
        public string? CustomerPhoneNumber { get; set; }
        public string? CustomerEmail { get; set; }
        public string Purpose { get; set; }
        public string? BankName { get; set; }
        public string? BankAccountNo { get; set; }
        public string? RoutingCode { get; set; }
        public TransactionType TransactionType { get; set; }
        public string? MobileWalletAccountNumber { get; set; }
        public TransactionRequestStatus Status { get; set; } = TransactionRequestStatus.Pending;
        public string? CallBackUrl { get; set; }
        public bool FinalStatusReported { get; set; } = false;
        public string TrackingNumber { get; set; }
        public double BalanceBefore { get; set; }
        public double BalanceAfter { get; set; }
        public DateTimeOffset? ScreeningStartDate { get; set; }
        public DateTimeOffset? ScreeningEndDate { get; set; }
        public DateTimeOffset? PaymentStartDate { get; set; }
        public DateTimeOffset? PaymentEndDate { get; set; }
        public string? Notes { get; set; }
        public bool PaymentFailureReported { get; set; } = false;
        public bool RejectionReported { get; set; } = false;
        public string? RejectionReason { get; set; }
        public string? PaymentFailedReason { get; set; }
        public string? PaymentFailedRecommendations { get; set; }
        public string PaymentPartner { get; set; }
        public int TsqRetries { get; set; } = 0;
        public string? SessionId { get; set; }
        public string? ElevyId { get; set; }
        public string? ElevyReserveTimestamp { get; set; }
        public string? ElevyReserverResponseTimestamp { get; set; }
        public string? ElevyStatus { get; set; }
        public double ElevyTaxableAmount { get; set; } = 0;
        public double ElevyAmount { get; set; } = 0;
        public string? ElevyClientTransactionId { get; set; }
        public string? ElevyConfirmedResponseTimestamp { get; set; }
        public string? ElevyCancelledResponseTimestamp { get; set; }
        public string? FullData { get; set; }
    }

    [Index(new[] { nameof(TransactionId), nameof(MoneyTransferOperatorId) }, IsUnique = true)]
    public class PendingTransactionRequest : AuditFields
    {
        [Required]
        public long MoneyTransferOperatorId { get; set; }
        public virtual MoneyTransferOperator MoneyTransferOperator { get; set; }
        [Required]
        public string TransactionId { get; set; }
        [Required, MaxLength(64)]
        public string Reference { get; set; }
        public DateTimeOffset Date { get; set; } = DateTimeOffset.UtcNow;

        [Required, MaxLength(64)]
        public string PIN { get; set; }
        public string CountryFrom { get; set; }
        public string CountryTo { get; set; }
        public string BeneficiaryQuestion { get; set; }
        public string BeneficiaryAnswer { get; set; }
        public string? PaymentInstructions { get; set; }
        public string OriginalCurrency { get; set; }
        public double OriginalAmount { get; set; }
        public string PaymentCurrency { get; set; }
        public double PaymentAmount { get; set; }
        public string CommissionCurrency { get; set; }
        public double CommissionAmount { get; set; }
        public string BeneficiaryId { get; set; }
        public string BeneficiaryFullName { get; set; }
        public string BeneficiaryFirstName { get; set; }
        public string? BeneficiaryMiddleName { get; set; }
        public string BeneficiaryLastName { get; set; }
        public string? BeneficiaryAddress { get; set; }
        public string? BeneficiaryCity { get; set; }
        public string BeneficiaryCountry { get; set; }
        public string? BeneficiaryPhoneNumber { get; set; }
        public string? BeneficiaryEmail { get; set; }
        public string? BeneficiarySex { get; set; }
        public string? BeneficiaryIdType { get; set; }
        public string? BeneficiaryIdNumber { get; set; }
        public string? BeneficiaryTaxId { get; set; }
        public string? CustomerId { get; set; }
        public string CustomerFullName { get; set; }
        public string CustomerFirstName { get; set; }
        public string? CustomerMiddleName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerCountry { get; set; }
        public string? CustomerIdType { get; set; }
        public string? CustomerIdNumber { get; set; }
        public string? CustomerIdIssuedBy { get; set; }
        public string? CustomerIdIssueCountry { get; set; }
        public DateTimeOffset? CustomerIdIssuedDate { get; set; }
        public DateTimeOffset? CustomerIdExpirationDate { get; set; }
        public string? CustomerCountryOfBirth { get; set; }
        public string CustomerNationality { get; set; }
        public DateTimeOffset? CustomerDateOfBirth { get; set; }
        public string CustomerOccupation { get; set; }
        public string CustomerSourceOfFunds { get; set; }
        public string? CustomerSex { get; set; }
        public string? CustomerPhoneNumber { get; set; }
        public string? CustomerEmail { get; set; }
        public string Purpose { get; set; }
        public string? BankName { get; set; }
        public string? BankAccountNo { get; set; }
        public string? RoutingCode { get; set; }
        public TransactionType TransactionType { get; set; }
        public string? MobileWalletAccountNumber { get; set; }
        public TransactionRequestStatus Status { get; set; } = TransactionRequestStatus.Pending;
        public string? CallBackUrl { get; set; }
        public bool FinalStatusReported { get; set; } = false;
        public string TrackingNumber { get; set; }
        public double BalanceBefore { get; set; }
        public double BalanceAfter { get; set; }
        public DateTimeOffset? ScreeningStartDate { get; set; }
        public DateTimeOffset? ScreeningEndDate { get; set; }
        public DateTimeOffset? PaymentStartDate { get; set; }
        public DateTimeOffset? PaymentEndDate { get; set; }
        public string? Notes { get; set; }
        public bool PaymentFailureReported { get; set; } = false;
        public bool RejectionReported { get; set; } = false;
        public string? RejectionReason { get; set; }
        public string? PaymentFailedReason { get; set; }
        public string? PaymentFailedRecommendations { get; set; }
        public string PaymentPartner { get; set; }
        public int TsqRetries { get; set; } = 0;
        public string? SessionId { get; set; }
        public string? ElevyId { get; set; }
        public string? ElevyReserveTimestamp { get; set; }
        public string? ElevyReserverResponseTimestamp { get; set; }
        public string? ElevyStatus { get; set; }
        public double ElevyTaxableAmount { get; set; } = 0;
        public double ElevyAmount { get; set; } = 0;
        public string? ElevyClientTransactionId { get; set; }
        public string? ElevyConfirmedResponseTimestamp { get; set; }
        public string? ElevyCancelledResponseTimestamp { get; set; }
        public string? FullData { get; set; }
    }

    [Index(new[] { nameof(TransactionId), nameof(MoneyTransferOperatorId) }, IsUnique = false)]
    public class ArchivedTransactionRequest : AuditFields
    {
        [Required]
        public long MoneyTransferOperatorId { get; set; }
        public virtual MoneyTransferOperator MoneyTransferOperator { get; set; }
        [Required]
        public string TransactionId { get; set; }
        [Required, MaxLength(64)]
        public string Reference { get; set; }
        public DateTimeOffset Date { get; set; } = DateTimeOffset.UtcNow;

        [Required, MaxLength(64)]
        public string PIN { get; set; }
        public string CountryFrom { get; set; }
        public string CountryTo { get; set; }
        public string BeneficiaryQuestion { get; set; }
        public string BeneficiaryAnswer { get; set; }
        public string? PaymentInstructions { get; set; }
        public string OriginalCurrency { get; set; }
        public double OriginalAmount { get; set; }
        public string PaymentCurrency { get; set; }
        public double PaymentAmount { get; set; }
        public string CommissionCurrency { get; set; }
        public double CommissionAmount { get; set; }
        public string BeneficiaryId { get; set; }
        public string BeneficiaryFullName { get; set; }
        public string BeneficiaryFirstName { get; set; }
        public string? BeneficiaryMiddleName { get; set; }
        public string BeneficiaryLastName { get; set; }
        public string? BeneficiaryAddress { get; set; }
        public string? BeneficiaryCity { get; set; }
        public string BeneficiaryCountry { get; set; }
        public string? BeneficiaryPhoneNumber { get; set; }
        public string? BeneficiaryEmail { get; set; }
        public string? BeneficiarySex { get; set; }
        public string? BeneficiaryIdType { get; set; }
        public string? BeneficiaryIdNumber { get; set; }
        public string? BeneficiaryTaxId { get; set; }
        public string? CustomerId { get; set; }
        public string CustomerFullName { get; set; }
        public string CustomerFirstName { get; set; }
        public string? CustomerMiddleName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerCountry { get; set; }
        public string? CustomerIdType { get; set; }
        public string? CustomerIdNumber { get; set; }
        public string? CustomerIdIssuedBy { get; set; }
        public string? CustomerIdIssueCountry { get; set; }
        public DateTimeOffset? CustomerIdIssuedDate { get; set; }
        public DateTimeOffset? CustomerIdExpirationDate { get; set; }
        public string? CustomerCountryOfBirth { get; set; }
        public string CustomerNationality { get; set; }
        public DateTimeOffset? CustomerDateOfBirth { get; set; }
        public string CustomerOccupation { get; set; }
        public string CustomerSourceOfFunds { get; set; }
        public string? CustomerSex { get; set; }
        public string? CustomerPhoneNumber { get; set; }
        public string? CustomerEmail { get; set; }
        public string Purpose { get; set; }
        public string? BankName { get; set; }
        public string? BankAccountNo { get; set; }
        public string? RoutingCode { get; set; }
        public TransactionType TransactionType { get; set; }
        public string? MobileWalletAccountNumber { get; set; }
        public TransactionRequestStatus Status { get; set; } = TransactionRequestStatus.Pending;
        public string? CallBackUrl { get; set; }
        public bool FinalStatusReported { get; set; } = false;
        public string TrackingNumber { get; set; }
        public double BalanceBefore { get; set; }
        public double BalanceAfter { get; set; }
        public DateTimeOffset? ScreeningStartDate { get; set; }
        public DateTimeOffset? ScreeningEndDate { get; set; }
        public DateTimeOffset? PaymentStartDate { get; set; }
        public DateTimeOffset? PaymentEndDate { get; set; }
        public string? Notes { get; set; }
        public bool PaymentFailureReported { get; set; } = false;
        public bool RejectionReported { get; set; } = false;
        public string? RejectionReason { get; set; }
        public string? PaymentFailedReason { get; set; }
        public string? PaymentFailedRecommendations { get; set; }
        public string PaymentPartner { get; set; }
        public int TsqRetries { get; set; } = 0;
        public string? SessionId { get; set; }
        public string? ElevyId { get; set; }
        public string? ElevyReserveTimestamp { get; set; }
        public string? ElevyReserverResponseTimestamp { get; set; }
        public string? ElevyStatus { get; set; }
        public double ElevyTaxableAmount { get; set; } = 0;
        public double ElevyAmount { get; set; } = 0;
        public string? ElevyClientTransactionId { get; set; }
        public string? ElevyConfirmedResponseTimestamp { get; set; }
        public string? ElevyCancelledResponseTimestamp { get; set; }
        public string? FullData { get; set; }
    }

    public class ArchivedPaymentOrderReversalRequest : AuditFields
    {
        [Required]
        public string TransactionId { get; set; }
        public string TransactionRequestReference { get; set; }
        public string Reason { get; set; }
        public DateTimeOffset? VettedOn { get; set; }
        public string? VettedBy { get; set; }
        public string? VettingNotes { get; set; }
        public bool Processed { get; set; } = false;
        public string Status { get; set; }
        public DateTimeOffset? ApprovedOn { get; set; }
        public string? ApprovedBy { get; set; }
        public double ReversalCharge { get; set; }
    }
    public class TransactionRequestMtoVm : AuditFields
    {
        [Required]
        public string RequestId { get; set; }
        [Required]
        public string TransactionId { get; set; }
        [Required, MaxLength(64)]
        public string Reference { get; set; }
        public DateTimeOffset Date { get; set; } = DateTimeOffset.UtcNow;

        [Required, MaxLength(64)]
        public string OrderNo { get; set; }
        [Required, MaxLength(64)]
        public string PIN { get; set; }
        public long? SendingCorrespondenceSequenceId { get; set; }
        public long? PayingCorrespondenceSeqequenceId { get; set; }
        public string SalesDate { get; set; }
        public string SalesTime { get; set; }
        public string CountryFrom { get; set; }
        public string CountryTo { get; set; }
        public long? PayingCorrespondenceLocationId { get; set; }
        public string? SendingCorrespondenceBranchNumber { get; set; }
        public string BeneficiaryQuestion { get; set; }
        public string BeneficiaryAnswer { get; set; }
        public string? PaymentInstructions { get; set; }
        public string OriginalCurrency { get; set; } //BeneficiaryCurrency
        public double OriginalAmount { get; set; } //BeneficiaryAmount
        public long DeliveryMethod { get; set; }
        public string PaymentCurrency { get; set; }
        public double PaymentAmount { get; set; }
        public string CommissionCurrency { get; set; }
        public double CommissionAmount { get; set; }
        public string? CustomerChargeCurrency { get; set; }
        public double? CustomerChargeAmount { get; set; }
        public string BeneficiaryId { get; set; }
        public string BeneficiaryFullName { get; set; }
        public string BeneficiaryFirstName { get; set; }
        public string? BeneficiaryMiddleName { get; set; }
        public string BeneficiaryLastName { get; set; }
        public string? BeneficiaryLastName2 { get; set; }
        public string BeneficiaryAddress { get; set; }
        public string BeneficiaryCity { get; set; }
        public string? BeneficiaryState { get; set; }
        public string? BeneficiaryZipCode { get; set; }
        public string BeneficiaryCountry { get; set; }
        public string BeneficiaryPhoneNumber { get; set; }
        public string? BeneficiaryCellNumber { get; set; }
        public string BeneficiaryMessage { get; set; }
        public string? CustomerId { get; set; }
        public string CustomerFullName { get; set; }
        public string CustomerFirstName { get; set; }
        public string? CustomerMiddleName { get; set; }
        public string CustomerLastName { get; set; }
        public string? CustomerLastName2 { get; set; }
        public string CustomerCountry { get; set; }
        public string CustomerId1Type { get; set; }
        public string CustomerId1Number { get; set; }
        public string? CustomerId1IssuedBy { get; set; }
        public string? CustomerId1IssuedByState { get; set; }
        public string CustomerId1IssuedByCountry { get; set; }
        public string CustomerId1IssuedDate { get; set; }
        public string CustomerId1ExpirationDate { get; set; }
        public string? CustomerId2Type { get; set; }
        public string? CustomerId2No { get; set; }
        public string? CustomerId2IssuedBy { get; set; }
        public string? CustomerId2IssuedByState { get; set; }
        public string? CustomerId2IssuedByCountry { get; set; }
        public string? CustomerId2IssuedDate { get; set; }
        public string? CustomerId2ExpirationDate { get; set; }
        public string? CustomerId3Type { get; set; }
        public string? CustomerId3No { get; set; }
        public string? CustomerId3IssuedBy { get; set; }
        public string? CustomerId3IssuedByState { get; set; }
        public string? CustomerId3IssuedByCountry { get; set; }
        public string? CustomerId3IssuedDate { get; set; }
        public string? CustomerId3ExpirationDate { get; set; }
        public string? CustomerId4Type { get; set; }
        public string? CustomerId4No { get; set; }
        public string? CustomerId4IssuedBy { get; set; }
        public string? CustomerId4IssuedByState { get; set; }
        public string? CustomerId4IssuedByCountry { get; set; }
        public string? CustomerId4IssuedDate { get; set; }
        public string? CustomerId4ExpirationDate { get; set; }
        public string? CustomerTaxId { get; set; }
        public string? CustomerTaxCountry { get; set; }
        public string CustomerCountryOfBirth { get; set; }
        public string CustomerNationality { get; set; }
        public string? CustomerDateOfBirth { get; set; }
        public string CustomerOccupation { get; set; }
        public string CustomerSourceOfFunds { get; set; }
        public string Purpose { get; set; }
        public string? BankName { get; set; }
        public string? BankAccountType { get; set; }
        public string? BankAccountNo { get; set; }
        public string BeneficiaryIdType { get; set; }
        public string BeneficiaryIdNumber { get; set; }
        public string? BeneficiaryTaxId { get; set; }
        public string? BankCity { get; set; }
        public string? BankBranchNumber { get; set; }
        public string? BankBranchName { get; set; }
        public string? BankBranchAddress { get; set; }
        public string? BankCode { get; set; }
        public string? BankRoutingCode { get; set; }
        public string? BankIdentifierCodeOrSWIFT { get; set; }
        public string? UnitaryBankAccountNumber { get; set; }
        public string Valuetype { get; set; }
        public string? MobileWalletPrefix { get; set; }
        public string? MobileWalletAccountNumber { get; set; }
        public TransactionRequestStatus Status { get; set; } = TransactionRequestStatus.Pending;
        //public string? RejectionReason { get; set; }
        //public string? PaymentFailedReason { get; set; }
        //public string? VerificationFailedReason { get; set; }
        //public string? CancellationReason { get; set; }
        public string? CallBackUrl { get; set; }
        //public string? ProcessingFailedReason { get; set; }
        public DateTimeOffset? PaidOn { get; set; }
        public bool FinalStatusReported { get; set; } = false;
        public string GipTrackingNumber { get; set; }
        public double BalanceBefore { get; set; }
        public double BalanceAfter { get; set; }
        public DateTimeOffset? ScreeningStartDate { get; set; }
        public DateTimeOffset? ScreeningEndDate { get; set; }
        //public string? ComplianceCheckErrorMessage { get; set; }
        public DateTimeOffset? PaymentStartDate { get; set; }
        public DateTimeOffset? PaymentEndDate { get; set; }
        public string? Notes { get; set; }
        public string? CustomerSex { get; set; }
        public string? BeneficiarySex { get; set; }
        public string? CustomerPhoneNumber { get; set; }
        public string? CustomerEmail { get; set; }
        public string? BeneficiaryEmail { get; set; }
        public bool RejectionReported { get; set; } = false;
        public string? RejectionReason { get; set; }
        public string? PaymentFailedReason { get; set; }

    }

    public class TransactionRequestComplianceDTO
    {
        public long Id { get; set; }
        public long MtoId { get; set; }
        public string TransactionId { get; set; }
        public string Reference { get; set; }
        public string TransactionType { get; set; }
        public DateTimeOffset Date { get; set; } = DateTimeOffset.UtcNow;
        public string CountryFrom { get; set; }
        public double PaymentAmount { get; set; }
        public string BeneficiaryFullName { get; set; }
        public string BeneficiaryCountry { get; set; }
        public string BeneficiaryPhoneNumber { get; set; }
        public string CustomerFullName { get; set; }
        public string CustomerCountry { get; set; }
        public string Purpose { get; set; }
        public string Status { get; set; }
        public DateTimeOffset? ScreeningStartDate { get; set; }
        public DateTimeOffset? ScreeningEndDate { get; set; }
        public string? Notes { get; set; }
        public string? RejectionReason { get; set; }
        public string? PaymentFailedReason { get; set; }

    }

    public class TransactionRequestPaymentDTO
    {
        public long Id { get; set; }
        public long MtoId { get; set; }
        public string TransactionId { get; set; }
        public string Reference { get; set; }
        public DateTimeOffset Date { get; set; } = DateTimeOffset.UtcNow;
        public string CountryFrom { get; set; }
        public double PaymentAmount { get; set; }
        public string BeneficiaryFullName { get; set; }
        public string BeneficiaryCountry { get; set; }
        public string BeneficiaryPhoneNumber { get; set; }
        public string CustomerFullName { get; set; }
        public string CustomerCountry { get; set; }
        public string Purpose { get; set; }
        public string Status { get; set; }
        public DateTimeOffset? PaymentStartDate { get; set; }
        public DateTimeOffset? PaymentEndDate { get; set; }
        public string? Notes { get; set; }
        public string? RejectionReason { get; set; }
        public string? PaymentFailedReason { get; set; }

    }

    public class TransactionRequestDetailsDTO
    {
        public long Id { get; set; }
        public string TransactionId { get; set; }
        public string Reference { get; set; }
        public DateTimeOffset Date { get; set; } = DateTimeOffset.UtcNow;
        public string CountryFrom { get; set; }
        public double PaymentAmount { get; set; }
        public string BeneficiaryFullName { get; set; }
        public string BeneficiaryCountry { get; set; }
        public string BeneficiaryPhoneNumber { get; set; }
        public string CustomerFullName { get; set; }
        public string CustomerCountry { get; set; }
        public string Purpose { get; set; }
        public string Status { get; set; }
        public DateTimeOffset? PaymentStartDate { get; set; }
        public DateTimeOffset? PaymentEndDate { get; set; }
        public DateTimeOffset? ScreeningStartDate { get; set; }
        public DateTimeOffset? ScreeningEndDate { get; set; }
        public string TransactionType { get; set; }
        public string? Notes { get; set; }
        public string? BankName { get; set; }
        public string? BankAccountNo { get; set; }
        public string? RoutingCode { get; set; }
        public string? BankRoutingCode { get; set; }
        public string? MobileWalletAccountNumber { get; set; }
        public string Type { get; set; }
        public string? CustomerSex { get; set; }
        public string? BeneficiarySex { get; set; }
        public string? CustomerPhoneNumber { get; set; }
        public string? CustomerEmail { get; set; }
        public string? BeneficiaryEmail { get; set; }
        public string? RejectionReason { get; set; }
        public string? PaymentFailedReason { get; set; }
        public string? PaymentFailedRecommendations { get; set; }
    }

    public class TransactionRequestDTO
    {
        public long Id { get; set; }
        public long MtoId { get; set; }
        public string TransactionId { get; set; }
        public string Reference { get; set; }
        public DateTimeOffset Date { get; set; } = DateTimeOffset.UtcNow;
        public string CountryFrom { get; set; }
        public string CountryTo { get; set; }
        public double PaymentAmount { get; set; }
        public string PaymentCurrency { get; set; }
        public string OriginalCurrency { get; set; } //BeneficiaryCurrency
        public double OriginalAmount { get; set; } //BeneficiaryAmount
        public string BeneficiaryFullName { get; set; }
        public string BeneficiaryCountry { get; set; }
        public string BeneficiaryPhoneNumber { get; set; }
        public string CustomerFullName { get; set; }
        public string CustomerCountry { get; set; }
        public string Purpose { get; set; }
        public string Status { get; set; }
        public string? Notes { get; set; }
        public string? CustomerSex { get; set; }
        public string? BeneficiarySex { get; set; }
        public string? CustomerPhoneNumber { get; set; }
        public string? CustomerEmail { get; set; }
        public string? BeneficiaryEmail { get; set; }
        public string? RejectionReason { get; set; }
        public string? PaymentFailedReason { get; set; }
        public string? PaymentFailedRecommendations { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }

    public class TransactionRequestDetailsMtosDTO
    {
        public long Id { get; set; }
        public string TransactionId { get; set; }
        public DateTimeOffset Date { get; set; }
        public long DeliveryMethod { get; set; }
        public string Type { get; set; }
        public string CountryFrom { get; set; }
        public string CountryTo { get; set; }
        public string OriginalCurrency { get; set; }
        public double OriginalAmount { get; set; }
        public string PaymentCurrency { get; set; }
        public double PaymentAmount { get; set; }
        public string BeneficiaryFullName { get; set; }
        public string BeneficiaryFirstName { get; set; }
        public string BeneficiaryLastName { get; set; }
        public string BeneficiaryPhoneNumber { get; set; }
        public string CustomerFullName { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerCountry { get; set; }
        public string CustomerOccupation { get; set; }
        public string Purpose { get; set; }
        public string? BankName { get; set; }
        public string? BankAccountNo { get; set; }
        public string? BankCode { get; set; }
        public string? BankRoutingCode { get; set; }
        public string Valuetype { get; set; }
        public string? MobileWalletAccountNumber { get; set; }
        public string RequestId { get; set; }
        public string Reference { get; set; }
        public long Status { get; set; }
        public DateTimeOffset? PaymentStartDate { get; set; }
        public DateTimeOffset? PaymentEndDate { get; set; }
        public DateTimeOffset? ScreeningStartDate { get; set; }
        public DateTimeOffset? ScreeningEndDate { get; set; }
        public string? Notes { get; set; }
        public string? CustomerSex { get; set; }
        public string? BeneficiarySex { get; set; }
        public string? CustomerPhoneNumber { get; set; }
        public string? CustomerEmail { get; set; }
        public string? BeneficiaryEmail { get; set; }
        public string? RejectionReason { get; set; }
        public string? PaymentFailedReason { get; set; }
        public string? PaymentFailedRecommendations { get; set; }
    }

    public class TransactionRequestDetailsMtosDTOV2
    {
        [Required]
        public string TransactionId { get; set; }
        public DateTimeOffset Date { get; set; } = DateTimeOffset.UtcNow;
        public string CountryFrom { get; set; }
        public string CountryTo { get; set; }
        public string OriginalCurrency { get; set; } //BeneficiaryCurrency
        public double OriginalAmount { get; set; } //BeneficiaryAmount
        public long DeliveryMethod { get; set; }
        public string PaymentCurrency { get; set; }
        public double PaymentAmount { get; set; }
        public string BeneficiaryFirstName { get; set; }
        public string? BeneficiaryMiddleName { get; set; }
        public string BeneficiaryLastName { get; set; }
        public string? BeneficiaryPhoneNumber { get; set; }
        public string CustomerFirstName { get; set; }
        public string? CustomerMiddleName { get; set; }
        public string CustomerLastName { get; set; }
        public string? CustomerNationality { get; set; }
        public string? Purpose { get; set; }
        public string? BankName { get; set; }
        public string? BankAccountNo { get; set; }
        public string? BankRoutingCode { get; set; }
        public string? MobileWalletAccountNumber { get; set; }
        public string? CallBackUrl { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerSex { get; set; }
        public string? CustomerPhoneNumber { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public DateTimeOffset? PaymentStartDate { get; set; }
        public DateTimeOffset? PaymentEndDate { get; set; }
        public DateTimeOffset? ScreeningStartDate { get; set; }
        public DateTimeOffset? ScreeningEndDate { get; set; }
        public string? RejectionReason { get; set; }
        public string? PaymentFailedReason { get; set; }
        public string? PaymentFailedRecommendations { get; set; }
    }

    public enum TransactionType
    {
        MobileWallet = 0,
        BankAccount = 1,
        HomeDelivery = 2,
        Pickup = 3
    }

    public enum TransactionRequestStatus
    {
        Pending = 0,
        Received = 1,
        Processing = 2,
        ComplianceChecked = 3,
        UnderComplianceReview = 4,
        Paid = 6,
        PaymentInitiated = 7,
        PaymentFailed = 8,
        Rejected = 10,
        Canceled = 12,
        HasIssues = 13,
        InsufficientFunds = 14,
        Downloaded = 15,
        ComplianceCheckError = 16,
        ComplianceFailureConfirmed = 17,
        PaymentError = 18,
        ComplianceCheckByPass = 19,
        PaymentProcessing = 20,
        PaidPending = 21,
        PendingReversal = 22,
        Reversed = 23,
        PaymentBeingProcessed = 24,
        Inconclusive = 25,
        PaymentRerouting = 26,
        Acknowledged = 27,
    }

    public class TransactionRequestPayload : HasId
    {
        public DateTimeOffset Date { get; set; } = DateTimeOffset.UtcNow;
        public long MtoId { get; set; }
        public string Payload { get; set; }
        public string Reference { get; set; }
    }

    public class PaymentRequestPayload : HasId
    {
        public DateTimeOffset Date { get; set; } = DateTimeOffset.UtcNow;
        public string Payload { get; set; }
        public string Reference { get; set; }
    }

    public class ReceivedRequestPayload : HasId
    {
        public DateTimeOffset Date { get; set; } = DateTimeOffset.UtcNow;
        public string Payload { get; set; }
        public string Reference { get; set; }
        public string System { get; set; }
    }

    public class TransactionLog : HasId
    {
        public DateTimeOffset Date { get; set; } = DateTimeOffset.UtcNow;
        public long? TransactionRequestId { get; set; }
        public string? Reference { get; set; }
        public string? TransactionId { get; set; }
        public string Notes { get; set; }
        public string DataBefore { get; set; }
        public string DataAfter { get; set; }
    }

    public class ArchivedTransactionLog : HasId
    {
        public DateTimeOffset Date { get; set; } = DateTimeOffset.UtcNow;
        public string TransactionRequestReference { get; set; }
        public string? Reference { get; set; }
        public string? TransactionId { get; set; }
        public string Notes { get; set; }
        public string DataBefore { get; set; }
        public string DataAfter { get; set; }
    }

    public class ForexLog : HasId
    {
        public long ForexId { get; set; }
        public virtual Forex Forex { get; set; }
        public DateTimeOffset Date { get; set; } = DateTimeOffset.UtcNow;
        public long MoneyTransferOperatorId { get; set; }
        public virtual MoneyTransferOperator MoneyTransferOperator { get; set; }
        public string Data { get; set; }
        public string PublishedBy { get; set; }
        public bool? Pushed { get; set; } = false;
    }

    public class ForexLogVm : HasId
    {
        public DateTimeOffset Date { get; set; } = DateTimeOffset.UtcNow;
        public string MoneyTransferOperator { get; set; }
        public List<ForexCurrencyRateDumpVm> Data { get; set; }
        public string PublishedBy { get; set; }
    }

    public class Forex : AuditFields
    {
        public long MoneyTransferOperatorId { get; set; }
        public virtual MoneyTransferOperator MoneyTransferOperator { get; set; }
        public virtual List<ForexCurrencyRate> CurrencyRates { get; set; }
        public virtual List<ForexLog> Logs { get; set; }
    }

    public class ForexCurrencyRate : HasId
    {
        public long ForexId { get; set; }
        public virtual Forex Forex { get; set; }
        public long CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }
        public double Rate { get; set; }
    }

    public class ForexCurrencyRateDump : HasId
    {
        public long ForexId { get; set; }
        public double Rate { get; set; }
        public long CurrencyId { get; set; }
        public string Currency { get; set; }
        public string Code { get; set; }
        public string Number { get; set; }
    }
    public class ForexCurrencyRateDumpVm
    {
        public double Rate { get; set; }
        public string Currency { get; set; }
        public string Code { get; set; }
        public string Number { get; set; }
    }

    public class ForexVm
    {
        public long Id { get; set; }
        public long MoneyTransferOperatorId { get; set; }
        public virtual List<ForexCurrencyRateVm> Rates { get; set; }
    }
    public class ForexCurrencyRateVm
    {
        public long Id { get; set; }
        public long ForexId { get; set; }
        public long CurrencyId { get; set; }
        public double Rate { get; set; }
    }

    public class UploadFile
    {
        public string File { get; set; }
        public string Filename { get; set; }
    }

    public class UploadModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string BankCode { get; set; }
    }

    public class AmlockScreeningResponse
    {
        public string RequestID { get; set; }
        public string TransactionId { get; set; }
        public long ResponseCode { get; set; }
        public string Comments { get; set; }
    }

    public class GenerateForMonitoringRequest
    {
        public DateTimeOffset StartDate { get; set; }
    }

    public class PaymentOrderRequestDto
    {
        [Required]
        public string TransactionId { get; set; }
        public DateTimeOffset Date { get; set; } = DateTimeOffset.UtcNow;
        public string? CountryFrom { get; set; }
        public string CountryTo { get; set; }
        public string OriginalCurrency { get; set; } //BeneficiaryCurrency
        public double OriginalAmount { get; set; } //BeneficiaryAmount
        public long DeliveryMethod { get; set; }
        public string PaymentCurrency { get; set; }
        public double PaymentAmount { get; set; }
        public string BeneficiaryFirstName { get; set; }
        public string? BeneficiaryMiddleName { get; set; }
        public string BeneficiaryLastName { get; set; }
        public string? BeneficiaryZipCode { get; set; }
        public string? BeneficiaryPhoneNumber { get; set; }
        public string CustomerFirstName { get; set; }
        public string? CustomerMiddleName { get; set; }
        public string CustomerLastName { get; set; }
        public string? CustomerNationality { get; set; }
        public string? Purpose { get; set; }
        public string? BankName { get; set; }
        public string? BankAccountNo { get; set; }
        public string? BankRoutingCode { get; set; }
        public string? MobileWalletAccountNumber { get; set; }
        public string? CallBackUrl { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerSex { get; set; }
        public string? CustomerPhoneNumber { get; set; }
    }

    public class AccountValidationRequestDto
    {

        public TransactionType Type { get; set; }
        public string? AccountNo { get; set; }
        public string? RoutingCode { get; set; }
    }

    //public class AccountValidationRequest
    //{
    //    public string Source { get; set; }
    //    public string Type { get; set; } //MobileWallet or BankAccount
    //    public string? BankAccountNo { get; set; }
    //    public string? BankCode { get; set; }
    //    public string? MobileWalletPrefix { get; set; }
    //    public string? MobileWalletAccountNumber { get; set; }
    //    public string SenderCountry { get; set; }
    //    public string Sender { get; set; }
    //    public string Purpose { get; set; }
    //    public string? NameToDebit { get; set; }
    //    public string? AccountToDebit { get; set; }
    //}

    public class AccountValidationResponse
    {
        public bool Success { get; set; }
        public GIPTransactionResponse Data { get; set; }
        public string Message { get; set; }
    }

    //public class AccountValidationResponseV2
    //{
    //    public bool Success { get; set; }
    //    public GIPAccountValidationResponseV2 Data { get; set; }
    //    public string Message { get; set; }
    //}

    public class PaymentOrderStatusRequest
    {
        public string Source { get; set; }
        [Required]
        public string TransactionId { get; set; }
    }

    public class CancelPendingPaymentOrderRequestVm
    {
        [Required]
        public string TransactionId { get; set; }
        public string Reason { get; set; }
    }

    public class CancelPendingPaymentOrderRequest
    {
        public string Source { get; set; }
        [Required]
        public string TransactionId { get; set; }
        public string Reason { get; set; }
    }

    public class ReversePaymentOrderRequestVm
    {
        [Required]
        public string TransactionId { get; set; }
        public string Reason { get; set; }
    }

    public class ReversePaymentOrderResponse
    {
        public string Message { get; set; }
        public string TransactionId { get; set; }
    }

    public class PaymentOrderReversalRequest : AuditFields
    {
        [Required]
        public long TransactionRequestId { get; set; }
        public virtual TransactionRequest TransactionRequest { get; set; }
        public string Reason { get; set; }
        public DateTimeOffset? VettedOn { get; set; }
        public string? VettedBy { get; set; }
        public string? VettingNotes { get; set; }
        public bool Processed { get; set; } = false;
        public string Status { get; set; } = "Pending"; //Pending, Reversed, Rejected, Approved, Completed
        public DateTimeOffset? ApprovedOn { get; set; }
        public string? ApprovedBy { get; set; }
        public double ReversalCharge { get; set; }
    }

    public class PaymentOrderReversalRequestDTO : AuditFields
    {
        public string TransactionId { get; set; }
        public long TransactionRequestId { get; set; }
        public string MoneyTransferOperator { get; set; }
        public string MoneyTransferOperatorCode { get; set; }
        public string Reason { get; set; }
        public DateTimeOffset? VettedOn { get; set; }
        public string? VettedBy { get; set; }
        public string? VettingNotes { get; set; }
        public string Status { get; set; } = "Pending"; //Pending, Reversed, Rejected, Approved, Completed
        public DateTimeOffset? ApprovedOn { get; set; }
        public string? ApprovedBy { get; set; }
    }

    public class PaymentOrderReversalRequestListResponse
    {
        public List<PaymentOrderReversalRequestDTO> data { get; set; }
        public string message { get; set; }
        public long total { get; set; }
    }

    public class ReversalRequestListDTO
    {
        public long Id { get; set; }
        public string TransactionId { get; set; }
        public string Status { get; set; }
        public string MTOCode { get; set; }
        public DateTimeOffset Date { get; set; }
    }

    public class VetPaymentOrderReversalRequest
    {
        public long Id { get; set; }
        public string? VettingNotes { get; set; }
    }

    public class VetPaymentOrderReversalRequestz
    {
        public long Id { get; set; }
        public string? VettingNotes { get; set; }
        public double ReversalCharge { get; set; } = 0;
    }

    public class PaymentOrderStatusResponse
    {
        public bool Success { get; set; }
        [Required]
        public string TransactionId { get; set; }
        public string Status { get; set; }
        public string OrderStatus { get; set; }
        public TransactionRequestStatus StatusCode { get; set; }
        public string InternalReference { get; set; }
        public string PaymentReference { get; set; }
        public string Message { get; set; }
    }

    public class PaymentAdviceResponse
    {
        public string TransactionId { get; set; }
        public double Amount { get; set; }
        public DateTimeOffset PaymentDate { get; set; }
        public string InternalReference { get; set; }
        public string ExternalReference { get; set; }
        public string PaymentInstitution { get; set; }
    }

    public class CreatePaymentOrderResponse
    {
        public bool Success { get; set; }
        public long Id { get; set; }
        [Required]
        public string TransactionId { get; set; }
        public string InternalReference { get; set; }
    }

    public class PaymentOrderDetailsRequest
    {
        public string Source { get; set; }
        [Required]
        public string TransactionId { get; set; }
    }
    public class PaymentOrderStatusRequestVm
    {
        [Required]
        public string TransactionId { get; set; }
    }

    public class PaymentOrderDetailsRequestVm
    {
        [Required]
        public string TransactionId { get; set; }
    }

    public class PaymentOrdersFilterVm
    {

        [Required]
        public DateTimeOffset StartDate { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? EndDate { get; set; }
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 1000;
    }

    public class PaymentOrdersFilter
    {
        public string Source { get; set; }
        [Required]
        public DateTimeOffset StartDate { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? EndDate { get; set; }
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 1000;
    }

    public class ExchangeRatesFilter
    {
        public DateTimeOffset Date { get; set; }
    }

    public class CancelPendingPaymentOrderResponse
    {
        public bool Cancelled { get; set; }
        public string Message { get; set; }
        public string TransactionId { get; set; }
    }

    public class AmlockOfflineTransactionsServiceRun : HasId
    {
        public DateTimeOffset? LastRunDate { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        [MaxLength(128), Required]
        public string FileName { get; set; }
        public long RecordsCount { get; set; }
        public string Notes { get; set; }
    }

    public class ErrorResponse
    {
        public string ErrorCode { get; set; }
        public string Message { get; set; }
    }

    public class TransactionStatisticsResponse
    {
        public long Received { get; set; }
        public double ReceivedValue { get; set; }
        public long Paid { get; set; }
        public double PaidValue { get; set; }
        public long Rejected { get; set; }
        public double RejectedValue { get; set; }
        public long ComplianceChecked { get; set; }
        public double ComplianceCheckedValue { get; set; }
        public long ComplianceFailed { get; set; }
        public double ComplianceFailedValue { get; set; }
        public long ComplianceError { get; set; }
        public double ComplianceErrorValue { get; set; }
        public long PaymentFailed { get; set; }
        public double PaymentFailedValue { get; set; }
        public long PaymentError { get; set; }
        public double PaymentErrorValue { get; set; }
        public long Cancelled { get; set; }
        public double CancelledValue { get; set; }
        public long PaymentInitiated { get; set; }
        public double PaymentInitiatedValue { get; set; }
        public long Reversed { get; set; }
        public double ReversedValue { get; set; }
        public long Inconclusive { get; set; }
        public double InconclusiveValue { get; set; }
    }

    public class TopUpTransactionsFilterVm
    {

        [Required]
        public DateTimeOffset StartDate { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? EndDate { get; set; }
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 1000;
    }

    public class ComplianceMonitorResponse
    {
        public long ComplianceChecked { get; set; }
        public long UnderComplianceReview { get; set; }
        public long ComplianceError { get; set; }
    }

    public class PaymentMonitorResponse
    {
        public long PaymentFailed { get; set; }
        public long PaymentError { get; set; }
        public long PaymentInitiated { get; set; }
    }

    public class MessageListContact : AuditFields
    {
        public string Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string Actions { get; set; }
    }

    public class CreateMessageListContactPayload
    {
        public string Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string Actions { get; set; }
    }
    public class UpdateMessageListContactPayload: CreateMessageListContactPayload
    {
        public long Id { get; set; }
    }
    public class AlertNotification : HasId
    {
        public string Action { get; set; }
        public string Message { get; set; }
        public DateTimeOffset Date { get; set; }
        public string MessageListContactIds { get; set; }
    }

    public class MessageTemplate : AuditFields
    {
        public string Title { get; set; }
        public string Action { get; set; }
        public string? Text { get; set; }
    }

    public class CreateMessageTemplatePayload
    {
        public string Title { get; set; }
        public string Action { get; set; }
        public string? Text { get; set; }
    }
    public class UpdateMessageTemplatePayload
    {
        public long Id { get; set; }
        public string? Text { get; set; }
    }

    public class ComplianceByPassTransaction : HasId
    {
        public DateTimeOffset Date { get; set; } = DateTimeOffset.UtcNow;
        [Required]
        public long TransactionRequestId { get; set; }
        public virtual PendingTransactionRequest TransactionRequest { get; set; }
        public string Notes { get; set; }
        public TransactionRequestStatus Status { get; set; } = TransactionRequestStatus.ComplianceCheckError;
        public DateTimeOffset? ScreeningStartDate { get; set; }
        public DateTimeOffset? ScreeningEndDate { get; set; }

    }

    public class GhipssRecon : AuditFields
    {
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
        public string FileName { get; set; }
        public string Data { get; set; }
        public string Notes { get; set; }
        public DateTimeOffset? ProcessedOn { get; set; }
        public ReconcilliantionStatus Status { get; set; }
        public virtual List<GhipssReconItem> Items { get; set; }
        public string NotFoundInGhipss { get; set; } = "";
        public double ValueOfNotFoundInGhipss { get; set; } = 0.0;
        public string NotFoundInFalcon { get; set; } = "";
        public double ValueOfNotFoundInFalcon { get; set; } = 0.0;
        public string FoundInGhipss { get; set; } = "";
        public double ValueOfFoundInGhipss { get; set; } = 0.0;
        public string FoundInFalcon { get; set; } = "";
        public double ValueOfFoundInFalcon { get; set; } = 0.0;
        public string NotPaidInFalcon { get; set; } = "";
        public double ValueOfNotPaidInFalcon { get; set; } = 0.0;
        public string NumberPaidInFalcon { get; set; } = "";
        public double ValueOfNumberPaidInFalcon { get; set; } = 0.0;
        public double TotalPaidInGhipss { get; set; } = 0.0;
        public double TotalPaidInFalcon { get; set; } = 0.0;
        public int NumberOfTransactionsInFalcon { get; set; } = 0;
        public int NumberOfTransactionsInGhipss { get; set; } = 0;

    }

    public class GhipssReconItem : HasId
    {
        public long GhipssReconId { get; set; }
        public virtual GhipssRecon GhipssRecon { get; set; }
        public string? Receiver { get; set; }
        public string? Reference { get; set; }
        public string? SourceAccountNumber { get; set; }
        public string? DestinationAccountNumber { get; set; }
        public double TransactionAmount { get; set; }
        public string DateCreated { get; set; }
        public string BusinessDate { get; set; }
        public bool Passed { get; set; } = false;
        public bool Confirmed { get; set; } = false;
    }

    public class GhipssReconDto
    {
        public long Id { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public DateTimeOffset? ProcessedOn { get; set; }
        public string FileName { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
        public DateTimeOffset? UploadedOn { get; set; }
        public string UploadedBy { get; set; }
        public virtual List<GhipssReconDtoItems> Items { get; set; }
    }

    public class GhipssReconDtoItems
    {
        public long Id { get; set; }
        public long GhipssReconId { get; set; }
        public string? Receiver { get; set; }
        public string? Reference { get; set; }
        public string? SourceAccountNumber { get; set; }
        public string? DestinationAccountNumber { get; set; }
        public double TransactionAmount { get; set; }
        public string DateCreated { get; set; }
        public string BusinessDate { get; set; }
        public bool Passed { get; set; } = false;
    }

    public class GhipssReconUpload
    {
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public string FileName { get; set; }
        public string File { get; set; }
    }

    public class ReconFileUpload
    {
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public string FileName { get; set; }
        public string File { get; set; }
    }

    public class ReconDto
    {
        public long Id { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public DateTimeOffset? ProcessedOn { get; set; }
        public string FileName { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
        public DateTimeOffset? UploadedOn { get; set; }
        public string UploadedBy { get; set; }
        //public virtual List<GhipssReconDtoItems> Items { get; set; }
    }

    public class MtnRecon : AuditFields
    {
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
        public string FileName { get; set; }
        public string Data { get; set; }
        public string Notes { get; set; }
        public DateTimeOffset? ProcessedOn { get; set; }
        public ReconcilliantionStatus Status { get; set; }
        public virtual List<MtnReconItem> Items { get; set; }
        public string NotFoundInMtn { get; set; } = "";
        public double ValueOfNotFoundInMtn { get; set; } = 0.0;
        public string NotFoundInFalcon { get; set; } = "";
        public double ValueOfNotFoundInFalcon { get; set; } = 0.0;
        public string FoundInMtn { get; set; } = "";
        public double ValueOfFoundInMtn { get; set; } = 0.0;
        public string FoundInFalcon { get; set; } = "";
        public double ValueOfFoundInFalcon { get; set; } = 0.0;
        public string NotPaidInFalcon { get; set; } = "";
        public double ValueOfNotPaidInFalcon { get; set; } = 0.0;
        public string NumberPaidInFalcon { get; set; } = "";
        public double ValueOfNumberPaidInFalcon { get; set; } = 0.0;
        public double TotalPaidInMtn { get; set; } = 0.0;
        public double TotalPaidInFalcon { get; set; } = 0.0;
        public int NumberOfTransactionsInFalcon { get; set; } = 0;
        public int NumberOfTransactionsInMtn { get; set; } = 0;

    }

    public class MtnReconItem : HasId
    {
        public long MtnReconId { get; set; }
        public virtual MtnRecon MtnRecon { get; set; }
        public string? TransactionId { get; set; }
        public string? Date { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Name { get; set; }
        public double Amount { get; set; }
        public bool Passed { get; set; } = false;
        public bool Confirmed { get; set; } = false;
    }

    public class MtnReconDto
    {
        public long Id { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public DateTimeOffset? ProcessedOn { get; set; }
        public string FileName { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
        public DateTimeOffset? UploadedOn { get; set; }
        public string UploadedBy { get; set; }
        public virtual List<MtnReconDtoItems> Items { get; set; }
    }

    public class MtnReconDtoItems
    {
        public long Id { get; set; }
        public long MtnReconId { get; set; }
        public string? TransactionId { get; set; }
        public string? Date { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Name { get; set; }
        public double Amount { get; set; }
        public bool Passed { get; set; } = false;
    }

    public class MtnReconListItem
    {
        public double Amount { get; set; }
        public string? TransactionId { get; set; }
        public string? XReference { get; set; }
    }

    public class VodafoneRecon : AuditFields
    {
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
        public string FileName { get; set; }
        public string Data { get; set; }
        public string Notes { get; set; }
        public DateTimeOffset? ProcessedOn { get; set; }
        public ReconcilliantionStatus Status { get; set; }
        public virtual List<VodafoneReconItem> Items { get; set; }
        public string NotFoundInVodafone { get; set; } = "";
        public double ValueOfNotFoundInVodafone { get; set; } = 0.0;
        public string NotFoundInFalcon { get; set; } = "";
        public double ValueOfNotFoundInFalcon { get; set; } = 0.0;
        public string FoundInVodafone { get; set; } = "";
        public double ValueOfFoundInVodafone { get; set; } = 0.0;
        public string FoundInFalcon { get; set; } = "";
        public double ValueOfFoundInFalcon { get; set; } = 0.0;
        public string NotPaidInFalcon { get; set; } = "";
        public double ValueOfNotPaidInFalcon { get; set; } = 0.0;
        public string NumberPaidInFalcon { get; set; } = "";
        public double ValueOfNumberPaidInFalcon { get; set; } = 0.0;
        public double TotalPaidInMtn { get; set; } = 0.0;
        public double TotalPaidInFalcon { get; set; } = 0.0;
        public int NumberOfTransactionsInFalcon { get; set; } = 0;
        public int NumberOfTransactionsInVodafone { get; set; } = 0;

    }

    public class VodafoneReconItem : HasId
    {
        public long VodafoneReconId { get; set; }
        public virtual VodafoneRecon VodafoneRecon { get; set; }
        public string? TransactionId { get; set; }
        public string? Date { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Name { get; set; }
        public double Amount { get; set; }
        public bool Passed { get; set; } = false;
        public bool Confirmed { get; set; } = false;
    }

    public class VodafoneReconDto
    {
        public long Id { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public DateTimeOffset? ProcessedOn { get; set; }
        public string FileName { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
        public DateTimeOffset? UploadedOn { get; set; }
        public string UploadedBy { get; set; }
        public virtual List<VodafoneReconDtoItems> Items { get; set; }
    }

    public class VodafoneReconDtoItems
    {
        public long Id { get; set; }
        public long VodafoneReconId { get; set; }
        public string? TransactionId { get; set; }
        public string? Date { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Name { get; set; }
        public double Amount { get; set; }
        public bool Passed { get; set; } = false;
    }

    public class VodafoneReconListItem
    {
        public double Amount { get; set; }
        public string? TransactionId { get; set; }
        public string? XReference { get; set; }
    }

    public class TigoRecon : AuditFields
    {
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
        public string FileName { get; set; }
        public string Data { get; set; }
        public string Notes { get; set; }
        public DateTimeOffset? ProcessedOn { get; set; }
        public ReconcilliantionStatus Status { get; set; }
        public virtual List<TigoReconItem> Items { get; set; }
        public string NotFoundInTigo { get; set; } = "";
        public double ValueOfNotFoundInTigo { get; set; } = 0.0;
        public string NotFoundInFalcon { get; set; } = "";
        public double ValueOfNotFoundInFalcon { get; set; } = 0.0;
        public string FoundInTigo { get; set; } = "";
        public double ValueOfFoundInTigo { get; set; } = 0.0;
        public string FoundInFalcon { get; set; } = "";
        public double ValueOfFoundInFalcon { get; set; } = 0.0;
        public string NotPaidInFalcon { get; set; } = "";
        public double ValueOfNotPaidInFalcon { get; set; } = 0.0;
        public string NumberPaidInFalcon { get; set; } = "";
        public double ValueOfNumberPaidInFalcon { get; set; } = 0.0;
        public double TotalPaidInMtn { get; set; } = 0.0;
        public double TotalPaidInFalcon { get; set; } = 0.0;
        public int NumberOfTransactionsInFalcon { get; set; } = 0;
        public int NumberOfTransactionsInTigo { get; set; } = 0;

    }

    public class TigoReconItem : HasId
    {
        public long TigoReconId { get; set; }
        public virtual TigoRecon TigoRecon { get; set; }
        public string? TransactionId { get; set; }
        public string? Date { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Name { get; set; }
        public double Amount { get; set; }
        public bool Passed { get; set; } = false;
        public bool Confirmed { get; set; } = false;
    }

    public class TigoReconDto
    {
        public long Id { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public DateTimeOffset? ProcessedOn { get; set; }
        public string FileName { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
        public DateTimeOffset? UploadedOn { get; set; }
        public string UploadedBy { get; set; }
        public virtual List<TigoReconDtoItems> Items { get; set; }
    }

    public class TigoReconDtoItems
    {
        public long Id { get; set; }
        public long TigoReconId { get; set; }
        public string? TransactionId { get; set; }
        public string? Date { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Name { get; set; }
        public double Amount { get; set; }
        public bool Passed { get; set; } = false;
    }

    public class TigoReconListItem
    {
        public double Amount { get; set; }
        public string? TransactionId { get; set; }
        public string? XReference { get; set; }
    }

    public class CrossSwitchRecon : AuditFields
    {
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
        public string FileName { get; set; }
        public string Data { get; set; }
        public string Notes { get; set; }
        public DateTimeOffset? ProcessedOn { get; set; }
        public ReconcilliantionStatus Status { get; set; }
        public virtual List<CrossSwitchReconItem> Items { get; set; }
        public string NotFoundInCrossSwitch { get; set; } = "";
        public double ValueOfNotFoundInCrossSwitch { get; set; } = 0.0;
        public string NotFoundInFalcon { get; set; } = "";
        public double ValueOfNotFoundInFalcon { get; set; } = 0.0;
        public string FoundInCrossSwitch { get; set; } = "";
        public double ValueOfFoundInCrossSwitch { get; set; } = 0.0;
        public string FoundInFalcon { get; set; } = "";
        public double ValueOfFoundInFalcon { get; set; } = 0.0;
        public string NotPaidInFalcon { get; set; } = "";
        public double ValueOfNotPaidInFalcon { get; set; } = 0.0;
        public string NumberPaidInFalcon { get; set; } = "";
        public double ValueOfNumberPaidInFalcon { get; set; } = 0.0;
        public double TotalPaidInMtn { get; set; } = 0.0;
        public double TotalPaidInFalcon { get; set; } = 0.0;
        public int NumberOfTransactionsInFalcon { get; set; } = 0;
        public int NumberOfTransactionsInCrossSwitch { get; set; } = 0;

    }

    public class CrossSwitchReconItem : HasId
    {
        public long CrossSwitchReconId { get; set; }
        public virtual CrossSwitchRecon CrossSwitchRecon { get; set; }
        public string? TransactionId { get; set; }
        public string? Date { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Name { get; set; }
        public double Amount { get; set; }
        public bool Passed { get; set; } = false;
        public bool Confirmed { get; set; } = false;
    }

    public class CrossSwitchReconDto
    {
        public long Id { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public DateTimeOffset? ProcessedOn { get; set; }
        public string FileName { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
        public DateTimeOffset? UploadedOn { get; set; }
        public string UploadedBy { get; set; }
        public virtual List<CrossSwitchReconDtoItems> Items { get; set; }
    }

    public class CrossSwitchReconDtoItems
    {
        public long Id { get; set; }
        public long CrossSwitchReconId { get; set; }
        public string? TransactionId { get; set; }
        public string? Date { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Name { get; set; }
        public double Amount { get; set; }
        public bool Passed { get; set; } = false;
    }

    public class CrossSwitchReconListItem
    {
        public double Amount { get; set; }
        public string? TransactionId { get; set; }
        public string? XReference { get; set; }
    }

    public enum ReconcilliantionStatus
    {
        Pending = 0,
        Processing = 1,
        Passed = 2,
        Failed = 3
    }

    public class PaysendRecon : AuditFields
    {
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
        public string FileName { get; set; }
        public string Data { get; set; }
        public string Notes { get; set; }
        public DateTimeOffset? ProcessedOn { get; set; }
        public ReconcilliantionStatus Status { get; set; }
        public virtual List<PaysendReconItem> Items { get; set; }
        public string NotFoundInPaysend { get; set; } = "";
        public double ValueOfNotFoundInPaysend { get; set; } = 0.0;
        public string NotFoundInFalcon { get; set; } = "";
        public double ValueOfNotFoundInFalcon { get; set; } = 0.0;
        public string FoundInPaysend { get; set; } = "";
        public double ValueOfFoundInPaysend { get; set; } = 0.0;
        public string FoundInFalcon { get; set; } = "";
        public double ValueOfFoundInFalcon { get; set; } = 0.0;
        public string NotPaidInFalcon { get; set; } = "";
        public double ValueOfNotPaidInFalcon { get; set; } = 0.0;
        public string NumberPaidInFalcon { get; set; } = "";
        public double ValueOfNumberPaidInFalcon { get; set; } = 0.0;
        public double TotalPaidInPaysend { get; set; } = 0.0;
        public double TotalPaidInFalcon { get; set; } = 0.0;
        public int NumberOfTransactionsInFalcon { get; set; } = 0;
        public int NumberOfTransactionsInPaysend { get; set; } = 0;
        public string NotPaidInPaysend { get; set; } = "";
        public double ValueOfNotPaidInPaysend { get; set; } = 0.0;
    }

    public class PaysendReconItem : HasId
    {
        public long PaysendReconId { get; set; }
        public virtual PaysendRecon PaysendRecon { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
        public TimeOnly TransactionTime { get; set; }
        public string Type { get; set; }
        public string? PartnerId { get; set; }
        public string TransactionId { get; set; }
        public string? OriginalCurrency { get; set; }
        public double? OriginalAmount { get; set; }
        public string SettlementCurrency { get; set; }
        public double SettlementAmount { get; set; }
        public double Fee { get; set; }
        public string Status { get; set; }
        public double PreviousBalance { get; set; }
        public double CurrentBalance { get; set; }
        public bool Seen { get; set; } = false;
        public bool Passed { get; set; } = false;
    }

    public class PaysendReconDto
    {
        public long Id { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public DateTimeOffset? ProcessedOn { get; set; }
        public string FileName { get; set; }
        public string Data { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
        public DateTimeOffset? UploadedOn { get; set; }
        public string UploadedBy { get; set; }
        public virtual List<PaysendReconDtoItems> Items { get; set; }
    }

    public class PaysendReconDtoItems
    {
        public long Id { get; set; }
        public long PaysendReconId { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
        public string TransactionTime { get; set; }
        public string Type { get; set; }
        public string? PartnerId { get; set; }
        public string TransactionId { get; set; }
        public string? OriginalCurrency { get; set; }
        public double? OriginalAmount { get; set; }
        public string SettlementCurrency { get; set; }
        public double SettlementAmount { get; set; }
        public double Fee { get; set; }
        public string Status { get; set; }
        public double PreviousBalance { get; set; }
        public double CurrentBalance { get; set; }
        public bool Seen { get; set; } = false;
        public bool Passed { get; set; } = false;
    }

    public class PaysendReconUpload
    {
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public string? StartTime { get; set; } = "00:00";
        public string? EndTime { get; set; } = "11:59";
        public string FileName { get; set; }
        public string File { get; set; }
    }

    public class PaysendReconTemplateDTO
    {
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
    }

    public class TransactionStatusUpdateRequest : AuditFields
    {
        [Required]
        public string TransactionId { get; set; }
        [Required, MaxLength(64)]
        public string Reference { get; set; }
        public string Reason { get; set; }
        public long MtoId { get; set; }
        public DateTimeOffset? VettedOn { get; set; }
        public string? VettedBy { get; set; }
        public string? VettingNotes { get; set; }
        public bool Processed { get; set; } = false;
        public string Status { get; set; } = "Pending"; //Pending, Approved, Rejected
        public TransactionRequestStatus OldTransactionStatus { get; set; }
        public TransactionRequestStatus NewTransactionStatus { get; set; }
    }

    public class ArchivedTransactionStatusUpdateRequest : AuditFields
    {
        [Required]
        public string TransactionRequestReference { get; set; }
        [Required]
        public string TransactionId { get; set; }
        [Required, MaxLength(64)]
        public string Reference { get; set; }
        public string Reason { get; set; }
        public long MtoId { get; set; }
        public DateTimeOffset? VettedOn { get; set; }
        public string? VettedBy { get; set; }
        public string? VettingNotes { get; set; }
        public bool Processed { get; set; } = false;
        public string Status { get; set; } = "Pending"; //Pending, Approved, Rejected
        public TransactionRequestStatus OldTransactionStatus { get; set; }
        public TransactionRequestStatus NewTransactionStatus { get; set; }
    }

    public class TransactionStatusUpdateRequestDTO
    {
        public long MtoId { get; set; }
        public string TransactionId { get; set; }
        public string Reference { get; set; }
        public string Reason { get; set; }
        public TransactionRequestStatus NewTransactionStatus { get; set; }
    }

    public class AdminReversePaymentOrderRequestVm
    {
        public long MtoId { get; set; }
        public string TransactionId { get; set; }
        public string Reason { get; set; }
    }

    public class TransactionStatusUpdateRequestVettingDTO
    {
        public string VettingNotes { get; set; }
        public long Id { get; set; }
    }

    public class TransactionStatusUpdateRequestView
    {
        public long Id { get; set; }
        public string TransactionId { get; set; }
        public string Reference { get; set; }
        public string Reason { get; set; }
        public DateTimeOffset? VettedOn { get; set; }
        public string? VettedBy { get; set; }
        public string? VettingNotes { get; set; }
        public string Status { get; set; }
        public string OldTransactionStatus { get; set; }
        public string NewTransactionStatus { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }

    public class UpdatePaymentFailureReason
    {
        public string Reason { get; set; }
        public long Id { get; set; }
        public string? Recommendation { get; set; }
    }

    public class TransactionsReportFilter
    {
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public string Type { get; set; }
        public long MtoId { get; set; }
    }

    public class ForexRatesReportFilter
    {
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public long MtoId { get; set; }
    }

    public class AccountTransactionsReportFilter
    {
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public long MtoId { get; set; }
    }

    public class PeriodReportFilter
    {
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public long MtoId { get; set; }
    }

    public class CommissionsReportFilter
    {
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
    }

    public class NameEnquiryRequest
    {
        public string Type { get; set; } //MobileWallet or BankAccount
        public string AccountNumber { get; set; }
        public string RoutingCode { get; set; }
    }

    public class NameEnquiryResponse
    {
        public bool Success { get; set; }
        public GIPTransactionResponse Data { get; set; }
        public string Message { get; set; }
    }

    public class ForexCurrencyRateReportData
    {
        public long ForexId { get; set; }
        public double Rate { get; set; }
        public long CurrencyId { get; set; }
        public string Currency { get; set; }
        public string Code { get; set; }
        public string Number { get; set; }
        public DateTimeOffset Date { get; set; }
        public string PublishedBy { get; set; }
    }

    public class PaymentAdviceReportFilter
    {
        public string TransactionId { get; set; }
        public long MtoId { get; set; }
    }

    public class MTOPaymentChannel: HasId
    {
        public long MtoId { get; set; }
        public MoneyTransferOperator Mto { get; set; }
        public string TransactionType { get; set; }
        public string Channel { get; set; }
    }

    public class MTOPaymentChannelRequest : AuditFields
    {
        public long MtoId { get; set; }
        public MoneyTransferOperator Mto { get; set; }
        public string TransactionType { get; set; }
        public string Channel { get; set; }
        public string Status { get; set; }
        public string VettedBy { get; set; }
        public DateTimeOffset? VettedOn { get; set; } = null;
        public string VettingNotes { get; set; } = "";
    }

    public class MTOPaymentChannelRequestDTO: HasId
    {
        public long MtoId { get; set; }
        public string Mto { get; set; }
        public string TransactionType { get; set; }
        public string Channel { get; set; }
        public string Status { get; set; }
        public string VettedBy { get; set; }
        public DateTimeOffset? VettedOn { get; set; } = null;
        public string VettingNotes { get; set; } = "";
        public DateTimeOffset? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }

    public class MTOPaymentChannelRequestVm
    {
        public long MtoId { get; set; }
        public string TransactionType { get; set; }
        public string Channel { get; set; }
    }

    public class RejectMTOPaymentChannelRequest
    {
        public long Id { get; set; }
        public string? VettingNotes { get; set; }
    }

    public class MTOPaymentChannelDTO
    {
        public string Mto { get; set; }
        public string TransactionType { get; set; }
        public string Channel { get; set; }
    }

    public class FundTransferRequest : AuditFields
    {
        public DateTimeOffset Date { get; set; }
        public string Type { get; set; } //BankAccount,MobileWallet
        public string AccountNumber { get; set; }
        public string RoutingCode { get; set; }
        public double Amount { get; set; }
        public string Purpose { get; set; }
        public string BeneficiaryFirstName { get; set; }
        public string BeneficiaryLastName { get; set; }
        public string? BeneficiaryPhoneNumber { get; set; }
        public DateTimeOffset? VettedOn { get; set; }
        public string? VettedBy { get; set; }
        public string? VettingNotes { get; set; }
        public VettingStatus VettingStatus { get; set; } = VettingStatus.Pending;
    }

    public class FundTransferRequestDTO
    {
        public string Type { get; set; } //BankAccount,MobileWallet
        public string AccountNumber { get; set; }
        public string RoutingCode { get; set; }
        public double Amount { get; set; }
        public string Purpose { get; set; }
        public string BeneficiaryFirstName { get; set; }
        public string BeneficiaryLastName { get; set; }
        public string BeneficiaryPhoneNumber { get; set; }
    }

    public class FundTransferRequestView: HasId
    {
        public string Type { get; set; } //BankAccount,MobileWallet
        public string AccountNumber { get; set; }
        public string RoutingCode { get; set; }
        public double Amount { get; set; }
        public string Purpose { get; set; }
        public string BeneficiaryFirstName { get; set; }
        public string BeneficiaryLastName { get; set; }
        public string BeneficiaryPhoneNumber { get; set; }
        public DateTimeOffset? VettedOn { get; set; }
        public string? VettedBy { get; set; }
        public string? VettingNotes { get; set; }
        public string Status { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }

    public class FundTransferRequestVettingDTO
    {
        public string VettingNotes { get; set; }
        public long Id { get; set; }
    }

    public class PaymentPartnerBalance : HasId
    {
        public DateTimeOffset Date { get; set; } = DateTimeOffset.UtcNow;
        public string PaymentPartner { get; set; }
        public double Balance { get; set; }
    }

    public class MonthlyInwardRemittanceTransactionsReportFilter
    {
        public int Year { get; set; } = 0;
        public int Month { get; set; } = 0;
        public long MtoId { get; set; } = 0;
    }

    public class TelcoInwardRemittanceTransactionsReportFilter
    {
        public int Year { get; set; } = 0;
        public int Month { get; set; } = 0;
        //public long MtoId { get; set; } = 0;
        public string Telco { get; set; }
    }

    public class BeneficiaryAccountTransactionsReportFilter
    {
        public string RoutingCode { get; set; }
        public string BeneficiaryAccount { get; set; }
    }

    public class BeneficiaryAccountTransactionObj
    {
        public long Id { get; set; }
        public DateTimeOffset Date { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string TransactionType { get; set; }
        public string TransactionId { get; set; }
        public string CountryFrom { get; set; }
        public string OriginalCurrency { get; set; }
        public double OriginalAmount { get; set; }
        public double PaymentAmount { get; set; }
        public string PaymentCurrency { get; set; }
        public string BeneficiarySex { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public string RoutingCode { get; set; }
        public string Status { get; set; }
    }

    public class ElevyTrustAccount : HasId
    {
        public string PaymentChannel { get; set; }
        public string IssuerId { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public string Tin { get; set; }
        public string PhoneNumber { get; set; }
        public bool Identified { get; set; } = false;
        public string? ElevyResponseObject { get; set; }
    }
}
