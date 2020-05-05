namespace BlockchainExchangeAPI.Json
{
	class JsonAdapter : JsonHandler
	{
		private NewtonsoftAdaptee jsonAdaptee = new NewtonsoftAdaptee();

		public override string Encode<T>(T obj)
		{
			return jsonAdaptee.Encode<T>(obj);
		}

		public override T Decode<T>(string json)
		{
			return jsonAdaptee.Decode<T>(json);
		}
	}
}
