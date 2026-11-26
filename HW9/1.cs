using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9
{
    //Создать интерфейс ICipher, который определяет методы поддержки шифрования строк. В интерфейсе объявляются два метода encode()
    //и decode(), которые используются для шифрования и дешифрования строк, соответственно. Создать класс ACipher, реализующий интерфейс ICipher.
    //Класс шифрует строку посредством сдвига каждого символа на одну «алфавитную» позицию выше. Например, в результате такого сдвига буква А становится буквой Б.
    //Создать класс BCipher, реализующий интерфейс
    //ICipher.Класс шифрует строку, выполняя замену каждой буквы, стоящей в алфавите на i-й позиции, на букву того же регистра, расположенную в алфавите на i - й позиции с конца
    //алфавита. Например, буква В заменяется на букву Э. Написать программу, демонстрирующую функционирование классов.

    interface ICipher
    {
        string encode(string text);
        string decode(string text);
    }

    class ACipher : ICipher
    {
        private string upperRu = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        private string lowerRu = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        private string upperEn = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private string lowerEn = "abcdefghijklmnopqrstuvwxyz";

        public string encode(string text)
        {
            string result = "";

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

                if (upperRu.Contains(c))
                {
                    int index = (upperRu.IndexOf(c) + 1) % upperRu.Length;
                    result += upperRu[index];
                }
                else if (lowerRu.Contains(c))
                {
                    int index = (lowerRu.IndexOf(c) + 1) % lowerRu.Length;
                    result += lowerRu[index];
                }
                else if (upperEn.Contains(c))
                {
                    int index = (upperEn.IndexOf(c) + 1) % upperEn.Length;
                    result += upperEn[index];
                }
                else if (lowerEn.Contains(c))
                {
                    int index = (lowerEn.IndexOf(c) + 1) % lowerEn.Length;
                    result += lowerEn[index];
                }
                else
                {
                    result += c;
                }
            }

            return result;
        }

        public string decode(string text)
        {
            string result = "";

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

                if (upperRu.Contains(c))
                {
                    int index = (upperRu.IndexOf(c) - 1 + upperRu.Length) % upperRu.Length;
                    result += upperRu[index];
                }
                else if (lowerRu.Contains(c))
                {
                    int index = (lowerRu.IndexOf(c) - 1 + lowerRu.Length) % lowerRu.Length;
                    result += lowerRu[index];
                }
                else if (upperEn.Contains(c))
                {
                    int index = (upperEn.IndexOf(c) - 1 + upperEn.Length) % upperEn.Length;
                    result += upperEn[index];
                }
                else if (lowerEn.Contains(c))
                {
                    int index = (lowerEn.IndexOf(c) - 1 + lowerEn.Length) % lowerEn.Length;
                    result += lowerEn[index];
                }
                else
                {
                    result += c;
                }
            }

            return result;
        }
    }

    class BCipher : ICipher
    {
        private string upperRu = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        private string lowerRu = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        private string upperEn = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private string lowerEn = "abcdefghijklmnopqrstuvwxyz";

        public string encode(string text)
        {
            string result = "";

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

                if (upperRu.Contains(c))
                {
                    int index = upperRu.Length - 1 - upperRu.IndexOf(c);
                    result += upperRu[index];
                }
                else if (lowerRu.Contains(c))
                {
                    int index = lowerRu.Length - 1 - lowerRu.IndexOf(c);
                    result += lowerRu[index];
                }
                else if (upperEn.Contains(c))
                {
                    int index = upperEn.Length - 1 - upperEn.IndexOf(c);
                    result += upperEn[index];
                }
                else if (lowerEn.Contains(c))
                {
                    int index = lowerEn.Length - 1 - lowerEn.IndexOf(c);
                    result += lowerEn[index];
                }
                else
                {
                    result += c;
                }
            }

            return result;
        }

        public string decode(string text)
        {
            return encode(text);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string message = "Привет, Мир!";

            ICipher aCipher = new ACipher();
            string encodedA = aCipher.encode(message);
            string decodedA = aCipher.decode(encodedA);

            Console.WriteLine("Исходная строка: " + message);
            Console.WriteLine("ACipher шифрование: " + encodedA);
            Console.WriteLine("ACipher дешифрование: " + decodedA);

            Console.WriteLine();

            ICipher bCipher = new BCipher();
            string encodedB = bCipher.encode(message);
            string decodedB = bCipher.decode(encodedB);

            Console.WriteLine("BCipher шифрование: " + encodedB);
            Console.WriteLine("BCipher дешифрование: " + decodedB);
        }
    }
}
