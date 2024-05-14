namespace RemittanceSharedModels
{
    public class GipFundTransferCreditRequest
    {
        public string Amount { get; set; } = "000000000000"; //n12
        public string Datetime { get; set; }
        public string TrackingNum { get; set; }
        public string DestBank { get; set; }
        public string SessionId { get; set; }
        public string NameToDebit { get; set; }
        public string AccountToDebit { get; set; }
        public string NameToCredit { get; set; }
        public string AccountToCredit { get; set; }
        public string Narration { get; set; }
        public string SenderCountry { get; set; }
        public string Sender { get; set; }
    }

    public class GipStatusQueryRequest
    {
        public string Amount { get; set; }
        public string Datetime { get; set; }
        public string TrackingNum { get; set; }
        public string DestBank { get; set; }
        public string SessionId { get; set; }
        public string NameToDebit { get; set; }
        public string AccountToDebit { get; set; }
        public string NameToCredit { get; set; }
        public string AccountToCredit { get; set; }
        public string Narration { get; set; }
        public string SenderCountry { get; set; }
        public string Sender { get; set; }
    }

    public class GipNameEnquiryForCreditRequest
    {
        public string Datetime { get; set; }
        public string TrackingNum { get; set; } //n6
        public string DestBank { get; set; } //n6
        public string SessionId { get; set; } //n12
        public string AccountToCredit { get; set; } //an28
        public string NameToDebit { get; set; }
        public string AccountToDebit { get; set; }
        public string Narration { get; set; }
        public string SenderCountry { get; set; }
        public string Sender { get; set; }
    }

    public class GipResponseObject
    {
        public GipResponseEnvelope Envelope { get; set; }
    }
    public class GipResponseEnvelope
    {
        public GipResponseBody Body { get; set; }
    }
    public class GipResponseBody
    {
        public GIPTransactionOpResponse GIPTransactionOpResponse { get; set; }
    }
    public class GIPTransactionOpResponse
    {
        public GIPTransactionResponse GIPTransactionResponse { get; set; }
    }
    public class GIPTransactionResponse
    {
        public object Amount { get; set; }
        public object DateTimeOffset { get; set; }
        public object TrackingNum { get; set; }
        public object FunctionCode { get; set; }
        public object OrigineBank { get; set; }
        public object DestBank { get; set; }
        public object SessionID { get; set; }
        public object NameToDebit { get; set; }
        public object AccountToDebit { get; set; }
        public object NameToCredit { get; set; }
        public object AccountToCredit { get; set; }
        public object Narration { get; set; } //an98
        public string ActCode { get; set; } //n6
        public string AprvCode { get; set; } //n3
        public string StatusQuery { get; set; } //n6
    }

    public class GIPAccountValidationResponseV2
    {        
        public object DestBank { get; set; }
        public object NameToCredit { get; set; }
        public object AccountToCredit { get; set; }
    }

    public class GIPTransactionConfirmationRequest
    {
        public string DestBank { get; set; }
        public string SessionId { get; set; }
    }

    public class GIPTransactionConfirmationResponse
    {
        public string amount { get; set; }
        public string date_create { get; set; }
        public string dest_bank { get; set; }
        public string errorCode { get; set; }
        public string errorMessage { get; set; }
        public string final_status { get; set; }
        public string original_status { get; set; }
        public string session_id { get; set; }
        public string src_bank { get; set; }
    }
    public class GipFundTransferCreditResponse
    {
        public string Amount { get; set; }
        public string DateTimeOffset { get; set; }
        public string TrackingNum { get; set; }
        public string FunctionCode { get; set; }
        public string OrigineBank { get; set; }
        public string DestBank { get; set; }
        public string SessionId { get; set; }
        public string ChannelCode { get; set; }
        public string AccountToCredit { get; set; }
        public string Naration { get; set; }
        public string ActCode { get; set; }
        public string AprvCode { get; set; }
    }
}
