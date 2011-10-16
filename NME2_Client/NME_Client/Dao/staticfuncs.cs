using System;
using System.Text;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace NME2.Dao
{
    public class Staticfuncs
    {
        public static string Serverpath;

        //The method we will use to send the data, this can be POST or GET.
        private const string Requestmethod = "POST";

        //Here we will enter the data to send, just like if we where to go to a webpage and enter variables,
        // we would type: "www.somesite.com?var1=Hello&var2=Server!"!

        //The type of content being send, this is almost always "application/x-www-form-urlencoded".
        private const string Contenttype = "application/x-www-form-urlencoded";

        //What the server sends back:
        private static string _responseFromServer;

        //We also need a Stream:
        private static Stream _dataStream;

        //...And a webResponce,
        private static WebResponse _response;

        //don't forget the streamreader either!
        private static StreamReader _reader;

        public static string QueryOperator(string operation)
        {
            /*
             * Operator codes
             * 0 -> check for folder
             * 1 -> check library version no
             * 2 -> get mission filelist
             */

            // check if coord folder exist on http server
            string postData = operation;

            //The Byte Array that will be used for writing the data to the stream.
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            //The URL of the webpage to send the data to.
            string url = Serverpath + "operator.php";

            //Here we will create the WebRequest object, and enter the URL as soon as it is created.
            WebRequest request = WebRequest.Create(url);

            //We will need to set the method used to send the data.
            request.Method = Requestmethod;

            //Then the contenttype:
            request.ContentType = Contenttype;

            //content length
            request.ContentLength = byteArray.Length;

            //ok, now get the request from the webRequest object, and put it into our Stream:
            _dataStream = request.GetRequestStream();

            // Write the data to the request stream.
            _dataStream.Write(byteArray, 0, byteArray.Length);

            // Close the Stream object.
            _dataStream.Close();

            //Get the responce
            try
            {
                _response = request.GetResponse();

                // Get the stream containing content returned by the server.
                _dataStream = _response.GetResponseStream();

                //Open the responce stream:
                _reader = new StreamReader(_dataStream);

                //read the content into the responcefromserver string
                _responseFromServer = _reader.ReadToEnd();

                // Clean up the streams.
                _reader.Close();
                _dataStream.Close();
                _response.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Now, display the responce!
            //lstLog.Items.Add(responseFromServer);
            //Console.WriteLine(_responseFromServer);
            return _responseFromServer;
            //Done!
        }
    }
}
