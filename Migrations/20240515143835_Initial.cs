using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RemittanceSharedModels.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlertNotifications",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Action = table.Column<string>(type: "text", nullable: true),
                    Message = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    MessageListContactIds = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertNotifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AmlockOfflineTransactionsServiceRuns",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LastRunDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    FileName = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    RecordsCount = table.Column<long>(type: "bigint", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmlockOfflineTransactionsServiceRuns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppSettings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArchivedPaymentOrderReversalRequests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TransactionId = table.Column<string>(type: "text", nullable: false),
                    TransactionRequestReference = table.Column<string>(type: "text", nullable: true),
                    Reason = table.Column<string>(type: "text", nullable: true),
                    VettedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    VettedBy = table.Column<string>(type: "text", nullable: true),
                    VettingNotes = table.Column<string>(type: "text", nullable: true),
                    Processed = table.Column<bool>(type: "boolean", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    ApprovedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ApprovedBy = table.Column<string>(type: "text", nullable: true),
                    ReversalCharge = table.Column<double>(type: "double precision", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivedPaymentOrderReversalRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArchivedTransactionLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    TransactionRequestReference = table.Column<string>(type: "text", nullable: true),
                    Reference = table.Column<string>(type: "text", nullable: true),
                    TransactionId = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    DataBefore = table.Column<string>(type: "text", nullable: true),
                    DataAfter = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivedTransactionLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArchivedTransactionStatusUpdateRequests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TransactionRequestReference = table.Column<string>(type: "text", nullable: false),
                    TransactionId = table.Column<string>(type: "text", nullable: false),
                    Reference = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: true),
                    MtoId = table.Column<long>(type: "bigint", nullable: false),
                    VettedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    VettedBy = table.Column<string>(type: "text", nullable: true),
                    VettingNotes = table.Column<string>(type: "text", nullable: true),
                    Processed = table.Column<bool>(type: "boolean", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    OldTransactionStatus = table.Column<int>(type: "integer", nullable: false),
                    NewTransactionStatus = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivedTransactionStatusUpdateRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Locked = table.Column<bool>(type: "boolean", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Locked = table.Column<bool>(type: "boolean", nullable: false),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SortCode = table.Column<string>(type: "text", nullable: true),
                    RoutingCode = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Notes = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Alpha2Code = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Alpha3Code = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    NumericCode = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Notes = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CrossSwitchRecons",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    EndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    StartTime = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    EndTime = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    FileName = table.Column<string>(type: "text", nullable: true),
                    Data = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    ProcessedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    NotFoundInCrossSwitch = table.Column<string>(type: "text", nullable: true),
                    ValueOfNotFoundInCrossSwitch = table.Column<double>(type: "double precision", nullable: false),
                    NotFoundInFalcon = table.Column<string>(type: "text", nullable: true),
                    ValueOfNotFoundInFalcon = table.Column<double>(type: "double precision", nullable: false),
                    FoundInCrossSwitch = table.Column<string>(type: "text", nullable: true),
                    ValueOfFoundInCrossSwitch = table.Column<double>(type: "double precision", nullable: false),
                    FoundInFalcon = table.Column<string>(type: "text", nullable: true),
                    ValueOfFoundInFalcon = table.Column<double>(type: "double precision", nullable: false),
                    NotPaidInFalcon = table.Column<string>(type: "text", nullable: true),
                    ValueOfNotPaidInFalcon = table.Column<double>(type: "double precision", nullable: false),
                    NumberPaidInFalcon = table.Column<string>(type: "text", nullable: true),
                    ValueOfNumberPaidInFalcon = table.Column<double>(type: "double precision", nullable: false),
                    TotalPaidInMtn = table.Column<double>(type: "double precision", nullable: false),
                    TotalPaidInFalcon = table.Column<double>(type: "double precision", nullable: false),
                    NumberOfTransactionsInFalcon = table.Column<int>(type: "integer", nullable: false),
                    NumberOfTransactionsInCrossSwitch = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrossSwitchRecons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Notes = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ElevyTrustAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PaymentChannel = table.Column<string>(type: "text", nullable: true),
                    IssuerId = table.Column<string>(type: "text", nullable: true),
                    AccountNumber = table.Column<string>(type: "text", nullable: true),
                    AccountType = table.Column<string>(type: "text", nullable: true),
                    Tin = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Identified = table.Column<bool>(type: "boolean", nullable: false),
                    ElevyResponseObject = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElevyTrustAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FundTransferRequests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true),
                    AccountNumber = table.Column<string>(type: "text", nullable: true),
                    RoutingCode = table.Column<string>(type: "text", nullable: true),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    Purpose = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryFirstName = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryLastName = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryPhoneNumber = table.Column<string>(type: "text", nullable: true),
                    VettedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    VettedBy = table.Column<string>(type: "text", nullable: true),
                    VettingNotes = table.Column<string>(type: "text", nullable: true),
                    VettingStatus = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundTransferRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GhipssRecons",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    EndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    StartTime = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    EndTime = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    FileName = table.Column<string>(type: "text", nullable: true),
                    Data = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    ProcessedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    NotFoundInGhipss = table.Column<string>(type: "text", nullable: true),
                    ValueOfNotFoundInGhipss = table.Column<double>(type: "double precision", nullable: false),
                    NotFoundInFalcon = table.Column<string>(type: "text", nullable: true),
                    ValueOfNotFoundInFalcon = table.Column<double>(type: "double precision", nullable: false),
                    FoundInGhipss = table.Column<string>(type: "text", nullable: true),
                    ValueOfFoundInGhipss = table.Column<double>(type: "double precision", nullable: false),
                    FoundInFalcon = table.Column<string>(type: "text", nullable: true),
                    ValueOfFoundInFalcon = table.Column<double>(type: "double precision", nullable: false),
                    NotPaidInFalcon = table.Column<string>(type: "text", nullable: true),
                    ValueOfNotPaidInFalcon = table.Column<double>(type: "double precision", nullable: false),
                    NumberPaidInFalcon = table.Column<string>(type: "text", nullable: true),
                    ValueOfNumberPaidInFalcon = table.Column<double>(type: "double precision", nullable: false),
                    TotalPaidInGhipss = table.Column<double>(type: "double precision", nullable: false),
                    TotalPaidInFalcon = table.Column<double>(type: "double precision", nullable: false),
                    NumberOfTransactionsInFalcon = table.Column<int>(type: "integer", nullable: false),
                    NumberOfTransactionsInGhipss = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GhipssRecons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MessageListContacts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Actions = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageListContacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Recipient = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Subject = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Text = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Response = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: true),
                    TimeStamp = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    SentTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    BulkId = table.Column<string>(type: "text", nullable: true),
                    MessageId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MessageTemplates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Action = table.Column<string>(type: "text", nullable: true),
                    Text = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MtnRecons",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    EndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    StartTime = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    EndTime = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    FileName = table.Column<string>(type: "text", nullable: true),
                    Data = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    ProcessedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    NotFoundInMtn = table.Column<string>(type: "text", nullable: true),
                    ValueOfNotFoundInMtn = table.Column<double>(type: "double precision", nullable: false),
                    NotFoundInFalcon = table.Column<string>(type: "text", nullable: true),
                    ValueOfNotFoundInFalcon = table.Column<double>(type: "double precision", nullable: false),
                    FoundInMtn = table.Column<string>(type: "text", nullable: true),
                    ValueOfFoundInMtn = table.Column<double>(type: "double precision", nullable: false),
                    FoundInFalcon = table.Column<string>(type: "text", nullable: true),
                    ValueOfFoundInFalcon = table.Column<double>(type: "double precision", nullable: false),
                    NotPaidInFalcon = table.Column<string>(type: "text", nullable: true),
                    ValueOfNotPaidInFalcon = table.Column<double>(type: "double precision", nullable: false),
                    NumberPaidInFalcon = table.Column<string>(type: "text", nullable: true),
                    ValueOfNumberPaidInFalcon = table.Column<double>(type: "double precision", nullable: false),
                    TotalPaidInMtn = table.Column<double>(type: "double precision", nullable: false),
                    TotalPaidInFalcon = table.Column<double>(type: "double precision", nullable: false),
                    NumberOfTransactionsInFalcon = table.Column<int>(type: "integer", nullable: false),
                    NumberOfTransactionsInMtn = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MtnRecons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentFailureReasons",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Notes = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentFailureReasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentFailureRecommendations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Notes = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentFailureRecommendations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentPartnerBalance",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    PaymentPartner = table.Column<string>(type: "text", nullable: true),
                    Balance = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentPartnerBalance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentRequestPayloads",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Payload = table.Column<string>(type: "text", nullable: true),
                    Reference = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentRequestPayloads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReceivedRequestPayloads",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Payload = table.Column<string>(type: "text", nullable: true),
                    Reference = table.Column<string>(type: "text", nullable: true),
                    System = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivedRequestPayloads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    User = table.Column<string>(type: "text", nullable: true),
                    Payload = table.Column<string>(type: "text", nullable: true),
                    Model = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TigoRecons",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    EndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    StartTime = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    EndTime = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    FileName = table.Column<string>(type: "text", nullable: true),
                    Data = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    ProcessedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    NotFoundInTigo = table.Column<string>(type: "text", nullable: true),
                    ValueOfNotFoundInTigo = table.Column<double>(type: "double precision", nullable: false),
                    NotFoundInFalcon = table.Column<string>(type: "text", nullable: true),
                    ValueOfNotFoundInFalcon = table.Column<double>(type: "double precision", nullable: false),
                    FoundInTigo = table.Column<string>(type: "text", nullable: true),
                    ValueOfFoundInTigo = table.Column<double>(type: "double precision", nullable: false),
                    FoundInFalcon = table.Column<string>(type: "text", nullable: true),
                    ValueOfFoundInFalcon = table.Column<double>(type: "double precision", nullable: false),
                    NotPaidInFalcon = table.Column<string>(type: "text", nullable: true),
                    ValueOfNotPaidInFalcon = table.Column<double>(type: "double precision", nullable: false),
                    NumberPaidInFalcon = table.Column<string>(type: "text", nullable: true),
                    ValueOfNumberPaidInFalcon = table.Column<double>(type: "double precision", nullable: false),
                    TotalPaidInMtn = table.Column<double>(type: "double precision", nullable: false),
                    TotalPaidInFalcon = table.Column<double>(type: "double precision", nullable: false),
                    NumberOfTransactionsInFalcon = table.Column<int>(type: "integer", nullable: false),
                    NumberOfTransactionsInTigo = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TigoRecons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    TransactionRequestId = table.Column<long>(type: "bigint", nullable: true),
                    Reference = table.Column<string>(type: "text", nullable: true),
                    TransactionId = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    DataBefore = table.Column<string>(type: "text", nullable: true),
                    DataAfter = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionRequestPayloads",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    MtoId = table.Column<long>(type: "bigint", nullable: false),
                    Payload = table.Column<string>(type: "text", nullable: true),
                    Reference = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionRequestPayloads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionStatusUpdateRequests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TransactionId = table.Column<string>(type: "text", nullable: false),
                    Reference = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: true),
                    MtoId = table.Column<long>(type: "bigint", nullable: false),
                    VettedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    VettedBy = table.Column<string>(type: "text", nullable: true),
                    VettingNotes = table.Column<string>(type: "text", nullable: true),
                    Processed = table.Column<bool>(type: "boolean", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    OldTransactionStatus = table.Column<int>(type: "integer", nullable: false),
                    NewTransactionStatus = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionStatusUpdateRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VodafoneRecons",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    EndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    StartTime = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    EndTime = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    FileName = table.Column<string>(type: "text", nullable: true),
                    Data = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    ProcessedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    NotFoundInVodafone = table.Column<string>(type: "text", nullable: true),
                    ValueOfNotFoundInVodafone = table.Column<double>(type: "double precision", nullable: false),
                    NotFoundInFalcon = table.Column<string>(type: "text", nullable: true),
                    ValueOfNotFoundInFalcon = table.Column<double>(type: "double precision", nullable: false),
                    FoundInVodafone = table.Column<string>(type: "text", nullable: true),
                    ValueOfFoundInVodafone = table.Column<double>(type: "double precision", nullable: false),
                    FoundInFalcon = table.Column<string>(type: "text", nullable: true),
                    ValueOfFoundInFalcon = table.Column<double>(type: "double precision", nullable: false),
                    NotPaidInFalcon = table.Column<string>(type: "text", nullable: true),
                    ValueOfNotPaidInFalcon = table.Column<double>(type: "double precision", nullable: false),
                    NumberPaidInFalcon = table.Column<string>(type: "text", nullable: true),
                    ValueOfNumberPaidInFalcon = table.Column<double>(type: "double precision", nullable: false),
                    TotalPaidInMtn = table.Column<double>(type: "double precision", nullable: false),
                    TotalPaidInFalcon = table.Column<double>(type: "double precision", nullable: false),
                    NumberOfTransactionsInFalcon = table.Column<int>(type: "integer", nullable: false),
                    NumberOfTransactionsInVodafone = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VodafoneRecons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LoginProvider = table.Column<string>(type: "text", nullable: true),
                    ProviderKey = table.Column<string>(type: "text", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankBranches",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    BankId = table.Column<long>(type: "bigint", nullable: false),
                    Location = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Notes = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankBranches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankBranches_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoneyTransferOperators",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Code = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    Abbrev = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: false),
                    AuthToken = table.Column<string>(type: "text", nullable: true),
                    AuthPin = table.Column<string>(type: "text", nullable: true),
                    Balance = table.Column<double>(type: "double precision", nullable: false),
                    Limit = table.Column<double>(type: "double precision", nullable: false),
                    Threshold = table.Column<double>(type: "double precision", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyTransferOperators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoneyTransferOperators_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CrossSwitchReconItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CrossSwitchReconId = table.Column<long>(type: "bigint", nullable: false),
                    TransactionId = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    Passed = table.Column<bool>(type: "boolean", nullable: false),
                    Confirmed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrossSwitchReconItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrossSwitchReconItems_CrossSwitchRecons_CrossSwitchReconId",
                        column: x => x.CrossSwitchReconId,
                        principalTable: "CrossSwitchRecons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GhipssReconItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GhipssReconId = table.Column<long>(type: "bigint", nullable: false),
                    Receiver = table.Column<string>(type: "text", nullable: true),
                    Reference = table.Column<string>(type: "text", nullable: true),
                    SourceAccountNumber = table.Column<string>(type: "text", nullable: true),
                    DestinationAccountNumber = table.Column<string>(type: "text", nullable: true),
                    TransactionAmount = table.Column<double>(type: "double precision", nullable: false),
                    DateCreated = table.Column<string>(type: "text", nullable: true),
                    BusinessDate = table.Column<string>(type: "text", nullable: true),
                    Passed = table.Column<bool>(type: "boolean", nullable: false),
                    Confirmed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GhipssReconItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GhipssReconItems_GhipssRecons_GhipssReconId",
                        column: x => x.GhipssReconId,
                        principalTable: "GhipssRecons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MtnReconItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MtnReconId = table.Column<long>(type: "bigint", nullable: false),
                    TransactionId = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    Passed = table.Column<bool>(type: "boolean", nullable: false),
                    Confirmed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MtnReconItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MtnReconItems_MtnRecons_MtnReconId",
                        column: x => x.MtnReconId,
                        principalTable: "MtnRecons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TigoReconItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TigoReconId = table.Column<long>(type: "bigint", nullable: false),
                    TransactionId = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    Passed = table.Column<bool>(type: "boolean", nullable: false),
                    Confirmed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TigoReconItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TigoReconItems_TigoRecons_TigoReconId",
                        column: x => x.TigoReconId,
                        principalTable: "TigoRecons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VodafoneReconItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VodafoneReconId = table.Column<long>(type: "bigint", nullable: false),
                    TransactionId = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    Passed = table.Column<bool>(type: "boolean", nullable: false),
                    Confirmed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VodafoneReconItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VodafoneReconItems_VodafoneRecons_VodafoneReconId",
                        column: x => x.VodafoneReconId,
                        principalTable: "VodafoneRecons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArchivedTransactionRequests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MoneyTransferOperatorId = table.Column<long>(type: "bigint", nullable: false),
                    TransactionId = table.Column<string>(type: "text", nullable: false),
                    Reference = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    PIN = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    CountryFrom = table.Column<string>(type: "text", nullable: true),
                    CountryTo = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryQuestion = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryAnswer = table.Column<string>(type: "text", nullable: true),
                    PaymentInstructions = table.Column<string>(type: "text", nullable: true),
                    OriginalCurrency = table.Column<string>(type: "text", nullable: true),
                    OriginalAmount = table.Column<double>(type: "double precision", nullable: false),
                    PaymentCurrency = table.Column<string>(type: "text", nullable: true),
                    PaymentAmount = table.Column<double>(type: "double precision", nullable: false),
                    CommissionCurrency = table.Column<string>(type: "text", nullable: true),
                    CommissionAmount = table.Column<double>(type: "double precision", nullable: false),
                    BeneficiaryId = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryFullName = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryFirstName = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryMiddleName = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryLastName = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryAddress = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryCity = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryCountry = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryPhoneNumber = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryEmail = table.Column<string>(type: "text", nullable: true),
                    BeneficiarySex = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryIdType = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryIdNumber = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryTaxId = table.Column<string>(type: "text", nullable: true),
                    CustomerId = table.Column<string>(type: "text", nullable: true),
                    CustomerFullName = table.Column<string>(type: "text", nullable: true),
                    CustomerFirstName = table.Column<string>(type: "text", nullable: true),
                    CustomerMiddleName = table.Column<string>(type: "text", nullable: true),
                    CustomerLastName = table.Column<string>(type: "text", nullable: true),
                    CustomerCountry = table.Column<string>(type: "text", nullable: true),
                    CustomerIdType = table.Column<string>(type: "text", nullable: true),
                    CustomerIdNumber = table.Column<string>(type: "text", nullable: true),
                    CustomerIdIssuedBy = table.Column<string>(type: "text", nullable: true),
                    CustomerIdIssueCountry = table.Column<string>(type: "text", nullable: true),
                    CustomerIdIssuedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CustomerIdExpirationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CustomerCountryOfBirth = table.Column<string>(type: "text", nullable: true),
                    CustomerNationality = table.Column<string>(type: "text", nullable: true),
                    CustomerDateOfBirth = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CustomerOccupation = table.Column<string>(type: "text", nullable: true),
                    CustomerSourceOfFunds = table.Column<string>(type: "text", nullable: true),
                    CustomerSex = table.Column<string>(type: "text", nullable: true),
                    CustomerPhoneNumber = table.Column<string>(type: "text", nullable: true),
                    CustomerEmail = table.Column<string>(type: "text", nullable: true),
                    Purpose = table.Column<string>(type: "text", nullable: true),
                    BankName = table.Column<string>(type: "text", nullable: true),
                    BankAccountNo = table.Column<string>(type: "text", nullable: true),
                    RoutingCode = table.Column<string>(type: "text", nullable: true),
                    TransactionType = table.Column<int>(type: "integer", nullable: false),
                    MobileWalletAccountNumber = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CallBackUrl = table.Column<string>(type: "text", nullable: true),
                    FinalStatusReported = table.Column<bool>(type: "boolean", nullable: false),
                    TrackingNumber = table.Column<string>(type: "text", nullable: true),
                    BalanceBefore = table.Column<double>(type: "double precision", nullable: false),
                    BalanceAfter = table.Column<double>(type: "double precision", nullable: false),
                    ScreeningStartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ScreeningEndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    PaymentStartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    PaymentEndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    PaymentFailureReported = table.Column<bool>(type: "boolean", nullable: false),
                    RejectionReported = table.Column<bool>(type: "boolean", nullable: false),
                    RejectionReason = table.Column<string>(type: "text", nullable: true),
                    PaymentFailedReason = table.Column<string>(type: "text", nullable: true),
                    PaymentFailedRecommendations = table.Column<string>(type: "text", nullable: true),
                    PaymentPartner = table.Column<string>(type: "text", nullable: true),
                    TsqRetries = table.Column<int>(type: "integer", nullable: false),
                    SessionId = table.Column<string>(type: "text", nullable: true),
                    ElevyId = table.Column<string>(type: "text", nullable: true),
                    ElevyReserveTimestamp = table.Column<string>(type: "text", nullable: true),
                    ElevyReserverResponseTimestamp = table.Column<string>(type: "text", nullable: true),
                    ElevyStatus = table.Column<string>(type: "text", nullable: true),
                    ElevyTaxableAmount = table.Column<double>(type: "double precision", nullable: false),
                    ElevyAmount = table.Column<double>(type: "double precision", nullable: false),
                    ElevyClientTransactionId = table.Column<string>(type: "text", nullable: true),
                    ElevyConfirmedResponseTimestamp = table.Column<string>(type: "text", nullable: true),
                    ElevyCancelledResponseTimestamp = table.Column<string>(type: "text", nullable: true),
                    FullData = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivedTransactionRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArchivedTransactionRequests_MoneyTransferOperators_MoneyTra~",
                        column: x => x.MoneyTransferOperatorId,
                        principalTable: "MoneyTransferOperators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Forex",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MoneyTransferOperatorId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forex", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Forex_MoneyTransferOperators_MoneyTransferOperatorId",
                        column: x => x.MoneyTransferOperatorId,
                        principalTable: "MoneyTransferOperators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoneyTransferOperatorAccountAdjustments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    MoneyTransferOperatorId = table.Column<long>(type: "bigint", nullable: false),
                    Narrative = table.Column<string>(type: "text", nullable: true),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Balance = table.Column<double>(type: "double precision", nullable: true),
                    VettedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    VettedBy = table.Column<string>(type: "text", nullable: true),
                    VettingNotes = table.Column<string>(type: "text", nullable: true),
                    VettingStatus = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyTransferOperatorAccountAdjustments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoneyTransferOperatorAccountAdjustments_MoneyTransferOperat~",
                        column: x => x.MoneyTransferOperatorId,
                        principalTable: "MoneyTransferOperators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoneyTransferOperatorAccountLimitAdjustments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    MoneyTransferOperatorId = table.Column<long>(type: "bigint", nullable: false),
                    Narrative = table.Column<string>(type: "text", nullable: true),
                    NewLimit = table.Column<double>(type: "double precision", nullable: false),
                    VettedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    VettedBy = table.Column<string>(type: "text", nullable: true),
                    VettingNotes = table.Column<string>(type: "text", nullable: true),
                    VettingStatus = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyTransferOperatorAccountLimitAdjustments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoneyTransferOperatorAccountLimitAdjustments_MoneyTransferO~",
                        column: x => x.MoneyTransferOperatorId,
                        principalTable: "MoneyTransferOperators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoneyTransferOperatorAccountThresholdAdjustments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    MoneyTransferOperatorId = table.Column<long>(type: "bigint", nullable: false),
                    Narrative = table.Column<string>(type: "text", nullable: true),
                    NewThreshold = table.Column<double>(type: "double precision", nullable: false),
                    VettedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    VettedBy = table.Column<string>(type: "text", nullable: true),
                    VettingNotes = table.Column<string>(type: "text", nullable: true),
                    VettingStatus = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyTransferOperatorAccountThresholdAdjustments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoneyTransferOperatorAccountThresholdAdjustments_MoneyTrans~",
                        column: x => x.MoneyTransferOperatorId,
                        principalTable: "MoneyTransferOperators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MTOPaymentChannelRequests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MtoId = table.Column<long>(type: "bigint", nullable: false),
                    TransactionType = table.Column<string>(type: "text", nullable: true),
                    Channel = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    VettedBy = table.Column<string>(type: "text", nullable: true),
                    VettedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    VettingNotes = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MTOPaymentChannelRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MTOPaymentChannelRequests_MoneyTransferOperators_MtoId",
                        column: x => x.MtoId,
                        principalTable: "MoneyTransferOperators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MTOPaymentChannels",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MtoId = table.Column<long>(type: "bigint", nullable: false),
                    TransactionType = table.Column<string>(type: "text", nullable: true),
                    Channel = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MTOPaymentChannels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MTOPaymentChannels_MoneyTransferOperators_MtoId",
                        column: x => x.MtoId,
                        principalTable: "MoneyTransferOperators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MtoUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MoneyTransferOperatorId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    UserName = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Email = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    PhoneNumber = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Hash = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MtoUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MtoUsers_MoneyTransferOperators_MoneyTransferOperatorId",
                        column: x => x.MoneyTransferOperatorId,
                        principalTable: "MoneyTransferOperators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PendingTransactionRequests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MoneyTransferOperatorId = table.Column<long>(type: "bigint", nullable: false),
                    TransactionId = table.Column<string>(type: "text", nullable: false),
                    Reference = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    PIN = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    CountryFrom = table.Column<string>(type: "text", nullable: true),
                    CountryTo = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryQuestion = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryAnswer = table.Column<string>(type: "text", nullable: true),
                    PaymentInstructions = table.Column<string>(type: "text", nullable: true),
                    OriginalCurrency = table.Column<string>(type: "text", nullable: true),
                    OriginalAmount = table.Column<double>(type: "double precision", nullable: false),
                    PaymentCurrency = table.Column<string>(type: "text", nullable: true),
                    PaymentAmount = table.Column<double>(type: "double precision", nullable: false),
                    CommissionCurrency = table.Column<string>(type: "text", nullable: true),
                    CommissionAmount = table.Column<double>(type: "double precision", nullable: false),
                    BeneficiaryId = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryFullName = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryFirstName = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryMiddleName = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryLastName = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryAddress = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryCity = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryCountry = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryPhoneNumber = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryEmail = table.Column<string>(type: "text", nullable: true),
                    BeneficiarySex = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryIdType = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryIdNumber = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryTaxId = table.Column<string>(type: "text", nullable: true),
                    CustomerId = table.Column<string>(type: "text", nullable: true),
                    CustomerFullName = table.Column<string>(type: "text", nullable: true),
                    CustomerFirstName = table.Column<string>(type: "text", nullable: true),
                    CustomerMiddleName = table.Column<string>(type: "text", nullable: true),
                    CustomerLastName = table.Column<string>(type: "text", nullable: true),
                    CustomerCountry = table.Column<string>(type: "text", nullable: true),
                    CustomerIdType = table.Column<string>(type: "text", nullable: true),
                    CustomerIdNumber = table.Column<string>(type: "text", nullable: true),
                    CustomerIdIssuedBy = table.Column<string>(type: "text", nullable: true),
                    CustomerIdIssueCountry = table.Column<string>(type: "text", nullable: true),
                    CustomerIdIssuedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CustomerIdExpirationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CustomerCountryOfBirth = table.Column<string>(type: "text", nullable: true),
                    CustomerNationality = table.Column<string>(type: "text", nullable: true),
                    CustomerDateOfBirth = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CustomerOccupation = table.Column<string>(type: "text", nullable: true),
                    CustomerSourceOfFunds = table.Column<string>(type: "text", nullable: true),
                    CustomerSex = table.Column<string>(type: "text", nullable: true),
                    CustomerPhoneNumber = table.Column<string>(type: "text", nullable: true),
                    CustomerEmail = table.Column<string>(type: "text", nullable: true),
                    Purpose = table.Column<string>(type: "text", nullable: true),
                    BankName = table.Column<string>(type: "text", nullable: true),
                    BankAccountNo = table.Column<string>(type: "text", nullable: true),
                    RoutingCode = table.Column<string>(type: "text", nullable: true),
                    TransactionType = table.Column<int>(type: "integer", nullable: false),
                    MobileWalletAccountNumber = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CallBackUrl = table.Column<string>(type: "text", nullable: true),
                    FinalStatusReported = table.Column<bool>(type: "boolean", nullable: false),
                    TrackingNumber = table.Column<string>(type: "text", nullable: true),
                    BalanceBefore = table.Column<double>(type: "double precision", nullable: false),
                    BalanceAfter = table.Column<double>(type: "double precision", nullable: false),
                    ScreeningStartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ScreeningEndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    PaymentStartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    PaymentEndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    PaymentFailureReported = table.Column<bool>(type: "boolean", nullable: false),
                    RejectionReported = table.Column<bool>(type: "boolean", nullable: false),
                    RejectionReason = table.Column<string>(type: "text", nullable: true),
                    PaymentFailedReason = table.Column<string>(type: "text", nullable: true),
                    PaymentFailedRecommendations = table.Column<string>(type: "text", nullable: true),
                    PaymentPartner = table.Column<string>(type: "text", nullable: true),
                    TsqRetries = table.Column<int>(type: "integer", nullable: false),
                    SessionId = table.Column<string>(type: "text", nullable: true),
                    ElevyId = table.Column<string>(type: "text", nullable: true),
                    ElevyReserveTimestamp = table.Column<string>(type: "text", nullable: true),
                    ElevyReserverResponseTimestamp = table.Column<string>(type: "text", nullable: true),
                    ElevyStatus = table.Column<string>(type: "text", nullable: true),
                    ElevyTaxableAmount = table.Column<double>(type: "double precision", nullable: false),
                    ElevyAmount = table.Column<double>(type: "double precision", nullable: false),
                    ElevyClientTransactionId = table.Column<string>(type: "text", nullable: true),
                    ElevyConfirmedResponseTimestamp = table.Column<string>(type: "text", nullable: true),
                    ElevyCancelledResponseTimestamp = table.Column<string>(type: "text", nullable: true),
                    FullData = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PendingTransactionRequests", x => x.Id);
                    table.UniqueConstraint("AK_PendingTransactionRequests_MoneyTransferOperatorId_Transact~", x => new { x.MoneyTransferOperatorId, x.TransactionId });
                    table.ForeignKey(
                        name: "FK_PendingTransactionRequests_MoneyTransferOperators_MoneyTran~",
                        column: x => x.MoneyTransferOperatorId,
                        principalTable: "MoneyTransferOperators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionRequests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MoneyTransferOperatorId = table.Column<long>(type: "bigint", nullable: false),
                    TransactionId = table.Column<string>(type: "text", nullable: false),
                    Reference = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    PIN = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    CountryFrom = table.Column<string>(type: "text", nullable: true),
                    CountryTo = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryQuestion = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryAnswer = table.Column<string>(type: "text", nullable: true),
                    PaymentInstructions = table.Column<string>(type: "text", nullable: true),
                    OriginalCurrency = table.Column<string>(type: "text", nullable: true),
                    OriginalAmount = table.Column<double>(type: "double precision", nullable: false),
                    PaymentCurrency = table.Column<string>(type: "text", nullable: true),
                    PaymentAmount = table.Column<double>(type: "double precision", nullable: false),
                    CommissionCurrency = table.Column<string>(type: "text", nullable: true),
                    CommissionAmount = table.Column<double>(type: "double precision", nullable: false),
                    BeneficiaryId = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryFullName = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryFirstName = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryMiddleName = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryLastName = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryAddress = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryCity = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryCountry = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryPhoneNumber = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryEmail = table.Column<string>(type: "text", nullable: true),
                    BeneficiarySex = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryIdType = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryIdNumber = table.Column<string>(type: "text", nullable: true),
                    BeneficiaryTaxId = table.Column<string>(type: "text", nullable: true),
                    CustomerId = table.Column<string>(type: "text", nullable: true),
                    CustomerFullName = table.Column<string>(type: "text", nullable: true),
                    CustomerFirstName = table.Column<string>(type: "text", nullable: true),
                    CustomerMiddleName = table.Column<string>(type: "text", nullable: true),
                    CustomerLastName = table.Column<string>(type: "text", nullable: true),
                    CustomerCountry = table.Column<string>(type: "text", nullable: true),
                    CustomerIdType = table.Column<string>(type: "text", nullable: true),
                    CustomerIdNumber = table.Column<string>(type: "text", nullable: true),
                    CustomerIdIssuedBy = table.Column<string>(type: "text", nullable: true),
                    CustomerIdIssueCountry = table.Column<string>(type: "text", nullable: true),
                    CustomerIdIssuedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CustomerIdExpirationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CustomerCountryOfBirth = table.Column<string>(type: "text", nullable: true),
                    CustomerNationality = table.Column<string>(type: "text", nullable: true),
                    CustomerDateOfBirth = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CustomerOccupation = table.Column<string>(type: "text", nullable: true),
                    CustomerSourceOfFunds = table.Column<string>(type: "text", nullable: true),
                    CustomerSex = table.Column<string>(type: "text", nullable: true),
                    CustomerPhoneNumber = table.Column<string>(type: "text", nullable: true),
                    CustomerEmail = table.Column<string>(type: "text", nullable: true),
                    Purpose = table.Column<string>(type: "text", nullable: true),
                    BankName = table.Column<string>(type: "text", nullable: true),
                    BankAccountNo = table.Column<string>(type: "text", nullable: true),
                    RoutingCode = table.Column<string>(type: "text", nullable: true),
                    TransactionType = table.Column<int>(type: "integer", nullable: false),
                    MobileWalletAccountNumber = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CallBackUrl = table.Column<string>(type: "text", nullable: true),
                    FinalStatusReported = table.Column<bool>(type: "boolean", nullable: false),
                    TrackingNumber = table.Column<string>(type: "text", nullable: true),
                    BalanceBefore = table.Column<double>(type: "double precision", nullable: false),
                    BalanceAfter = table.Column<double>(type: "double precision", nullable: false),
                    ScreeningStartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ScreeningEndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    PaymentStartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    PaymentEndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    PaymentFailureReported = table.Column<bool>(type: "boolean", nullable: false),
                    RejectionReported = table.Column<bool>(type: "boolean", nullable: false),
                    RejectionReason = table.Column<string>(type: "text", nullable: true),
                    PaymentFailedReason = table.Column<string>(type: "text", nullable: true),
                    PaymentFailedRecommendations = table.Column<string>(type: "text", nullable: true),
                    PaymentPartner = table.Column<string>(type: "text", nullable: true),
                    TsqRetries = table.Column<int>(type: "integer", nullable: false),
                    SessionId = table.Column<string>(type: "text", nullable: true),
                    ElevyId = table.Column<string>(type: "text", nullable: true),
                    ElevyReserveTimestamp = table.Column<string>(type: "text", nullable: true),
                    ElevyReserverResponseTimestamp = table.Column<string>(type: "text", nullable: true),
                    ElevyStatus = table.Column<string>(type: "text", nullable: true),
                    ElevyTaxableAmount = table.Column<double>(type: "double precision", nullable: false),
                    ElevyAmount = table.Column<double>(type: "double precision", nullable: false),
                    ElevyClientTransactionId = table.Column<string>(type: "text", nullable: true),
                    ElevyConfirmedResponseTimestamp = table.Column<string>(type: "text", nullable: true),
                    ElevyCancelledResponseTimestamp = table.Column<string>(type: "text", nullable: true),
                    FullData = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionRequests", x => x.Id);
                    table.UniqueConstraint("AK_TransactionRequests_MoneyTransferOperatorId_TransactionId", x => new { x.MoneyTransferOperatorId, x.TransactionId });
                    table.ForeignKey(
                        name: "FK_TransactionRequests_MoneyTransferOperators_MoneyTransferOpe~",
                        column: x => x.MoneyTransferOperatorId,
                        principalTable: "MoneyTransferOperators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ForexCurrencyRates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ForexId = table.Column<long>(type: "bigint", nullable: false),
                    CurrencyId = table.Column<long>(type: "bigint", nullable: false),
                    Rate = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForexCurrencyRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForexCurrencyRates_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ForexCurrencyRates_Forex_ForexId",
                        column: x => x.ForexId,
                        principalTable: "Forex",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ForexLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ForexId = table.Column<long>(type: "bigint", nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    MoneyTransferOperatorId = table.Column<long>(type: "bigint", nullable: false),
                    Data = table.Column<string>(type: "text", nullable: true),
                    PublishedBy = table.Column<string>(type: "text", nullable: true),
                    Pushed = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForexLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForexLogs_Forex_ForexId",
                        column: x => x.ForexId,
                        principalTable: "Forex",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ForexLogs_MoneyTransferOperators_MoneyTransferOperatorId",
                        column: x => x.MoneyTransferOperatorId,
                        principalTable: "MoneyTransferOperators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComplianceByPassTransactions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    TransactionRequestId = table.Column<long>(type: "bigint", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    ScreeningStartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ScreeningEndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplianceByPassTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplianceByPassTransactions_PendingTransactionRequests_Tra~",
                        column: x => x.TransactionRequestId,
                        principalTable: "PendingTransactionRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentOrderReversalRequests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TransactionRequestId = table.Column<long>(type: "bigint", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: true),
                    VettedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    VettedBy = table.Column<string>(type: "text", nullable: true),
                    VettingNotes = table.Column<string>(type: "text", nullable: true),
                    Processed = table.Column<bool>(type: "boolean", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    ApprovedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ApprovedBy = table.Column<string>(type: "text", nullable: true),
                    ReversalCharge = table.Column<double>(type: "double precision", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentOrderReversalRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentOrderReversalRequests_TransactionRequests_Transactio~",
                        column: x => x.TransactionRequestId,
                        principalTable: "TransactionRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppSettings_Name",
                table: "AppSettings",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_ArchivedTransactionRequests_MoneyTransferOperatorId",
                table: "ArchivedTransactionRequests",
                column: "MoneyTransferOperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchivedTransactionRequests_TransactionId_MoneyTransferOper~",
                table: "ArchivedTransactionRequests",
                columns: new[] { "TransactionId", "MoneyTransferOperatorId" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BankBranches_BankId",
                table: "BankBranches",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceByPassTransactions_TransactionRequestId",
                table: "ComplianceByPassTransactions",
                column: "TransactionRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_CrossSwitchReconItems_CrossSwitchReconId",
                table: "CrossSwitchReconItems",
                column: "CrossSwitchReconId");

            migrationBuilder.CreateIndex(
                name: "IX_Forex_MoneyTransferOperatorId",
                table: "Forex",
                column: "MoneyTransferOperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ForexCurrencyRates_CurrencyId",
                table: "ForexCurrencyRates",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ForexCurrencyRates_ForexId",
                table: "ForexCurrencyRates",
                column: "ForexId");

            migrationBuilder.CreateIndex(
                name: "IX_ForexLogs_ForexId",
                table: "ForexLogs",
                column: "ForexId");

            migrationBuilder.CreateIndex(
                name: "IX_ForexLogs_MoneyTransferOperatorId",
                table: "ForexLogs",
                column: "MoneyTransferOperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_GhipssReconItems_GhipssReconId",
                table: "GhipssReconItems",
                column: "GhipssReconId");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyTransferOperatorAccountAdjustments_MoneyTransferOperat~",
                table: "MoneyTransferOperatorAccountAdjustments",
                column: "MoneyTransferOperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyTransferOperatorAccountLimitAdjustments_MoneyTransferO~",
                table: "MoneyTransferOperatorAccountLimitAdjustments",
                column: "MoneyTransferOperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyTransferOperatorAccountThresholdAdjustments_MoneyTrans~",
                table: "MoneyTransferOperatorAccountThresholdAdjustments",
                column: "MoneyTransferOperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyTransferOperators_CountryId",
                table: "MoneyTransferOperators",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_MtnReconItems_MtnReconId",
                table: "MtnReconItems",
                column: "MtnReconId");

            migrationBuilder.CreateIndex(
                name: "IX_MTOPaymentChannelRequests_MtoId",
                table: "MTOPaymentChannelRequests",
                column: "MtoId");

            migrationBuilder.CreateIndex(
                name: "IX_MTOPaymentChannels_MtoId",
                table: "MTOPaymentChannels",
                column: "MtoId");

            migrationBuilder.CreateIndex(
                name: "IX_MtoUsers_MoneyTransferOperatorId",
                table: "MtoUsers",
                column: "MoneyTransferOperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrderReversalRequests_TransactionRequestId",
                table: "PaymentOrderReversalRequests",
                column: "TransactionRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_PendingTransactionRequests_TransactionId",
                table: "PendingTransactionRequests",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_PendingTransactionRequests_TransactionId_MoneyTransferOpera~",
                table: "PendingTransactionRequests",
                columns: new[] { "TransactionId", "MoneyTransferOperatorId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TigoReconItems_TigoReconId",
                table: "TigoReconItems",
                column: "TigoReconId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionRequests_TransactionId",
                table: "TransactionRequests",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionRequests_TransactionId_MoneyTransferOperatorId",
                table: "TransactionRequests",
                columns: new[] { "TransactionId", "MoneyTransferOperatorId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VodafoneReconItems_VodafoneReconId",
                table: "VodafoneReconItems",
                column: "VodafoneReconId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlertNotifications");

            migrationBuilder.DropTable(
                name: "AmlockOfflineTransactionsServiceRuns");

            migrationBuilder.DropTable(
                name: "AppSettings");

            migrationBuilder.DropTable(
                name: "ArchivedPaymentOrderReversalRequests");

            migrationBuilder.DropTable(
                name: "ArchivedTransactionLogs");

            migrationBuilder.DropTable(
                name: "ArchivedTransactionRequests");

            migrationBuilder.DropTable(
                name: "ArchivedTransactionStatusUpdateRequests");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BankBranches");

            migrationBuilder.DropTable(
                name: "ComplianceByPassTransactions");

            migrationBuilder.DropTable(
                name: "CrossSwitchReconItems");

            migrationBuilder.DropTable(
                name: "ElevyTrustAccounts");

            migrationBuilder.DropTable(
                name: "ForexCurrencyRates");

            migrationBuilder.DropTable(
                name: "ForexLogs");

            migrationBuilder.DropTable(
                name: "FundTransferRequests");

            migrationBuilder.DropTable(
                name: "GhipssReconItems");

            migrationBuilder.DropTable(
                name: "MessageListContacts");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "MessageTemplates");

            migrationBuilder.DropTable(
                name: "MoneyTransferOperatorAccountAdjustments");

            migrationBuilder.DropTable(
                name: "MoneyTransferOperatorAccountLimitAdjustments");

            migrationBuilder.DropTable(
                name: "MoneyTransferOperatorAccountThresholdAdjustments");

            migrationBuilder.DropTable(
                name: "MtnReconItems");

            migrationBuilder.DropTable(
                name: "MTOPaymentChannelRequests");

            migrationBuilder.DropTable(
                name: "MTOPaymentChannels");

            migrationBuilder.DropTable(
                name: "MtoUsers");

            migrationBuilder.DropTable(
                name: "PaymentFailureReasons");

            migrationBuilder.DropTable(
                name: "PaymentFailureRecommendations");

            migrationBuilder.DropTable(
                name: "PaymentOrderReversalRequests");

            migrationBuilder.DropTable(
                name: "PaymentPartnerBalance");

            migrationBuilder.DropTable(
                name: "PaymentRequestPayloads");

            migrationBuilder.DropTable(
                name: "ReceivedRequestPayloads");

            migrationBuilder.DropTable(
                name: "SystemLogs");

            migrationBuilder.DropTable(
                name: "TigoReconItems");

            migrationBuilder.DropTable(
                name: "TransactionLogs");

            migrationBuilder.DropTable(
                name: "TransactionRequestPayloads");

            migrationBuilder.DropTable(
                name: "TransactionStatusUpdateRequests");

            migrationBuilder.DropTable(
                name: "VodafoneReconItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "PendingTransactionRequests");

            migrationBuilder.DropTable(
                name: "CrossSwitchRecons");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Forex");

            migrationBuilder.DropTable(
                name: "GhipssRecons");

            migrationBuilder.DropTable(
                name: "MtnRecons");

            migrationBuilder.DropTable(
                name: "TransactionRequests");

            migrationBuilder.DropTable(
                name: "TigoRecons");

            migrationBuilder.DropTable(
                name: "VodafoneRecons");

            migrationBuilder.DropTable(
                name: "MoneyTransferOperators");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
