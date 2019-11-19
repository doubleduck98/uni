fn main() {
    println!("{}", chessboard_cell_color("A1", "A3"));
}

fn chessboard_cell_color(cell1: &str, cell2: &str) -> bool {
    let c1: Vec<u32> = cell1.chars().map(|c| c as u32).collect();
    let c2: Vec<u32> = cell2.chars().map(|c| c as u32).collect();
    (c1[0] + c1[1]) % 2 == (c2[0] + c2[1]) % 2
}

#[test]
fn test0() {
    assert_eq!(chessboard_cell_color("A1", "C3"), true);
}
#[test]
fn test1() {
    assert_eq!(chessboard_cell_color("A1", "H3"), false);
}
#[test]
fn test2() {
    assert_eq!(chessboard_cell_color("A1", "A2"), false);
}
#[test]
fn test3() {
    assert_eq!(chessboard_cell_color("A1", "C1"), true);
}
#[test]
fn test4() {
    assert_eq!(chessboard_cell_color("A1", "B3"), false);
}
#[test]
fn test5() {
    assert_eq!(chessboard_cell_color("A1", "A1"), true);
}
#[test]
fn test6() {
    assert_eq!(chessboard_cell_color("H1", "F3"), true);
}
#[test]
fn test7() {
    assert_eq!(chessboard_cell_color("B4", "C5"), true);
}
#[test]
fn test8() {
    assert_eq!(chessboard_cell_color("A8", "C8"), true);
}
#[test]
fn test9() {
    assert_eq!(chessboard_cell_color("D2", "E1"), true);
}
