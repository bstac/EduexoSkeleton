const int servoAnalogInPin = A0;
const int baudRate = 9600;
const int initSerialDelay = 1000;
const int loopSerialDelay = 20;
int posIs;
byte sendValue;

void setup()
{
  Serial.begin(baudRate);
  delay(initSerialDelay);
  //comment
}

void loop()
{
  posIs = analogRead(servoAnalogInPin);
  //sendValue = map(posIs,80,350,0,255);
  //Serial.write(sendValue);
  Serial.print("Position is: ");
  Serial.println(posIs);
  //Serial.flush();
  delay(loopSerialDelay);
  //analogWrite
}
