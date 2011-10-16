using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace Com.QueoMedia.Updater.Utilities
{
    /**
     * DeSerializer.
     * Serialize and deserialize classes to and from xml files.
     */
    public class DeSerializer
    {
        /**
         * Serialize class T.
         * @param data input data of type T
         * @param file filename to serialize to
         * @return true if finished without error
         */
        public static bool Serialize<T>(T data, string file){
            bool result = false;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                TextWriter txtWriter = new StreamWriter(file,false,Encoding.Default,1024);
                serializer.Serialize(txtWriter, data);
                txtWriter.Close();
                result = true;
            }
            catch (Exception e) { }
            return result;
        }

        /**
         * Deserialize class T.
         * @param file filename from file to deserialize
         * @result T class of type T
         */
        public static T Deserializer<T>(string file){
            T result = default(T);
            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(T));
                TextReader txtReader = new StreamReader(file, Encoding.Default);
                result = (T)deserializer.Deserialize(txtReader);
                txtReader.Close();
            }catch{}
            return result;
        }
    }
}
