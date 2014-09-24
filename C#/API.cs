using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;


public class API {
	private string username;
	private string[] usergroups;
	private int posts, reputation, thanks, userID = 0;
	private bool subscriber = false;

	public API() {
		string input = new System.Net.WebClient().DownloadString("http://thebot.net/api/post.php?legacy=0");
		if (input.Contains("log in on TBN and try again")) {
			return;
		}

		string pattern = @": (.*?)<br>";
		List < string > returnValue = new List < string > ();

		foreach(Match m in Regex.Matches(input, pattern)) {
			returnValue.Add(m.Groups[1].Value);
		}

		this.username = returnValue[0];
		this.posts = Convert.ToInt32(returnValue[1]);
		this.reputation = 9001;
		this.subscriber = returnValue[3].Equals("Yes");
		this.usergroups = returnValue[4].Split(new string[] {
			", "
		}, StringSplitOptions.None);
		this.thanks = Convert.ToInt32(returnValue[5]);
		this.userID = Convert.ToInt32(returnValue[6]);

	}

	public int getReputation() {
		return reputation;
	}

	public int getPosts() {
		return posts;
	}

	public int getThanks() {
		return thanks;
	}

	public int getUserID() {
		return userID;
	}

	public String getUsername() {
		return username;
	}

	public bool isSubscriber() {
		return subscriber;
	}

	public string[] getUsergroups() {
		return usergroups;
	}

	public bool isMemberOf(string group) {
		int pos = Array.IndexOf(usergroups, group);
		if (pos > -1) {
			return true;
		}
		return false;
	}
}
