using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace O2.ToolKit.Core
{
    /// <remarks> Класс помощник позволяющий сохранять данные классов </remarks>
    public static class O2Serializer
    {
        /// <summary>
        /// </summary>
        public const string JsonExtension = ".json";

        /// <summary>
        /// </summary>
        public static readonly List<Type> KnownTypes = new List<Type>
        {
            typeof(Type),
            typeof(Dictionary<string, string>)
        };

        /// <summary>
        /// Serialized object to string
        /// </summary>
        /// <param name="item"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string SerializeDataContractToJsonString(this object item, Type type = null)
        {
            //    type = type ?? item.GetType();
            //    var serializer = new DataContractJsonSerializer(type, KnownTypes);

            //    using (var stream = new MemoryStream())
            //    {
            //        var currentCulture = Thread.CurrentThread.CurrentCulture;
            //        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            //        serializer.WriteObject(stream, item);
            //        Thread.CurrentThread.CurrentCulture = currentCulture;
            //        return Encoding.UTF8.GetString((stream.ToArray()));
            //    }
            return default(string);
        }

        /// <summary>
        /// </summary>
        /// <param name="item"> </param>
        /// <param name="file"> </param>
        /// <param name="type"> </param>
        public static async Task SerializeDataContractAsync(this object item, IFileWorker fileWorker, string file = null, Type type = null)
        {
            try
            {
                               type = type ?? item.GetType();

                                if (string.IsNullOrEmpty(file))
                                    file = type.Name + JsonExtension;
                                string json = JsonConvert.SerializeObject(type);
                                await fileWorker.SaveTextAsync(file, json);
                //                var serializer = new DataContractJsonSerializer(type, KnownTypes);

                //                using (var stream = File.Create(file))
                //                {
                //#if !NETFX_CORE
                //                    var currentCulture = Thread.CurrentThread.CurrentCulture;
                //                    Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
                //                    serializer.WriteObject(stream, item);
                //                    Thread.CurrentThread.CurrentCulture = currentCulture;
                //#elif !WINDOWS_UWP
                //                     var currentCulture = CultureInfo.DefaultThreadCurrentCulture;
                //                    CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
                //                    serializer.WriteObject(stream, item);
                //                    CultureInfo.DefaultThreadCurrentCulture = currentCulture;
                //#endif

                //#if WINDOWS_UWP
                //                    var currentCulture = CultureInfo.DefaultThreadCurrentCulture;
                //                    CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
                //                    serializer.WriteObject(stream, item);
                //                    CultureInfo.DefaultThreadCurrentCulture = currentCulture;
                //#endif
                //                }
            }
            catch (Exception exception) //Отбработать ошибку как следует
            {
                Debug.WriteLine("Ошибка серилизации срочно обработать!\r\n" + exception.Message +
                                "\r\n" + exception.Source + "\r\n" + exception.StackTrace);
                //throw;
            }
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="TItem"> </typeparam>
        /// <param name="file"> </param>
        /// <returns> </returns>
        public static TItem DeserializeDataContract<TItem>(string file = null)
        {
            try
            {
                if (string.IsNullOrEmpty(file))
                    file = typeof(TItem).Name + JsonExtension;
                            
                var item = JsonConvert.DeserializeObject<TItem>(file);
                return item;
                            //await fileWorker.SaveTextAsync(file, json);
                //                var serializer = new DataContractJsonSerializer(typeof(TItem), KnownTypes);
                //                using (var stream = File.OpenRead(file))
                //                {
                //                    //using (var sr = new StreamReader(stream, Encoding.UTF8))
                //                    //{
                //                    //    Debug.WriteLine(sr.ReadToEnd());
                //                    //}


                //#if !NETFX_CORE
                //                    var currentCulture = Thread.CurrentThread.CurrentCulture;
                //                    Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
                //                    var item = (TItem) serializer.ReadObject(stream);
                //                    Thread.CurrentThread.CurrentCulture = currentCulture;
                //#elif !WINDOWS_UWP
                //                     var currentCulture = CultureInfo.DefaultThreadCurrentCulture;
                //                    CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
                //                    var item = (TItem)serializer.ReadObject(stream);
                //                    CultureInfo.DefaultThreadCurrentCulture = currentCulture;
                //#endif

                //#if WINDOWS_UWP
                //                    var currentCulture = CultureInfo.DefaultThreadCurrentCulture;
                //                    CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
                //                    var item = (TItem)serializer.ReadObject(stream);
                //                    CultureInfo.DefaultThreadCurrentCulture = currentCulture;
                //#endif
                //                    return item;
                //}
                return default(TItem);
            }
            catch (Exception exception)
            {
                //throw new Exception(exception.Message);
                return default(TItem);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="file"></param>
        /// <param name="type"></param>
        public static void SerializeDataContractFile(this object item, string file = null, Type type = null)
        {
            try
            {
                //                type = type ?? item.GetType();
                //                if (string.IsNullOrEmpty(file))
                //                    file = type.Name + JsonExtension;
                //                var serializer = new DataContractJsonSerializer(type, KnownTypes);
                //                using (var stream = File.Create(file))
                //                {
                //                    var currentCulture = Thread.CurrentThread.CurrentCulture;
                //                    Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
                //                    serializer.WriteObject(stream, item);
                //                    Thread.CurrentThread.CurrentCulture = currentCulture;
                //                }
                Debug.WriteLine("SerializeDataContractFile");
            }
            catch (Exception exception) //Отбработать ошибку как следует
            {
                Debug.WriteLine("Ошибка серилизации срочно обработать!\r\n" + exception.Message +
                                "\r\n" + exception.Source + "\r\n" + exception.StackTrace);
                //throw;
            }
        }
        /// <summary>
        /// </summary>
        /// <param name="item"> </param>
        /// <param name="file"> </param>
        /// <param name="type"> </param>
        public static void ClearDataContract(this object item, string file = null, Type type = null)
        {
            try
            {
                type = type ?? item.GetType();
                if (string.IsNullOrEmpty(file))
                    file = type.Name + JsonExtension;

                //File.Delete(file);
            }
            catch (Exception)
            {
                throw;
            }
        }
    
    }
}