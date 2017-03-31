import processing.serial.*;
Serial myPort;

void setup()
{
  size (256,150); //window size
  myPort = new Serial(this,"COM3",9600); //For me the serial port is COM3
}


void draw()
{//drawing a gradient from black to white
  for(int j = 0; j < 256; j++ )
  {
    stroke (j);
    line (j, 0, j, 150);
  } 
  myPort.write(mouseX); //writing the current mouse position in the X axis to the serial port as a single byte 
}
  