using System;
using System.IO;
using LibraryHoffmanАlgorithm;

namespace main
{
    class Program
    {
        static void Main(string[] args)
        {
            //string str1 = "abra cadabra";
            //HoffmanAlgorithm ha1 = new HoffmanAlgorithm();

            //string codingstr = ha1.Coding(str1);
            //Console.WriteLine($"Encoded text: {codingstr}");

            //string decodeStr = ha1.Decoding(codingstr);

            //Console.WriteLine($"Decoded text: {decodeStr}");



            //В кореневой папке проекта лежат два текстовыйх файла для проверки textEn.txt и textRu.txt
            //Чтобы закодировать текст нужно создать объект HoffmanAlgorithm и вызвать метод Coding 
            // и передать ему строку с текстом. Для декодирования вызывается метод Decoding, в который
            //передается закодированный текст.
            //Для работы нужно указать ваш каталог с проектом в переменной path.



            string path = @"E:\Users\Documents\Visual Studio 2017\repos\C#\Защита информации\Solution_HoffmanАlgorithm\";
            string str = string.Empty;

            using (StreamReader sr = new StreamReader(path + "textEn.txt"))
            {
                str = sr.ReadToEnd();
            }

            HoffmanAlgorithm ha = new HoffmanAlgorithm();

            string codeStr = ha.Coding(str);

            Console.WriteLine($"Encoded text: {codeStr}");


            using (StreamWriter sw = new StreamWriter(path + "encodedTextEn.txt", false, System.Text.Encoding.Default))
            {
                sw.Write(codeStr);
            }


            string decodeStr = ha.Decoding(codeStr);

            Console.WriteLine($"Decoded text: {decodeStr}");

            Console.ReadLine();
        }
    }
}
