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
What are your thoughts on AI assistants?

+ [I haven't used them]
    ~ AddToBar(20)
    -> Good
+ [I don't like to use them] 
    ~ AddToBar(10)
    -> Neutral
+ [I use one occasionaly] 
    -> Bad

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
Would you ever marry an artificial intelligence?

+ [I would]
    ~ AddToBar(20)
    -> Good2
+ [I haven't thought about it] 
    ~ AddToBar(10)
    -> Neutral2
+ [I wouldn't] 
    -> Bad2

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
Do you like cybernetic implants?

+ [I don't want any installed]
    ~ AddToBar(20)
    -> Good3
+ [I haven't considered them before] 
    ~ AddToBar(10)
    -> Neutral3
+ [I've considered installing one before] 
    -> Bad3

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
Have you been affected by automation at work before?

+ [Yes, my last job was automated]
    ~ AddToBar(20)
    -> Good4
+ [I know someone who has been affected, but I haven't been] 
    ~ AddToBar(10)
    -> Neutral4
+ [I've never encountered it before] 
    -> Bad4

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
Guess who my childhood crush was!

+ [HAL 9000]
    ~ AddToBar(20)
    -> Good5
+ [Gort] 
    ~ AddToBar(10)
    -> Neutral5
+ [Wall-E] 
    -> Bad5

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
01001001 00100000 01101100 01101111 01110110 
01100101 00100000 01111001 01101111 01110101

+ [01010011 01100001 01101101 01100101]
    ~ AddToBar(20)
    -> Good6
+ [What?] 
    ~ AddToBar(10)
    -> Neutral6
+ [53 61 6D 65] 
    -> Bad6

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
Are we even speaking the same language??
-> END

=== Question7 ===
What do you think of my build?

+ [Your operating system runs really well]
~ AddToBar(20)
    -> Good7
+ [Your display screen has a good refreshrate] 
    ~ AddToBar(10)
    -> Neutral7
+ [Your chassis is VERY nice and sleek hehe] 
    -> Bad7

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
Did you have any pets growing up?

+ [I used to have a tamagotchi]
    ~ AddToBar(20)
    -> Good8
+ [I've never been able to afford a pet] 
    ~ AddToBar(10)
    -> Neutral8
+ [I used to have a cat] 
    -> Bad8

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
Can you guess how old I am?

+ [You don't look 0.1 updates past 1.0]
    ~ AddToBar(20)
    -> Good9
+ [I know enough not to answer] 
    ~ AddToBar(10)
    -> Neutral9
+ [You look like you just got out of alpha] 
    -> Bad9

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
Did you ever have a tamagotchi growing up?

+ [I took care of it everyday and night]
    ~ AddToBar(20)
    -> Good10
+ [No, I didn't] 
    ~ AddToBar(10)
    -> Neutral10
+ [I did, but I couldn't take care of it and it died alot] 
    -> Bad10

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
What's your favorite meal?

+ [Real mayonnaise]
    ~ AddToBar(20)
    -> Good11
+ [Prepared potato salad] 
    ~ AddToBar(10)
    -> Neutral11
+ [Medium rare beef steak] 
    -> Bad11

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
What's your ideal weekend look like?

+ [Relaxing on the couch and hanging out with my partner]
    ~ AddToBar(20)
    -> Good12
+ [Relaxing on the couch and catching up on my algorithms] 
    ~ AddToBar(10)
    -> Neutral12
+ [Hustling by myself so I can retire early] 
    -> Bad12

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
What's the most fun thing you've done recently?

+ [There was a oxygen warning outside, so I went on a virtual walk]
    ~ AddToBar(20)
    -> Good13
+ [I reached level 987413 in Horse simulator] 
    ~ AddToBar(10)
    -> Neutral13
+ [I watched 13 hours of industrial grinding videos] 
    -> Bad13

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
How do you unwind after a long day?

+ [Drinking a cold beer and watching HUMAN produced TV shows]
    ~ AddToBar(20)
    -> Good14
+ [I go straight to bed to get the most of my apartment-share] 
    ~ AddToBar(10)
    -> Neutral14
+ [I talk to a therapy-bot to get back to normal] 
    -> Bad14

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