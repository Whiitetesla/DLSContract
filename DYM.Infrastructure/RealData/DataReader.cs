using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace DYM.Infrastructure.RealData
{
    public class DataReader
    {
        private List<string> Data;

        private void SetData()
        {
            string urlAddress = "https://raw.githubusercontent.com/dwyl/english-words/master/words.txt";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader readStream = null;
                    try
                    {
                        Stream receiveStream = response.GetResponseStream();

                        if (response.CharacterSet == null)
                        {
                            readStream = new StreamReader(receiveStream);
                        }
                        else
                        {
                            readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                        }

                        string data = readStream.ReadToEnd();

                        Data = new List<string>(data.Split("\n"));
                    }
                    finally
                    {
                        readStream.Close();
                    }
                }
            }
        }

        public List<string> GetData()
        {
            SetData();
            return Data;
        }
    }
}
