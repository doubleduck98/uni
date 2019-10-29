fn main() {
    println!(
        "{:?}",
        even_numbers(&vec![1, 2, 3, 4, 5, 6, 7, 8, 9, 10], 4)
    );
}

fn even_numbers(array: &Vec<i32>, number: usize) -> Vec<i32> {
    let mut res: Vec<i32> = array.to_vec();
    res.retain(|&x| x % 2 == 0);
    res.reverse();
    res.truncate(number);
    res.reverse();
    res
}

#[test]
fn test0() {
    assert_eq!(
        even_numbers(&vec!(1, 2, 3, 4, 5, 6, 7, 8, 9), 3),
        vec!(4, 6, 8)
    );
}
#[test]
fn test1() {
    assert_eq!(
        even_numbers(&vec!(-22, 5, 3, 11, 26, -6, -7, -8, -9, -8, 26), 2),
        vec!(-8, 26)
    );
}
#[test]
fn test2() {
    assert_eq!(
        even_numbers(&vec!(6, -25, 3, 7, 5, 5, 7, -3, 23), 1),
        vec!(6)
    );
}
#[test]
fn test3() {
    assert_eq!(even_numbers(&vec!(1, 1, 1, 1, 1, 1, 1, 1), 5), vec!());
}
#[test]
fn test4() {
    assert_eq!(even_numbers(&vec!(2, 2, 2, 2, 2), 5), vec!(2, 2, 2, 2, 2));
}
#[test]
fn test5() {
    assert_eq!(even_numbers(&vec!(1, 2, 3, 4, 5, 6, 7, 8, 9), 0), vec!());
}
#[test]
fn test6() {
    assert_eq!(even_numbers(&vec!(12, 24, 36, 48), 3), vec!(24, 36, 48));
}
#[test]
fn test7() {
    assert_eq!(even_numbers(&vec!(5, 5, 5, 5, 5, 5, 5), 2), vec!());
}
#[test]
fn test8() {
    assert_eq!(
        even_numbers(&vec!(1, 2, 3, 4, 5, 6, 7, 8, 9), 4),
        vec!(2, 4, 6, 8)
    );
}
#[test]
fn test9() {
    assert_eq!(even_numbers(&vec!(0), 0), vec!());
}
