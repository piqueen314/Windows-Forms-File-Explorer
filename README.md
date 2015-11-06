# Windows-Forms-File-Explorer
A simple file explorer program to showcase my c# and win forms skills 


This is a riff of a coding challege I did while interviewing at a company.
The criteria for the code I had to write was something like
-the user should be able to select any file he or she wants, 
but the file you need to read containg fake bank data is located in C:/Users/User_Name/MyDocuments
-make a program that lets the user see the data in this file

I utilized the win form tree view control and recursion to list all the directoies, 
with the first node being located at C:/Users/User_Name/MyDocuments.

However the user can enter any directory location for the first node,
if they wish to overwrite the default.

