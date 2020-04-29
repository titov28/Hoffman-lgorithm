using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryHoffmanАlgorithm
{
    public class HoffmanAlgorithm
    {
        int encodedStringLenght = 0;

        private Dictionary<char, string> tabelLetterCode;

        private Node parentNode;

        public HoffmanAlgorithm()
        {

            tabelLetterCode = null;
            parentNode = null;
        }

        #region Coding

        public string Coding(string inputStr)
        {
            string tempStr = string.Empty;

            Dictionary<char, int> dict = FormPairsLetterWeight(inputStr);

            FormParentNode(dict);

            FormTableLetterCode();

            tempStr = CodingString(inputStr);

            return tempStr;
        }


        private Dictionary<char, int> FormPairsLetterWeight(string inputStr)
        {
            char[] letters = inputStr.ToArray();
            Dictionary<char, int> dict = new Dictionary<char, int>();

            for(int i = 0; i < letters.Length; i++)
            {
                if (!dict.ContainsKey(letters[i]))
                {
                    dict.Add(letters[i], 1);
                }
                else
                {
                    dict[letters[i]]++;
                }
            }

            //Console.WriteLine(dict);

            return dict;

        }

        private void FormParentNode(Dictionary<char, int> pairsLetterWeight)
        {
            List<Node> listNode = new List<Node>();

            char tempKey;
            int tempValue;

            foreach(KeyValuePair<char, int> key in pairsLetterWeight)
            {
                tempKey = key.Key;
                tempValue = key.Value;

                Node temp = new Node(tempKey, tempValue);

                listNode.Add(temp);
            }

            Node tempLeftNode;
            Node tempRightNode;

            while (listNode.Count != 1)
            {
                listNode.Sort();

                tempLeftNode = listNode.ElementAt(0);
                listNode.RemoveAt(0);

                tempRightNode = listNode.ElementAt(0);
                listNode.RemoveAt(0);

                Node tempNode = new Node(tempLeftNode, tempRightNode);

                listNode.Add(tempNode);

            }

            parentNode = listNode.ElementAt(0);

        }

        private void FormTableLetterCode()
        {
            if(parentNode != null)
            {
                tabelLetterCode = parentNode.FormTableLetterKey();
            }
        }

        private string CodingString(string inputStr)
        {
            string tempStr = string.Empty;
            char[] letters = inputStr.ToArray();

            if (tabelLetterCode != null)
            {

                for (int i = 0; i < letters.Length; i++)
                {
                    tempStr += tabelLetterCode[letters[i]];
                }
            }

            letters = tempStr.ToArray();
            tempStr = string.Empty;

            encodedStringLenght = letters.Length;

            int count = 0;
            int letter = 0;
            for(int i = 0; i < letters.Length; i++, count++)
            {
                if (letters[i] == '1')
                {
                    letter = letter | (1 << 15 - count);
                }

                if (count == 15 || i == letters.Length - 1)
                {
                    count = -1;
                    tempStr += Convert.ToChar((ushort)letter);
                    letter = 0;
                }
            }

            return tempStr;
        }

        #endregion

        #region Decoding
        public string Decoding(string str)
        {
            string tempstr = string.Empty;
            tempstr = DecodingString(str);

            char[] letters = tempstr.ToArray();
            tempstr = string.Empty;

            if(parentNode != null)
            {

                Node tempNode = parentNode;
                for (int i = 0; i < encodedStringLenght; i++)
                {
                    tempNode = tempNode.GetNode(Convert.ToInt32(letters[i].ToString()));

                    if(tempNode.LeftNode == null && tempNode.RightNode == null)
                    {
                        tempstr += tempNode.Letter;
                        tempNode = parentNode;
                    }

                }
            }

            return tempstr;
        }


        private string DecodingString(string str)
        {
            string tempStr = string.Empty;

            char[] letters = str.ToArray();

            for(int i = 0; i < letters.Length; i++)
            {
                for(int j = 0; j < 16; j++)
                {
                    //int let = (letters[i] >> 15 - j) & 1;
                    tempStr += (letters[i] >> 15 - j) & 1;
                }
            }

            return tempStr;
        }
        #endregion
    }
}
