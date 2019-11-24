fn main() {
    println!("{}", last_digit(&[7, 6, 21]));
}

fn last_digit(lst: &[u64]) -> u64 {
    (lst.iter().rev().fold(1, |acc, x| {
        let exp = if acc < 4 { acc } else { acc % 4 + 4 };
        x.pow(exp) as u32 % 10
    }) % 10)
        .into()
}

#[test]
fn test0() {
    assert_eq!(last_digit(&vec![3, 4, 5]), 1)
}
#[test]
fn test1() {
    assert_eq!(last_digit(&vec![]), 1)
}
#[test]
fn test2() {
    assert_eq!(last_digit(&vec![0, 0]), 1)
}
#[test]
fn test3() {
    assert_eq!(last_digit(&vec![4, 3, 6]), 4)
}
#[test]
fn test4() {
    assert_eq!(last_digit(&vec![7, 6, 21]), 1)
}
#[test]
fn test5() {
    assert_eq!(last_digit(&vec![12, 30, 21]), 6)
}
#[test]
fn test6() {
    assert_eq!(last_digit(&vec![2, 2, 2, 0]), 4)
}
#[test]
fn test7() {
    assert_eq!(last_digit(&vec![937640, 767456, 981242]), 0)
}
#[test]
fn test8() {
    assert_eq!(last_digit(&vec![123232, 694022, 140249]), 6)
}
#[test]
fn test9() {
    assert_eq!(last_digit(&vec![499942, 898102, 846073]), 6)
}
