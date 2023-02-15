# CW6: Databases

Name: Zach Coomer

Date: 02/14/2023

## Description

This is a WPF application that is linked to a Windows Access Database. It is used to show the contents of the two tables: Employees and Assets. This is the first look at Databases in CSCI 352.

## Challenges

* The biggest challenge I faced was figuring out how to link the database to WPF with the Connection String. Following the steps in the assignment, gives you a differenct Connection String which is not the one that works.
Finding the correct Connection String still has some prunning required. This portion of the assignment required much more time than the rest for me. 

* Another challenge is finding a way to list all of the information. Microsoft's guides are not easily understandable, maybe with much more base knowlegdge of WPF functionality it would make more sense.

* Saving or adding rows of data took quite a bit of working, it seems as if the freedom of choice of how to present the data is also a burden in just the crazy ways the code can be implemented.

## Design Decisions

* I decided to use DataGrid instead of a TextBox for cleaner output of information. I wanted everything to be organized and labeled. 

* I opted for new windows to open when adding Employees or Assets. 

## Files Required

* MainWindow.xaml - The WPF file that determines the user facing output.

* MainWindow.xaml.cs - The C# file that provides the workings of the corresponding WPF file.

* AddEmployeeWindow.xaml - WPF file that allows user to input employee addition information

* AddEmployeeWindow.xaml.cs - C# file that adds employee information to database

* AddAssetWindow.xaml - WPF file that allows user to input asset addition information

* AddAssetWindow.xaml.cs - C# file that adds asset information to database

* ZC CW6 DatabasesFH.accdb - Microsoft Access database file

* README.md
	- Here I list brief information about the program and topics related to the program.

## How to Run

This program is currently intended to be run in Visual Studios 2022.

## Bugs

Program will crash if you try and add an asset that is not tied to an established EmployeeID.

## Extra Credit

I added the ability to add Employees and Assets
