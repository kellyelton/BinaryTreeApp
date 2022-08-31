using System;
using System.Diagnostics;
using System.Linq;

namespace BinaryTreeApp
{
    internal static class Program
    {
        public static void Main(string[] args) {
            var ints = new int[] { 4, 7, 8, 6, 3 };//ReadInts();

            var xandy = new int[2] { 3, 7 };// ReadInts(2);

            var xValue = xandy[0];
            var yValue = xandy[1];

            var tree = new BinaryTree(ints);

            var xNode = tree.Find(xValue);
            var yNode = tree.Find(yValue);

            Debug.Assert(xNode != null, "xNode is null");
            Debug.Assert(yNode != null, "yNode is null");

            var between = tree.BetweenInclusive(xNode, yNode);

            Debug.Assert(between != null, "between is null");

            var maxValueBetween = between.Max(node => node.Value);

            if(maxValueBetween == 7) {
                Console.WriteLine("Right");
            } else {
                Console.WriteLine("Wrong");
            }

            Console.WriteLine(maxValueBetween);

            Console.ReadKey();
        }

        static int ReadInt() {
            var line = Console.ReadLine();

            var i = int.Parse(line);

            return i;
        }

        static int[] ReadInts() {
            var line = Console.ReadLine();

            var parts = line.Split(new char[1] { ' ' });

            return parts.Select(p => int.Parse(p)).ToArray();
        }

        static int[] ReadInts(int count) {
            var line = Console.ReadLine();

            var parts = line.Split(new char[1] { ' ' }, count);

            return parts.Select(p => int.Parse(p)).ToArray();
        }
    }
}
