using System;
using System.Numerics;

namespace DiffieHellman
{
    class Program
    {
        static void Main(string[] args)
        {
            TextReader textReader = new TextReader();
            RabinMiller rabinMiller = new RabinMiller();

            string message = textReader.ReadText();

            int generator = rabinMiller.GetPrimeNumber();
            int primemodulus = rabinMiller.GetPrimeNumber();

            Client alice = new Client("Alice", generator, primemodulus, message);
            Client bob = new Client("Bob", generator, primemodulus);

            BigInteger keyAlice = alice.GetKey(alice.Secret, bob.Prime);
            BigInteger keyBob = bob.GetKey(bob.Secret, alice.Prime);

            Console.WriteLine($"Key {alice.Name}: {keyAlice}\nKey {bob.Name}: {keyBob}");

            string encrypteMessage = alice.SendMessage(keyAlice);

            textReader.WriteEncodeText(encrypteMessage);

            string decryptedMessage = bob.GetMessage(encrypteMessage, keyBob);

            textReader.WriteDecodeText(decryptedMessage);
        }
    }
}