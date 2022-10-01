const circleArea = (radius) => {
    console.log(Math.PI * radius * radius);
}

const circleCircumference = (radius) => {
    console.log(2 * Math.PI * radius);
}

module.exports = {
    circleArea: circleArea,
    circleCircumference: circleCircumference,
}