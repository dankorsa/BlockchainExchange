namespace BlockchainExchangeAPI.Json
{
    public class JsonHandler
    {
       public virtual T Decode<T>(string json)
       {
			return default(T);
       }

        public virtual string Encode<T>(T obj)
        {
			return "Encoding virtual method";
        }

    }
}
