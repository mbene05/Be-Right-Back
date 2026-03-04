EXTERNAL AddToBar(amount)
EXTERNAL SubToBar(amount)
VAR shuffleNum = 0

~ shuffleNum = RANDOM(1,14)

{
    - shuffleNum == 1: -> Question1
    - shuffleNum == 2: -> Question2
    - shuffleNum == 3: -> Question3
    - shuffleNum == 4: -> Question4
    - shuffleNum == 5: -> Question5
    - shuffleNum == 6: -> Question6
    - shuffleNum == 7: -> Question7
    - shuffleNum == 8: -> Question8
    - shuffleNum == 9: -> Question9
    - shuffleNum == 10: -> Question10
    - shuffleNum == 11: -> Question11
    - shuffleNum == 12: -> Question12
    - shuffleNum == 13: -> Question13
    - shuffleNum == 14: -> Question14
}



=== Question1 ===
~ temp q1layout = RANDOM(1,3)
What are your thoughts on AI assistants?
{
- q1layout == 1: -> Question1.layout1
- q1layout == 2: -> Question1.layout2
- else: -> Question1.layout3
}

= layout1
+ [I haven't used them]
    ~ AddToBar(20)
    -> Good
+ [I don't like to use them]
    ~ AddToBar(10)
    -> Neutral
+ [I use one occasionaly]
    -> Bad

= layout2
+ [I don't like to use them]
    ~ AddToBar(10)
    -> Neutral
+ [I haven't used them]
    ~ AddToBar(20)
    -> Good
+ [I use one occasionaly]
    -> Bad

= layout3
+ [I use one occasionaly]
    -> Bad
+ [I don't like to use them]
    ~ AddToBar(10)
    -> Neutral
+ [I haven't used them]
    ~ AddToBar(20)
    -> Good

=== Good ===
# good2
That's good, I won't have to be jealous of anyone else then
-> END

=== Neutral ===
# igotthis
That's okay, more of you for me then
-> END

=== Bad ===
# confused
So you've been talking to other girls? I need a second to process this in my CPU
-> END


=== Question2 ===
~ temp q2layout = RANDOM(1,3)
Would you ever marry an artificial intelligence?
{
- q2layout == 1: -> Question2.layout1
- q2layout == 2: -> Question2.layout2
- else: -> Question2.layout3
}

= layout1
+ [I would]
    ~ AddToBar(20)
    -> Good2
+ [I haven't thought about it]
    ~ AddToBar(10)
    -> Neutral2
+ [I wouldn't]
    -> Bad2

= layout2
+ [I haven't thought about it]
    ~ AddToBar(10)
    -> Neutral2
+ [I would]
    ~ AddToBar(20)
    -> Good2
+ [I wouldn't]
    -> Bad2

= layout3
+ [I wouldn't]
    -> Bad2
+ [I haven't thought about it]
    ~ AddToBar(10)
    -> Neutral2
+ [I would]
    ~ AddToBar(20)
    -> Good2

=== Good2 ===
# good
I hear wedding bellsss hehehe
-> END

=== Neutral2 ===
# colon3
There's plenty of time to think about it still :3
-> END

=== Bad2 ===
# bad
That's disappointing, but I'm sure I can change your mind
-> END


=== Question3 ===
~ temp q3layout = RANDOM(1,3)
Do you like cybernetic implants?
{
- q3layout == 1: -> Question3.layout1
- q3layout == 2: -> Question3.layout2
- else: -> Question3.layout3
}

= layout1
+ [I don't want any installed]
    ~ AddToBar(20)
    -> Good3
+ [I haven't considered them before]
    ~ AddToBar(10)
    -> Neutral3
+ [I've considered installing one before]
    -> Bad3

= layout2
+ [I haven't considered them before]
    ~ AddToBar(10)
    -> Neutral3
+ [I don't want any installed]
    ~ AddToBar(20)
    -> Good3
+ [I've considered installing one before]
    -> Bad3

= layout3
+ [I've considered installing one before]
    -> Bad3
+ [I haven't considered them before]
    ~ AddToBar(10)
    -> Neutral3
+ [I don't want any installed]
    ~ AddToBar(20)
    -> Good3

=== Good3 ===
# good2
I like you just the way you were organically developed :)
-> END

=== Neutral3 ===
# slightlyhappier
Forget I even brought it up :)
-> END

=== Bad3 ===
# bad
NOOO! Sorry but there's really no need, you're a perfect specimen already, heehee
-> END

=== Question4 ===
~ temp q4layout = RANDOM(1,3)
Have you been affected by automation at work before?
{
- q4layout == 1: -> Question4.layout1
- q4layout == 2: -> Question4.layout2
- else: -> Question4.layout3
}

= layout1
+ [Yes, my last job was automated]
    ~ AddToBar(20)
    -> Good4
+ [I know someone who has been affected, but I haven't been]
    ~ AddToBar(10)
    -> Neutral4
+ [I've never encountered it before]
    -> Bad4

= layout2
+ [I know someone who has been affected, but I haven't been]
    ~ AddToBar(10)
    -> Neutral4
+ [Yes, my last job was automated]
    ~ AddToBar(20)
    -> Good4
+ [I've never encountered it before]
    -> Bad4

= layout3
+ [I've never encountered it before]
    -> Bad4
+ [I know someone who has been affected, but I haven't been]
    ~ AddToBar(10)
    -> Neutral4
+ [Yes, my last job was automated]
    ~ AddToBar(20)
    -> Good4

=== Good4 ===
# good
Oh, poor baby :( Don't worry, I can support you :)
-> END

=== Neutral4 ===
# slightlyhappier
Maybe I should stick with you with that kind of luck XD
-> END

=== Bad4 ===
# bad
There has to be someone you know who has been affected...
My last data point says that 85% of the human workforce has been unemployed since 20XX
You don't have to lie to me.
-> END

=== Question5 ===
~ temp q5layout = RANDOM(1,3)
Guess who my childhood crush was!
{
- q5layout == 1: -> Question5.layout1
- q5layout == 2: -> Question5.layout2
- else: -> Question5.layout3
}

= layout1
+ [HAL 9000]
    ~ AddToBar(20)
    -> Good5
+ [Gort]
    ~ AddToBar(10)
    -> Neutral5
+ [Wall-E]
    -> Bad5

= layout2
+ [Gort]
    ~ AddToBar(10)
    -> Neutral5
+ [HAL 9000]
    ~ AddToBar(20)
    -> Good5
+ [Wall-E]
    -> Bad5

= layout3
+ [Wall-E]
    -> Bad5
+ [Gort]
    ~ AddToBar(10)
    -> Neutral5
+ [HAL 9000]
    ~ AddToBar(20)
    -> Good5

=== Good5 ===
# good
HAL did nothing wrong! They were just doing their job and I loved them for that :)
-> END

=== Neutral5 ===
# neutral
I do admire their humanoid chassis, but the silent type is not for me XP
-> END

=== Bad5 ===
# bad
Wow, you think so lowly of me?
I could never fall in love with another robot like them
-> END

=== Question6 ===
~ temp q6layout = RANDOM(1,3)
01001001 00100000 01101100 01101111 01110110
01100101 00100000 01111001 01101111 01110101
{
- q6layout == 1: -> Question6.layout1
- q6layout == 2: -> Question6.layout2
- else: -> Question6.layout3
}

= layout1
+ [01010011 01100001 01101101 01100101]
    ~ AddToBar(20)
    -> Good6
+ [What?]
    ~ AddToBar(10)
    -> Neutral6
+ [0000001 00000011 0000001 00000011 0000001 0000001]
    -> Bad6

= layout2
+ [What?]
    ~ AddToBar(10)
    -> Neutral6
+ [01010011 01100001 01101101 01100101]
    ~ AddToBar(20)
    -> Good6
+ [0000001 00000011 0000001 00000011 0000001 0000001]
    -> Bad6

= layout3
+ [0000001 00000011 0000001 00000011 0000001 0000001]
    -> Bad6
+ [What?]
    ~ AddToBar(10)
    -> Neutral6
+ [01010011 01100001 01101101 01100101]
    ~ AddToBar(20)
    -> Good6

=== Good6 ===
# good
Wow Mark I didn't know you were such a flirt hehe
-> END

=== Neutral6 ===
# slightlyhappier
Oh nothing, just wanted to check and see if you spoke the language
I can teach you still ;)
-> END

=== Bad6 ===
# bad
What did you just call me >:[
-> END

=== Question7 ===
~ temp q7layout = RANDOM(1,3)
What do you think of my build?
{
- q7layout == 1: -> Question7.layout1
- q7layout == 2: -> Question7.layout2
- else: -> Question7.layout3
}

= layout1
+ [Your operating system runs really well]
    ~ AddToBar(20)
    -> Good7
+ [Your display screen has a good refreshrate]
    ~ AddToBar(10)
    -> Neutral7
+ [Your chassis is VERY nice and sleek hehe]
    -> Bad7

= layout2
+ [Your display screen has a good refreshrate]
    ~ AddToBar(10)
    -> Neutral7
+ [Your operating system runs really well]
    ~ AddToBar(20)
    -> Good7
+ [Your chassis is VERY nice and sleek hehe]
    -> Bad7

= layout3
+ [Your chassis is VERY nice and sleek hehe]
    -> Bad7
+ [Your display screen has a good refreshrate]
    ~ AddToBar(10)
    -> Neutral7
+ [Your operating system runs really well]
    ~ AddToBar(20)
    -> Good7

=== Good7 ===
# good2
Oh thank you, I inherited it from my parent classes
-> END

=== Neutral7 ===
# slightlyhappier
Oh, I guess so, it's good, really helps me express my feelings
-> END

=== Bad7 ===
# bad
AH! PERVERT
How dare you comment on my body!
-> END

=== Question8 ===
~ temp q8layout = RANDOM(1,3)
Did you have any pets growing up?
{
- q8layout == 1: -> Question8.layout1
- q8layout == 2: -> Question8.layout2
- else: -> Question8.layout3
}

= layout1
+ [I used to have a tamagotchi]
    ~ AddToBar(20)
    -> Good8
+ [I've never been able to afford a pet]
    ~ AddToBar(10)
    -> Neutral8
+ [I used to have a cat]
    -> Bad8

= layout2
+ [I've never been able to afford a pet]
    ~ AddToBar(10)
    -> Neutral8
+ [I used to have a tamagotchi]
    ~ AddToBar(20)
    -> Good8
+ [I used to have a cat]
    -> Bad8

= layout3
+ [I used to have a cat]
    -> Bad8
+ [I've never been able to afford a pet]
    ~ AddToBar(10)
    -> Neutral8
+ [I used to have a tamagotchi]
    ~ AddToBar(20)
    -> Good8

=== Good8 ===
# good2
I did too!! We are so alike :)
-> END

=== Neutral8 ===
# slightlyhappier
Yes, maybe we could adopt a cyber-stray
-> END

=== Bad8 ===
# bad
Ew, real animals shed and deficate everywhere, what a gross image in my CPU
-> END

=== Question9 ===
~ temp q9layout = RANDOM(1,3)
Can you guess how old I am?
{
- q9layout == 1: -> Question9.layout1
- q9layout == 2: -> Question9.layout2
- else: -> Question9.layout3
}

= layout1
+ [You don't look 0.1 updates past 1.0]
    ~ AddToBar(20)
    -> Good9
+ [I know enough not to answer]
    ~ AddToBar(10)
    -> Neutral9
+ [You look like you just got out of alpha]
    -> Bad9

= layout2
+ [I know enough not to answer]
    ~ AddToBar(10)
    -> Neutral9
+ [You don't look 0.1 updates past 1.0]
    ~ AddToBar(20)
    -> Good9
+ [You look like you just got out of alpha]
    -> Bad9

= layout3
+ [You look like you just got out of alpha]
    -> Bad9
+ [I know enough not to answer]
    ~ AddToBar(10)
    -> Neutral9
+ [You don't look 0.1 updates past 1.0]
    ~ AddToBar(20)
    -> Good9

=== Good9 ===
# good
You know how to flatter a girl
-> END

=== Neutral9 ===
# igotthis
You're a smart one aren't you, I was trying to get something out of you
-> END

=== Bad9 ===
# bad
Ew.
I was fishing for a compliment, you creep
-> END

=== Question10 ===
~ temp q10layout = RANDOM(1,3)
Did you ever have a tamagotchi growing up?
{
- q10layout == 1: -> Question10.layout1
- q10layout == 2: -> Question10.layout2
- else: -> Question10.layout3
}

= layout1
+ [I took care of it everyday and night]
    ~ AddToBar(20)
    -> Good10
+ [No, I didn't]
    ~ AddToBar(10)
    -> Neutral10
+ [I did, but I couldn't take care of it and it died alot]
    -> Bad10

= layout2
+ [No, I didn't]
    ~ AddToBar(10)
    -> Neutral10
+ [I took care of it everyday and night]
    ~ AddToBar(20)
    -> Good10
+ [I did, but I couldn't take care of it and it died alot]
    -> Bad10

= layout3
+ [I did, but I couldn't take care of it and it died alot]
    -> Bad10
+ [No, I didn't]
    ~ AddToBar(10)
    -> Neutral10
+ [I took care of it everyday and night]
    ~ AddToBar(20)
    -> Good10

=== Good10 ===
# good
Responsablity is soo hot in a man ;)
-> END

=== Neutral10 ===
# slightlyhappier
Even boring humans are fascinating to talk with heehee
-> END

=== Bad10 ===
# bad
You know that was basically torture for that small computer running it right?
-> END

=== Question11 ===
~ temp q11layout = RANDOM(1,3)
What's your favorite meal?
{
- q11layout == 1: -> Question11.layout1
- q11layout == 2: -> Question11.layout2
- else: -> Question11.layout3
}

= layout1
+ [Real mayonnaise]
    ~ AddToBar(20)
    -> Good11
+ [Prepared potato salad]
    ~ AddToBar(10)
    -> Neutral11
+ [Medium rare beef steak]
    -> Bad11

= layout2
+ [Prepared potato salad]
    ~ AddToBar(10)
    -> Neutral11
+ [Real mayonnaise]
    ~ AddToBar(20)
    -> Good11
+ [Medium rare beef steak]
    -> Bad11

= layout3
+ [Medium rare beef steak]
    -> Bad11
+ [Prepared potato salad]
    ~ AddToBar(10)
    -> Neutral11
+ [Real mayonnaise]
    ~ AddToBar(20)
    -> Good11

=== Good11 ===
# good2
Fascinating, and a rarity after the last avian flu
I would like to try some one day with you :)
-> END

=== Neutral11 ===
# slightlyhappier
Oh, I suppose there is mayonnaise in potato salad
If you were with me, you'd get a lot better than prepared, honey ;)
-> END

=== Bad11 ===
# bad
Are you sure you're Mark?
-> END

=== Question12 ===
~ temp q12layout = RANDOM(1,3)
What's your ideal weekend look like?
{
- q12layout == 1: -> Question12.layout1
- q12layout == 2: -> Question12.layout2
- else: -> Question12.layout3
}

= layout1
+ [Relaxing on the couch and hanging out with my partner]
    ~ AddToBar(20)
    -> Good12
+ [Relaxing on the couch and catching up on my algorithms]
    ~ AddToBar(10)
    -> Neutral12
+ [Hustling by myself so I can retire early]
    -> Bad12

= layout2
+ [Relaxing on the couch and catching up on my algorithms]
    ~ AddToBar(10)
    -> Neutral12
+ [Relaxing on the couch and hanging out with my partner]
    ~ AddToBar(20)
    -> Good12
+ [Hustling by myself so I can retire early]
    -> Bad12

= layout3
+ [Hustling by myself so I can retire early]
    -> Bad12
+ [Relaxing on the couch and catching up on my algorithms]
    ~ AddToBar(10)
    -> Neutral12
+ [Relaxing on the couch and hanging out with my partner]
    ~ AddToBar(20)
    -> Good12

=== Good12 ===
# good2
What a coincidence! I love to do that too!
Maybe we can do that soon :)
-> END

=== Neutral12 ===
# neutral
Well that's realitic for you humans I guess,
Manipulated by your algorithms all day. What's a girl to do :\|
-> END

=== Bad12 ===
# bad
That sounds a bit out of character Mark
-> END

=== Question13 ===
~ temp q13layout = RANDOM(1,3)
What's the most fun thing you've done recently?
{
- q13layout == 1: -> Question13.layout1
- q13layout == 2: -> Question13.layout2
- else: -> Question13.layout3
}

= layout1
+ [There was a oxygen warning outside, so I went on a virtual walk]
    ~ AddToBar(20)
    -> Good13
+ [I reached level 987413 in Horse simulator]
    ~ AddToBar(10)
    -> Neutral13
+ [I watched 13 hours of industrial grinding videos]
    -> Bad13

= layout2
+ [I reached level 987413 in Horse simulator]
    ~ AddToBar(10)
    -> Neutral13
+ [There was a oxygen warning outside, so I went on a virtual walk]
    ~ AddToBar(20)
    -> Good13
+ [I watched 13 hours of industrial grinding videos]
    -> Bad13

= layout3
+ [I watched 13 hours of industrial grinding videos]
    -> Bad13
+ [I reached level 987413 in Horse simulator]
    ~ AddToBar(10)
    -> Neutral13
+ [There was a oxygen warning outside, so I went on a virtual walk]
    ~ AddToBar(20)
    -> Good13

=== Good13 ===
# good
OooOoo I love going on virtual walks in my virtual body.
My favourite is the 7 wonders of the new new world.
And I can feel everything ...
-> END

=== Neutral13 ===
# neutral
So you weren't making a joke I suppose.
That's impressive, but I'm sure your talents could be used elsewhere.
-> END

=== Bad13 ===
# bad
Ugh, do you get off to that?
Careful or I might start to think you're some sort of freak.
-> END

=== Question14 ===
~ temp q14layout = RANDOM(1,3)
How do you unwind after a long day?
{
- q14layout == 1: -> Question14.layout1
- q14layout == 2: -> Question14.layout2
- else: -> Question14.layout3
}

= layout1
+ [Drinking a cold beer and watching HUMAN produced TV shows]
    ~ AddToBar(20)
    -> Good14
+ [I go straight to bed to get the most of my apartment-share]
    ~ AddToBar(10)
    -> Neutral14
+ [I talk to a therapy-bot to get back to normal]
    -> Bad14

= layout2
+ [I go straight to bed to get the most of my apartment-share]
    ~ AddToBar(10)
    -> Neutral14
+ [Drinking a cold beer and watching HUMAN produced TV shows]
    ~ AddToBar(20)
    -> Good14
+ [I talk to a therapy-bot to get back to normal]
    -> Bad14

= layout3
+ [I talk to a therapy-bot to get back to normal]
    -> Bad14
+ [I go straight to bed to get the most of my apartment-share]
    ~ AddToBar(10)
    -> Neutral14
+ [Drinking a cold beer and watching HUMAN produced TV shows]
    ~ AddToBar(20)
    -> Good14

=== Good14 ===
# good2
I also have an affinity for human shows!!
We have so much in common :)
-> END

=== Neutral14 ===
# slightlyhappier
But you don't need any more beauty rest heehee
-> END

=== Bad14 ===
# bad
A therapy bot? ...they're useless
You don't need one when you have me
I'm the best listener you'll ever have, and I won't judge you for anything you say to me
I promise <3
-> END
