using System;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace blazorIoT.Data
{
    public class LDRDeviceService
    {
        const string IIO_PATH =
            "/sys/bus/iio/devices/iio:device0/in_voltage0_raw";

        private Thread LDRRoutine;
        public int LevelPercentage { get; set; }

        public LDRDeviceService ()
        {
            Console.WriteLine(File.ReadAllText(IIO_PATH));

            LDRRoutine = new Thread(() => {
                while (true)
                {
                    var val = Int32.Parse(File.ReadAllText(IIO_PATH));
                    LevelPercentage = (val * 100) / 4000;
                    LevelPercentage = Math.Abs(100 - LevelPercentage);

                    if (NotifyDataChanged != null)
                    {
                        NotifyDataChanged?.Invoke();
                    }

                    // sleep 1s
                    Thread.Sleep(1000);
                }
            });

            LDRRoutine.Start();
        }

        public event Func<Task> NotifyDataChanged;
    }
}
