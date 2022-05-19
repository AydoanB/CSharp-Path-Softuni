function solve(data, criteria) {
    let parsedData = JSON.parse(data);
    const criteriaType = criteria.split("-")[0];
    const criteriaValue = criteria.split("-")[1];
let counter=0;
    let result = [];
    if (criteriaType == "all") {
        for (const employee of parsedData) {
            console.log(`${counter++}. ${employee.first_name} ${employee.last_name} - ${employee.email}`);
        }
    }
    else {
        for (const employee of parsedData) {
            if (employee[criteriaType] == criteriaValue) {
               console.log(`${counter++}. ${employee.first_name} ${employee.last_name} - ${employee.email}`);
            }
        }
    }
}
let d = `[{
    "id": "1",
    "first_name": "Ardine",
    "last_name": "Bassam",
    "email": "abassam0@cnn.com",
    "gender": "Female"
  }, {
    "id": "2",
    "first_name": "Kizzee",
    "last_name": "Jost",
    "email": "kjost1@forbes.com",
    "gender": "Female"
  },  
{
    "id": "3",
    "first_name": "Evanne",
    "last_name": "Maldin",
    "email": "emaldin2@hostgator.com",
    "gender": "Male"
  }]`
    ;
solve(d, 'gender-Female');
console.log(new Array(60).fill("-"));
let c = `[{
    "id": "1",
    "first_name": "Kaylee",
    "last_name": "Johnson",
    "email": "k0@cnn.com",
    "gender": "Female"
  }, {
    "id": "2",
    "first_name": "Kizzee",
    "last_name": "Johnson",
    "email": "kjost1@forbes.com",
    "gender": "Female"
  }, {
    "id": "3",
    "first_name": "Evanne",
    "last_name": "Maldin",
    "email": "emaldin2@hostgator.com",
    "gender": "Male"
  }, {
    "id": "4",
    "first_name": "Evanne",
    "last_name": "Johnson",
    "email": "ev2@hostgator.com",
    "gender": "Male"
  }]`

solve(c, 'last_name-Johnson');

