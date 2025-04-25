character(harry_potter, 1, 1, 0, 1, 0).
character(hermione_granger, 1, 1, 0, 1, 0).
character(draco_malfoy, 1, 1, 1, 0, 1).
character(voldemort, 1, 0, 0, 0, 1).


question1(X1) :-
    write("Does the character belong to the magical world?"), nl,
    write("1. Yes"), nl,
    write("0. No"), nl,
    read(X1).

question2(X2) :-
    write("Is the character a Hogwarts student?"), nl,
    write("1. Yes"), nl,
    write("0. No"), nl,
    read(X2).

question3(X3) :-
    write("Is the character related to the Malfoy family?"), nl,
    write("1. Yes"), nl,
    write("0. No"), nl,
    read(X3).

question4(X4) :-
    write("Is the character a member of the Order of the Phoenix?"), nl,
    write("1. Yes"), nl,
    write("0. No"), nl,
    read(X4).

question5(X5) :-
    write("Does the character use dark magic?"), nl,
    write("1. Yes"), nl,
    write("0. No"), nl,
    read(X5).


start :-
    question1(Q1),
    question2(Q2),
    question3(Q3),
    question4(Q4),
    question5(Q5),
    character(Name, Q1, Q2, Q3, Q4, Q5),
    write("Your character: "), write(Name), nl.

start :-
    write("Character not found!"), nl.