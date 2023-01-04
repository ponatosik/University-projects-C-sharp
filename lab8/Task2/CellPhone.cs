namespace lab8.Task2
{
    using TelephoneNumber = System.UInt64;

    class CellPhone : GreyscalePhone
    {
        public int ColorDepth { get; set; }
        public override char[] AvalibleSymbols { get => "0123456789*#+".ToCharArray(); }
        public bool HasSecondNumber => _secondPhoneNumber is not null;
        public TelephoneNumber SecondPhoneNumber
        {
            get => _secondPhoneNumber is not null ? _secondPhoneNumber.Value : 0;
            set => _secondPhoneNumber = value;
        }

        public CellPhone(TelephoneNumber number) : base(number) { }
        public CellPhone(TelephoneNumber number, TelephoneNumber secondlNumber) : base(number)
        {
            _secondPhoneNumber = secondlNumber;
            TelephoneNetwork.GetConection().RegisterNumber(secondlNumber, this);
        }

        public void MakeCall(TelephoneNumber calledNumber, int simCardSlot)
        {
            if (simCardSlot == 1)
            {
                MakeCall(calledNumber);
                return;
            }
            if (simCardSlot != 2 || !HasSecondNumber)
            {
                return;
            }

            // Make call using second phone number
            TelephoneNumber secondPhoneNumber = _secondPhoneNumber!.Value;
            string phoneName = this.GetType().Name;
            Console.WriteLine($"{phoneName} is calling {calledNumber} using his second number ({secondPhoneNumber}) ...");

            TelephoneNetwork.GetConection().MakeCall(secondPhoneNumber, calledNumber);
        }
        public void SendSMS(TelephoneNumber recipientNumber, string content, int simCardSlot = 1)
        {
            TelephoneNumber numberToUse;
            switch (simCardSlot)
            {
                case 1:
                    numberToUse = PhoneNumber;
                    break;
                case 2:
                    if (HasSecondNumber)
                    {
                        numberToUse = SecondPhoneNumber;
                    }
                    else
                    {
                        return;
                    }
                    break;
                default:
                    return;
            }

            TelephoneNetwork.GetConection().SendSMS(numberToUse, recipientNumber, content);
        }

        public void RecieveMMS(TelephoneNumber senderNumber, string content)
        {
            string phoneName = this.GetType().Name;
            Console.WriteLine($"{phoneName}({PhoneNumber}) recieved MMS from {senderNumber}:");
            Console.WriteLine(content);
        }
        public void SendMMS(TelephoneNumber recipientNumber, string content)
        {
            TelephoneNetwork.GetConection().SendSMS(PhoneNumber, recipientNumber, content);
        }

        private TelephoneNumber? _secondPhoneNumber;
    }
}