import processing.serial.*;

Serial myPort;
int data;

void setup()
{
  size (500,500);   // size of the window
  myPort = new Serial(this, "COM3", 9600); //I know my serial port is COM3. For others it might differ
}

void draw()
{
  if (myPort.available() > 0) //if data is received
  {
    data = myPort.read();  // store it to the variable data
  }
  background(255);
  if (data == 0)
  {
    fill(0);     // for 0 received turns the circle to black color
  }
  else {
    fill(240,0,240); // for 1 received turns the circle to pink color
  }
  ellipse(250,250,300,300);
}
  
  