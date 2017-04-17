#!/usr/local/env/ python
# -*- coding:utf-8 -*-
# -*- author:erm3nda.github.com -*-

'''
TBN - https://thebot.net API
This python is a module, not a part of a web page like the PHP version
__author__ = "Rob Knight, Gavin Huttley, and Peter Maxwell"
'''

import requests
import json

class Tbn():

    # Autorun is just a way to call the getData() at load time
    def __init__(self, json_output=True, legacy_mode=False, headers=None):

        # an API key should be perfect, both for query and be identified
        self.api_url = "http://thebot.net/api/post.php"
        self.headers = {"User-Agent":"TBN API_KEY xxxx", } if not headers else headers
        self.json_output = json_output if json_output else True
        self.legacy_mode = legacy_mode if legacy_mode else False

        # append url options if enabled
        if json_output:
            self.api_url += "?json"
        if not legacy_mode:
            self.api_url += "&legacy=0"
        self.api_url += "&ip=" + self.get_ip()

        self.r = requests.get(self.api_url, headers=self.headers)
        self.login_again = "log in on TBN and try again"

    def query(self):
        if self.r.status_code == 200:
            if self.login_again not in self.r.headers:
                if self.json_output:
                    self.userdata = self.r.json()
                    return self.r.json()
                else:
                    return str(self.r.content)
            else:
                return login_again
        else:
            return False

    def reload(func):
        def _decorator(self, *args, **kwargs):
            print("--> Reloading info <--") # should not print in threre
            self.r = requests.get(self.api_url, headers=self.headers)
            self.userdata = self.r.json()
            func(self, *args, **kwargs)
        return _decorator

    def get_ip(self):
        return json.loads(requests.get("http://httpbin.org/ip").content)["origin"]

    def get_id(self):
        return self.userdata["User ID"]

    def get_username(self):
        return self.userdata["Username"]

    @reload
    def get_posts(self):
        return self.userdata["Posts"]

    @reload
    def get_thanks(self):
        return self.userdata["Thanks"]

    @reload
    def get_reputation(self):
        return self.userdata["Reputation"]

    @reload
    def get_followers(self):
        return self.userdata["Followers"]

    @reload
    def get_following(self):
        return self.userdata["Following"]

    @reload
    def is_subscriber(self):
        return True if self.userdata["Subscription"] == "Yes" else False

    @reload
    def get_user_groups(self):
        return self.userdata["Usergroups"]

    @reload
    def is_member_of(self, group_name):
        return True if group_name in self.userdata["Usergroups"] else False