function czy_pierwsza(num){
    for(var i = 2; i < num; i++){
        if(num % i == 0)
            return false;
    }
    return true;
}

function fn3(){
    res = [];
    for(var i = 2; i <= 100000; i++){
        if(czy_pierwsza(i))
            res.push(i);
    }
    console.log(res);
}

fn3();