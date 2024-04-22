Approach
The input can be presented as a graph where each node points to its child (or children) who present a dependency for a parent node.
If a child has its dependencies too, they are sub dependencies for a parent node and are added to dependency list as well while traversing through the graph.
This point leads to implementation of a recursive algorithm.

Algorithm 
For each listed in input (top level) node it goes through all its direct dependency and recursively stores their sub dependencies in HashSet of a parent node

Data structures
To present the input I used Dictionary<string, List<string>> where Key is a node name and Value is a list of direct dependencies.
To store a result I used Dictionary<string, HashSet<string>> since multiple references for a same node might exist and storing them in HashSet<string>
helps to exclude duplications.

Circular dependencies case
When circular dependencies occurred, it might lead to a self-referencing for some nodes: if A->B and B->A, list of references for A is A, B, A (since B depends in A)
Logically this presents A->A dependencies which is trivial and is excluded from a result list (line 37 in DependenciesFinder class)

Assumptions
- each line in an input file is a string having space ' ' delimited tokens 
- input file is in a valid format so no additional check done
- user cam play with content of input.txt file to change the input

