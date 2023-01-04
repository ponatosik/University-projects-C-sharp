namespace lab8.Task2
{
    using TelephoneNumber = System.UInt64;

    class Smartphone : CellPhone
    {
        public int MultiTouchNumber { get; set; } = 10;
        public int CamerasNumber { get; set; } = 2; 

        public Smartphone(TelephoneNumber number) : base(number) { }
        public Smartphone(TelephoneNumber number, TelephoneNumber aditionalNumber) : base(number, aditionalNumber) { }

        public string TakeVideo(int cameraID = 0) { 
            if(cameraID >=  CamerasNumber)
            {
                throw new IndexOutOfRangeException();
            } 

            return "some video";
        }
        public string TakePhoto(int cameraID = 0) { 
            if(cameraID >=  CamerasNumber)
            {
                throw new IndexOutOfRangeException();
            } 
            
            return "some picture";
        }   
    }
}