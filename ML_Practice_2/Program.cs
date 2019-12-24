using ML_Practice_2ML.Model;
using IMService;
using System;
using System.IO;

namespace ML_Practice_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program Starts Now");
            Console.WriteLine("Enter Source Path");
            string sourcePath =Console.ReadLine() ;
            Console.WriteLine("Enter Destination Path");
            string destionationPath = Console.ReadLine();
            Console.WriteLine("Enter LabelName to process");
            //Rose,Tupile
            string predicateName = Console.ReadLine();
            FileHelperService.SegaregateImagesBasedOnFeatureName(sourcePath,predicateName,destionationPath);


            Console.ReadLine();
        }


    }
}