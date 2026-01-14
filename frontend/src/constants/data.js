import images from "./images";

const wines = [
  {
    title: "Chapel Hill Shiraz",
    price: "$56",
    tags: "AU | Bottle",
  },
  {
    title: "Catena Malbee",
    price: "$59",
    tags: "AU | Bottle",
  },
  {
    title: "La Vieillw Rose",
    price: "$44",
    tags: "FR | 750 ml",
  },
  {
    title: "Rhino Pale Ale",
    price: "$31",
    tags: "CA | 750 ml",
  },
  {
    title: "Irish Guinness",
    price: "$26",
    tags: "IE | 750 ml",
  },
];

const cocktails = [
  {
    title: "Aperol Sprtiz",
    price: "$20",
    tags: "Aperol | Villa Marchesi prosecco | soda | 30 ml",
  },
  {
    title: "Dark 'N' Stormy",
    price: "$16",
    tags: "Dark rum | Ginger beer | Slice of lime",
  },
  {
    title: "Daiquiri",
    price: "$10",
    tags: "Rum | Citrus juice | Sugar",
  },
  {
    title: "Old Fashioned",
    price: "$31",
    tags: "Bourbon | Brown sugar | Angostura Bitters",
  },
  {
    title: "Negroni",
    price: "$26",
    tags: "Gin | Sweet Vermouth | Campari | Orange garnish",
  },
];

const awards = [
  {
    imgUrl: images.award02,
    title: "Bib Gourmand",
    subtitle:
      "Your talent, dedication, and hard work have truly paid off. Keep shining bright!",
  },
  {
    imgUrl: images.award01,
    title: "Rising Star",
    subtitle: "Your talent, ambition, and dedication are truly inspiring. Keep reaching for the stars!",
  },
  {
    imgUrl: images.award05,
    title: "AA Hospitality",
    subtitle: "Your commitment to excellence and dedication to providing outstanding hospitality are truly commendable. Keep up the exceptional work!",
  },
  {
    imgUrl: images.award03,
    title: "Outstanding Chef",
    subtitle: "Congratulations on being named Outstanding Chef! Your culinary mastery and dedication to excellence are truly remarkable. Keep inspiring us with your incredible talent!",
  },
];
const object = { wines, cocktails, awards };
export default object;
