using System;

namespace Largest_Number_After_Digit_Swaps_by_Parity
{
  class Program
  {
    static void Main(string[] args)
    {
      var num = 8712954;
      Solution s = new Solution();
      var answer = s.LargestInteger(num);
      Console.WriteLine(answer);
    }


    // https://leetcode.com/problems/largest-number-after-digit-swaps-by-parity/
    public int LargestInteger(int num)
    {
      // for each no will do below steps -
      // we have to search for the bigger even no OR bigger odd no, to right side if current is even or odd.
      // if found swap them
      // move to the next no
      var array = num.ToString().ToCharArray();
      for (int i = 0; i < array.Length; i++)
      {
        for (int j = i + 1; j < array.Length; j++)
        {
          if (array[j] > array[i] && (array[j] - array[i]) % 2 == 0)
          {
            char current = array[j];
            array[j] = array[i];
            array[i] = current;
          }
        }
      }

      string str = new string(array);
      return Convert.ToInt32(str);
    }
  }

  public class Solution
  {
    public int LargestInteger(int num)
    {
      var numArray = num.ToString().ToCharArray();
      for (int i = 0; i < numArray.Length; i++)
      {
        char c = numArray[i];
        int no = Convert.ToInt32(c);
        bool isEven = no % 2 == 0;
        if (isEven)
        {
          var (n, pos) = BiggestOddOrEven(isEven, i + 1, numArray);
          if (n > no)
          {
            numArray[i] = Convert.ToChar(n);
            numArray[pos] = c;
          }
        }
        else
        {
          var (m, posm) = BiggestOddOrEven(isEven, i + 1, numArray);
          if (m > no)
          {
            numArray[i] = Convert.ToChar(m);
            numArray[posm] = c;
          }
        }
      }
      string str = string.Join("", numArray);
      return Convert.ToInt32(str);
    }
    private (int, int) BiggestOddOrEven(bool isEven, int startIndex, char[] noArray)
    {
      int maxOdd = 0;
      int maxOddPosition = startIndex;
      int maxEven = 0;
      int maxEvenPosition = startIndex;
      for (int i = startIndex; i < noArray.Length; i++)
      {
        char c = noArray[i];
        int no = Convert.ToInt32(c);
        bool isOdd = no % 2 != 0;
        if (isOdd)
        {
          if (no > maxOdd)
          {
            maxOdd = no;
            maxOddPosition = i;
          }
        }
        else
        {
          if (no > maxEven)
          {
            maxEven = no;
            maxEvenPosition = i;
          }
        }
      }

      return isEven ? (maxEven, maxEvenPosition) : (maxOdd, maxOddPosition);
    }
  }
}
