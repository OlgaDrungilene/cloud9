export const scrollTo = (id) => {
  const el = document.querySelector(id);
  if (el) {
    el.scrollIntoView({ behavior: "smooth" });
  }
};

export const scrollToTop = () => {
  window.scrollTo({ top: 0, behavior: "smooth" });
};
