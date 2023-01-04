namespace lab8.Task2
{
    using TelephoneNumber = System.UInt64;
    using Abonent = DialPhone;

    class TelephoneNetwork
    {
        public void MakeCall(TelephoneNumber callingNumber, TelephoneNumber calledNumber)
        {
            if (!_registratedNumbers.ContainsKey(callingNumber)) return;
            if (!_registratedNumbers.ContainsKey(calledNumber)) return;

            _registratedNumbers[calledNumber].RecieveCall(callingNumber);
        }
        public void SendSMS(TelephoneNumber senderNumber, TelephoneNumber recipientNumber, string message)
        {
            Abonent? recipient;
            _registratedNumbers.TryGetValue(recipientNumber, out recipient);

            if (recipient is GreyscalePhone)
            {
                GreyscalePhone validRecipient = (GreyscalePhone)recipient;
                validRecipient.RecieveSMS(senderNumber, message);
            }
        }
        public void SendMMS(TelephoneNumber senderNumber, TelephoneNumber recipientNumber, string content)
        {
            Abonent? recipient;
            _registratedNumbers.TryGetValue(recipientNumber, out recipient);
            
            if (recipient is CellPhone)
            {
                CellPhone validRecipient = (CellPhone)recipient;
                validRecipient.RecieveMMS(senderNumber, content);
            }
        }

        public static TelephoneNetwork GetConection()
        {
            if (_instance == null)
            {
                _instance = new TelephoneNetwork();
            }
            return _instance;
        }
        public void RegisterNumber(TelephoneNumber number, Abonent abonent)
        {
            _registratedNumbers.Add(number, abonent);
        }
        
        private static TelephoneNetwork? _instance;
        private Dictionary<TelephoneNumber, Abonent> _registratedNumbers = new();
    }
}