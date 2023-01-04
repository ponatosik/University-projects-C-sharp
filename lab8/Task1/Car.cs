namespace lab8.Task1
{
    class Car
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int Speed { get; set; } 
        public int ReleaseYear { get; set; }

        public Car(string name, string color, int speed, int releaseYear)
        {
            Name = name;
            Color = color;
            Speed = speed;
            ReleaseYear = releaseYear;
        }
        public override string ToString()
        {
            return $"Car: {Name} {Color} ({ReleaseYear})";
        } 
    }
}