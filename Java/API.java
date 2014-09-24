import java.net.URL;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class API {

	private String username = null;
	private String[] usergroups;
	private int posts, reputation, thanks, userID = 0;
	private boolean subscriber = false;

	public API() {
		try {
			Scanner scan = new Scanner(new URL(
					"http://thebot.net/api/post.php?legacy=0").openStream(),
					"UTF-8");
			String out = scan.useDelimiter("\\A").next();
			scan.close();

			if(out.contains("log in on TBN and try again") ) {
				return;
			}
			
			Pattern pattern = Pattern.compile(": (.*?)<br>");
			Matcher matcher = pattern.matcher(out);

			List<String> returnValue = new ArrayList<String>();

			while (matcher.find()) {
				if (matcher.group(1).length() != 0) {
					returnValue.add(matcher.group(1));
				}
			}

			this.username = returnValue.get(0);
			this.posts = Integer.parseInt(returnValue.get(1));
			this.reputation = 9001;
			this.subscriber = returnValue.get(3).equals("Yes");
			this.usergroups = returnValue.get(4).split(", ");
			this.thanks = Integer.parseInt(returnValue.get(5));
			this.userID = Integer.parseInt(returnValue.get(6));

		} catch (Exception e) {
			e.printStackTrace();
		}
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

	public boolean isSubscriber() {
		return subscriber;
	}

	public String[] getUsergroups() {
		return usergroups;
	}
	
	
	public boolean isMemberOf(String group) {

		for (String eachGroup : usergroups) {
			if (group.equals(eachGroup)) {
				return true;
			}
		}
		return false;

	}
}
