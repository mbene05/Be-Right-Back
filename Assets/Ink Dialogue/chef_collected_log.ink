EXTERNAL giveLog(givenLog)
-> chef_collected_logs

=== chef_collected_logs ===
You're back!
Let me access conFOS.
...
YES! I've got them back!
conFOS, where did I leave my key to the prep area?
conFOS - Welcome back Matt, you left that key in the coatroom.
+ [Do you have access there?]
    -> Answer

=== Answer ===
I do!
Here's my employee keycard to get into the coat room.
Once you get my key, you're welcome to use to it to get into the prep area.
I'm so grateful to you for getting my Connie back!
~ giveLog(1)
-> END