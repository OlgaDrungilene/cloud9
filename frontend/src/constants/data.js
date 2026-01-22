import images from "./images";
import salmon from '../assets/salmon.jpg';
import ribeye from '../assets/ribeye.jpg';
import cheesecake from '../assets/cheesecake.jpg';
import lava_cake from '../assets/lava_cake.jpg';
import bruschetta from '../assets/bruschetta.jpg';
import garlic_shrimp from '../assets/garlicshrimp.jpg';
import stuffedmushrooms from '../assets/stuffed_mushrooms.jpg';
import caprese from '../assets/caprese.jpg';
import chapel_shiraz from '../assets/shiraz.jpg';
import malbee from '../assets/malbee.jpg';
import rose from '../assets/rose.jpg';
import pale_ale from '../assets/pale_ale.jpg';
import irish_guinness from '../assets/irish_guiness.jpg';
import aperol from '../assets/aperol.jpg';
import dark_stormy from '../assets/dark_stormy.jpg';
import strawberry_daiquiri from '../assets/strawberry_daiquiri.jpg';
import old_fashioned from '../assets/old_fashioned.jpg';
import negroni from '../assets/negroni.jpg';

export const mains = [
  { title: "Grilled Salmon",
    price: "$25",
    tags: "Salmon | Lemon | Asparagus",
    img: salmon,
    description: "Freshly grilled salmon served with a side of lemon and asparagus."
  },
  {
    title: "Ribeye Steak",
    price: "$30",
    tags: "Beef | Garlic Butter | Mashed Potatoes",
    img: ribeye,
    description: "Juicy ribeye steak cooked to perfection, topped with garlic butter and served with creamy mashed potatoes."
  }
]
export const desserts = [
  {
    title: "Cheesecake",
    price: "$8",
    tags: "Cream Cheese | Graham Cracker Crust | Strawberry Sauce",
    img: cheesecake,
    description: "Classic cheesecake with a graham cracker crust, topped with fresh strawberry sauce."
  },
  {
    title: "Chocolate Lava Cake",
    price: "$9",
    tags: "Dark Chocolate | Vanilla Ice Cream | Raspberry Sauce",
    img: lava_cake,
    description: "Warm chocolate cake with a gooey center, served with vanilla ice cream and raspberry sauce."
  },
];

export const appetizers = [
  {
    title: "Bruschetta",
    price: "$12",
    tags: "Tomato | Basil | Balsamic Glaze",
    img: bruschetta,
    description: "Toasted bread topped with fresh tomatoes, basil, and a drizzle of balsamic glaze."
  },
  { title: "Garlic Shrimp",
    price: "$14", 
    tags: "Shrimp | Garlic | Butter",
    img: garlic_shrimp,
    description: "Succulent shrimp sautéed in garlic butter sauce, served with a side of crusty bread."
  },
  {
    title: "Stuffed Mushrooms",
    price: "$14",
    tags: "Mushrooms | Cheese | Herbs",
    img: stuffedmushrooms,
    description: "Mushroom caps stuffed with a savory mixture of cheese and herbs, baked to perfection."
  },
  { title: "Caprese Salad", 
    price: "$11", 
    tags: "Mozzarella | Tomato | Basil",
    img: caprese,
    description: "Fresh mozzarella, ripe tomatoes, and basil leaves drizzled with olive oil and balsamic reduction."
  },
];
export const wines = [
  {
    title: "Chapel Hill Shiraz",
    price: "$56",
    tags: "AU | Bottle",
    img: chapel_shiraz,
    description: "A full-bodied red wine with rich flavors of dark fruit and a hint of spice."
  },
  {
    title: "Catena Malbee",
    price: "$59",
    tags: "AU | Bottle",
    img: malbee,
    description: "A robust red wine with notes of blackberry, plum, and a touch of oak."
  },
  {
    title: "La Vieillw Rose",
    price: "$44",
    tags: "FR | 750 ml",
    img: rose,
    description: "A crisp and refreshing rosé wine with flavors of strawberry and citrus."
  },
 
]

export const beers = [
 {
    title: "Rhino Pale Ale",
    price: "$31",
    tags: "CA | 750 ml",
    img: pale_ale,
    description: "A smooth and hoppy pale ale with notes of citrus and pine."
  },
  {
    title: "Irish Guinness",
    price: "$26",
    tags: "IE | 750 ml",
    img: irish_guinness,
    description: "A classic Irish stout with a rich, creamy texture and flavors of roasted malt and coffee."
  },
]
export const cocktails = [
  {
    title: "Aperol Spritz",
    price: "$20",
    tags: "Aperol | Prosecco | soda | 30 ml",
    img: aperol,
    description: "A refreshing cocktail made with Aperol, prosecco, and a splash of soda, garnished with an orange slice."
  },
  {
    title: "Dark 'N' Stormy",
    price: "$16",
    tags: "Dark rum | Ginger beer | Slice of lime",
    img: dark_stormy,
    description: "A classic cocktail made with dark rum and ginger beer, served over ice with a slice of lime."
  },
  {
    title: "Strawberry Daiquiri",
    price: "$10",
    tags: "Rum | Citrus juice | Sugar",
    img: strawberry_daiquiri,
    description: "A sweet and tangy cocktail made with rum, fresh strawberries, citrus juice, and a touch of sugar."
  },
  {
    title: "Old Fashioned",
    price: "$31",
    tags: "Bourbon | Brown sugar | Angostura Bitters",
    img: old_fashioned,
    description: "A timeless cocktail made with bourbon, brown sugar, and Angostura bitters, garnished with an orange twist."
  },
  {
    title: "Negroni",
    price: "$26",
    tags: "Gin | Vermouth | Campari | Orange garnish",
    img: negroni,
    description: "A classic Italian cocktail made with gin, sweet vermouth, and Campari, garnished with an orange slice."
  },
]

export const awards = [
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
]
