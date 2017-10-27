using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Remote_Healtcare_Console.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserData;

namespace Remote_Healtcare_Console
{
    class BikeSimulator : Kettler 
    {

        private Thread BikeThread;
        private ISet<BikeData> data;
        private int count;
        private Astrand FormAstrand;
        BikeData latestData;

        public BikeSimulator(Console console) : base(console) {
            this.console = console;
            data = console.data;
            count = 0;
            BikeThread = new Thread(Update);
            FormAstrand = new Astrand();
            FormAstrand.Closed += (s, args) => FormAstrand.Close();
            FormAstrand.Show();
        }

        public override void Reset() {
            throw new NotImplementedException();
        }

        public override void SetResistance(int power) {
            throw new NotImplementedException();
        }

        public override void SetTime(int mm, int ss) {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            while (count != data.Count)
            {
                // Running on the UI thread
                FormAstrand.setAll(
                    ((data.ElementAt(count).Time < TimeSpan.Zero) ? "-" : "") + data.ElementAt(count).Time.ToString(@"mm\:ss"),
                    (data.ElementAt(count).Speed),
                    (data.ElementAt(count).Resistance),
                    (data.ElementAt(count).Energy),
                    (data.ElementAt(count).Power),
                    (data.ElementAt(count).Pulse),
                    (data.ElementAt(count).Rpm));

                RpmCheck(data.ElementAt(count).Rpm);
                
                count++;
                System.Threading.Thread.Sleep(1000);
            }
        }

        private void RpmCheck(int rpm)
        {
            if (rpm <= 50)
            {
                //go faster
                FormAstrand.resistanceUp();
            }
            else if (rpm >= 60)
            {
                //go slower
                FormAstrand.resistanceDown();
            }
            else
            {
                //ga zo door
                FormAstrand.resistenceGood();
            }
        }

        public override void SetDistance(int distance)
        {
            throw new NotImplementedException();
        }

        public override void Start()
        {
            BikeThread.Start();
        }

        public override void Stop()
        {
            BikeThread.Abort();
        }

        public override void SetManual()
        {
            throw new NotImplementedException();
        }
    }
}
