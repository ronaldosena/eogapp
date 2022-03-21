#include "lib/FSM.c"
#define timerPeriod 1000 //in microseconds
#define DEBUG

void setup()
{
  Serial.begin(115200);
  pinMode(LED_BUILTIN, OUTPUT);
  Timer1.initialize(timerPeriod);
}

void loop()
{
  // As of version 2.1.0, the main finite state machine has only two states:
  // wait handshake with host, wait host incoming order.
  RunFSM(); // aka .vai()
}