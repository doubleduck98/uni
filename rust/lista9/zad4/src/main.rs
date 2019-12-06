fn main() {
    println!("{}", camel_case("the quick brown fox jumped over lazy dog"));
}

fn camel_case(str: &str) -> String {
    str.split_whitespace()
        .map(|w| {
            let mut chars: Vec<char> = w.chars().collect();
            chars[0] = chars[0].to_uppercase().nth(0).unwrap();
            chars.iter().collect::<String>()
        })
        .collect::<Vec<String>>()
        .join("")
}

#[test]
fn test0() {
    assert_eq!(camel_case("test case"), "TestCase");
}
#[test]
fn test1() {
    assert_eq!(camel_case("camel case method"), "CamelCaseMethod");
}
#[test]
fn test2() {
    assert_eq!(camel_case("say hello "), "SayHello");
}
#[test]
fn test3() {
    assert_eq!(camel_case(" camel case word"), "CamelCaseWord");
}
#[test]
fn test4() {
    assert_eq!(camel_case(""), "");
}
#[test]
fn test5() {
    assert_eq!(
        camel_case("the quick brown fox jumped over lazy dog"),
        "TheQuickBrownFoxJumpedOverLazyDog"
    );
}
#[test]
fn test6() {
    assert_eq!(camel_case("x d d d d d   "), "XDDDDD");
}
#[test]
fn test7() {
    assert_eq!(camel_case("worki na smieci"), "WorkiNaSmieci");
}
#[test]
fn test8() {
    assert_eq!(camel_case("nervarien na allstars"), "NervarienNaAllstars");
}
#[test]
fn test9() {
    assert_eq!(
        camel_case("i cant go to yemen im an analyst"),
        "ICantGoToYemenImAnAnalyst"
    );
}
