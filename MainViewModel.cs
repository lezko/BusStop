using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Lab4.library;

namespace Lab4
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<Bus> buses;
        private ObservableCollection<BusStop> busStops;
        private ObservableCollection<IPassenger> passengers;

        public ObservableCollection<Bus> Buses
        {
            get => buses;
            set => SetProperty(ref buses, value);
        }

        public ObservableCollection<BusStop> BusStops
        {
            get => busStops;
            set => SetProperty(ref busStops, value);
        }

        public ObservableCollection<IPassenger> Passengers
        {
            get => passengers;
            set => SetProperty(ref passengers, value);
        }

        public ICommand AddBusCommand { get; }
        public ICommand AddBusStopCommand { get; }
        public ICommand AddPassengerCommand { get; }

        public MainViewModel()
        {
            Buses = new ObservableCollection<Bus>();
            BusStops = new ObservableCollection<BusStop>();
            Passengers = new ObservableCollection<IPassenger>();

            AddBusCommand = new RelayCommand(AddBus);
            AddBusStopCommand = new RelayCommand(AddBusStop);
            AddPassengerCommand = new RelayCommand(AddPassenger);

            Task.Run(() => SimulateBusArrival());
        }

        private void AddBus()
        {
            var bus = new Bus("AB123CD", 10);
            bus.BusArrived += OnBusArrived;
            bus.BusOverloaded += OnBusOverloaded;
            Buses.Add(bus);
        }

        private void AddBusStop()
        {
            var busStop = new BusStop("Main Street");
            BusStops.Add(busStop);
        }

        private void AddPassenger()
        {
            var passenger = new Passenger("John Doe");
            Passengers.Add(passenger);
        }

        private void OnBusArrived(Bus bus)
        {
            Console.WriteLine($"Bus {bus.LicensePlate} arrived at the stop.");
        }

        private void OnBusOverloaded(Bus bus)
        {
            Console.WriteLine($"Bus {bus.LicensePlate} is overloaded!");
        }

        private void SimulateBusArrival()
        {
            while (true)
            {
                foreach (var bus in Buses)
                {
                    foreach (var busStop in BusStops)
                    {
                        bus.ArriveAtBusStop(busStop);
                    }
                }
                Thread.Sleep(5000);
            }
        }
    }
}
