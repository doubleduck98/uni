fn main() {
    println!("{}", dont_give_me_five(5, 5));
}

fn dont_give_me_five(start: isize, end: isize) -> isize {
    let mut res: Vec<isize> = (start..=end).collect();
    res.retain(|x| !x.to_string().contains("5"));
    res.len() as isize
}

#[test]
fn test0() {
    assert_eq!(dont_give_me_five(1, 9), 8);
}
#[test]
fn test1() {
    assert_eq!(dont_give_me_five(4, 17), 12);
}
#[test]
fn test2() {
    assert_eq!(dont_give_me_five(-91, 91), 147);
}
#[test]
fn test3() {
    assert_eq!(dont_give_me_five(5, 5), 0);
}
#[test]
fn test4() {
    assert_eq!(dont_give_me_five(1421, 1426), 5);
}
#[test]
fn test5() {
    assert_eq!(dont_give_me_five(13, 14), 2);
}
#[test]
fn test6() {
    assert_eq!(dont_give_me_five(-1, 9), 10);
}
#[test]
fn test7() {
    assert_eq!(dont_give_me_five(12, 71), 45);
}
#[test]
fn test8() {
    assert_eq!(dont_give_me_five(9, 99), 73);
}
#[test]
fn test9() {
    assert_eq!(dont_give_me_five(-100, -50), 37);
}
