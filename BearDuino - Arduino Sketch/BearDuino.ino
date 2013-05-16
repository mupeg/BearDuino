
#include <Servo.h>

Servo myservo;
int val;

void setup()
{
  myservo.attach(9);
  myservo.write(90);
  Serial.begin(9600);
  while (!Serial) {;} // wait for serial port to connect. Needed for Leonardo only
}

void loop()
{
  if(Serial.available())
  {
    char serialData[3];
    Serial.readBytesUntil(10, serialData, 3);
   
    if(serialData[0] == (char)127)
    {
      int val = map((int)serialData[1], 26, 126, 0, 179);
      if(val > 179) val = 179;
      if(val < 0) val = 0;
      myservo.write(val);
    }
  }
}
