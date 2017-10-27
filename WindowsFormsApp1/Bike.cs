using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Remote_Healtcare_Console.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using UserData;

namespace Remote_Healtcare_Console
{
    class Bike : Kettler {
        private bool start;
        private SerialCommunicator serialCommunicator;
        private Client client;
        private Thread BikeThread;
        private Thread ChangesThread;
        private string hashcode;
        private bool autoCalculateResistance;
        private bool autoCalculateResistanceNotExactly;
        private List<int> heartrates;
        private User user;
        private double factor;
        private int hartfrequentie;
        private int Resistance = 25;
        private bool Busy = true;
        private bool startTest = false;
        private bool AstrandWFAisNotActive = false;
        Astrand FormAstrand;
        private int timeTestDone = 6;
        private bool startStandby;
        private bool pauze;
        private bool testReady;
        BikeData latestData;

        public Bike(string port, User user, Console console, ref Client client) : base(console) {
            this.client = client;
            this.user = user;
            start = false;
            serialCommunicator = new SerialCommunicator(port);
            BikeThread = new Thread(InitBike);
            ChangesThread = new Thread(changes);
            //Astrand Form1 = new Astrand();
            FormAstrand = new Astrand();
            FormAstrand.Closed += (s, args) => FormAstrand.Close();
            FormAstrand.Show();
        }

        private void changes()
        {
            while (serialCommunicator.IsConnected() && start)
            {
                SetChanges();
                Thread.Sleep(500);
            }
        }

        private void SetChanges()
        {
            JObject obj = client.ReadMessage();

            switch ((string)obj["id"])
            {
                case ("setResistance"):
                    int resistance = (int)obj["data"]["resistance"];
                    SetResistance(resistance);
                    break;
                case ("chat"):
                    string message = (string)obj["data"]["message"];
                    AstrandWFAisNotActive = (bool)obj["data"]["message"];
                    new Thread(() => console.AddMessage(message)).Start();
                    break;
                case "setdoctor":
                    client.SendMessage(obj);
                    break;
                case ("start"):
                    BikeThread.Start();
                    break;
                case ("stop"):
                    BikeThread.Abort();
                    break;
                case ("startTest"):
                    AstrandWFAisNotActive = (bool)obj["data"]["message"];
                    startTest = (bool)obj["data"]["message"];
                    break;
            }

        }

        public override void Start() {
            start = true;
            serialCommunicator.OpenConnection();
            ChangesThread.Start();
        }

        private void AstradAvans()
        {
            if (Busy)
            {
                //BikeData latestData = RecordedData.Last();
                //int Pulse = latestData.Pulse;
                int Pulse = 120; // aanpassen via GUI !!!!!!!
                if (Pulse > hartfrequentie)
                    Busy = false;
                if (latestData.Time.Minutes < 2)
                {

                    FormAstrand.SetFaseText("Opwarming");

                    if (Resistance == 60)
                        RpmCheck(latestData.Rpm);
                    else
                    {
                        Resistance = 60;
                        SetResistance(Resistance);
                    }
                }
                else if (latestData.Time.Minutes < timeTestDone)
                {
                    int PulseCheck;
                    int minutes = latestData.Time.Minutes;
                    int seconds = latestData.Time.Seconds;
                    if (testReady)
                    {
                        PulseCheck = 59;
                        FormAstrand.SetFaseText("BeginTest");
                        if (seconds % 10 == 0 && Pulse < 140 && Resistance < 180 && pauze)
                        {
                            pauze = false;
                            SetResistance(Resistance += 15);
                        }
                        if (seconds % 10 == 1)
                            pauze = true;
                        if (Pulse < 140)
                            testReady = true;
                    }
                    else {
                        PulseCheck = 15;
                    if (Pulse < 130)
                        {
                        PulseCheck = 0;
                        timeTestDone += 2;
                        }
                    }
                       
                    RpmCheck(latestData.Rpm);
                    if (seconds % PulseCheck == 0)
                    {
                        heartrates.Add(latestData.Pulse);
                    }
                    
                    
                }
                else
                {
                    FormAstrand.SetFaseText("Cooling down");
                    AverageHeartBeatRate();
                    CalculateVO2MAX();
                    SetResistance(25);
                    // cool down
                    Busy = false;
                }
            }
        }

        private void RpmCheck(int rpm) {
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
        public override void Stop() {
            start = false;
            serialCommunicator.CloseConnection();
        }

        private void InitBike() {
            Thread.Sleep(500);
            Reset();
            Thread.Sleep(500);
            SetManual();
            Thread.Sleep(500);
            Run();
        }

        private void Run() {
            while (serialCommunicator.IsConnected() && start) {
                Update();
                //SetResistance((int)console.connectForm.connector.CalculateIncline("bike"));
                //Thread.Sleep(500);
            }
        }

        public override void Reset() {
            serialCommunicator.SendMessage("RS");
            RecordedData.Clear();
        }

        public override void SetManual() {
            serialCommunicator.SendMessage("CM");
            if (serialCommunicator.ReadInput() != "RUN") {
                Thread.Sleep(500);
                serialCommunicator.ReadInput();
            }
        }

        public override void SetResistance(int resistance) {
            int trueResistance;
            if (resistance > 400) {
                trueResistance = 400;
            }
            else if (resistance < 25) {
                trueResistance = 25;
            }
            else {
                trueResistance = resistance;
            }
            serialCommunicator.SendMessage("PW " + trueResistance);
        }

        public override void SetTime(int mm, int ss) {
            string time = (mm.ToString() + ss.ToString());
            serialCommunicator.SendMessage("PT " + time);
            serialCommunicator.ReadInput();
        }

        public override void SetDistance(int distance) {
            int trueDistance;
            if (distance > 999) {
                trueDistance = 999;
            }
            else if (distance < 0) {
                trueDistance = 0;
            }
            else {
                trueDistance = distance;
            }
            serialCommunicator.SendMessage("PD " + trueDistance);
            serialCommunicator.ReadInput();
        }

        public override void Update() {
            serialCommunicator.SendMessage("ST");
            string data = serialCommunicator.ReadInput();
            data = data.Replace("\r", "");
            string[] dataSplitted = data.Split('\t');

            BikeData bikeData = new BikeData(
                int.Parse(dataSplitted[0]), int.Parse(dataSplitted[1]),
                dataSplitted[2],
                int.Parse(dataSplitted[3]), int.Parse(dataSplitted[4]), int.Parse(dataSplitted[5]),
                dataSplitted[6],
                int.Parse(dataSplitted[7]));

            if (RecordedData.Count == 0) {
                RecordedData.Add(bikeData);
            }
            else if (RecordedData.Last().Time != bikeData.Time) {
                RecordedData.Add(bikeData);
            }

            latestData = RecordedData.Last();
            FormAstrand.setAll(latestData.Time.ToString(), latestData.Speed, latestData.Resistance, latestData.Energy, latestData.Power, latestData.Pulse, latestData.Rpm);
            RpmCheck(latestData.Rpm);

            AstradAvans();
            
            client.SendMessage(new
            {
                id = "update",
                data = new
                {
                    bikeData = bikeData
                }
            });

            SetDataToGUI();
        }

        public int AverageHeartBeatRate()
        {
            return (int)heartrates.Average();
        }

        public void CalculateVO2MAX()
        {
            double VO2MAX = 0;
            if(user.Man)
            {
                VO2MAX = (174.2 * Resistance + 4020) / (103.2 * AverageHeartBeatRate() - 6299);
                VO2MAX *= factor;
            }
            else
            {
                VO2MAX = (163.8 * Resistance + 3780) / (104.4 * AverageHeartBeatRate() - 7514);
                VO2MAX *= factor;
            }
        }

        public double CorrectieFactorLeeftijd(int leeftijd)
        {
            double factor;

            if (leeftijd <= 15)
                factor = 1.10;
            else if (leeftijd <= 25)
                factor = 1;
            else if (leeftijd <= 35)
                factor = 0.87;
            else if (leeftijd <= 40)
                factor = 0.83;
            else if (leeftijd <= 45)
                factor = 0.87;
            else if (leeftijd <= 50)
                factor = 0.75;
            else if (leeftijd <= 55)
                factor = 0.71;
            else if (leeftijd <= 60)
                factor = 0.68;
            else if (leeftijd <= 65)
                factor = 0.65;
            else
                factor = 0.65;

            return factor;
        }

        public double CorrectieFactorHartfrequentie()
        {
            double factor;

            if (hartfrequentie >= 210)
                factor = 1.12;
            else if (hartfrequentie >= 200)
                factor = 1;
            else if (hartfrequentie >= 190)
                factor = 0.93;
            else if (hartfrequentie >= 180)
                factor = 0.83;
            else if (hartfrequentie >= 170)
                factor = 0.75;
            else if (hartfrequentie >= 160)
                factor = 0.69;
            else if (hartfrequentie >= 150)
                factor = 0.64;
            else
                factor = 0.64;

            return factor;
        }
    }
}
