fn main() {
    println!("{}", find_digit(5673, 4));
}

fn find_digit(num: i32, nth: i32) -> i32 {
    if nth <= 0 {
        return -1;
    }
    else if num.to_string().len() < (nth as usize) { 
        return 0;
    }
    (num.abs() / (10 as i32).pow((nth - 1) as u32)) % 10
}

#[test]
fn test0() {
    assert_eq!(find_digit(5673, 4), 5);
}
#[test]
fn test1() {
    assert_eq!(find_digit(24, -8), -1);
}
#[test]
fn test2() {
    assert_eq!(find_digit(-2825, 3), 8);
}
#[test]
fn test3() {
    assert_eq!(find_digit(65, 0), -1);
}
#[test]
fn test4() {
    assert_eq!(find_digit(0, 20), 0);
}
#[test]
fn test5() {
    assert_eq!(find_digit(-456, 4), 0);
}
#[test]
fn test6() {
    assert_eq!(find_digit(129, 2), 2);
}
#[test]
fn test7() {
    assert_eq!(find_digit(78322, 3), 3);
}
#[test]
fn test8() {
    assert_eq!(find_digit(799131105, 5), 3);
}
#[test]
fn test9() {
    assert_eq!(find_digit(-5125, 1), 5);
}
