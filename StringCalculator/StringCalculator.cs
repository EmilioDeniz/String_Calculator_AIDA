using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator {

    public static class Program
    {
        public static void Main(string[] args) { }
    }

    public static class StringCalculatorClass {

        public static int add(string argsGiven){
            if (string.IsNullOrEmpty(argsGiven)) { return 0; }
            IEnumerable<int> numbers = TransformInput(argsGiven);
            CheckNegativeNumbers(numbers);
            return numbers.Where(number => number <= 1000).Sum();
        }

        private static IEnumerable<int> TransformInput(string argsGiven){

            var delimiter = ",";

            if (argsGiven.Contains("//")){
                delimiter = argsGiven[2].ToString();
                argsGiven = argsGiven.Remove(0, 3);
            }

            argsGiven = argsGiven.Replace("\n", delimiter);
            var nums = argsGiven.Split(delimiter).Select(int.Parse);

            Console.WriteLine(nums);
            return nums;
        }

        private static void CheckNegativeNumbers(IEnumerable<int> numbers) {
            var negatives = numbers.Where(number => number < 0);
            if (negatives.Count() > 0) {
                throw new Exception("Negatives not allowed: " + string.Join(" ", negatives));
            }
        }
    }
} 
