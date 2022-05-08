using System;
using System.Linq;

namespace Test_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var testDeltaResultCount = int.Parse(Console.ReadLine());
            var deltaResult = Console.ReadLine().Split(' ').Select(it => int.Parse(it)).ToArray();
            int[] subsequence = new int[testDeltaResultCount + 1];
            
            switch (testDeltaResultCount)
            {

                case 1:
                    if (deltaResult[0] > 0)
                    {
                        subsequence[0] = 0;
                        subsequence[1]= deltaResult[0];
                    }
                    else
                    {
                        subsequence[1] = 0;
                        subsequence[0] = -deltaResult[0];
                    }
                    break;
                case 2:
                    if (deltaResult[0] < 0 && deltaResult[1] > 0)
                    {
                        subsequence[1] = 0;
                        subsequence[0] = -deltaResult[0];
                    }


                    if (deltaResult[0] < 0 && deltaResult[1] < 0)
                    {
                        subsequence[0] = 2 * (-deltaResult[0]);
                        subsequence[1] = -deltaResult[0];

                    }
                    if (deltaResult[0] > 0 && deltaResult[1] > 0)
                    {
                        subsequence[0] = 0;
                        subsequence[1] = deltaResult[0];
                        

                    }
                    if (deltaResult[0] > 0 && deltaResult[1] < 0)
                    {
                        subsequence[0] = 0;
                        subsequence[1] = deltaResult[0];

                    }
                    subsequence[2] = subsequence[1] + deltaResult[1];

                    break;

                default:
                    if (deltaResult[testDeltaResultCount - 1] >= 0)
                    {
                        if (deltaResult[0] > 0)
                        {
                            subsequence[0] = 0;
                            subsequence[1] = deltaResult[0];
                            for (int i = 2; i < subsequence.Length; i++)
                            {
                                subsequence[i] = subsequence[i - 1] + deltaResult[i-1];
                            }
                            break;
                        }
                        else
                        {
                            if (deltaResult[0] < 0)
                            {
                                subsequence[1] = 0;
                                subsequence[0] = - deltaResult[0];
                                for (int i = 2; i < subsequence.Length; i++)
                                {
                                    subsequence[i] = subsequence[i - 1] + deltaResult[i-1];
                                }
                                subsequence[testDeltaResultCount] += Math.Abs(subsequence.Min());
                                for (int i = testDeltaResultCount; i > 0; i--)
                                {
                                    subsequence[i - 1] = subsequence[i] - deltaResult[i - 1];
                                }
                                break;
                            }

                            else
                            {
                                subsequence[1] = 0;
                                subsequence[0] = 0;
                                for (int i = 2; i < subsequence.Length; i++)
                                {
                                    subsequence[i] = subsequence[i - 1] + deltaResult[i - 1];
                                }
                                break;

                            }
                            

                        }
                        
                    }
                    else
                    {
                        if (deltaResult[0] == 0)
                        {                            
                            subsequence[testDeltaResultCount] = 0;                            
                            if (deltaResult.Sum() >= 0)
                            {
                                for (int i = 2; i < subsequence.Length; i++)
                                {
                                    subsequence[i] = subsequence[i - 1] + deltaResult[i - 1];
                                }

                            }
                            else
                            {
                                for (int i = testDeltaResultCount; i > 2; i--)
                                {
                                    subsequence[i-1] = subsequence[i] - deltaResult[i - 1];
                                }
                                subsequence[1] = subsequence[2] - deltaResult[1];
                                subsequence[0] = subsequence[1];

                                subsequence[testDeltaResultCount] = Math.Abs(subsequence.Min());
                                for (int i = testDeltaResultCount; i > 2; i--)
                                {
                                    subsequence[i - 1] = subsequence[i] - deltaResult[i - 1];
                                }
                                subsequence[1] = subsequence[2] - deltaResult[1];
                                subsequence[0] = subsequence[1];

                            }
                            
                            break;

                        }
                        else
                        {
                            subsequence[testDeltaResultCount] = 0;
                            subsequence[testDeltaResultCount - 1] = -deltaResult[testDeltaResultCount - 1];

                        }
                        
                    }
                    for (int i = testDeltaResultCount - 2; i >= 0; i--)
                    {
                        subsequence[i] = subsequence[i + 1] - deltaResult[i];
                    }
                    break;
            }

            for (int i = 0; i < subsequence.Length; i++)
            {
                Console.Write(subsequence[i] + " ");
            }
        }
    }
}
