using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ElroubyMauiLibrary.Api;

public static class JsonGetSend
{
	public static HttpClient http = new HttpClient();

	public static async Task<T> ReceiveDataJson<T>(string Url)
	{
		return await http.GetFromJsonAsync<T>(Url);
	}

	public static async void SendDataGET(string Url)
	{
		HttpMethod Method = new HttpMethod("GET");
		await http.SendAsync(new HttpRequestMessage(Method, Url));
	}

	public static async void SendDataPOST<T>(string Url, T Data)
	{
		await http.PostAsJsonAsync(Url, Data);
	}
}
