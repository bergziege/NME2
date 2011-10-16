using System.Collections.Generic;
using System.IO;
using Com.QueoMedia.Updater.Utilities;
using ICSharpCode.SharpZipLib.Zip;
using System.Net;
using NME2.Domain;
using NME2.Nme2Ws;
using NME2.Properties;

namespace NME2.Service.Implementation
{
    class SynchonisationService
    {
        public static void StartSync()
        {
            // load local catalog
            CustomObjectCatalog localObjects = null;
            try
            {
                localObjects = DeSerializer.Deserializer<CustomObjectCatalog>("localObjects.xml");
            }
            catch { }

            if (localObjects == null)
            {
                bool ok = DeSerializer.Serialize<CustomObjectCatalog>(new CustomObjectCatalog(new List<CustomObject>()), "localObjects.xml");
                if (ok) localObjects = DeSerializer.Deserializer<CustomObjectCatalog>("localObjects.xml");
            }

            if (localObjects != null)
            {
                // ask for update
                // TODO: invoke message box to ask user if he realy wants to sync.

                // get catalog from net
                Nme2Ws.Nme2Ws ws = new Nme2Ws.Nme2Ws();
                CustomObjectCatalog webObjects = new CustomObjectCatalog(ws.CustomObjectServiceGetAllCustomObjectsAsArray());

                // compare catalog
                IList<LocalCustomObject> toBeDeleted = new List<LocalCustomObject>();
                IList<LocalCustomObject> newItems = new List<LocalCustomObject>();

                foreach (LocalCustomObject webObject in webObjects.CustomObjects)
                {
                    bool exists = false;
                    foreach (LocalCustomObject localObject in localObjects.CustomObjects)
                    {
                        if (webObject.Id == localObject.Id && webObject.Version == localObject.Version)
                        {
                            exists = true;
                        }
                        else if (webObject.Id == localObject.Id && webObject.Version != localObject.Version)
                        {
                            exists = true;
                            if (!toBeDeleted.Contains(webObject)) toBeDeleted.Add(localObject);
                            if (!newItems.Contains(webObject)) newItems.Add(webObject);
                        }
                    }

                    if (!exists)
                    {
                        if (!newItems.Contains(webObject)) newItems.Add(webObject);
                    }

                }

                foreach (LocalCustomObject localObject in localObjects.CustomObjects)
                {
                    bool clearedForDelete = true;

                    foreach (LocalCustomObject webObject in webObjects.CustomObjects)
                    {
                        if (localObject.Id == webObject.Id)
                        {
                            clearedForDelete = false;
                        }
                    }

                    if (clearedForDelete)
                        if (!toBeDeleted.Contains(localObject)) toBeDeleted.Add(localObject);
                }

                // delete old items
                string customObjectPath = Settings.Default.CustomSimObjectPath;
                foreach (LocalCustomObject localOject in toBeDeleted)
                {
                    Directory.Delete(customObjectPath + Path.DirectorySeparatorChar + localOject.Id + "_" + localOject.Version, true);
                }

                // download new items
                foreach (LocalCustomObject webObject in newItems)
                {
                    // extract to custom object folder
                    WebClient client = new WebClient();

                    // Load new object from remot to [temp]
                    string copysource = webObject.DownloadPath;
                    string destinationFilename = webObject.Id + "_" + webObject.Version + ".zip";
                    string unzipDestination = webObject.Id + "_" + webObject.Version;
                    string destination = "./[temp]/" + destinationFilename;
                    System.Diagnostics.Trace.Write(copysource);
                    //Console.ForegroundColor = Program.ConsoleOrange;
                    System.Diagnostics.Trace.Write("Inet access for download ...");
                    client.DownloadFile(copysource, destination);
                    //File.Copy(copysource, "./[temp]/" + ObjectName.Replace('.', '_') + ".zip",true);
                    //Console.ForegroundColor = Program.ConsoleGreen;
                    System.Diagnostics.Trace.Write("... completed");
                    //Console.ForegroundColor = Program.ConsoleWhite;

                    // unzip to simobject folder
                    string unzipdir = customObjectPath + Path.DirectorySeparatorChar + unzipDestination;
                    Directory.CreateDirectory(unzipdir);
                    UnZipFiles(destination, unzipdir, "", false);

                    // delete from [temp]
                    File.Delete(destination);
                }

                // save catalog as new local
                DeSerializer.Serialize(webObjects, "localObjects.xml");

            }
        }

        private static void UnZipFiles(string zipPathAndFile, string outputFolder, string password, bool deleteZipFile)
        {
            FastZip fast = new FastZip();
            fast.ExtractZip(zipPathAndFile, outputFolder, "");

        }
    }
}
