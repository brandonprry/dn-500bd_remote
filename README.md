# Denon DN-500BD Software Remote
I lost my DN-500BD remote and couldn't use the box to play blurays, but I noticed that you can drive the player from either Serial or Ethernet. This remote can drive the bluray player over a serial interface with basic functionality such as up/down/left/right, enter, and home. If you have a particular feature you need, please submit an issue. Adapting to support IP should be simple but I only need serial for my purposes.

To build, cd to project directory.
```
dotnet restore
dotnet build
sudo dotnet run
```
Type the USB device (/dev/ttyUSB0) into the text box and click connect. The buttons can now drive the player over the serial interface.

![image](https://github.com/user-attachments/assets/2b691490-6dd2-4d99-94e2-442389ff2a86)

