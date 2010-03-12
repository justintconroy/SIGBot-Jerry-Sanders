#include <Servo.h>

Servo panServo;
Servo tiltServo;
Servo cutterServo;
Servo elbowServo;
Servo clampServo;
 
// SERIAL PORT VARS
 
//int  serIn;             // var that will hold the bytes-in read from the serialBuffer
char serInString[80];  // array that will hold command string (though we'll only need length 3)
int serInIndx = 0;
 
// SERVO VARS
 
int icount = 0;
long pval = 0;
long tval = 0;
long cval = 0;
long eval = 0;
long uval = 0;
 
int servoPanPin = 3;     // Control pin for servo motor
int servoTiltPin = 10;     // Control pin for servo motor
int servoCutterPin = 12;
int servoElbowPin = 13;
int servoClampPin = 11;


 
void setup() {
 
  Serial.begin(9600);         // connect to the serial port
 
  panServo.attach(servoPanPin);  //attach pin to servo control
  tiltServo.attach(servoTiltPin);
  elbowServo.attach(servoElbowPin);
  clampServo.attach(servoClampPin);
  cutterServo.attach(servoCutterPin);
  
  //analogWrite(servoTiltPin, 127);
  /*
  pinMode(2, OUTPUT);
  pinMode(3, OUTPUT);
  pinMode(4, OUTPUT);
  digitalWrite(2,LOW);
  digitalWrite(3,HIGH);
  digitalWrite(4,LOW);
  */
    
  
  Serial.println("servos_ready");
}
 
void loop() {
 
  //read the serial port and create a string out of what you read
  //readSerialString(serInString, serInIndx);
  readSerialString();
  
  //try to print out collected information. it will do it only if there actually is some info.
  setServoValues();
 
}
 
void readSerialString () {
    int sb = 0;  
    int readFlag = 0;
    int incoming = Serial.read();
    
    // Do while we don't have a line feed or carriage return
    while (Serial.available() > 0)
    {
        sb = Serial.read();    
        delay(1);
         
      //Serial.print(sb);
      //Serial.println(" recieved.");
       
      if (sb == 253)  // start byte
      {
        //Serial.print("Recieved start byte.\n");
        //serInIndx = 0;
        readFlag = 1;
      }
      else if (sb == 255)
      {
        //Serial.print("Recieved stop byte.\n");
        readFlag = 0;
        //serInString[serInIndx] = '\0';
        //serInIndx++;
        break;
      }
      else
      {
        //Serial.print("Recieved regular text.\n");
        if (readFlag)
        {
          serInString[serInIndx] = sb;
          serInIndx++;
        }
      }
    }  
}
void setServoValues(){

  
/*Servo panServo;
Servo tiltServo;
Servo cutterServo;
Servo elbowServo;
Servo clampServo;  */

  int pos;
  //panServo.write(serInString[5]);
  for(pos = 0; pos < 180; pos += 1)  // goes from 0 degrees to 180 degrees 
  {                                  // in steps of 1 degree 
    panServo.write(pos);              // tell servo to go to position in variable 'pos' 
    delay(15);                       // waits 15ms for the servo to reach the position 
  } 
  for(pos = 180; pos>=1; pos-=1)     // goes from 180 degrees to 0 degrees 
  {                                
    panServo.write(pos);              // tell servo to go to position in variable 'pos' 
    delay(15);                       // waits 15ms for the servo to reach the position 
  } 
      
  tiltServo.write(serInString[6]);
  elbowServo.write(serInString[7]);
  
  int clampPosition, cutterPosition;
  int clampOpen = 70, clampClosed = 150;
  int cutterOpen = 70, cutterClosed = 0;
   
  
  switch (serInString[8]) {
    case 0:
      clampPosition = clampClosed;
      cutterPosition = cutterClosed;
      break;
    case 1:
      clampPosition = clampOpen;
      cutterPosition = cutterClosed;
      break;
    case 2:
      clampPosition = clampClosed;
      cutterPosition = cutterOpen;
      break;
    case 3:
      clampPosition = clampOpen;
      cutterPosition = cutterClosed;
      break;
  }
  
  clampServo.write(clampPosition);
  cutterServo.write(cutterPosition);
  


  
}




/* 
//print the string all in one time
//this func as well uses global variables
void printSerialString() {
   if( serInIndx > 0) {
     int serOutIndx;
      Serial.print("Command: ");    
      //loop through all bytes in the array and print them out
      for(serOutIndx=0; serOutIndx < serInIndx; serOutIndx++) {
          Serial.print( serInString[serOutIndx] );    //print out the byte at the specified index
      }
 
      if(serInString[0] == '1') // first char should be P or T
      {
      Serial.print("Pan!");
  
        // Nigel Method
        pval += (serInString[1]-48)*100;
        pval += (serInString[2]-48)*10;
        pval += (serInString[3]-48)*1;
  
      Serial.println();
      Serial.print("Value to pan servo: ");
      Serial.print(pval, DEC);
      
      panServo.write(pval);
      //analogWrite(servoPanPin,pval);
 
      }
  
      if(serInString[0] == '2')
      {
      Serial.print("Tilt!");
  
      tval += (serInString[1]-48)*100;
      tval += (serInString[2]-48)*10;
      tval += (serInString[3]-48)*1;
  
      Serial.println();
      Serial.print("Value to tilt servo: ");
      Serial.print(tval, DEC);
      
      tiltServo.write(tval);
      //analogWrite(10, tval);
      
      }      
      
      Serial.println();
      // Re-init
      serInIndx = 0;
      icount = 0;
      pval = 0;
      tval = 0 ;
      
      
   }
 
}
*/
