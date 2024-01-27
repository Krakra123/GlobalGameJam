-> start_knot

=== start_knot ===
Hello from the start knot!
Now we'll go to knot 2!
-> knot_2

=== knot_2 ===
Hello from knot 2!
Time for a personality test.
Red pill or blue pill?
*** Red pill
-> red_pill
*** Blue pill
-> blue_pill

=== red_pill ===
My god, how brave!
-> continue_conversation

=== blue_pill
Bold move, my friend
-> continue_conversation

=== continue_conversation
Alright. You have answered my question.
{ red_pill:
You chose the red pill. But I'm still not sure I can trust you
}
{ not red_pill: -> no_red_pill_comment}
->END

=== no_red_pill_comment ===
You didn't choose the red pill. I'm not sure I can trust you.
-> END