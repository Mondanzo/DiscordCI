using Discord;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordCI.Application
{
	class Program
	{
		//This work is based on https://github.com/lukemonaghan/ForerunnerCI 's work.
		//Luke originally wrote the bot, this is just a cleaned up version.

		private static DiscordClient client = new DiscordClient();

		static void Main(string[] args)
		{
			//Throw if the args aren't valid
			if (args.Length < 8)
				throw new InvalidOperationException("Args Mismatch, should be \n [EMAIL] [PASSWORD] [SERVER_ID] [CHANNEL_ID] [URL] [COMMIT] [BRANCH] [SLUG] [MESSAGE STRING GOES AT THE END]");

			//Display all log messages in the console
			client.Log.Message += (s, e) => Console.WriteLine($"[{e.Severity}] {e.Source}: {e.Message}");

			string username = args[0];
			string password = args[1];
			string serverID = args[2];
			string channelID = args[3];

			IDiscordCIMessage discordMessage = new ArgParser(args).Generate();

			//Set its status
			client.LoggedIn += (s, e) =>
			{
				client.SetGame("By Andrew Blakely (github.com/HelloKitty)");
			};

			client.ExecuteAndWait(async () =>
			{
				// Attempt to login to the Discord server
				await Login(username, password);

				// Grab the server from the given ID
				Server server = GetServerFromID(serverID);

				//Grab the channel from the server
				Channel channel = GetChannelFromServer(server, channelID);

				//Send the bot message
				await channel.SendMessage(discordMessage.Message);

				await Task.Run(() =>
				{
					while (client.MessageQueue.Count != 0) Thread.Sleep(100);
				});

				await client.Disconnect();
			});
		}

		// Creation of a credentials text file (RAW PASSWORD VISIBLE)
		private static Task<string> Login(string email, string pass)
		{
			return client.Connect(email, pass);	
		}

		public static Server GetServerFromID(string id)
		{
			try
			{
				return client.GetServer(ulong.Parse(id));
			}
			catch (InvalidOperationException ioe)
			{
				throw new Exception($"There are no servers with ID {id}.", ioe);
			}
			catch (Exception e)
			{
				throw new Exception($"Unable to find Server with ID: {id}.", e);
			}
		}

		public static Channel GetChannelFromServer(Server server, string id)
		{
			try
			{
				return server.GetChannel(ulong.Parse(id));
			}
			catch(InvalidOperationException ioe)
			{
				throw new Exception("There are no channels present in the server.", ioe);
			}
			catch(Exception e)
			{
				throw new Exception($"Unable to find Channel with ID: {id} in server {server.Name}.", e);
			}
		}
	}
}
