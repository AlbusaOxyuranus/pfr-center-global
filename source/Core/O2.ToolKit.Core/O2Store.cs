using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace O2.ToolKit.Core
{
    /// <summary>
    /// Class storage is configured to save states
    /// </summary>
    public static class O2Store
    {
        
        /// <summary>
        /// There are stored all the objects that are involved in the work
        /// </summary>
        private static readonly Dictionary<Type, object> StoreItemsDictionary;

        static O2Store()
        {
            StoreItemsDictionary = new Dictionary<Type, object>();
        }

        public static void DeleteSore<TItem>() where TItem : class
        {
            var itemType = typeof(TItem);


            if (StoreItemsDictionary.ContainsKey(itemType))
            {
                StoreItemsDictionary[itemType].ClearDataContract();
                StoreItemsDictionary.Remove(itemType);
            }

        }

        /// <summary>
        /// Create an object in the collection or store an existing one
        /// </summary>
        /// <typeparam name="TClass"> </typeparam>
        /// <param name="args"> </param>
        /// <returns> </returns>
        public static TClass CreateOrGet<TClass>(params object[] args) where TClass : class
        {
            var typeClass = typeof(TClass);



            if (StoreItemsDictionary.ContainsKey(typeClass))
                return (TClass)StoreItemsDictionary[typeClass];

            var itemClass = O2Serializer.DeserializeDataContract<TClass>() ?? (TClass)Activator.CreateInstance(typeClass, args);

            StoreItemsDictionary.Add(typeClass, itemClass);

            return (TClass)StoreItemsDictionary[typeClass];
        }

        //public static Attribute GetAttribute<T>(this PropertyInfo PI, T t) where T : Type
        //{
        //    var Attrs = PI.DeclaringType.GetCustomAttributes(typeof(MetadataTypeAttribute), true);
        //    if (Attrs.Length < 1) return null;

        //    var metaAttr = Attrs[0] as AssemblyMetadataAttribute;
        //    var metaProp = metaAttr.MetadataClassType.GetProperty(PI.Name);
        //    if (metaProp == null) return null;

        //    Attrs = metaProp.GetCustomAttributes(t, true);
        //    if (Attrs.Length < 1) return null;
        //    return Attrs[0] as Attribute;
        //}

        public static async Task SaveState(IFileWorker fileWorker)
        {
            await Task.Delay(100);
            StoreItemsDictionary
              //.Where(p=>p.Key != null)
              //.Where(p => Attribute.IsDefined(p.Key, typeof(DataContractAttribute)))
              .Select(p => p.Value).ToList()
               .ForEach(async i =>
               {
                   await i.SerializeDataContractAsync(fileWorker);
               });
          
            //save(json);
            // Get the path to a file on internal storage
            //var backingFile = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "saveData.json");

            // Get the path to a file in the cache directory
            //var cacheFile = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "saveData.json");
            //string path = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory);
            //string settingsPath = Path.Combine(path, "settings.xml");
            //StreamWriter stream = File.CreateText(settingsPath);
            //stream.Write("SomeData");
            //stream.Close();
            //string path = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory);
            //string filename = Path.Combine(path, "saveData.json");

            //using (var streamWriter = new StreamWriter(filename, true))
            //{
            //    streamWriter.WriteLine(DateTime.UtcNow);
            //}

            //using (var streamReader = new StreamReader(filename))
            //{
            //    string content = streamReader.ReadToEnd();
            //    System.Diagnostics.Debug.WriteLine(content);
            //}
            //var jsonRead = await fileWorker.LoadTextAsync("saveData.json");
            //var restoreItems = JsonConvert.DeserializeObject<Dictionary<Type, object>>(jsonRead);
            //StoreItemsDictionary.ser
            //Debug.WriteLine("Save state");
            //JsonConvert.SerializeObject()
        }
    }
}