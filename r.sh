# Name : Hoang Nguyen
# Email : Hnguyen1193@csu.fullerton.edu
# Course : CPSC 223N

echo "First Remove Old Binary Files"
rm *.dll
rm *.exe

echo "Compile DirectionLogic.cs to create the file: logic.dll"
mcs -target:library DirectionLogic.cs -r:System.Drawing.dll -out:logic.dll

echo "Compile catandmouseui.cs to create the file: UI.dll"
mcs -target:library -r:System.Windows.Forms.dll -r:System.Drawing.dll -r:logic.dll -out:UI.dll catandmouseui.cs

echo "Compile catandmouse.cs main method to create executable files"
mcs -r:System -r:System.Windows.Forms -r:UI.dll -r:logic.dll -out:final.exe catandmouse.cs

echo "View the list of files in current folder."
ls -l

echo "Run the assigment 6 program."
./final.exe

echo "Remove binary files"
rm *.dll
rm *.exe

echo "the script has terminated."