#!/usr/local/env/ python
# -*- coding:utf-8 -*-

'''
TBN - https://thebot.net API
This python is a module, not a part of a web page like the PHP version
__author__ = "Rob Knight, Gavin Huttley, and Peter Maxwell"
'''

import sys
sys.dont_write_bytecode = True


from tbn import Tbn

if __name__ == "__main__":

    print("-- Running API Example --")

    tbn = Tbn()
    tbn.query()

    # also no need to save username into username...
    # username = tbn.username # a property
    # username = tbn.getUsername() # a function

    print("Welcome,{}".format(tbn.userdata["Username"] + "\n"))

    # items that may vary have a decoractor that fetches again api function
    # that makes it to be more live-data. U still can fetch static values from class instance

    # soo, OPTION 1
    def option_1():
        if "Old School" not in tbn.userdata["Usergroups"]:
            print("Sorry, you must be an Old School member to use this bot (option_1)")

    # and OPTION 2
    def option_2():
        if not tbn.is_member_of("Old School"):
            print("Sorry, you must be an Old School member to use this bot (option_2)")

    print("-- Running option 1")
    option_1()

    print("\n-- Running option 2")
    option_2()

    print("\nYou have " + str(len(tbn.userdata["Followers"])) + " follwers :D")

    print("\nAPI example finished\n")