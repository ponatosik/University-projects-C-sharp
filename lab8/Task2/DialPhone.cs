namespace lab8.Task2
{
    using TelephoneNumber = System.UInt64;

    class DialPhone
    {
        public TelephoneNumber PhoneNumber { get; set; }
        public virtual char[] AvalibleSymbols { get => "0123456789".ToCharArray(); }

        public DialPhone(TelephoneNumber number)
        {
            PhoneNumber = number;
            TelephoneNetwork.GetConection().RegisterNumber(number, this);
        }

        public virtual void MakeCall(TelephoneNumber calledNumber)
        {
            string phoneName = this.GetType().Name;
            Console.WriteLine($"{phoneName}({PhoneNumber}) is calling {calledNumber}...");

            TelephoneNetwork.GetConection().MakeCall(PhoneNumber, calledNumber);
        }
        public virtual void RecieveCall(TelephoneNumber callingNumber)
        {
            string phoneName = this.GetType().Name;
            Console.WriteLine($"{phoneName}({PhoneNumber}) recieved call");
        }
    }
}