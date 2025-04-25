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

%X является дедушкой Y
grand_pa(X, Y) :-
    man(X),              
    parent(X, Z),          
    parent(Z, Y),
    !.          

%Дедушки X
grand_pas(X) :-
    grand_pa(Y, X),        
    print(Y),
    nl,
    fail.   


%X является бабушкой Y
grandma(X, Y) :-
    woman(X),          
    parent(X, Rod),
    parent(Rod, Y), вер
    man(Y).

%X и Y бабушка и внук и наоборот
grand_ma_and_son(X, Y) :-
    (grandma(X, Y) ; grandma(Y, X)),
    X \= Y.   


%общий родитель есть?
sestrabrat(X, Y) :-
    parent(Z, X),
    parent(Z, Y),
    X \= Y.

%X является племянником Y
plemyannik(X, Y) :-
    man(X),           
    parent(Rod, X),    
    sestrabrat(Y, Rod),   
    Y \= Rod.          

%Племянники X
plemyanniks(X) :-
    plemyannik(Y, X),         
    print(Y),
    nl,
    fail. 
                      