fn main() {
    println!("{}", square_area_to_circle(14.0));
}

fn square_area_to_circle(size: f64) -> f64 {
    size / 4.0 * std::f64::consts::PI
}

fn assert_close(a: f64, b: f64, epsilon: f64) {
    assert!(
        (a - b).abs() < epsilon,
        format!("Expected: {}, got: {}", b, a)
    );
}

#[test]
fn test0() {
    assert_close(square_area_to_circle(9.0), 7.0685834705770345, 1e-8);
}
#[test]
fn test1() {
    assert_close(square_area_to_circle(20.0), 15.70796326794897, 1e-8);
}
#[test]
fn test2() {
    assert_close(square_area_to_circle(16.0), 12.5663706144, 1e-8);
}
#[test]
fn test3() {
    assert_close(square_area_to_circle(69.0), 54.1924732744, 1e-8);
}
#[test]
fn test4() {
    assert_close(square_area_to_circle(71.0), 55.7632696012, 1e-8);
}
#[test]
fn test5() {
    assert_close(square_area_to_circle(420.0), 329.867228627, 1e-8);
}
#[test]
fn test6() {
    assert_close(square_area_to_circle(133.0), 104.457955732, 1e-8);
}
#[test]
fn test7() {
    assert_close(square_area_to_circle(152.0), 119.380520836, 1e-8);
}
#[test]
fn test8() {
    assert_close(square_area_to_circle(2115.0), 1661.11711559, 1e-8);
}
#[test]
fn test9() {
    assert_close(square_area_to_circle(412412.0), 323907.62736306, 1e-5);
}
