fn main() {
    println!("{:?}", alphabet_position("essa"));
}

fn alphabet_position(text: &str) -> String {
    let mut res: String = text
        .split_whitespace()
        .collect::<String>()
        .to_lowercase()
        .chars()
        .collect();
    res.retain(|c| c.is_alphabetic());
    res = res
        .chars()
        .map(|c| format!("{} ", (c as u32) - ('a' as u32) + 1))
        .collect::<String>;
    res.trim_end().to_string()
}

#[test]
fn test0() {
    assert_eq!(
        alphabet_position("The sunset sets at twelve o' clock."),
        "20 8 5 19 21 14 19 5 20 19 5 20 19 1 20 20 23 5 12 22 5 15 3 12 15 3 11".to_string()
    );
}
#[test]
fn test1() {
    assert_eq!(
        alphabet_position("The narwhal bacons at midnight."),
        "20 8 5 14 1 18 23 8 1 12 2 1 3 15 14 19 1 20 13 9 4 14 9 7 8 20".to_string()
    );
}
#[test]
fn test2() {
    assert_eq!(
        alphabet_position(""),
        "".to_string()
    );
}
#[test]
fn test3() {
    assert_eq!(
        alphabet_position("Leszek to kumpel."),
        "12 5 19 26 5 11 20 15 11 21 13 16 5 12".to_string()
    );
}
#[test]
fn test4() {
    assert_eq!(
        alphabet_position("Czesc."),
        "3 26 5 19 3".to_string()
    );
}
#[test]
fn test5() {
    assert_eq!(
        alphabet_position("Do widzenia."),
        "4 15 23 9 4 26 5 14 9 1".to_string()
    );
}
#[test]
fn test6() {
    assert_eq!(
        alphabet_position("Aalsh duahs ifyhal hfdy sap fys."),
        "1 1 12 19 8 4 21 1 8 19 9 6 25 8 1 12 8 6 4 25 19 1 16 6 25 19".to_string()
    );
}
#[test]
fn test7() {
    assert_eq!(
        alphabet_position("Replace With Alphabet Position."),
        "18 5 16 12 1 3 5 23 9 20 8 1 12 16 8 1 2 5 20 16 15 19 9 20 9 15 14".to_string()
    );
}
#[test]
fn test8() {
    assert_eq!(
        alphabet_position("xDDD&*&^%$$!@@&*"),
        "24 4 4 4".to_string()
    );
}
#[test]
fn test9() {
    assert_eq!(
        alphabet_position("?><MNBVYIOP{}{:L32cqv6v"),
        "13 14 2 22 25 9 15 16 12 3 17 22 22".to_string()
    );
}
