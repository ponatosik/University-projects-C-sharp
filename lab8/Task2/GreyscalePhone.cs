namespace lab8.Task2
{
    using TelephoneNumber = System.UInt64;

    class GreyscalePhone : KeypadPhone
    {
        public Size PhoneSize { get; set; }
        public Size DisplaySize { get; set; }
        public string PhoneColor { get; set; } = "Grey";
        public struct Size { int Width; int Height; }

        public GreyscalePhone(TelephoneNumber number) : base(number) { }

        public void SendSMS(TelephoneNumber recipientNumber, string message)
        {
            TelephoneNetwork.GetConection().SendSMS(PhoneNumber, recipientNumber, message);
        }
        public void RecieveSMS(TelephoneNumber senderNumber, string message)
        {
            string phoneName = this.GetType().Name;
            Console.WriteLine($"{phoneName}({PhoneNumber}) recieved SMS from {senderNumber}:");
            Console.WriteLine(message);
        }

    }
}