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
           //string imagePath1 = "C:\\Users\\mfurqan\\Desktop\\Fetch Image\\1.jpg";
           // string imagePath2 = "C:\\Users\\mfurqan\\Desktop\\Fetch Image\\2.jpg";
           // string imagePath3 = "C:\\Users\\mfurqan\\Desktop\\Fetch Image\\3.jpg";
           // string imagePath4 = "C:\\Users\\mfurqan\\Desktop\\Fetch Image\\4.jpg";
           // string imagePath5 = "C:\\Users\\mfurqan\\Desktop\\Fetch Image\\5.jpg";
            for(int i = 1; i <= 5; i++)
            {
                string imagePath = "C:\\Users\\mfurqan\\Desktop\\Fetch Image\\"+i+".jpg";
                Console.WriteLine(imagePath);

                getSerial_no(imagePath);
                
            }
            
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
                            string searchText = "Serial No.";
                            //Console.WriteLine(extractedText);
                            bool res = extractedText.Contains(searchText);
                            if (res == true)
                            {
                                int startIndex = extractedText.IndexOf(searchText) + searchText.Length;
                                string result = extractedText.Substring(startIndex, 10);
                                Console.WriteLine(result);
                            }
                            else
                            {
                                Console.WriteLine("Serial No. not found");
                                Console.WriteLine("Furqan Changes");
                            }
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
