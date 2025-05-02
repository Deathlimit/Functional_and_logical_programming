minDigitDown(N, Min):- minDigitloop(N, 10, Min).
minDigitloop(0, CurrMin, CurrMin):- !.
minDigitloop(N, CurrMin, Min):- 
	Cifr is N mod 10, 
	NewMin is min(Cifr, CurrMin),
	N1 is N div 10,
	minDigitloop(N1, NewMin, Min).

minDigitUp(N, Min):-
	N < 10,
	Min is N.
minDigitUp(N, Min):-
	Cifr is N mod 10,
	N1 is N div 10,
	minDigitUp(N1, NewMin),
	Min is min(Cifr, NewMin).



multNotFiveDown(N, Mult):- multNotFiveloop(N, 1, Mult).
multNotFiveloop(0, Acc, Acc):- !.
multNotFiveloop(N, Acc, Mult):-
    Cifr is N mod 10,
    N1 is N div 10,
    (Cifr =\= 5 -> NewAcc is Acc * Cifr ; NewAcc is Acc),
    multNotFiveloop(N1, NewAcc, Mult).


multNotFiveUp(N, Mult):-
	N<10,
	(N mod 5 =\= 0 -> Mult is N ; Mult = 1).

multNotFiveUp(N, Mult):-
	Cifr is N mod 10,
	N1 is N div 10,
	multNotFiveUp(N1, NewMult),
	(Cifr mod 5 =\= 0 -> Mult is NewMult * Cifr ; Mult = NewMult).


 gcd(0, N, N) :- !.
 gcd(N, 0, N) :- !.
 gcd(N1, N2, Result) :-
     N1 >= N2 -> Nod is N1 mod N2, gcd(Nod, N2, Result);
     gcd(N2, N1, Result).