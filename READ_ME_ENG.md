This program is in the C # programming language,
produces simulation of a single-processor computing system of operational processing,
a single two-level resource management algorithm for uniprocessor systems,
where tasks for processing appear large and slow or small and fast.
Levels of a single two-level resource management algorithm:

1) SPT algorithm level - performs quick tasks in the first place.
The main efficiency criterion is the average service time of tasks,
where moving forward of a task with a shorter solution time leads to a decrease in the average task service time;
2) the level of the RR algorithm reveals short and long work directly during the computational
SPT algorithm process to take advantage of planning principles based on this algorithm.
To service a separate application, a constant time slot is allocated.
sufficient to perform several thousand operations.
If the work was done for a time slice, it leaves the system.
Otherwise, it again arrives at the end of the queue and waits for the next quantum of processor time to be provided to it.

The main module UpravlenieResursamiOdnoprocessornihSystem contains the only main function Main
- fully performing this task.