using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{
    public static int pickingNumbers(List<int> a)
    {
        var freq = new Dictionary<int, int>();
        foreach (int num in a)
        {
            if (freq.ContainsKey(num))
            {
                freq[num]++;
            }
            else
            {
                freq[num] = 1;
            }
        }

        int maxLength = 0;
        foreach (int key in freq.Keys)
        {
            int length = freq[key];
            if (freq.ContainsKey(key + 1)) // sprawdza czy istnieją wartości o 1 większe od klucza 
            {
                length += freq[key + 1]; // wtedy ten klucz dodaje do długości 
            }
            if (length > maxLength) // sprawdza czy bierząca długść tabeli jest większa 
            {
                maxLength = length;
            }
        }

        return maxLength;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

        int result = Result.pickingNumbers(a);

        Console.WriteLine(result);
    }
}
