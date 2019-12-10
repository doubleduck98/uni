use std::collections::HashMap;

fn main() {
    let a = vec!["BBAR 150", "CDXE 515", "BKWR 250", "BTSQ 890", "DRTY 600"];
    let b = vec!["A", "B", "C", "D"];
    println!("{}", stock_list(a, b))
}

fn stock_list(list_art: Vec<&str>, list_cat: Vec<&str>) -> String {
    if list_art.is_empty() || list_cat.is_empty() {
        return String::new();
    }
    let mut arts: Vec<&str> = list_art;
    let mut map: HashMap<String, u32> = HashMap::new();
    let mut res: Vec<String> = Vec::new();
    arts.retain(|art| {
        let art_type: String = art.chars().nth(0).unwrap().to_string();
        list_cat.iter().any(|cat| *cat.to_string() == art_type)
    });
    list_cat.iter().for_each(|cat| {
        map.entry(cat.to_string()).or_insert(0);
    });
    arts.iter().for_each(|art| {
        let art_type: String = art.chars().nth(0).unwrap().to_string();
        let quantity: u32 = art.split_whitespace().collect::<Vec<_>>()[1]
            .to_string()
            .parse()
            .unwrap();
        map.entry(art_type)
            .and_modify(|q| *q += quantity)
            .or_insert(0);
    });
    map.iter()
        .for_each(|(k, v)| res.push(format!("({} : {})", k, v.to_string())));
    res.sort_by_key(|s| {
        list_cat
            .iter()
            .position(|&c| c.to_string().chars().nth(0).unwrap() == s.chars().nth(1).unwrap())
            .unwrap()
    });
    res.join(" - ")
}
