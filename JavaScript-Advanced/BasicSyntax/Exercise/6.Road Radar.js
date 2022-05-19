function radar(spiid, area) {
    const speed = Number(spiid);
    let output;
    let status;
    let allowedSpeed;
    if (area == 'motorway') {
        allowedSpeed = 130;
        if (speed <= allowedSpeed) {
            output = `Driving ${speed} km/h in a 130 zone`;
        } else if (speed > allowedSpeed && speed - allowedSpeed <= 20) {
            status = 'speeding';
        } else if (speed > allowedSpeed && speed - allowedSpeed <= 40) {
            status = 'excessive speeding';
        } else {
            status = 'reckless driving'
        }
    } else if (area == 'interstate') {
        allowedSpeed = 90;
        if (speed <= allowedSpeed) {
            output = `Driving ${speed} km/h in a ${allowedSpeed} zone`;
        } else if (speed > allowedSpeed && speed - allowedSpeed <= 20) {
            status = 'speeding';
        } else if (speed > allowedSpeed && speed - allowedSpeed <= 40) {
            status = 'excessive speeding';
        } else {
            status = 'reckless driving'
        }
    } else if (area == 'city') {
        allowedSpeed = 50;
        if (speed <= allowedSpeed) {
            output = `Driving ${speed} km/h in a ${allowedSpeed} zone`;
        } else if (speed > allowedSpeed && speed - allowedSpeed <= 20) {
            status = 'speeding';
        } else if (speed > allowedSpeed && speed - allowedSpeed <= 40) {
            status = 'excessive speeding';
        } else {
            status = 'reckless driving'
        }
    } else if (area == 'residential') {
        allowedSpeed = 20;
        if (speed <= allowedSpeed) {
            output = `Driving ${speed} km/h in a ${allowedSpeed} zone`;
        } else if (speed > allowedSpeed && speed - allowedSpeed <= 20) {
            status = 'speeding';
        } else if (speed > allowedSpeed && speed - allowedSpeed <= 40) {
            status = 'excessive speeding';
        } else {
            status = 'reckless driving'
        }
    }

    console.log(speed <= allowedSpeed ? output : `The speed is ${speed - allowedSpeed} km/h faster than the allowed speed of ${allowedSpeed} - ${status}`)
}


radar(21, 'residential')
radar(20, 'residential')
radar(19, 'residential')
radar(45, 'residential')
radar(100, 'residential')
