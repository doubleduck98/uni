fn main() {
    println!("{:?}", print(5));
}

fn print(n: i32) -> Option<String> {
    if n < 1 || n % 2 == 0 {
        return None;
    }
    let mut res: String = String::new();
    for i in 0..n {
        let row: String;
        if i <= n / 2 {
            row = "*".repeat((i * 2 + 1) as usize);
        } else {
            row = "*".repeat(((n - i) * 2 - 1) as usize);
        }
        res.push_str(&" ".repeat(((n - row.len() as i32) / 2) as usize));
        res.push_str(&row);
        res.push_str(&"\n");
    }
    Some(res)
}

#[test]
fn test0() {
    assert_eq!(print(3), Some(" *\n***\n *\n".to_string()));
}
#[test]
fn test1() {
    assert_eq!(print(5), Some("  *\n ***\n*****\n ***\n  *\n".to_string()));
}
#[test]
fn test2() {
    assert_eq!(print(-3), None);
}
#[test]
fn test3() {
    assert_eq!(print(2), None);
}
#[test]
fn test4() {
    assert_eq!(print(0), None);
}
#[test]
fn test5() {
    assert_eq!(print(1), Some("*\n".to_string()));
}
#[test]
fn test6() {
    assert_eq!(print(4), None);
}
#[test]
fn test7() {
    assert_eq!(print(6), None);
}
#[test]
fn test8() {
    assert_eq!(print(5), Some("  *\n ***\n*****\n ***\n  *\n".to_string()));
}
#[test]
fn test9() {
    assert_eq!(print(10), None);
}
