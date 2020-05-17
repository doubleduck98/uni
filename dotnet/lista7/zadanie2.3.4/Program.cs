using System;
using System.Threading;

namespace zadanie2._3._4
{
    internal class Program
    {
        private static Semaphore _tyton;
        private static Semaphore _papier;
        private static Semaphore _zapalki;
        private static Semaphore _koniecPalenia;
        private static Semaphore _palaczTyton;
        private static Semaphore _palaczPapier;
        private static Semaphore _palaczZapalki;
        private static Mutex _mutex;
        private static bool _papierDostepny;
        private static bool _tytonDostepny;
        private static bool _zapalkiDostepne;

        private static void Agent()
        {
            var rand = new Random();
            while (true)
            {
                _koniecPalenia.WaitOne();
                var wybor = rand.Next(1, 4) % 3;
                // dajemy papier i tytoń
                if (wybor == 0)
                {
                    _tyton.Release(1);
                    _papier.Release(1);
                }
                // dajemy papier i zapałki
                else if (wybor == 1)
                {
                    _zapalki.Release(1);
                    _papier.Release(1);
                }
                // dajemy zapałki i tytoń
                else
                {
                    _zapalki.Release(1);
                    _tyton.Release(1);
                }
            }
        }

        private static void PalaczZZapalkami()
        {
            while (true)
            {
                _palaczZapalki.WaitOne();
                Zapal("Palacz z zapałkami");
                _koniecPalenia.Release(1);
            }
        }

        private static void PodawaczZap()
        {
            while (true)
            {
                _zapalki.WaitOne();
                _mutex.WaitOne();
                if (_papierDostepny)
                {
                    _papierDostepny = false;
                    _palaczTyton.Release(1);
                }
                else if (_tytonDostepny)
                {
                    _tytonDostepny = false;
                    _palaczPapier.Release(1);
                }
                else
                {
                    _zapalkiDostepne = true;
                }

                _mutex.ReleaseMutex();
            }
        }

        private static void PalaczZTytoniem()
        {
            while (true)
            {
                _palaczTyton.WaitOne();
                Zapal("Palacz z tytoniem");
                _koniecPalenia.Release(1);
            }
        }

        private static void PodawaczTyt()
        {
            while (true)
            {
                _tyton.WaitOne();
                _mutex.WaitOne();
                if (_papierDostepny)
                {
                    _papierDostepny = false;
                    _palaczZapalki.Release(1);
                }
                else if (_zapalkiDostepne)
                {
                    _zapalkiDostepne = false;
                    _palaczPapier.Release(1);
                }
                else
                {
                    _tytonDostepny = true;
                }

                _mutex.ReleaseMutex();
            }
        }

        private static void PalaczZPapierem()
        {
            while (true)
            {
                _palaczPapier.WaitOne();
                Zapal("Palacz z papierem");
                _koniecPalenia.Release(1);
            }
        }

        private static void PodawaczPap()
        {
            while (true)
            {
                _papier.WaitOne();
                _mutex.WaitOne();
                if (_tytonDostepny)
                {
                    _tytonDostepny = false;
                    _palaczZapalki.Release(1);
                }
                else if (_zapalkiDostepne)
                {
                    _zapalkiDostepne = false;
                    _palaczTyton.Release(1);
                }
                else
                {
                    _papierDostepny = true;
                }

                _mutex.ReleaseMutex();
            }
        }

        private static void Zapal(string kto)
        {
            Console.WriteLine(kto + " skręca i zapala papierosa.");
            Thread.Sleep(500);
        }

        private static void Init()
        {
            _tyton = new Semaphore(0, 1);
            _palaczTyton = new Semaphore(0, 1);
            _papier = new Semaphore(0, 1);
            _palaczPapier = new Semaphore(0, 1);
            _zapalki = new Semaphore(0, 1);
            _palaczZapalki = new Semaphore(0, 1);
            _koniecPalenia = new Semaphore(1, 1);
            _mutex = new Mutex();
            _papierDostepny = _zapalkiDostepne = _tytonDostepny = false;
        }

        private static void StartAndWait()
        {
            var agent = new Thread(Agent) {IsBackground = true};
            var palaczT = new Thread(PalaczZTytoniem) {IsBackground = true};
            var palaczZ = new Thread(PalaczZZapalkami) {IsBackground = true};
            var palaczP = new Thread(PalaczZPapierem) {IsBackground = true};
            var pusherT = new Thread(PodawaczTyt) {IsBackground = true};
            var pusherZ = new Thread(PodawaczZap) {IsBackground = true};
            var pusherP = new Thread(PodawaczPap) {IsBackground = true};
            palaczT.Start();
            palaczZ.Start();
            palaczP.Start();
            pusherT.Start();
            pusherZ.Start();
            pusherP.Start();
            agent.Start();
            agent.Join();
            palaczT.Join();
            palaczZ.Join();
            palaczP.Join();
            pusherT.Join();
            pusherZ.Join();
            pusherP.Join();
        }
        
        public static void Main(string[] args)
        {
            Init();
            StartAndWait();
        }
    }
}