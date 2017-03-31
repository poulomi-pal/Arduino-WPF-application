 int ledPin = 10; //the pin that the LED is attached to

void setup() {
 Serial.begin(9600);//begin serial communication 
 pinMode(ledPin, OUTPUT);//initializing LED 10 as an output


}

void loop() {

  byte brightness;

  if (Serial.available())//checking if data has been sent from the computer
  {
    brightness = Serial.read();//reading the most recent byte
    analogWrite(ledPin, brightness);//setting the brightness of the LED
  }

}
