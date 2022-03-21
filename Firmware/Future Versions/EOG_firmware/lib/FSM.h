#ifndef FSM_h
#define FSM_h

typedef enum {waitHandShake,waitHostCommand} State;
typedef struct
{
  State state = waitHandShake;
  bool handshake = false;
}FiniteStateMachine;

// Send order
void ConfirmOrder(uint8_t order);

// ISR function
void Callback();

// Initial FSM's state, performs handshake with host
void DoHandShake();

// Second and final FSM's state, waits for incoming commands
void DoHostCommand();

// Run the FSM, called every main loop
void RunFSM();

#endif