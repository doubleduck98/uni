#include <avr/io.h>
#include <avr/pgmspace.h>
#define __DELAY_BACKWARD_COMPATIBLE__  // dodaje takie coś, żeby funkcja delay
                                       // mogła przyjmować zmienne
#include <inttypes.h>
#include <util/delay.h>

#define BUZZ PB1
#define BUZZ_DDR DDRB
#define BUZZ_PORT PORTB

// bardzo dużo makr do nut
#define C 0
#define CS 1
#define D 2
#define DS 3
#define E 4
#define F 5
#define FS 6
#define G 7
#define GS 8
#define A 9
#define AS 10
#define B 11
#define PAUSE 12

// oktawy
#define OCT0 0
#define OCT1 1
#define OCT2 2
#define OCT3 3
#define OCT4 4
#define OCT5 5
#define OCT6 6
#define OCT7 7
#define OCT8 8

// nuty
#define FULL 666
#define HALF 333
#define QRTR 166

// tablica [nuta][oktawa] w cpu_clk/Hz*2
const uint16_t freq[12][9] PROGMEM = {
    {50000, 25000, 12307, 6153, 3065, 1529, 764, 382, 191},
    {47058, 23529, 11594, 5797, 2888, 1444, 722, 360, 180},
    {44444, 22222, 10958, 5479, 2730, 1362, 618, 340, 170},
    {42105, 21052, 10389, 5161, 2572, 1296, 643, 321, 160},
    {40000, 19512, 9756, 4878, 2431, 1213, 606, 303, 151},
    {38095, 18603, 9195, 4597, 2292, 1146, 573, 286, 142},
    {34782, 17391, 8695, 4324, 2168, 1082, 540, 270, 135},
    {33333, 16326, 8163, 4081, 2040, 1021, 510, 255, 127},
    {32000, 15686, 7766, 3864, 1927, 963, 481, 240, 120},
    {29629, 14545, 7272, 3636, 1818, 909, 454, 227, 113},
    {27586, 13893, 6896, 3433, 1716, 858, 429, 214, 107},
    {26666, 13114, 6504, 3252, 1622, 810, 405, 202, 101}};

#define TONE(step, delay)                                                  \
    for (uint16_t i = 0; i < (uint32_t)1000 * (delay) / (step) / 2; i++) { \
        BUZZ_PORT |= _BV(BUZZ);                                            \
        _delay_us(step);                                                   \
        BUZZ_PORT &= ~_BV(BUZZ);                                           \
        _delay_us(step);                                                   \
    }

int read_note(uint16_t note, uint16_t octave) {
    return pgm_read_word(&freq[note][octave]);
}

typedef struct note {
    uint16_t note;
    uint16_t octave;
    uint16_t len;
} note_t;

#define MELODY_LEN 269

const note_t melody[MELODY_LEN] PROGMEM = {
    {D, OCT4, QRTR},
    {D, OCT4, QRTR},
    {D, OCT5, QRTR},
    {PAUSE, OCT4, QRTR},
    {A, OCT4, QRTR},
    {PAUSE, OCT4, HALF},
    {GS, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {G, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {F, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {D, OCT4, QRTR},
    {F, OCT4, QRTR},
    {G, OCT4, QRTR},
    {C, OCT4, QRTR},
    {C, OCT4, QRTR},
    {D, OCT5, QRTR},
    {PAUSE, OCT4, QRTR},
    {A, OCT4, QRTR},
    {PAUSE, OCT4, HALF},
    {GS, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {G, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {F, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {D, OCT4, QRTR},
    {F, OCT4, QRTR},
    {G, OCT4, QRTR},
    {B, OCT3, QRTR},
    {B, OCT3, QRTR},
    {D, OCT5, QRTR},
    {PAUSE, OCT4, QRTR},
    {A, OCT4, QRTR},
    {PAUSE, OCT4, HALF},
    {GS, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {G, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {F, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {D, OCT4, QRTR},
    {F, OCT4, QRTR},
    {G, OCT4, QRTR},
    {A, OCT3, QRTR},
    {A, OCT3, QRTR},
    {D, OCT5, QRTR},
    {PAUSE, OCT5, QRTR},
    {A, OCT4, QRTR},
    {PAUSE, OCT4, HALF},
    {GS, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {G, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {F, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {D, OCT4, QRTR},
    {F, OCT4, QRTR},
    {G, OCT4, QRTR},
    {D, OCT4, QRTR},
    {D, OCT4, QRTR},
    {D, OCT5, QRTR},
    {PAUSE, OCT4, QRTR},
    {A, OCT4, QRTR},
    {PAUSE, OCT4, HALF},
    {GS, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {G, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {F, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {D, OCT4, QRTR},
    {F, OCT4, QRTR},
    {G, OCT4, QRTR},
    {C, OCT4, QRTR},
    {C, OCT4, QRTR},
    {D, OCT5, QRTR},
    {PAUSE, OCT4, QRTR},
    {A, OCT4, QRTR},
    {PAUSE, OCT4, HALF},
    {GS, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {G, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {F, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {D, OCT4, QRTR},
    {F, OCT4, QRTR},
    {G, OCT4, QRTR},
    {B, OCT3, QRTR},
    {B, OCT3, QRTR},
    {D, OCT5, QRTR},
    {PAUSE, OCT4, QRTR},
    {A, OCT4, QRTR},
    {PAUSE, OCT4, HALF},
    {GS, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {G, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {F, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {D, OCT4, QRTR},
    {F, OCT4, QRTR},
    {G, OCT4, QRTR},
    {A, OCT3, QRTR},
    {A, OCT3, QRTR},
    {D, OCT5, QRTR},
    {PAUSE, OCT5, QRTR},
    {A, OCT4, QRTR},
    {PAUSE, OCT4, HALF},
    {GS, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {G, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {F, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {D, OCT4, QRTR},
    {F, OCT4, QRTR},
    {G, OCT4, QRTR},
    {F, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {F, OCT4, QRTR},
    {F, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {F, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {F, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {D, OCT4, QRTR},
    {PAUSE, OCT4, HALF},
    {D, OCT4, QRTR},
    {F, OCT4, QRTR},
    {F, OCT4, QRTR},
    {F, OCT4, QRTR},
    {F, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {G, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {GS, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {G, OCT4, QRTR},
    {F, OCT4, QRTR},
    {D, OCT4, QRTR},
    {F, OCT4, QRTR},
    {G, OCT4, QRTR},
    {PAUSE, OCT4, HALF},
    {F, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {F, OCT4, QRTR},
    {F, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {G, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {GS, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {A, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {C, OCT5, QRTR},
    {PAUSE, OCT4, QRTR},
    {A, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {D, OCT5, QRTR},
    {PAUSE, OCT4, QRTR},
    {D, OCT5, QRTR},
    {PAUSE, OCT4, QRTR},
    {D, OCT5, QRTR},
    {A, OCT4, QRTR},
    {D, OCT5, QRTR},
    {C, OCT5, HALF},
    {C, OCT5, HALF},
    {PAUSE, OCT4, FULL},
    {A, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {A, OCT4, QRTR},
    {A, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {A, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {A, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {G, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {G, OCT4, HALF},
    {PAUSE, OCT4, HALF},
    {A, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {A, OCT4, QRTR},
    {A, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {A, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {G, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {A, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {D, OCT5, QRTR},
    {PAUSE, OCT4, QRTR},
    {A, OCT4, QRTR},
    {G, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {D, OCT5, QRTR},
    {PAUSE, OCT4, QRTR},
    {A, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {G, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {F, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {C, OCT5, QRTR},
    {PAUSE, OCT4, QRTR},
    {A, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {G, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {F, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {D, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {E, OCT4, QRTR},
    {F, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {A, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {C, OCT5, HALF},
    {PAUSE, OCT4, FULL},
    {F, OCT4, QRTR},
    {D, OCT4, QRTR},
    {F, OCT4, QRTR},
    {G, OCT4, QRTR},
    {GS, OCT4, QRTR},
    {G, OCT4, QRTR},
    {F, OCT4, QRTR},
    {D, OCT4, QRTR},
    {GS, OCT4, QRTR},
    {G, OCT4, QRTR},
    {F, OCT4, QRTR},
    {D, OCT4, QRTR},
    {F, OCT4, QRTR},
    {G, OCT4, HALF},
    {PAUSE, OCT4, QRTR},
    {GS, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {A, OCT4, QRTR},
    {C, OCT5, QRTR},
    {PAUSE, OCT4, QRTR},
    {A, OCT4, QRTR},
    {GS, OCT4, QRTR},
    {G, OCT4, QRTR},
    {F, OCT4, QRTR},
    {D, OCT4, QRTR},
    {E, OCT4, QRTR},
    {F, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {G, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {GS, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {C, OCT5, QRTR},
    {PAUSE, OCT4, HALF},
    {CS, OCT5, QRTR},
    {PAUSE, OCT4, QRTR},
    {GS, OCT4, QRTR},
    {PAUSE, OCT4, QRTR},
    {GS, OCT4, QRTR},
    {G, OCT4, QRTR},
    {F, OCT4, QRTR},
    {G, OCT4, HALF},
    {PAUSE, OCT4, FULL}
};

void play_note(int n) {
    note_t note;
    memcpy_P(&note, &melody[n], sizeof(note_t));
    if (note.note == PAUSE) {
        _delay_ms(note.len);
    } else {
        TONE(read_note(note.note, note.octave), note.len);
    }
    return;
}

int main() {
    BUZZ_DDR |= _BV(BUZZ);
    while (1) {
        for (uint16_t i = 0; i < MELODY_LEN; ++i) {
            play_note(i);
        }
    }
}