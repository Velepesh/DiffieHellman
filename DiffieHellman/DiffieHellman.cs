using System.Numerics;
using System;

namespace DiffieHellman
{
    class DiffieHellman
    {
        private RabinMiller _rabinMiller = new RabinMiller();

        public DiffieHellman()
        {
            PrimeNumber = _rabinMiller.GetPrimeNumber();
        }

        public int PrimeNumber { get; private set; }

        public BigInteger GetKey(int g, int p, int a)
        {
            return BigInteger.Pow(g, a) % p;
        }

        public string EncryptMessage(string message, BigInteger key)
        {
            string encryptedMessage = "";

            foreach (var item in message)
                encryptedMessage += (Convert.ToInt32(item) + key) + "\n";

            return encryptedMessage;
        }

        public string DecryptMessage(string message, BigInteger key)
        {
            string decryptedMessage = "";

            string[] words = message.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string item in words)
            {
                int cod = (int)(Convert.ToInt32(item) - key);

                decryptedMessage += Convert.ToChar(cod);
            }

            return decryptedMessage;
        }
    }
}
