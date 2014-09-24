public class Example {
	
	public static void main (String[] args) {
		API TBN = new API();
		String username = TBN.getUsername();
		System.out.println("Welcome, " + username);
		
		if(!TBN.isMemberOf("Old School")) {
			System.out.println("Sorry, you must be an Old School member to use this bot.");
			return;
		}	
		//Do stuff here
		
	}

}