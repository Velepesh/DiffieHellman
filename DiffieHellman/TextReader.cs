using System;
using System.IO;

namespace DiffieHellman
{
    class TextReader
    {
        readonly private string _inputPath = @"..\..\..\Input.txt";
        readonly private string _encodePath = @"..\..\..\Encode.txt";
        readonly private string _decodePath = @"..\..\..\Decode.txt";

        public string ReadText()
        {
            string text = "";

            try
            {
                using (StreamReader streamReader = new StreamReader(_inputPath))
                {
                    text = streamReader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return text;
        }

        public void WriteEncodeText(string text)
        {
            WriteText(_encodePath, text);
        }

        public void WriteDecodeText(string text)
        {
            WriteText(_decodePath, text);
        }

        private void WriteText(string path, string text)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(text);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
