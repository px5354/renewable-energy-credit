// export default class OrderBook {
    
//   backEndUrl = '';
  
//   constructor () {

//   }
// }

export const generateRandomNumber = (min, max) => {
  return (Math.random() * (max - min) + min);
};

export const generateRandomNumberArray = (min, max, n) => {
  let data = [];
  for(let i=0; i<n; i++) {
    data.push(generateRandomNumber(min, max));
  }
  return data;
};

export const generateInitialData = (minA, maxA, minB, maxB, n, reverseOrder) => {
  let data = [];
  for(let i=0; i<n; i++) {
    data.push({
      price: generateRandomNumber(minA, maxA),
      amount: generateRandomNumber(minB, maxB),
    });
  }
  // data = data.sort((a, b) => {
  //   return a.price > b.price;
  // });
  return data.sort((a,b) => {
    if(reverseOrder){
      return (a.price < b.price) ? 1 : ((b.price < a.price) ? -1 : 0);
    } else {
      return (a.price > b.price) ? 1 : ((b.price > a.price) ? -1 : 0);
    }
  });
};
