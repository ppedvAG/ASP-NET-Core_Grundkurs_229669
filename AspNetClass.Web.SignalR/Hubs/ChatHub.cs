using Microsoft.AspNetCore.SignalR;

namespace AspNetClass.Web.SignalR.Hubs
{
	public class ChatHub : Hub
	{
		/// <summary>
		/// Client klickt den Send Message Button -> connection.invoke -> connection ist eine Variable die die Verbindung zum Hub aufbaut
		/// Der Client schickt den SendMessage Befehl mit Benutzername und Passwort und im Hub ist dann der Code dazu festgelegt
		/// Program.cs hat SignalR registriert
		/// Der Client hört mithilfe von connection.on auf eingehende Nachrichten (mit einer bestimmten Methode)
		/// </summary>
		/// <param name="user"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		public async Task SendMessage(string user, string message)
		{
			await Clients.All.SendAsync("ReceiveMessage", user, message);
		}
	}
}