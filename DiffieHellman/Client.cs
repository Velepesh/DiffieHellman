using System;
using System.Numerics;

namespace DiffieHellman
{
    class Client
    {
        private DiffieHellman _diffieHellman = new DiffieHellman();
        private int _generator;
        private int _primemodulus;
        private string _message;

        public Client(string name, int generator, int primemodulus, string message = "")
        {
            Name = name;
            _generator = generator;
            _primemodulus  = primemodulus;
            _message = message;
            Prime = _diffieHellman.PrimeNumber;
            Secret = _diffieHellman.GetKey(_generator, _primemodulus, Prime);
        }

        public string Name { get; private set; }
        public int Prime { get; private set; }
        public BigInteger Secret { get; private set; }

        public BigInteger GetKey(BigInteger secret, int prime)
        {
            BigInteger g = BigInteger.Pow(secret, prime);
            BigInteger Chave = g % _primemodulus;

            return Chave;
        }

        public string SendMessage(BigInteger key)
        {
            string encryptedMessage = _diffieHellman.EncryptMessage(_message, key);

            return encryptedMessage;
        }

        public string GetMessage(string message, BigInteger key)
        {
            string decryptedMessage = _diffieHellman.DecryptMessage(message, key);

            return decryptedMessage;
        }
    }
}
