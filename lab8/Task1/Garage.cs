namespace lab8.Task1
{
    class Garage
    {
        public void ParkCar(Car car) => _parkedCars.Add(car);
        public void TakeCar(Car car) => _parkedCars.Remove(car);
        public IEnumerable<Car> FindCars(string? name = null, string? color = null, int? speed = null, int? releaseYear = null)
        {
            IEnumerable<Car> result = _parkedCars.AsEnumerable();

            if(name is not null)
            {
                result = result.Where(car => car.Name == name);
            }
            if(color is not null)
            {
                result = result.Where(car => car.Color == color);
            }
            if(speed is not null)
            {
                result = result.Where(car => car.Speed == speed);
            }
            if(releaseYear is not null)
            {
                result = result.Where(car => car.ReleaseYear == releaseYear);
            }

            return result;
        }
        private HashSet<Car> _parkedCars = new HashSet<Car>();
    }
}