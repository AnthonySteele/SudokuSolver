Code for a simple Sudoku solver in C#.

This program works in a very simple, brute force way: it recursively tries all possible number in all free cells, until it finds one combination that meets all of the constraints of the Sudoku board (i.e. that each number is unique in the row, column and nonstant)

It may sound like there will be a lot of branches to this search tree, and enumerating them all will take a lot of time, but this is really not so. Branches are discarded as soon as they break the rules, and the entire search space can be walked for a typical newspaper puzzle in about 0.5 seconds. Almost empty boards can take longer, however note that you won't find these in newspapers - the rules for newspaper puzzles is that there is one and only one solution to be found.
There are more subtle ways to solve Sudoku boards, which use rules that behave more like human strategies and only work sometimes, and these are the ways that people generally come up with first. But when the brute force method always gives the right answer, and is simple and fast, why bother?

- Anthony Steele