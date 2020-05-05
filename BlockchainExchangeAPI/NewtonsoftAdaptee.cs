using System;
using Newtonsoft.Json;

namespace BlockchainExchangeAPI
{
    class NewtonsoftAdaptee
	{
		public T Decode<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch(Exception e)
            {
                return default(T);
            }
        }

        public string Encode<T>(T obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj);
            }
            catch
            {
                return "";
            }
        }
	}
}
