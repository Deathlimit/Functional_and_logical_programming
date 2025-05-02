read_list(List) :- 
    write('Input list:'),
    read(List).

logic_last(List, Result) :-
    last_min_position(List, Pos), 
    N is Pos - 1,                 
    take_before(List, N, Result). 


last_min_position([H|T], Pos) :-
    last_min_pos(T, H, 1, 1, Pos). 

last_min_pos([], _, _, LastPos, LastPos).
last_min_pos([H|T], CurrentMin, CurrentPos, CurrentLastPos, Pos) :-
    NextPos is CurrentPos + 1,
    (H =< CurrentMin -> 
	NewMin = H, NewLastPos = NextPos;
	NewMin = CurrentMin, NewLastPos = CurrentLastPos),
    last_min_pos(T, NewMin, NextPos, NewLastPos, Pos).


take_before(_, 0, []):- !.             
take_before([H|T], N, [H|Acc]):-
    N1 is N - 1,
    take_before(T, N1, Acc).


output_result(Result) :-
    write('Before last min: '),
    write(Result), nl.


main1 :-
    read_list(List),       
    logic_last(List, Result),  
    output_result(Result). 

%------------------------------------------------------------------


logic_first(List, Result) :-
    first_min_position(List, Pos), 
    N is Pos - 1,                 
    take_before(List, N, Result). 


first_min_position([H|T], Pos) :-
    first_min_pos(T, H, 2, 1, Pos). 

first_min_pos([], _, _, PosMin, PosMin).
first_min_pos([H|T], CurrentMin, CurrentPos, PosMin, FinalPos) :-
    (H < CurrentMin -> 
	NewMin = H, NewPosMin = CurrentPos;  
	NewMin = CurrentMin, NewPosMin = PosMin),
    NextPos is CurrentPos + 1,
    first_min_pos(T, NewMin, NextPos, NewPosMin, FinalPos).


output_result2(Result) :-
    write('Before first min: '),
    write(Result), nl.


main2 :-
    read_list(List),        
    logic_first(List, Result),  
    output_result2(Result). 



%-----------------------------------------------------------------------


sdvig_left([], []).     
sdvig_left([X], [X]).       
sdvig_left([H|T], Result) :-
    append(T, [H], Result).        


output_result3(Result) :-
    write('Sdvig resut: '),
    write(Result), nl.


main3:-
    read_list(List),          
    sdvig_left(List, Result),
    output_result3(Result).    



%-----------------------------------------------------------------------

surnames([borisov, ivanov, semenov]).
professions([slesapb, tokapb, svarshik]).


solution(SlesaPb, TokaPb, Svarshik) :-
    permutation([SlesaPb, TokaPb, Svarshik], [borisov, ivanov, semenov]),
    SlesaPb \= borisov,              
    Svarshik = semenov,                 
    SlesaPb = ivanov.         

start :-
    solution(SlesaPb, TokaPb, Svarshik),
    format('SlesaPb: ~w~nTokaPb: ~w~nSvarshik: ~w~n', [SlesaPb, TokaPb, Svarshik]).

