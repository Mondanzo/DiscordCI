using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordCI.Application
{
	/// <summary>
	/// Parses the args to build a <see cref="IDiscordCIMessage"/>.
	/// </summary>
	public class ArgParser
	{
		/// <summary>
		/// <see cref="IDiscordCIMessage"/> without an optional message parameter.
		/// </summary>
		private class ParsedDiscordMessageWithoutMessage : IDiscordCIMessage
		{
			public string Message
			{
				get
				{
					return $"**TravisCI**\n" +
						  $"```\n" +
						  $"Commit: {commitHash}\n" +
						  $"Repo: {repoName}\n" +
						  $"Branch: {branchName}\n" +
						  $"```" +
						  $"URL: {buildUrl}\n\n";
				}
			}

			private string buildUrl { get; }
			private string commitHash { get; }
			private string branchName { get; }
			private string repoName { get; }

			public ParsedDiscordMessageWithoutMessage(string url, string commit, string branch, string slug)
			{
				buildUrl = url;
				commitHash = commit;
				branchName = branch;
				repoName = slug;
			}
		}

		private string url { get; }
		private string commit { get; }
		private string branch { get; }
		private string slug { get; }

		public ArgParser(string[] args)
		{
			url = args[4];
			commit = args[5];
			branch = args[6];
			slug = args[7];
		}

		public IDiscordCIMessage Generate()
		{
			return new ParsedDiscordMessageWithoutMessage(url, commit, branch, slug);
		}
	}
}
