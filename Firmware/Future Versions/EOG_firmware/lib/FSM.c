#include <TimerOne.h>
#include "FSM.h"
#include "SerialCommands.h"

#define PIN_CH_1 A0
#define PIN_CH_2 A1

// Buffer used in serial communication
const uint8_t bufferLength = 3;
uint8_t incomingBuffer[bufferLength];
uint16_t valueCh1, valueCh2;
bool sendFlag = false;

FiniteStateMachine FSM;

// Main routine of the machine
void RunFSM()
{
  switch ( FSM.state )
  {
    case waitHandShake :
      DoHandShake();
    break;

    case waitHostCommand :
      DoHostCommand();
    break;

    default:
    break;
  }
}

// DoHandShake sends a string with current firmware version burnt into chip
void DoHandShake()
{
  // Host requested firmware version
  if (Serial.available() && !FSM.handshake)
  {
    Serial.readBytes(incomingBuffer, bufferLength);
    if ( incomingBuffer[0] == CMD_FMR_VER )
    {
      Serial.println(FIRMWARE_VERSION);
    }
    else if ( incomingBuffer[0] == CMD_FMR_VER_OK )
    {
      // Go to the next state in FSM
      FSM.handshake = true;
      FSM.state = waitHostCommand;      
    }
  }
}

void DoHostCommand()
{
  if(Serial.available())
  {
    Serial.readBytes(incomingBuffer, 1);

    switch (incomingBuffer[0])
    { 
      case CMD_RESET:
        sendFlag = false;
        digitalWrite(LED_BUILTIN, 0);
        FSM.handshake = false;
        FSM.state = waitHandShake;
        ConfirmOrder(CO_RESET);
      break;

      case CMD_LED_ON:
        digitalWrite(LED_BUILTIN, 1);
        ConfirmOrder(CO_LED_ON);
      break;

      case CMD_LED_OFF:
        digitalWrite(LED_BUILTIN, 0);
        ConfirmOrder(CO_LED_OFF);
      break;

      case CMD_START:
        sendFlag = true;
        Timer1.attachInterrupt(Callback);
      break;

      case CMD_STOP:
        sendFlag = false;
        Timer1.detachInterrupt();
      break;

      default:
        // Stay where you are
      break;
    }
    // Serial.write(END_OF_MSG);
  }
}

void ConfirmOrder(uint8_t order)
{
  Serial.write(CONFIRM_ORDER);
  Serial.write(order);
  Serial.write(ORDER_CONFIRMED);
}

void Callback()
{
  if(sendFlag)
  {
    valueCh1 = analogRead(PIN_CH_1);
    valueCh2 = analogRead(PIN_CH_2);

    #ifdef DEBUG
      Serial.println((uint8_t) (valueCh1 >> 8));
      Serial.println((uint8_t) (valueCh1 & 0xFF));
      Serial.println((uint8_t) (valueCh2 >> 8));
      Serial.println((uint8_t) (valueCh2 & 0xFF));
    #else
      Serial.write(DATA_HEADER);
      Serial.write((uint8_t) (valueCh1 >> 8));
      Serial.write((uint8_t) (valueCh1 & 0xFF));
      Serial.write((uint8_t) (valueCh2 >> 8));
      Serial.write((uint8_t) (valueCh2 & 0xFF));
      Serial.write(DATA_TAIL);
    #endif
  }
}