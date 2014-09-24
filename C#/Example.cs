class Example {

	static void Main() {
		API TBN = new API();
		string username = TBN.getUsername();
		Console.WriteLine("Welcome, " + username);
		
		if(!TBN.isMemberOf("Old School")) {
			Console.WriteLine("Sorry, you must be an Old School member to use this bot.");
			return;
		}	

		//Do stuff here

	}
}