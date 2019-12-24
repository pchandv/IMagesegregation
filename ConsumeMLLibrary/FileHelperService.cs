using ML_Practice_2ML.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace IMService
{
    public class FileHelperService
    {
        static ModelOutput ProcessImage(string path)
        {
            var input = new ModelInput();
            input.ImageSource = path;

            // Load model and predict output of sample data
            ModelOutput result = ConsumeModel.Predict(input);
            return result;
        }


        public static void SegaregateImagesBasedOnFeatureName(string parentDirectory, string predictionName, string destionationFolderPath = null)
        {
            List<string> listOffilePathsToMove = new List<string>();
            Console.WriteLine("-------Processing Image--------");
            foreach (string filePath in System.IO.Directory.GetFiles(parentDirectory, "*", SearchOption.AllDirectories))
            {
                Console.WriteLine(filePath);
                var mlresult = ProcessImage(filePath);

                if (mlresult.Prediction == predictionName)
                {
                    MoveToNewFolder(filePath, predictionName, destionationFolderPath);
                }
            }
            //MoveToNewFolder(listOffilePathsToMove, predictionName);

            Console.WriteLine("------Processing ends-------------");
        }

        private static void MoveToNewFolder(List<string> listOffilePathsToMove, string predicteName)
        {
            foreach (var filePath in listOffilePathsToMove)
            {
                FileInfo f = new FileInfo(filePath);
                string d = Path.Combine(f.DirectoryName, predicteName, f.Name);

                f.MoveTo(d);
                Console.WriteLine("File Moved->" + filePath);
            }
        }

        private static void MoveToNewFolder(string filePath, string predicteName, string destionationFolderPath = null)
        {
            FileInfo f = new FileInfo(filePath);
            string destinationRootFolder = string.IsNullOrEmpty(destionationFolderPath) ?
                Path.Combine(f.DirectoryName, predicteName) :
                Path.Combine(destionationFolderPath, predicteName);
            string d = Path.Combine(destinationRootFolder, f.Name);
            if (!Directory.Exists(destinationRootFolder))
            {
                Directory.CreateDirectory(destinationRootFolder);
            }
            f.MoveTo(d);
            Console.WriteLine("File Moved->" + filePath);
        }
    }
}
