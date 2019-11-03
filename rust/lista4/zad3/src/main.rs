fn main() {
    print!("{}", highlight("F3RF5LF7"))
}

#[derive(PartialEq)]
enum TYP {
    F,
    L,
    R,
    NUM,
    NIC,
}

fn typ(c: char) -> TYP {
    match c {
        'F' => TYP::F,
        'L' => TYP::L,
        'R' => TYP::R,
        '0'..='9' => TYP::NUM,
        _ => TYP::NIC,
    }
}

pub fn highlight(code: &str) -> String {
    let mut res: String = String::new();
    let mut str = <Vec<(String, TYP)>>::new();
    let mut last = TYP::NIC;
    code.chars()
        .collect::<Vec<char>>()
        .into_iter()
        .for_each(|c| match c {
            'F' => {
                if typ(c) == last {
                    str.last_mut().unwrap().0.push_str(&c.to_string());
                } else {
                    str.push((c.to_string(), TYP::F));
                    last = TYP::F;
                }
            }
            'L' => {
                if typ(c) == last {
                    str.last_mut().unwrap().0.push_str(&c.to_string());
                } else {
                    str.push((c.to_string(), TYP::L));
                    last = TYP::L;
                }
            }
            'R' => {
                if typ(c) == last {
                    str.last_mut().unwrap().0.push_str(&c.to_string());
                } else {
                    str.push((c.to_string(), TYP::R));
                    last = TYP::R;
                }
            }
            '0'..='9' => {
                if typ(c) == last {
                    str.last_mut().unwrap().0.push_str(&c.to_string());
                } else {
                    str.push((c.to_string(), TYP::NUM));
                    last = TYP::NUM;
                }
            }
            _ => {
                str.push((c.to_string(), TYP::NIC));
                last = TYP::NIC;
            }
        });
    str.into_iter().for_each(|(st, cl)| match cl {
        TYP::F => {
            res.push_str(&format!("<span style=\"color: pink\">{}</span>", st).to_string());
        }
        TYP::R => {
            res.push_str(&format!("<span style=\"color: green\">{}</span>", st).to_string());
        }
        TYP::L => {
            res.push_str(&format!("<span style=\"color: red\">{}</span>", st).to_string());
        }
        TYP::NUM => {
            res.push_str(&format!("<span style=\"color: orange\">{}</span>", st).to_string());
        }
        TYP::NIC => {
            res.push_str(&st);
        }
    });
    res
}

#[cfg(test)]
mod tests {
    use super::*;

    #[cfg(test)]
    macro_rules! assert_highlight {
        ($code:expr , $expected:expr $(,)*) => {{
            let actual = highlight($code);
            let expected = $expected;
            println!("Code without syntax highlighting: {}", $code);
            println!("Your code with syntax highlighting: {}", actual);
            println!("Expected syntax highlighting: {}", expected);
            assert_eq!(actual, expected);
        }};
    }

    #[test]
    fn test0() {
        assert_highlight!(
            "F3RF5LF7",
            r#"<span style="color: pink">F</span><span style="color: orange">3</span><span style="color: green">R</span><span style="color: pink">F</span><span style="color: orange">5</span><span style="color: red">L</span><span style="color: pink">F</span><span style="color: orange">7</span>"#,
        )
    }
    #[test]
    fn test1() {
        assert_highlight!(
            "FFFR345F2LL",
            r#"<span style="color: pink">FFF</span><span style="color: green">R</span><span style="color: orange">345</span><span style="color: pink">F</span><span style="color: orange">2</span><span style="color: red">LL</span>"#,
        )
    }
    #[test]
    fn test2() {
        assert_highlight!("ABCDEFGH", r#"ABCDE<span style="color: pink">F</span>GH"#,)
    }
    #[test]
    fn test3() {
        assert_highlight!(
            "SDGAISVNXZ523",
            r#"SDGAISVNXZ<span style="color: orange">523</span>"#,
        )
    }
    #[test]
    fn test4() {
        assert_highlight!("SZYMON", r#"SZYMON"#,)
    }
    #[test]
    fn test5() {
        assert_highlight!(
            "5LISTOPADA2019",
            r#"<span style="color: orange">5</span><span style="color: red">L</span>ISTOPADA<span style="color: orange">2019</span>"#,
        )
    }
    #[test]
    fn test6() {
        assert_highlight!(
            "BLABLABLA",
            r#"B<span style="color: red">L</span>AB<span style="color: red">L</span>AB<span style="color: red">L</span>A"#,
        )
    }
    #[test]
    fn test7() {
        assert_highlight!("", r#""#,)
    }
    #[test]
    fn test8() {
        assert_highlight!(
            "2374659L412",
            r#"<span style="color: orange">2374659</span><span style="color: red">L</span><span style="color: orange">412</span>"#,
        )
    }
    #[test]
    fn test9() {
        assert_highlight!(
            "QWE123ASD456ZXC789",
            r#"QWE<span style="color: orange">123</span>ASD<span style="color: orange">456</span>ZXC<span style="color: orange">789</span>"#,
        )
    }
}
