using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;

namespace ConsoleApp1
{
    class Program
    {


        static void Main(string[] args)
        {
           string imagePath = "C:\\Users\\mfurqan\\Desktop\\Fetch Image\\1.jpg";
            getSerial_no(imagePath);
        }

        static void getSerial_no(string imagepath)
        {
            string imagePath = imagepath;
            string tessdataPath = @"C:\Users\mfurqan\source\repos\OCR_ConsoleApp\packages\Tesseract.5.2.0\tessdata";

            // Specify the Tesseract engine options
            var engineOptions = new TesseractEngineConfig
            {
                TessDataPrefix = tessdataPath
            };

            try
            {
                // Create a Tesseract instance
                using (TesseractEngine engine = new TesseractEngine(tessdataPath, "eng", EngineMode.Default))
                {
                    // Load the image
                    using (var image = Pix.LoadFromFile(imagePath))
                    {
                        // Apply OCR on the image
                        using (var page = engine.Process(image))
                        {
                            // Retrieve the recognized text
                            string extractedText = page.GetText();

                            // Print the extracted text
                            Console.WriteLine(extractedText);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Message: " + ex);
            }

            Console.ReadLine();
        }
    }
}
