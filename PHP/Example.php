<?php

require "API.php";

$TBN = new API();

$username = $TBN->getUsername();

echo("Welcome, {$username}\n");

if(!$TBN->isMemberOf("Old School")) {
	die("Sorry, you must be an Old School member to use this bot.");
}

//Do stuff here

?>