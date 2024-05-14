namespace RemittanceSharedModels
{
    public class Privileges
    {
        public const string CanViewDashboard = "CanViewDashboard";
        public const string CanResetPassword = "CanResetPassword";
        public const string CanViewReconciliations = "CanViewReconciliations";
        public const string CanDoReconciliations = "CanDoReconciliations";

        //Roles
        public const string CanViewRoles = "CanViewRoles";
        public const string CanCreateRoles = "CanCreateRoles";
        public const string CanUpdateRoles = "CanUpdateRoles";
        public const string CanDeleteRoles = "CanDeleteRoles";

        //System Users
        public const string CanViewUsers = "CanViewUsers";
        public const string CanCreateUsers = "CanCreateUsers";
        public const string CanUpdateUsers = "CanUpdateUsers";
        public const string CanDeleteUsers = "CanDeleteUsers";

        //MTO Users
        public const string CanViewMtoUsers = "CanViewMtoUsers";
        public const string CanCreateMtoUsers = "CanCreateMtoUsers";
        public const string CanUpdateMtoUsers = "CanUpdateMtoUsers";
        public const string CanActivateMtoUsers = "CanActivateMtoUsers";
        public const string CanDeactivateMtoUsers = "CanDeactivateMtoUsers";
        public const string CanResetMtoUserPassword = "CanResetMtoUserPassword";


        //Settings
        public const string CanViewSettings = "CanViewSettings";
        public const string CanManageSettings = "CanManageSettings";

        //MoneyTransferOperators
        public const string CanViewMtos = "CanViewMtos";
        public const string CanCreateMTOs = "CanCreateMTOs";
        public const string CanUpdateMTOs = "CanUpdateMTOs";
        public const string CanManageMTOAccountBalance = "CanManageMTOAccountBalance";
        public const string CanSetMTOAccountLimit = "CanSetMTOAccountLimit";
        public const string CanSetMTOAccountThreshold = "CanSetMTOAccountThreshold";
        public const string CanSetMTOPin = "CanSetMTOPin";
        public const string CanViewMTOAccountAdjustments= "CanViewMTOAccountAdjustments";

        //Forex
        public const string CanViewForex = "CanViewForex";
        public const string CanManageForex = "CanManageForex";
        public const string CanPublishForex = "CanPublishForex";

        //Alerts
        public const string CanViewAlerts = "CanViewAlerts";
        public const string CanManageAlertTemplates = "CanManageAlertTemplates";
        public const string CanManageAlertContacts = "CanManageAlertContacts";

        //Alerts
        public const string CanViewApprovals = "CanViewApprovals";
        public const string CanApproveMtoAccountBalanceAdjustment = "CanApproveMtoAccountBalanceAdjustment";
        public const string CanApproveMtoAccountLimitAdjustment = "CanApproveMtoAccountLimitAdjustment";
        public const string CanApproveTransactionStatusUpdateRequests = "CanApproveTransactionStatusUpdateRequests";
        public const string CanApproveMtoAccountThreshold = "CanApproveMtoAccountThreshold";

        //TransactionStatusUpdateRequests
        public const string CanViewTransactionStatusUpdateRequests = "CanViewTransactionStatusUpdateRequests";
        public const string CanManageTransactionStatusUpdateRequests = "CanManageTransactionStatusUpdateRequests";
        public const string CanRejectTransactionStatusUpdateRequests = "CanRejectTransactionStatusUpdateRequests";

        //TransactionMonitoring
        public const string CanViewTransactionMonitoring = "CanViewTransactionMonitoring";
        public const string CanViewTransactionMonitoringCompliance = "CanViewTransactionMonitoringCompliance";
        public const string CanViewTransactionMonitoringPayment = "CanViewTransactionMonitoringPayment";

        public const string CanManageFailedTransactions = "CanManageFailedTransactions";

        //Reports
        public const string CanViewReports = "CanViewReports";
        public const string CanViewTransactionsReport = "CanViewTransactionsReport";
        public const string CanViewFailedTransactionsReport = "CanViewFailedTransactionsReport";
        public const string CanViewRejectedTransactionsReport = "CanViewRejectedTransactionsReport";
        public const string CanViewPaidTransactionsReport = "CanViewPaidTransactionsReport";
        public const string CanViewAccountTransactionsReport = "CanViewAccountTransactionsReport";
        public const string CanViewForexReport = "CanViewForexReport";
        public const string CanViewAccountStatementReport = "CanViewAccountStatementReport";
        public const string CanViewAccountBalanceAdjustmentsReport = "CanViewAccountBalanceAdjustmentsReport";
        public const string CanViewAccountLimitAdjustmentsReport = "CanViewAccountLimitAdjustmentsReport";
        public const string CanViewAccountThresholdAdjustmentsReport = "CanViewAccountThresholdAdjustmentsReport";
        public const string CanViewTransactionStatisticsReport = "CanViewTransactionStatisticsReport";
        public const string CanViewTransactionsDurationReport = "CanViewTransactionsDurationReport";
        public const string CanViewPaysendCommissionsReport = "CanViewPaysendCommissionsReport";
        public const string CanViewPendingReversalsReport = "CanViewPendingReversalsReport";
        public const string CanViewReversedTransactionsReport = "CanViewReversedTransactionsReport";
        public const string CanViewTransactionStatusUpdateReport = "CanViewTransactionStatusUpdateReport";
        public static string CanViewReversalAdviceReport = "CanViewReversalAdviceReport";
        public static string CanViewReversalStatisticsReport = "CanViewReversalStatisticsReport";
        public static string CanViewReversalRequestsReport = "CanViewReversalRequestsReport";

        //TransactionMonitoring
        public const string CanViewTransactionReversal = "CanViewTransactionReversal";
        public const string CanReverseTransaction = "CanReverseTransaction";
        public const string CanApproveAndRejectTransactionReversal = "CanApproveAndRejectTransactionReversal";

        //PaymentChannelRequests
        public const string CanViewPaymentChannels = "CanViewPaymentChannels";
        public const string CanMakeMTOPaymentChannelRequests = "CanMakeMTOPaymentChannelRequests";
        public const string CanApproveOrRejectMTOPaymentChannelRequests = "CanApproveOrRejectMTOPaymentChannelRequests";
        //TransactionMonitoring
        public const string CanTransferFunds = "CanTransferFunds";
        public const string CanApproveAndRejectFundTransfer = "CanApproveAndRejectFundTransfer";

        public const string CanAddReversalRequest = "CanAddReversalRequest";
    }

    public class GenericProperties
    {
        public const string Administrator = "Administrator";
        public const string Privilege = "Privilege";
        public const string CreatedBy = "CreatedBy";
        public const string CreatedAt = "CreatedAt";
        public const string ModifiedAt = "ModifiedAt";
        public const string ModifiedBy = "ModifiedBy";
        public const string Locked = "Locked";
        public const string IsDeleted = "IsDeleted";
    }

    public class ExceptionMessage
    {
        public const string RecordLocked = "Record is locked and can't be deleted.";
        public const string NotFound = "Record not found.";
    }

    public class ConfigKeys
    {
        public static string EmailAccountName = "EmailAccountName";
        public static string EmailApiKey = "EmailApiKey";
        public static string EmailSender = "EmailSender";
        public static string SmsApiKey = "SmsApiKey";
        public static string SmsSender = "SmsSender";
        public static string AppTitle = "AppTitle";
        public static string Logo = "Logo";
        public static string KeepAlive = "KeepAlive";
    }

    public class ResultObj
    {
        public long Total { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }

    public class MessageTemplateTitles
    {
        public const string SmsNotification = "SMS Notification";
        public const string SystemDownNotification = "System Down Notification";
        public const string InfobipLowAccountBalanceNotification = "Infobip Low Account Balance Notification";
        public const string MTOLowAccountBalanceNotification = "MTO Low Account Balance Notification";
        public const string _116AlertNotification = "116 Alert Notification";
        public const string MTNLowAccountBalanceNotification = "MTN Low Account Balance Notification";
        public const string VodafoneLowAccountBalanceNotification = "Vodafone Low Account Balance Notification";
        public const string TigoLowAccountBalanceNotification = "Tigo Low Account Balance Notification";
        public const string CrossSwitchLowAccountBalanceNotification = "CrossSwitch Low Account Balance Notification";
    }

    public class AlertActions
    {
        public const string ReceiveSystemDownNotification = "ReceiveSystemDownNotification";
        public const string ReceiveInfobipLowAccountBalanceNotification = "ReceiveInfobipLowAccountBalanceNotification";
        public const string ReceiveMTOLowAccountBalanceNotification = "ReceiveMTOLowAccountBalanceNotification";

        public const string Receive116AlertNotification = "Receive116AlertNotification";
        public const string ReceiveMTNLowAccountBalanceNotification = "ReceiveMTNLowAccountBalanceNotification";
        public const string ReceiveVodafoneLowAccountBalanceNotification = "ReceiveVodafoneLowAccountBalanceNotification";
        public const string ReceiveTigoLowAccountBalanceNotification = "ReceiveTigoLowAccountBalanceNotification";
        public const string ReceiveCrossSwitchLowAccountBalanceNotification = "ReceiveCrossSwitchLowAccountBalanceNotification";
    }
}
