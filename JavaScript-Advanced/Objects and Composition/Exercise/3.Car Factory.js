function car(obj) {
    const carObj = {};

    carObj.model = obj.model;
    if (obj.power <= 90) {
        carObj.engine = { power: 90, volume: 1800 };
    }
    else if (obj.power <= 120) {
        carObj.engine = { power: 120, volume: 2400 };
    }
    else {
        carObj.engine = { power: 200, volume: 3500 };
    }
    carObj.carriage = { type: obj.carriage, color: obj.color };

    let wheelsize = obj.wheelsize % 2 == 0 ? obj.wheelsize - 1 : obj.wheelsize;
    carObj.wheels = new Array(4).fill(wheelsize,0,4);

    return carObj;
}

console.log(car({ model: 'Opel Vectra',
        power: 110,
        color: 'grey',
        carriage: 'coupe',
        wheelsize: 17 }
    )
)