fn main() {
    zakoduj("ab", "cd");
}

fn zakoduj(code1: &str, code2: &str, msg: &str) {
    let kod = code1.chars().zip(code2.chars()).collect::<Vec<_>>();
    msg.chars().
}

struct Cipher {
    code1: String,
    code2: String,
}

impl Cipher {
    fn new(map1: &str, map2: &str) -> Cipher {
        Cipher {
            code1: map1.to_string(),
            code2: map2.to_string(),
        }
    }
}
