<?php
class API
{
    private $json;
    private $userIP;
	private $data;
    
    function __construct()
    {
        if (isset($_SERVER['HTTP_CF_CONNECTING_IP'])) {
            $_SERVER['REMOTE_ADDR'] = $_SERVER['HTTP_CF_CONNECTING_IP'];
        }
        
		$this->userIP = $_SERVER['REMOTE_ADDR'];
        $this->data = file_get_contents("http://thebot.net/api/post.php?json&legacy=0&ip=" . $this->userIP);
		if (strpos($this->data, 'log in on TBN and try again') !== false) {
			return;
		}
        $this->json = json_decode($this->data, true);
    }
    
    
    
    function getIP()
    {
        return $this->userIP;
    }
    
    function getUsername()
    {
        return $this->json['Username'];
    }
    
    function getPosts()
    {
        return $this->json['Posts'];
    }
    
    function getReputation()
    {
        return $this->json['Reputation'];
    }
    
    function isSubscriber()
    {
        return $this->json['Subscription'] === "Yes";
    }
    
    function getUsergroups()
    {
        return ($this->json['Usergroups']);
    }
    
    function isMemberOf($group)
    {
        return (in_array($group, $this->json['Usergroups']));
    }
    
}
?>