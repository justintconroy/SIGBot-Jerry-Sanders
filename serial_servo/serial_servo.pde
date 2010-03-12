#include <Servo.h>

// Driving motors
Servo motorAServo;
Servo motorBServo;
Servo motorCServo;
Servo motorDServo;

Servo waistServo;
Servo shoulderServo;
Servo elbowServo;
Servo gripServo;
Servo cutterServo;



// array to  
int serInBytes[80];
int serInIndx = 0;

// Pins for the arm servos
int servoWaistPin = 3;
int servoShoulderPin = 5;
int servoElbowPin = 6;
int servoGripPin = 9;
int servoCutterPin = 10;

// Pins for the driving motors
int motorAPin = 14;
int motorBPin = 15;
int motorCPin = 16;
int motorDPin = 17;
 
void setup()
{
  Serial.begin(9600);         // connect to the serial port
  
  // attach to motors
  motorAServo.attach(motorAPin);
  motorBServo.attach(motorBPin);
  motorCServo.attach(motorCPin);
  motorDServo.attach(motorDPin);
  
 // attach to arm servos
  waistServo.attach(servoWaistPin);
  shoulderServo.attach(servoShoulderPin);
  elbowServo.attach(servoElbowPin);
  gripServo.attach(servoGripPin);
  cutterServo.attach(servoCutterPin);
  
  Serial.println("servos_ready");
}
 
void loop()
{
  //read the serial port and create a string out of what you read
  //readSerialString(serInBytes, serInIndx);
  readSerialString();
  
  //try to print out collected information. it will do it only if there actually is some info.
  setServoValues();
 
}
 
void readSerialString() 
{
  int sb = 0;  
  int readFlag = 0;
  int incoming = Serial.read();
    
  // Do while we don't have a line feed or carriage return
  while (Serial.available() > 0)
  {
    sb = Serial.read();    
    delay(1);
          
    if (sb == 253)  // start byte
    {
      //Serial.print("Recieved start byte.\n");
      readFlag = 1;
    }
    else if (sb == 255)
    {
      //Serial.print("Recieved stop byte.\n");
      readFlag = 0;
      break;
    }
    else
    {
      //Serial.print("Recieved regular text.\n");
      if (readFlag)
      {
        serInBytes[serInIndx] = sb;
        serInIndx++;
      }
    }
  }  
}


void setServoValues()
{
  // Set driving motor values
  motorAServo.write(serInBytes[0]);
  motorBServo.write(serInBytes[1]);
  motorCServo.write(serInBytes[2]);
  motorDServo.write(serInBytes[3]);
  
  waistServo.write(serInBytes[4]);
  shoulderServo.write(serInBytes[5]);
  elbowServo.write(serInBytes[6]);
  
  int gripPosition, cutterPosition;
  int gripOpen = 70, gripClosed = 150;
  int cutterOpen = 70, cutterClosed = 0;
   
  
  switch (serInBytes[7]) {
    case 0:
      gripPosition = gripClosed;
      cutterPosition = cutterClosed;
      break;
    case 1:
      gripPosition = gripOpen;
      cutterPosition = cutterClosed;
      break;
    case 2:
      gripPosition = gripClosed;
      cutterPosition = cutterOpen;
      break;
    case 3:
      gripPosition = gripOpen;
      cutterPosition = cutterClosed;
      break;
  }
  
  gripServo.write(gripPosition);
  cutterServo.write(cutterPosition); 
}
