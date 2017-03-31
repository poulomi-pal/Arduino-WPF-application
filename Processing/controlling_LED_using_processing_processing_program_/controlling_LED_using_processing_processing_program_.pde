import processing.serial.*;

Serial myPort;

void setup()
{
  size(200,200);
  myPort = new Serial(this,"COM3",9600);
}

void draw() {
  background(255,0,0);//sets the background color(color of window) to red
  if (mousePressed == true) 
  {                           //if we clicked in the window
   myPort.write('1');         //send a 1
   println("1");   
  } else 
  {                           //otherwise
  myPort.write('0');          //send a 0
  }   
}