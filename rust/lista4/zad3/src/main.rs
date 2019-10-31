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
