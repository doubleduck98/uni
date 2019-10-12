fn main() {
    println!("Hello, world!");
}

fn printer_error(s: &str) -> std::string::String {
    let mut err = 0;
    for c in s.chars() {
        if c > 'm' {
            err += 1;
        }
    }
    let word_count = s.chars().count();
    format!("{}/{}", err, word_count)
}

#[test]
fn test0() {
    assert_eq!(
        &printer_error("aaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbmmmmmmmmmmmmmmmmmmmxyz"),
        "3/56"
    );
}
#[test]
fn test1() {
    assert_eq!(
        &printer_error("kkkwwwaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbmmmmmmmmmmmmmmmmmmmxyz"),
        "6/60"
    );
}
#[test]
fn test2() {
    assert_eq!(
        &printer_error("kkkwwwaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbmmmmmmmmmmmmmmmmmmmxyzuuuuu"),
        "11/65"
    );
}
#[test]
fn test3() {
    assert_eq!(
        &printer_error("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee"),
        "0/36"
    );
}
#[test]
fn test4() {
    assert_eq!(
        &printer_error("hhhhhhhhhhhhhhhhhhhhhhhhhhhijklmnzzzzz"),
        "6/38"
    );
}
#[test]
fn test5() {
    assert_eq!(
        &printer_error(""),
        "0/0"
    );
}
#[test]
fn test6() {
    assert_eq!(
        &printer_error("mmmmmmmmmmmmmmmmmmnnnnnnnnnnnnnnn"),
        "15/33"
    );
}
#[test]
fn test7() {
    assert_eq!(
        &printer_error("zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz"),
        "53/53"
    );
}
#[test]
fn test8() {
    assert_eq!(
        &printer_error("asjkdhfasbnvkxjchgvoaesropiuaser"),
        "14/32"
    );
}
#[test]
fn test9() {
    assert_eq!(
        &printer_error("mnxcmvbnzxmnvbxznmvbxzmvbzxvzxbncvmzxnv"),
        "26/39"
    );
}
