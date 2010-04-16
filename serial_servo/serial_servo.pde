#include <Servo.h>

#define GRIPOPEN 70
#define GRIPCLOSED 150
#define CUTTEROPEN 70
#define CUTTERCLOSED 0

int timeint = 0;
int printflag = 1;

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

int readFlag = 0;

int serialCount;
 
void setup()
{
  Serial.begin(115200);         // connect to the serial port
  
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
  
  // Set driving motor values
  motorAServo.write(90-5);
  motorBServo.write(90+5);
  motorCServo.write(90+5);
  motorDServo.write(90);
  
  // Set arm servos
  waistServo.write(90);
  shoulderServo.write(74);
  elbowServo.write(90);
  
  gripServo.write(GRIPCLOSED);
  cutterServo.write(CUTTERCLOSED); 
  
  
  Serial.println("servos_ready");
}
 
void loop()
{
//  if (serialStatus())
  {
    readSerialString();
    setServoValues();
  } 
}
 
void readSerialString() 
{
  int sb = 0;
  readFlag = 0;

  while (Serial.available() > 0)
  {
    sb = Serial.read();    
    delay(1);
//    Serial.println(sb);
          
    if (sb == 253)  // start byte
    {
//      Serial.println("Recieved start byte.");
      readFlag = 1;
      serialCount = 0;
    }
    else if (sb == 255)
    {
//      Serial.println("Recieved stop byte.");
      readFlag = 0;
      printflag = 1;
      serInIndx = 0;
      break;
    }
    else
    {
      //Serial.print("Recieved regular text.\n");
      //Serial.print(sb);
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
  if (timeint%10 == 0 && printflag)
  {
    for (int i = 0; i < 10; i++)
    {
      Serial.println(serInBytes[i]);
    }
    printflag = 0;
  }
  
  // Set driving motor values
  motorAServo.write(serInBytes[0]-5);
  motorBServo.write(serInBytes[1]+5);
  motorCServo.write(serInBytes[2]+5);
  motorDServo.write(serInBytes[3]);
  
  // Set arm servos
  waistServo.write(serInBytes[4]);
  shoulderServo.write(serInBytes[5]);
  elbowServo.write(serInBytes[6]);
  
  // set state of gripper and cutter
  int gripPosition, cutterPosition;
  
  switch (serInBytes[7]) {
    case 0:
      gripPosition = GRIPCLOSED;
      cutterPosition = CUTTERCLOSED;
      break;
    case 1:
      gripPosition = GRIPOPEN;
      cutterPosition = CUTTERCLOSED;
      break;
    case 2:
      gripPosition = GRIPCLOSED;
      cutterPosition = CUTTEROPEN;
      break;
    case 3:
      gripPosition = GRIPOPEN;
      cutterPosition = CUTTERCLOSED;
  }
  
  gripServo.write(gripPosition);
  cutterServo.write(cutterPosition); 
  
  timeint++;
}

int serialStatus()
{
  if (serialCount > 1)
  {
    if (serialCount%100 == 0)
    {
      Serial.println("Timeout recieving serial data.");
    }

    // Set driving motor values 
    motorAServo.write(90-5);
    motorBServo.write(90+5);
    motorCServo.write(90+5);
    motorDServo.write(90);
  
    // Set arm servos
    waistServo.write(90);
    shoulderServo.write(74);
    elbowServo.write(90);
  
    gripServo.write(0);
    cutterServo.write(0); 
    
    if (Serial.available() > 0)
    {
      serialCount = 0;
      return 1;
    }
    
    return 0;
  }
  else
  {
    serialCount++;
  }
  
  return 1;
}
