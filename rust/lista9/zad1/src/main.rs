fn main() {
    println!("{}", part_list(vec!["I", "wish", "I", "hadn't", "come"]));
}

fn part_list(arr: Vec<&str>) -> String {
    let mut res: Vec<String> = Vec::new();
    for i in 1..arr.len() {
        res.push(format!("({}, {})", arr[..i].join(" "), arr[i..].join(" ")))
    }
    res.join("")
}

#[test]
fn test0() {
    assert_eq!(part_list(vec!["I", "wish", "I", "hadn't", "come"]),
                "(I, wish I hadn't come)(I wish, I hadn't come)(I wish I, hadn't come)(I wish I hadn't, come)")
}
#[test]
fn test1() {
    assert_eq!(
        part_list(vec!["cdIw", "tzIy", "xDu", "rThG"]),
        "(cdIw, tzIy xDu rThG)(cdIw tzIy, xDu rThG)(cdIw tzIy xDu, rThG)"
    )
}
#[test]
fn test2() {
    assert_eq!(
        part_list(vec!["fnatic", "vs", "liquid"]),
        "(fnatic, vs liquid)(fnatic vs, liquid)"
    )
}
#[test]
fn test3() {
    assert_eq!(
        part_list(vec!["Xd", "xd", "XD", "xD"]),
        "(Xd, xd XD xD)(Xd xd, XD xD)(Xd xd XD, xD)"
    )
}
#[test]
fn test4() {
    assert_eq!(part_list(vec!["dasd", "das d", "fasfasfa", "fasfafsa"]),
                "(dasd, das d fasfasfa fasfafsa)(dasd das d, fasfasfa fasfafsa)(dasd das d fasfasfa, fasfafsa)")
}
#[test]
fn test5() {
    assert_eq!(part_list(vec!["sprzedam", "fmsa"]), "(sprzedam, fmsa)")
}
#[test]
fn test6() {
    assert_eq!(part_list(vec![""]), "")
}
#[test]
fn test7() {
    assert_eq!(part_list(vec!["lorem", "ipsum", "dolor", "sit", "amet"]),
                "(lorem, ipsum dolor sit amet)(lorem ipsum, dolor sit amet)(lorem ipsum dolor, sit amet)(lorem ipsum dolor sit, amet)")
}
#[test]
fn test8() {
    assert_eq!(part_list(vec!["xd"]), "")
}
#[test]
fn test9() {
    assert_eq!(part_list(vec![]), "")
}
