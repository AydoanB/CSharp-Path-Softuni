function solve(obj=[]){
    let hero=[];
    obj.forEach((el)=>{
        let [name, level,items]=el.split(' / ');
        level=Number(level);
        items=items? items.split(', ') : [];
        hero.push({name,level,items});
    })
    return JSON.stringify(hero);
}
console.log(solve(['Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara']
))