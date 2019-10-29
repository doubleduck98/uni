fn main() {
    let map1 = "abcdefghijklmnopqrstuvwxyz";
    let map2 = "etaoinshrdlucmfwypvbgkjqxz";

    let cipher = Cipher::new(map1, map2);
    println!("{}", cipher.encode("siema"));
    println!("{}", cipher.decode("vrice"))
}

struct Cipher {
    kod: Vec<(char, char)>,
}

impl Cipher {
    fn new(map1: &str, map2: &str) -> Cipher {
        Cipher {
            kod: map1.chars().zip(map2.chars()).collect::<Vec<_>>(),
        }
    }

    fn encode(&self, string: &str) -> String {
        string
            .chars()
            .map(|c| self.kod.iter().find(|x| x.0 == c).map_or(c, |x| x.1))
            .collect()
    }

    fn decode(&self, string: &str) -> String {
        string
            .chars()
            .map(|c| self.kod.iter().find(|x| x.1 == c).map_or(c, |x| x.0))
            .collect()
    }
}

#[test]
fn test0() {
    let map1 = "abcdefghijklmnopqrstuvwxyz";
    let map2 = "etaoinshrdlucmfwypvbgkjqxz";

    let cipher = Cipher::new(map1, map2);
    assert_eq!(cipher.encode("abc"), "eta");
}
#[test]
fn test1() {
    let map1 = "abcdefghijklmnopqrstuvwxyz";
    let map2 = "etaoinshrdlucmfwypvbgkjqxz";

    let cipher = Cipher::new(map1, map2);
    assert_eq!(cipher.encode("xyz"), "qxz");
}
#[test]
fn test2() {
    let map1 = "abcdefghijklmnopqrstuvwxyz";
    let map2 = "etaoinshrdlucmfwypvbgkjqxz";

    let cipher = Cipher::new(map1, map2);
    assert_eq!(cipher.decode("eirfg"), "aeiou");
}
#[test]
fn test3() {
    let map1 = "abcdefghijklmnopqrstuvwxyz";
    let map2 = "etaoinshrdlucmfwypvbgkjqxz";

    let cipher = Cipher::new(map1, map2);
    assert_eq!(cipher.decode("erlang"), "aikcfu");
}
#[test]
fn test4() {
    let map1 = "abcdefghijklmnopqrstuvwxyz";
    let map2 = "etaoinshrdlucmfwypvbgkjqxz";

    let cipher = Cipher::new(map1, map2);
    assert_eq!(cipher.encode("essa"), "ivve");
}
#[test]
fn test5() {
    let map1 = "abcdefghijklmnopqrstuvwxyz";
    let map2 = "etaoinshrdlucmfwypvbgkjqxz";

    let cipher = Cipher::new(map1, map2);
    assert_eq!(cipher.encode("szymon"), "vzxcfm");
}
#[test]
fn test6() {
    let map1 = "abcdefghijklmnopqrstuvwxyz";
    let map2 = "etaoinshrdlucmfwypvbgkjqxz";

    let cipher = Cipher::new(map1, map2);
    assert_eq!(cipher.encode("zienkiewicz"), "zrimlrijraz");
}
#[test]
fn test7() {
    let map1 = "abcdefghijklmnopqrstuvwxyz";
    let map2 = "etaoinshrdlucmfwypvbgkjqxz";

    let cipher = Cipher::new(map1, map2);
    assert_eq!(cipher.encode("rustjestsuper"), "pgvbdivbvgwip");
}
#[test]
fn test8() {
    let map1 = "abcdefghijklmnopqrstuvwxyz";
    let map2 = "etaoinshrdlucmfwypvbgkjqxz";

    let cipher = Cipher::new(map1, map2);
    assert_eq!(cipher.decode("zelfofjemejreofcfva"), "zakodowanawiadomosc");
}
#[test]
fn test9() {
    let map1 = "abcdefghijklmnopqrstuvwxyz";
    let map2 = "etaoinshrdlucmfwypvbgkjqxz";

    let cipher = Cipher::new(map1, map2);
    assert_eq!(
        cipher.decode("fmevzwruiorecimbxdebrvzipbxqulr"),
        "onaszpilediamentyjatiszertyxlki"
    );
}
