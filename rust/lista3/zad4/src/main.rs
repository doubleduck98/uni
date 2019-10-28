fn main() {
    println!("{}", last_digit("10", "100000"));
}

fn exp_mod_4(exp: &str) -> u32 {
    exp.chars()
        .fold(0, |acc, x| (acc * 10 + x.to_digit(10).unwrap()) % 4)
}

fn last_digit(str1: &str, str2: &str) -> i32 {
    if str2 == "0" {
        return 1;
    }
    str1.chars()
        .last()
        .unwrap()
        .to_digit(10)
        .unwrap()
        .pow(if exp_mod_4(str2) == 0 {
            4
        } else {
            exp_mod_4(str2)
        }) as i32
        % 10
}

#[test]
fn test0() {
    assert_eq!(last_digit("5235678567852345", "52351351235235"), 5)
}
#[test]
fn test1() {
    assert_eq!(last_digit("111111111", "11111111111111"), 1)
}
#[test]
fn test2() {
    assert_eq!(last_digit("12", "0"), 1)
}
#[test]
fn test3() {
    assert_eq!(last_digit("1606938044258990275541962092341162602522202993782792835301376", "2037035976334486086268445688409378161051468393665936250636140449354381299763336706183397376"), 6)
}
#[test]
fn test4() {
    assert_eq!(last_digit("13", "71"), 7)
}
#[test]
fn test5() {
    assert_eq!(last_digit("28", "82"), 4)
}
#[test]
fn test6() {
    assert_eq!(last_digit("7", "4"), 1)
}
#[test]
fn test7() {
    assert_eq!(last_digit("32", "55"), 8)
}
#[test]
fn test8() {
    assert_eq!(last_digit("2", "52351351235235"), 8)
}
#[test]
fn test9() {
    assert_eq!(last_digit("632", "1"), 2)
}
