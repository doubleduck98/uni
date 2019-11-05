fn main() {
    print!("{}", descending_order(1234567));
}

fn descending_order(x: u64) -> u64 {
    let mut res = x.to_string().chars().into_iter().collect::<Vec<char>>();
    res.sort_by(|a, b| b.cmp(a));
    res.iter().collect::<String>().parse::<u64>().unwrap()
}

#[test]
fn test0() {
    assert_eq!(descending_order(0), 0);
}
#[test]
fn test1() {
    assert_eq!(descending_order(1), 1);
}
#[test]
fn test2() {
    assert_eq!(descending_order(15), 51);
}
#[test]
fn test3() {
    assert_eq!(descending_order(1021), 2110);
}
#[test]
fn test4() {
    assert_eq!(descending_order(145263), 654321);
}
#[test]
fn test5() {
    assert_eq!(descending_order(1254859723), 9875543221);
}
#[test]
fn test6() {
    assert_eq!(descending_order(123456789), 987654321);
}
#[test]
fn test7() {
    assert_eq!(descending_order(997), 997);
}
#[test]
fn test8() {
    assert_eq!(descending_order(445566), 665544);
}
#[test]
fn test9() {
    assert_eq!(descending_order(123123123), 333222111);
}
