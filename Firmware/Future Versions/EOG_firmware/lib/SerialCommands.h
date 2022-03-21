#ifndef SerialCommands_h
#define SerialCommands_h

#define FIRMWARE_VERSION "2.0.0"



/* Forming Data Packets 
 *
 * There will be two types of Data Packets:
 *      1) Confirming an order
 *      2) Giving feedback of the process
 *
 * The first type will be a 3-byte packet as follows:
 * | HEADER | ORDER TO CONFIRM | TAIL
 * (CONFIRM_ORDER)(CMD_@)(END_OF_MSG)
 *
 * The second type will be a 6-byte packet, giving numerical information about what is going on 
 * | HEADER | CH1_DATA_MSB | CH1_DATA_LSB| CH2_DATA_MSB | CH2_DATA_LSB | TAIL
 */

// Incoming commands
#define CMD_RESET       0x20 // Reset FSM (ASCII  )
#define CMD_FMR_VER     0x21 // Send firmware version (ASCII !)
#define CMD_FMR_VER_OK  0x22 // Confirm firmware version (ASCII ")
#define CMD_LED_OFF     0x26 // Turn on indication led
#define CMD_LED_ON      0x27 // Turn off indication led
#define CMD_START       0x30 // Start acquisition process
#define CMD_STOP        0x31 // Stop acquisition process

// Confirming orders
#define CONFIRM_ORDER    0xF0 // Confirming order indicator
#define ORDER_CONFIRMED  0xF1 // End of confirmation message
#define CO_FMR_VER       0xF2 // Confirm firmware version
#define CO_RESET         0xF3 // Confirm firmware version
#define CO_LED_ON        0xF4 // Confirm light on indication led
#define CO_LED_OFF       0xF5 // Confirm light off indication led


#define DATA_HEADER  0xA0
#define DATA_TAIL    0xA1

#endif
