//using System.Diagnostics;

//namespace Rehearsal.Web.Api.Services.Items
//{
//    public class ItemService : IItemService
//    {
//        public (string, string, byte[]) BasicPy()
//        {
//            //Create Process Info
//            ProcessStartInfo psi = new();
//            psi.FileName = "C:/Python312/python.exe";

//            //Provide script and arguments
//            var script = "../Shared.Lib/py-scripts/nda2.py";
//            //string start_date = "2024-03-10", end_date = "2024-03-28";
//            string user_code = "de9e6db6-54aa-4802-8842-f1e83dfd1f30";
//            psi.Arguments = $"\"{script}\" \"{user_code}\"";

//            //Process Configuration
//            psi.UseShellExecute = false;
//            psi.CreateNoWindow = true;
//            psi.RedirectStandardOutput = true;
//            psi.RedirectStandardError = true;

//            //Execute process abd get output
//            string errors = string.Empty, results = string.Empty;
//            using (var process = Process.Start(psi))
//            {
//                errors = process?.StandardError.ReadToEnd()!;
//                results = process?.StandardOutput.ReadToEnd()!;
//            }

//            var directory_path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "PDFs");
//            var output_path = Path.Combine(directory_path, $"{user_code}.pdf");

//            // Read the file into a byte array
//            byte[] fileBytes;
//            using (var stream = new FileStream(output_path, FileMode.Open))
//            {
//                using (var memoryStream = new MemoryStream())
//                {
//                    stream.CopyTo(memoryStream);
//                    fileBytes = memoryStream.ToArray();
//                }
//            }

//            if (Directory.Exists(directory_path))
//            {
//                // Delete a directory and all files within this directory
//                Directory.Delete(directory_path, true);
//            }

//            return (errors, results, fileBytes);
//            //wwwroot/PDFs/de9e6db6-54aa-4802-8842-f1e83dfd1f30.pdf
//        }
//    }
//}
