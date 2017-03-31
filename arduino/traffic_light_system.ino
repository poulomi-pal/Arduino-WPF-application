void setup() {
  // put your setup code here, to run once:
  
pinMode (10,OUTPUT); //red

pinMode (9,OUTPUT); //yellow

pinMode (8,OUTPUT); //blue

}



void loop() {
  // put your main code here, to run repeatedly:

  digitalWrite (10,HIGH);//red on for 10 seconds
  delay (10000);
  digitalWrite (10,LOW);
  digitalWrite (9,HIGH);//yellow on for 2 seconds
  delay (2000);
  digitalWrite (9,LOW);
  digitalWrite (8,HIGH);//blue on for 10 seconds
  delay (10000 );
  digitalWrite (8,LOW);
 
 }   
  


