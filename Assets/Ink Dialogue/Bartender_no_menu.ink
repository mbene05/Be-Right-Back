-> bartender_nomenu

=== bartender_nomenu ===
What would you like to drink?

+ [I don't know, what do you have?]
    -> menu_answer

+ [Can I use your employee keycard?]
    -> keycard_answer
    
=== menu_answer ===
The available drinks are in the drink menu at your table.
-> END

=== keycard_answer ===
I don't have one available for you.
Maybe the chef will let you use his.
-> END