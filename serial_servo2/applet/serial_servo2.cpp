#include <Servo.h>
#include "WProgram.h"
void setup();
void loop();
void readSerialString ();
void printSerialString();
Servo panServo;
Servo tiltServo;

// SERIAL PORT VARS

//int  serIn;             // var that will hold the bytes-in read from the serialBuffer
char serInString[80];  // array that will hold command string (though we'll only need length 3)
int serInIndx = 0;

// SERVO VARS

int icount = 0;
long pval = 0;
long tval = 0;

int servoPanPin = 14;     // Control pin for servo motor
int servoTiltPin = 10;     // Control pin for servo motor

void setup() {

  Serial.begin(9600);         // connect to the serial port

  panServo.attach(servoPanPin);  
  tiltServo.attach(servoTiltPin);
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
  printSerialString();

}

void readSerialString () {
    int sb = 0;  
    int readFlag = 0;
    
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

      if(serInString[0] == 'P') // first char should be P or T
      {
      Serial.print("Pan!");
  
        // Nigel Method
        pval += (serInString[1]-48)*100;
        pval += (serInString[2]-48)*10;
        pval += (serInString[3]-48)*1;
  
      Serial.println();
      Serial.print("Value to pan servo: ");
      Serial.println(pval, DEC);
      
      panServo.write(pval);
      //analogWrite(servoPanPin,pval);

      }
  
      if(serInString[0] == 'T')
      {
      Serial.print("Tilt!");
  
      tval += (serInString[1]-48)*100;
      tval += (serInString[2]-48)*10;
      tval += (serInString[3]-48)*1;
  
      Serial.println();
      Serial.print("Value to tilt servo: ");
      Serial.println(tval, DEC);
      
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

int main(void)
{
	init();

	setup();
    
	for (;;)
		loop();
        
	return 0;
}

