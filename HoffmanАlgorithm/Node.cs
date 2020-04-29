using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryHoffmanАlgorithm
{
    public class Node: IComparable
    {
        public char Letter { get; set; }
        public int Weight { get; set; }

        public Node LeftNode;
        public Node RightNode;


        public Node()
        {
            LeftNode = null;
            RightNode = null;
        }

        public Node(char letter, int weight)
        {
            this.Letter = letter;
            this.Weight = weight;
        }

        public Node(Node left, Node right)
        {
            this.LeftNode = left;
            this.RightNode = right;
            this.Weight = left.Weight + right.Weight;
        }

        public int CompareTo(object obj)
        {
            Node temp = obj as Node;

            if(temp != null)
            {
                if(this.Weight > temp.Weight)
                {
                    return 1;
                }
                if (this.Weight < temp.Weight)
                {
                    return -1;
                }else
                {
                    return 0;
                }
            }
            else
            {
                throw new ArgumentException("Parameter is not a Node");
            }
        }



        public Dictionary<char, string> FormTableLetterKey()
        {
            Dictionary<char, string> keyValuePairs = new Dictionary<char, string>();
            List<char> vectorByte = new List<char>();
            SetCode(keyValuePairs, vectorByte);

            return keyValuePairs;
        }

        private void SetCode(Dictionary<char, string> keyValuePairs, List<char> vectorByte)
        {

            if(this.LeftNode!= null)
            {
                vectorByte.Add('0');
                this.LeftNode.SetCode(keyValuePairs, vectorByte);
            }
            if (this.RightNode != null)
            {
                vectorByte.Add('1');
                this.RightNode.SetCode(keyValuePairs, vectorByte);
            }

            if(this.LeftNode == null && this.RightNode == null)
            {
                keyValuePairs.Add(this.Letter, new string(vectorByte.ToArray()));
            }

            if (vectorByte.Count != 0)
            {
                vectorByte.RemoveAt(vectorByte.Count - 1);
            }
        }

        public Node GetNode(int index)
        {
            if(index == 0 && this.LeftNode != null)
            {
                return this.LeftNode;
            }

            if (index == 1 && this.RightNode != null)
            {
                return this.RightNode;
            }

            return this;
        }

    }
}
