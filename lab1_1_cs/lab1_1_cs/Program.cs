using System;
using System.Linq;
using System.Text;
using System.IO;

namespace lab1_1_cs
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = File.ReadAllText("D:\\labs_sys_prog\\lab1_cs\\text2.txt", Encoding.GetEncoding(1251));
            var bits = string.Empty;
            foreach (var character in s)
            {
                bits += Convert.ToString(character, 2).PadLeft(8, '0');
            }

            string base64 = string.Empty;

            const byte threeOctets = 24;
            var octetsTaken = 0;
            while (octetsTaken < bits.Length)
            {
                var currentOctects = bits.Skip(octetsTaken).Take(threeOctets).ToList();

                const byte sixBits = 6;
                int hextetsTaken = 0;
                while (hextetsTaken < currentOctects.Count())
                {
                    var chunk = currentOctects.Skip(hextetsTaken).Take(sixBits);
                    hextetsTaken += sixBits;

                    var bitString = chunk.Aggregate(string.Empty, (current, currentBit) => current + currentBit);

                    if (bitString.Length < 6)
                    {
                        bitString = bitString.PadRight(6, '0');
                    }
                    var singleInt = Convert.ToInt32(bitString, 2);

                    base64 += Base64Letters[singleInt];
                }

                octetsTaken += threeOctets;
            }

            // Pad with = for however many octects we have left
            for (var i = 0; i < (bits.Length % 3); i++)
            {
                base64 += "=";
            }
            string writePath = @"D:\\labs_sys_prog\\lab1_cs\\text5.txt";
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(base64);
            }
            Console.WriteLine(base64);
            //return base64;
            //var Bytes = System.Text.Encoding.UTF8.GetBytes("D:\\labs_sys_prog\\lab1_cs\\text.txt");
            //be.EncodeFromFile(@"src/galera.txt", @"src/result.txt", Resources.StandardBase64Alphabet);
            //Console.WriteLine(be.CheckCorrect(@"src/galera.txt", @"src/result.txt"));

            ////Console.WriteLine(Base64Encode(s));
        }
        public static string Base64Encode(string s)
        {
            s = File.ReadAllText("D:\\labs_sys_prog\\lab1_cs\\text2.txt", Encoding.GetEncoding(1251));
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(s);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        private static readonly char[] Base64Letters = new[]
        {  'A','B','C','D','E','F','G','H','I','J','K','L','M',
            'N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
            'a','b','c','d','e','f','g','h','i','j','k','l','m',
            'n','o','p','q','r','s','t','u','v','w','x','y','z',
            '0','1','2','3','4','5','6','7','8','9','+','/'};
    }
}
