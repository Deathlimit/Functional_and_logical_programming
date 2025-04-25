%X является дочерью Y
daughter(X, Y) :-
    woman(X),
    parent(Y, X).

%X является дочерью
daughter(X) :-
    woman(X),
    parent(Z, X),
    woman(Z).

%X является женой Y
wife(X, Y) :-
    woman(X),
    man(Y),
    parent(X, Child),
    parent(Y, Child),
    !.

%Жена X
wife(X) :-
    man(X),
    wife(Y, X),
    print(Y),
    !.