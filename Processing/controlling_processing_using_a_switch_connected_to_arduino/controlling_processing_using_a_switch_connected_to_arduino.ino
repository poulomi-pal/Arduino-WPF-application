
int switchPin = 13           ;   //switch connected to pin 13

void setup() {
  pinMode(switchPin, INPUT);  //Sets pin 13 as input
  Serial.begin(9600);    //Starts serial communication at 9600bps
}

void loop() {
  if (digitalRead(switchPin) == HIGH)     //if the switch is ON,
  {
    Serial.write(1);                     //sends 1 to Processing
  }
  else {                                //if switch is OFF
    Serial.write(0);                   //sends 0 to Processing       
  }
  delay(100);                        //Waits for 100miliseconds

}
