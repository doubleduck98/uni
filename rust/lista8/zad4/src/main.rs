use std::collections::HashMap;

fn main() {
    let decoder = MorseDecoder::new();
    println!("{:?}", decoder.decode_morse(".... . -.--  .--- ..- -.. ."));
}
struct MorseDecoder {
    morse_code: HashMap<String, String>,
}

impl MorseDecoder {
    pub fn new() -> MorseDecoder {
        MorseDecoder {
            morse_code: [
                (".-", "A"),
                ("-...", "B"),
                ("-.-.", "C"),
                ("-..", "D"),
                (".", "E"),
                ("..-.", "F"),
                ("--.", "G"),
                ("....", "H"),
                ("..", "I"),
                (".---", "J"),
                ("-.-", "K"),
                (".-..", "L"),
                ("--", "M"),
                ("-.", "N"),
                ("---", "O"),
                (".--.", "P"),
                ("--.-", "Q"),
                (".-.", "R"),
                ("...", "S"),
                ("-", "T"),
                ("..-", "U"),
                ("...-", "V"),
                (".--", "W"),
                ("-..-", "X"),
                ("-.--", "Y"),
                ("--..", "Z"),
            ]
            .iter()
            .map(|&(a, b)| (a.to_string(), b.to_string()))
            .collect(),
        }
    }

    fn decode_morse(&self, encoded: &str) -> String {
        let mut res = Vec::new();
        for word in encoded.trim().split("  ") {
            res.push(word.split_whitespace().map(|ch| self.morse_code.get(ch).unwrap().to_string()).collect::<String>());
        }
        res.join(" ")
    }
}

#[test]
fn test0() {
    let decoder = MorseDecoder::new();
    assert_eq!(
        decoder.decode_morse(".... . -.--   .--- ..- -.. ."),
        "HEY JUDE"
    );
}
#[test]
fn test1() {
    let decoder = MorseDecoder::new();
    assert_eq!(decoder.decode_morse(""), "");
}
#[test]
fn test2() {
    let decoder = MorseDecoder::new();
    assert_eq!(
        decoder.decode_morse(
            "-..- -..   -..- -..   -..-   -.. -..-   -.. -..-   -.. -..- -..   -..- -.."
        ),
        "XD XD X DX DX DXD XD"
    );
}
#[test]
fn test3() {
    let decoder = MorseDecoder::new();
    assert_eq!(decoder.decode_morse("... --- ..."), "SOS");
}
#[test]
fn test4() {
    let decoder = MorseDecoder::new();
    assert_eq!(
        decoder.decode_morse("... --.. -.-- -- --- -.   --.. .. . -. -.- .. . .-- .. -.-. --.."),
        "SZYMON ZIENKIEWICZ"
    );
}
#[test]
fn test5() {
    let decoder = MorseDecoder::new();
    assert_eq!(
        decoder.decode_morse("-.-. .... .. . ..-.   -.- . . ..-."),
        "CHIEF KEEF"
    );
}
#[test]
fn test6() {
    let decoder = MorseDecoder::new();
    assert_eq!(
        decoder.decode_morse("-.. ..-. -.. ..-. -... -..- -. -.. --- .-- --- ..   .- ... -.. ...- -..- -.- ...-   -.."),
        "DFDFBXNDOWOI ASDVXKV D"
    );
}
#[test]
fn test7() {
    let decoder = MorseDecoder::new();
    assert_eq!(
        decoder.decode_morse("                                       -..."),
        "B"
    );
}
#[test]
fn test8() {
    let decoder = MorseDecoder::new();
    assert_eq!(
        decoder.decode_morse(".--. . .--. .   .--- .- --"),
        "PEPE JAM"
    );
}
#[test]
fn test9() {
    let decoder = MorseDecoder::new();
    assert_eq!(
        decoder.decode_morse(".-.. . -.-. .... ..-   .-- -.- ..."),
        "LECHU WKS"
    );
}
