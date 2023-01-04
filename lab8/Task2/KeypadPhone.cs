namespace lab8.Task2
{
    using TelephoneNumber = System.UInt64;

    class KeypadPhone : DialPhone
    {
        public override char[] AvalibleSymbols { get => "0123456789*#".ToCharArray(); }

        public KeypadPhone(TelephoneNumber number) : base(number) { }
        
        public override void RecieveCall(TelephoneNumber callingNumber)
        {
            string phoneName = this.GetType().Name;
            Console.WriteLine($"{phoneName}({PhoneNumber}) recieved call from {callingNumber}");
        }
    }
}