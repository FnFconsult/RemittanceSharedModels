using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RemittanceSharedModels
{
    public class ApplicationDbContext : IdentityDbContext<
        User, Role, string,
        UserClaim, UserRole, UserLogin,
        RoleClaim, UserToken>
    {
        //private readonly IConfiguration _configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<AppSetting> AppSettings { get; set; }
        public DbSet<SystemLog> SystemLogs { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankBranch> BankBranches { get; set; }
        public DbSet<MoneyTransferOperator> MoneyTransferOperators { get; set; }
        public DbSet<TransactionRequest> TransactionRequests { get; set; }
        public DbSet<PendingTransactionRequest> PendingTransactionRequests { get; set; }
        public DbSet<TransactionRequestPayload> TransactionRequestPayloads { get; set; }
        public DbSet<PaymentRequestPayload> PaymentRequestPayloads { get; set; }
        public DbSet<ReceivedRequestPayload> ReceivedRequestPayloads { get; set; }
        public DbSet<TransactionLog> TransactionLogs { get; set; }
        public DbSet<Forex> Forex { get; set; }
        public DbSet<ForexCurrencyRate> ForexCurrencyRates { get; set; }
        public DbSet<ForexLog> ForexLogs { get; set; }
        public DbSet<MoneyTransferOperatorAccountBalanceAdjustment> MoneyTransferOperatorAccountAdjustments { get; set; }
        public DbSet<MoneyTransferOperatorAccountLimitAdjustment> MoneyTransferOperatorAccountLimitAdjustments { get; set; }
        public DbSet<MoneyTransferOperatorAccountThresholdAdjustment> MoneyTransferOperatorAccountThresholdAdjustments { get; set; }
        public DbSet<AmlockOfflineTransactionsServiceRun> AmlockOfflineTransactionsServiceRuns { get; set; }
        public DbSet<MtoUser> MtoUsers { get; set; }
        public DbSet<MessageListContact> MessageListContacts { get; set; }
        public DbSet<AlertNotification> AlertNotifications { get; set; }
        public DbSet<MessageTemplate> MessageTemplates { get; set; }
        public DbSet<ComplianceByPassTransaction> ComplianceByPassTransactions { get; set; }
        public DbSet<GhipssRecon> GhipssRecons { get; set; }
        public DbSet<GhipssReconItem> GhipssReconItems { get; set; }
        public DbSet<TransactionStatusUpdateRequest> TransactionStatusUpdateRequests { get; set; }
        public DbSet<PaymentFailureReason> PaymentFailureReasons { get; set; }
        public DbSet<PaymentFailureRecommendation> PaymentFailureRecommendations { get; set; }
        public DbSet<PaymentOrderReversalRequest> PaymentOrderReversalRequests { get; set; }
        public DbSet<MTOPaymentChannel> MTOPaymentChannels { get; set; }
        public DbSet<MTOPaymentChannelRequest> MTOPaymentChannelRequests { get; set; }
        public DbSet<MtnRecon> MtnRecons { get; set; }
        public DbSet<MtnReconItem> MtnReconItems { get; set; }
        public DbSet<FundTransferRequest> FundTransferRequests { get; set; }
        public DbSet<VodafoneRecon> VodafoneRecons { get; set; }
        public DbSet<VodafoneReconItem> VodafoneReconItems { get; set; }
        public DbSet<TigoRecon> TigoRecons { get; set; }
        public DbSet<TigoReconItem> TigoReconItems { get; set; }
        public DbSet<CrossSwitchRecon> CrossSwitchRecons { get; set; }
        public DbSet<CrossSwitchReconItem> CrossSwitchReconItems { get; set; }
        public DbSet<PaymentPartnerBalance> PaymentPartnerBalance { get; set; }

        public DbSet<ArchivedTransactionRequest> ArchivedTransactionRequests { get; set; }
        public DbSet<ArchivedTransactionLog> ArchivedTransactionLogs { get; set; }
        public DbSet<ArchivedPaymentOrderReversalRequest> ArchivedPaymentOrderReversalRequests { get; set; }
        public DbSet<ArchivedTransactionStatusUpdateRequest> ArchivedTransactionStatusUpdateRequests { get; set; }
        public DbSet<ElevyTrustAccount> ElevyTrustAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>(b =>
            {
                // Each User can have many UserClaims
                b.HasMany(e => e.Claims)
                    .WithOne(e => e.User)
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                // Each User can have many UserLogins
                b.HasMany(e => e.Logins)
                    .WithOne(e => e.User)
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                // Each User can have many UserTokens
                b.HasMany(e => e.Tokens)
                    .WithOne(e => e.User)
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                // Each User can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            builder.Entity<Role>(b =>
            {
                // Each Role can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                // Each Role can have many associated RoleClaims
                b.HasMany(e => e.RoleClaims)
                    .WithOne(e => e.Role)
                    .HasForeignKey(rc => rc.RoleId)
                    .IsRequired();
            });

            builder.Entity<RoleClaim>(b =>
            {
                b.HasKey(e => e.Id);
            });
            builder.Entity<UserClaim>(b =>
            {
                b.HasKey(e => e.Id);
            });
            builder.Entity<UserLogin>(b =>
            {
                b.HasKey(e => e.Id);
            });

            builder.Entity<AppSetting>()
            .HasIndex(b => b.Name);

            builder.Entity<PendingTransactionRequest>(x =>
            {
                x.HasIndex(b => b.TransactionId);
                x.HasAlternateKey(c => new { c.MoneyTransferOperatorId, c.TransactionId });
            });

            builder.Entity<TransactionRequest>(x =>
            {
                x.HasIndex(b => b.TransactionId);
                x.HasAlternateKey(c => new { c.MoneyTransferOperatorId, c.TransactionId });
            });
        }
    }
}
