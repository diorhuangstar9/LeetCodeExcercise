using System;

namespace LeetCodeExcercise
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            var words = new string[] { "cd", "f", "kl" };
            StreamChecker streamChecker = new StreamChecker(words); // init the dictionary.
            Console.WriteLine(streamChecker.Query('a'));          // return false
            Console.WriteLine(streamChecker.Query('b'));          // return false
            Console.WriteLine(streamChecker.Query('c'));          // return false
            Console.WriteLine(streamChecker.Query('d'));          // return true, because 'cd' is in the wordlist
            Console.WriteLine(streamChecker.Query('e'));          // return false
            Console.WriteLine(streamChecker.Query('f'));          // return true, because 'f' is in the wordlist
            Console.WriteLine(streamChecker.Query('g'));          // return false
            Console.WriteLine(streamChecker.Query('h'));          // return false
            Console.WriteLine(streamChecker.Query('i'));          // return false
            Console.WriteLine(streamChecker.Query('j'));          // return false
            Console.WriteLine(streamChecker.Query('k'));          // return false
            Console.WriteLine(streamChecker.Query('l'));          // return true, because 'kl' is in the wordlist

        }
    }
}
